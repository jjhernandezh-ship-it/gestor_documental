using GDIIECA.Application.DTOs;
using GDIIECA.Application.Interfaces;
using GDIIECA.Domain.Entities;
using GDIIECA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GDIIECA.Infrastructure.Services;

public sealed class DocumentService(ApplicationDbContext db, IFileStorageService storage, IAuditService audit) : IDocumentService
{
    public async Task<IReadOnlyList<DocumentDto>> ListAsync(Guid? folderId, string? query, CancellationToken ct = default)
    {
        var q = db.Documents.AsNoTracking().AsQueryable(); if (folderId.HasValue) q = q.Where(x => x.FolderId == folderId); if (!string.IsNullOrWhiteSpace(query)) { var term = query.Trim(); q = q.Where(x => x.Name.Contains(term) || (x.Description != null && x.Description.Contains(term)) || x.Versions.Any(v => v.Extension.Contains(term))); }
        return await q.OrderBy(x => x.Name).Select(x => new DocumentDto(x.Id, x.Name, x.Description, x.FolderId, x.CurrentVersionNumber, x.Versions.Where(v => v.VersionNumber == x.CurrentVersionNumber).Select(v => v.Extension).FirstOrDefault(), x.CreatedAtUtc)).ToListAsync(ct);
    }
    public async Task<DocumentDto?> GetAsync(Guid id, CancellationToken ct = default) => await db.Documents.AsNoTracking().Where(x => x.Id == id).Select(x => new DocumentDto(x.Id, x.Name, x.Description, x.FolderId, x.CurrentVersionNumber, x.Versions.Where(v => v.VersionNumber == x.CurrentVersionNumber).Select(v => v.Extension).FirstOrDefault(), x.CreatedAtUtc)).SingleOrDefaultAsync(ct);
    public async Task<Guid> CreateAsync(string name, string? description, Guid folderId, Stream content, string fileName, string mimeType, string? comment, string userId, CancellationToken ct = default)
    {
        name = name.Trim();
        if (string.IsNullOrWhiteSpace(name)) throw new InvalidOperationException("El nombre del documento es obligatorio.");
        var existingId = await db.Documents.Where(x => x.FolderId == folderId && x.Name == name).Select(x => (Guid?)x.Id).SingleOrDefaultAsync(ct);
        if (existingId.HasValue)
        {
            await AddVersionAsync(existingId.Value, content, fileName, mimeType, comment ?? "Versión automática por archivo con el mismo nombre", userId, ct);
            return existingId.Value;
        }
        var stored = await storage.SaveAsync(content, fileName, ct); await using var tx = await db.Database.BeginTransactionAsync(ct);
        try { var doc = new Document { Name = name, Description = description?.Trim(), FolderId = folderId, CurrentVersionNumber = 1, CreatedById = userId }; db.Documents.Add(doc); doc.Versions.Add(Version(doc.Id, 1, stored, fileName, mimeType, comment, userId)); await db.SaveChangesAsync(ct); await audit.RecordAsync("DOCUMENTO_CREADO", nameof(Document), doc.Id.ToString(), doc.Name, userId, ct: ct); await tx.CommitAsync(ct); return doc.Id; }
        catch { await tx.RollbackAsync(ct); await storage.DeleteAsync(stored.RelativePath, ct); throw; }
    }
    public async Task RenameAsync(Guid id, string name, string userId, CancellationToken ct = default)
    {
        name = name.Trim();
        if (string.IsNullOrWhiteSpace(name)) throw new InvalidOperationException("El nombre del documento es obligatorio.");
        var doc = await db.Documents.SingleAsync(x => x.Id == id, ct);
        if (await db.Documents.AnyAsync(x => x.Id != id && x.FolderId == doc.FolderId && x.Name == name, ct)) throw new InvalidOperationException("Ya existe otro documento con ese nombre en la carpeta.");
        var previousName = doc.Name;
        if (previousName == name) return;
        doc.Name = name; doc.ModifiedAtUtc = DateTime.UtcNow; doc.ModifiedById = userId;
        await db.SaveChangesAsync(ct);
        await audit.RecordAsync("DOCUMENTO_RENOMBRADO", nameof(Document), id.ToString(), $"{previousName} → {name}", userId, oldValues: new { Name = previousName }, newValues: new { Name = name }, ct: ct);
    }
    public async Task AddVersionAsync(Guid documentId, Stream content, string fileName, string mimeType, string? comment, string userId, CancellationToken ct = default)
    {
        var stored = await storage.SaveAsync(content, fileName, ct); await using var tx = await db.Database.BeginTransactionAsync(ct);
        try { var doc = await db.Documents.SingleAsync(x => x.Id == documentId, ct); doc.CurrentVersionNumber++; doc.ModifiedAtUtc = DateTime.UtcNow; doc.ModifiedById = userId; db.DocumentVersions.Add(Version(documentId, doc.CurrentVersionNumber, stored, fileName, mimeType, comment, userId)); await db.SaveChangesAsync(ct); await audit.RecordAsync("VERSION_CREADA", nameof(DocumentVersion), documentId.ToString(), $"Versión {doc.CurrentVersionNumber}", userId, ct: ct); await tx.CommitAsync(ct); }
        catch { await tx.RollbackAsync(ct); await storage.DeleteAsync(stored.RelativePath, ct); throw; }
    }
    public async Task<IReadOnlyList<DocumentVersionDto>> VersionsAsync(Guid id, CancellationToken ct = default) => await db.DocumentVersions.AsNoTracking().Where(x => x.DocumentId == id).OrderByDescending(x => x.VersionNumber).Select(x => new DocumentVersionDto(x.Id, x.VersionNumber, x.OriginalFileName, x.MimeType, x.SizeBytes, x.Sha256, x.ChangeComment, x.CreatedAtUtc)).ToListAsync(ct);
    public async Task<(Stream Content, string FileName, string MimeType)> OpenVersionAsync(Guid id, string userId, CancellationToken ct = default) { var v = await db.DocumentVersions.AsNoTracking().SingleAsync(x => x.Id == id, ct); var stream = await storage.OpenReadAsync(v.RelativePath, ct); await audit.RecordAsync("DOCUMENTO_DESCARGADO", nameof(DocumentVersion), id.ToString(), v.OriginalFileName, userId, ct: ct); return (stream, v.OriginalFileName, v.MimeType); }
    public async Task DeleteAsync(Guid id, string userId, CancellationToken ct = default) => await SetDeleted(id, true, userId, ct);
    public async Task RestoreAsync(Guid id, string userId, CancellationToken ct = default) => await SetDeleted(id, false, userId, ct);
    private async Task SetDeleted(Guid id, bool value, string userId, CancellationToken ct) { var d = await db.Documents.IgnoreQueryFilters().SingleAsync(x => x.Id == id, ct); d.IsDeleted = value; d.DeletedAtUtc = value ? DateTime.UtcNow : null; d.DeletedById = value ? userId : null; await db.SaveChangesAsync(ct); await audit.RecordAsync(value ? "DOCUMENTO_ELIMINADO" : "DOCUMENTO_RESTAURADO", nameof(Document), id.ToString(), d.Name, userId, ct: ct); }
    private static DocumentVersion Version(Guid id, int number, StoredFile f, string original, string mime, string? comment, string user) => new() { DocumentId = id, VersionNumber = number, OriginalFileName = Path.GetFileName(original), StoredFileName = f.StoredFileName, Extension = Path.GetExtension(original).ToLowerInvariant(), MimeType = mime, SizeBytes = f.SizeBytes, RelativePath = f.RelativePath, Sha256 = f.Sha256, ChangeComment = comment, CreatedById = user };
}
