using GDIIECA.Domain.Common;

namespace GDIIECA.Domain.Entities;

public sealed class Folder : SoftDeletableEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid? ParentFolderId { get; set; }
    public Folder? ParentFolder { get; set; }
    public ICollection<Folder> Children { get; set; } = [];
    public Guid? AreaId { get; set; }
    public Area? Area { get; set; }
    public Guid? ProcessId { get; set; }
    public Process? Process { get; set; }
    public ICollection<Document> Documents { get; set; } = [];
    public byte[] RowVersion { get; set; } = [];
}

public sealed class Document : SoftDeletableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid FolderId { get; set; }
    public Folder Folder { get; set; } = null!;
    public Guid? AreaId { get; set; }
    public Area? Area { get; set; }
    public Guid? ProcessId { get; set; }
    public Process? Process { get; set; }
    public int CurrentVersionNumber { get; set; }
    public ICollection<DocumentVersion> Versions { get; set; } = [];
    public byte[] RowVersion { get; set; } = [];
}

public sealed class DocumentVersion : AuditableEntity
{
    public Guid DocumentId { get; set; }
    public Document Document { get; set; } = null!;
    public int VersionNumber { get; set; }
    public string OriginalFileName { get; set; } = string.Empty;
    public string StoredFileName { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;
    public string MimeType { get; set; } = "application/octet-stream";
    public long SizeBytes { get; set; }
    public string RelativePath { get; set; } = string.Empty;
    public string Sha256 { get; set; } = string.Empty;
    public string? ChangeComment { get; set; }
}
