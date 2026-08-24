using System.Text.Json;
using GDIIECA.Application.Interfaces;
using GDIIECA.Domain.Entities;
using GDIIECA.Domain.Enums;
using GDIIECA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GDIIECA.Infrastructure.Services;

public sealed class AuditService(ApplicationDbContext db) : IAuditService
{
    public async Task RecordAsync(string action, string entity, string? entityId, string description, string? userId, object? oldValues = null, object? newValues = null, CancellationToken ct = default)
    { db.AuditEntries.Add(new AuditEntry { Action = action, EntityName = entity, EntityId = entityId, Description = description, UserId = userId, OldValuesJson = oldValues is null ? null : JsonSerializer.Serialize(oldValues), NewValuesJson = newValues is null ? null : JsonSerializer.Serialize(newValues) }); await db.SaveChangesAsync(ct); }
}

public sealed class PermissionService(ApplicationDbContext db) : IPermissionService
{
    public async Task<bool> HasPermissionAsync(string userId, IEnumerable<string> roles, Guid resourceId, PermissionResourceType type, PermissionAction action, Guid? areaId = null, CancellationToken ct = default)
    {
        if (roles.Contains("Administrador", StringComparer.OrdinalIgnoreCase)) return true;
        var subjects = new HashSet<string>(roles.Append(userId), StringComparer.OrdinalIgnoreCase); if (areaId.HasValue) subjects.Add(areaId.Value.ToString());
        var resources = new List<Guid> { resourceId };
        if (type == PermissionResourceType.Folder) { var folders = await db.Folders.AsNoTracking().Select(x => new { x.Id, x.ParentFolderId }).ToDictionaryAsync(x => x.Id, ct); var current = folders.GetValueOrDefault(resourceId)?.ParentFolderId; while (current is { } id) { resources.Add(id); current = folders.GetValueOrDefault(id)?.ParentFolderId; } }
        else { var folderId = await db.Documents.Where(x => x.Id == resourceId).Select(x => x.FolderId).SingleAsync(ct); resources.Add(folderId); var folders = await db.Folders.AsNoTracking().Select(x => new { x.Id, x.ParentFolderId }).ToDictionaryAsync(x => x.Id, ct); var current = folders.GetValueOrDefault(folderId)?.ParentFolderId; while (current is { } id) { resources.Add(id); current = folders.GetValueOrDefault(id)?.ParentFolderId; } }
        var permissions = await db.Permissions.AsNoTracking().Where(x => subjects.Contains(x.SubjectId) && resources.Contains(x.ResourceId) && (x.ResourceType == type || x.ResourceType == PermissionResourceType.Folder)).ToListAsync(ct);
        if (permissions.Any(x => x.Effect == PermissionEffect.Deny && (x.Actions & action) == action)) return false;
        return permissions.Any(x => x.Effect == PermissionEffect.Allow && (x.Actions & action) == action);
    }
}
