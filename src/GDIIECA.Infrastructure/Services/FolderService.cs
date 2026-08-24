using GDIIECA.Application.DTOs;
using GDIIECA.Application.Interfaces;
using GDIIECA.Application.Validation;
using GDIIECA.Domain.Entities;
using GDIIECA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GDIIECA.Infrastructure.Services;

public sealed class FolderService(ApplicationDbContext db, IAuditService audit) : IFolderService
{
    public async Task<IReadOnlyList<FolderDto>> ListAsync(CancellationToken ct = default) => await db.Folders.AsNoTracking().OrderBy(x => x.Name).Select(x => new FolderDto(x.Id, x.Name, x.ParentFolderId, x.AreaId, x.ProcessId)).ToListAsync(ct);
    public async Task<IReadOnlyList<BreadcrumbDto>> BreadcrumbsAsync(Guid id, CancellationToken ct = default)
    {
        var all = await db.Folders.AsNoTracking().Select(x => new { x.Id, x.Name, x.ParentFolderId }).ToDictionaryAsync(x => x.Id, ct); var result = new List<BreadcrumbDto>(); Guid? current = id;
        while (current is { } key && all.TryGetValue(key, out var f)) { result.Add(new(f.Id, f.Name)); current = f.ParentFolderId; }
        result.Reverse(); return result;
    }
    public async Task<Guid> CreateAsync(string name, Guid? parentId, Guid? areaId, Guid? processId, string userId, CancellationToken ct = default)
    {
        name = name.Trim(); if (!FolderRules.IsValidName(name)) throw new InvalidOperationException("Nombre de carpeta inválido.");
        if (await db.Folders.AnyAsync(x => x.ParentFolderId == parentId && x.Name == name, ct)) throw new InvalidOperationException("Ya existe una carpeta con ese nombre.");
        var item = new Folder { Name = name, ParentFolderId = parentId, AreaId = areaId, ProcessId = processId, CreatedById = userId }; db.Folders.Add(item); await db.SaveChangesAsync(ct); await audit.RecordAsync("CARPETA_CREADA", nameof(Folder), item.Id.ToString(), name, userId, ct: ct); return item.Id;
    }
    public async Task MoveAsync(Guid id, Guid? parentId, string userId, CancellationToken ct = default)
    {
        var parents = await db.Folders.AsNoTracking().ToDictionaryAsync(x => x.Id, x => x.ParentFolderId, ct); if (FolderRules.WouldCreateCycle(id, parentId, parents)) throw new InvalidOperationException("El movimiento crearía un ciclo.");
        var item = await db.Folders.SingleAsync(x => x.Id == id, ct); item.ParentFolderId = parentId; item.ModifiedAtUtc = DateTime.UtcNow; item.ModifiedById = userId; await db.SaveChangesAsync(ct); await audit.RecordAsync("CARPETA_MOVIDA", nameof(Folder), id.ToString(), item.Name, userId, ct: ct);
    }
    public async Task DeleteAsync(Guid id, string userId, CancellationToken ct = default) => await SetDeleted(id, userId, true, ct);
    public async Task RestoreAsync(Guid id, string userId, CancellationToken ct = default) => await SetDeleted(id, userId, false, ct);
    private async Task SetDeleted(Guid id, string userId, bool deleted, CancellationToken ct)
    {
        var all = await db.Folders.IgnoreQueryFilters().ToListAsync(ct); var ids = new HashSet<Guid> { id }; bool changed; do { changed = false; foreach (var f in all.Where(x => x.ParentFolderId is { } p && ids.Contains(p))) changed |= ids.Add(f.Id); } while (changed);
        foreach (var folder in all.Where(x => ids.Contains(x.Id))) { folder.IsDeleted = deleted; folder.DeletedAtUtc = deleted ? DateTime.UtcNow : null; folder.DeletedById = deleted ? userId : null; }
        var documents = await db.Documents.IgnoreQueryFilters().Where(x => ids.Contains(x.FolderId)).ToListAsync(ct);
        foreach (var document in documents) { document.IsDeleted = deleted; document.DeletedAtUtc = deleted ? DateTime.UtcNow : null; document.DeletedById = deleted ? userId : null; }
        await db.SaveChangesAsync(ct); await audit.RecordAsync(deleted ? "CARPETA_ELIMINADA" : "CARPETA_RESTAURADA", nameof(Folder), id.ToString(), $"{ids.Count} carpeta(s), {documents.Count} documento(s)", userId, ct: ct);
    }
}
