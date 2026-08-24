using GDIIECA.Domain.Common;
using GDIIECA.Domain.Enums;

namespace GDIIECA.Domain.Entities;

public sealed class Permission : AuditableEntity
{
    public PermissionSubjectType SubjectType { get; set; }
    public string SubjectId { get; set; } = string.Empty;
    public PermissionResourceType ResourceType { get; set; }
    public Guid ResourceId { get; set; }
    public PermissionAction Actions { get; set; }
    public PermissionEffect Effect { get; set; } = PermissionEffect.Allow;
    public bool InheritToChildren { get; set; } = true;
}

public sealed class AuditEntry
{
    public long Id { get; set; }
    public string? UserId { get; set; }
    public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;
    public string Action { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? EntityId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? OldValuesJson { get; set; }
    public string? NewValuesJson { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
}
