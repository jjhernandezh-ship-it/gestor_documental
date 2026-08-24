using GDIIECA.Domain.Common;

namespace GDIIECA.Domain.Entities;

public sealed class Area : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<Process> Processes { get; set; } = [];
}

public sealed class Process : AuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? AreaId { get; set; }
    public Area? Area { get; set; }
    public bool IsActive { get; set; } = true;
}
