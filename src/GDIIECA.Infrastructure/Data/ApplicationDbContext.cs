using GDIIECA.Domain.Entities;
using GDIIECA.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GDIIECA.Infrastructure.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Area> Areas => Set<Area>();
    public DbSet<Process> Processes => Set<Process>();
    public DbSet<Folder> Folders => Set<Folder>();
    public DbSet<Document> Documents => Set<Document>();
    public DbSet<DocumentVersion> DocumentVersions => Set<DocumentVersion>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<AuditEntry> AuditEntries => Set<AuditEntry>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        b.Entity<ApplicationUser>(e => { e.Property(x => x.FirstName).HasMaxLength(100).IsRequired(); e.Property(x => x.LastName).HasMaxLength(150).IsRequired(); e.HasOne(x => x.Area).WithMany().HasForeignKey(x => x.AreaId).OnDelete(DeleteBehavior.Restrict); });
        b.Entity<Area>(e => { e.Property(x => x.Name).HasMaxLength(200).IsRequired(); e.HasIndex(x => x.Name).IsUnique(); });
        b.Entity<Process>(e => { e.Property(x => x.Code).HasMaxLength(30).IsRequired(); e.Property(x => x.Name).HasMaxLength(250).IsRequired(); e.HasIndex(x => x.Code).IsUnique(); e.HasOne(x => x.Area).WithMany(x => x.Processes).HasForeignKey(x => x.AreaId).OnDelete(DeleteBehavior.Restrict); });
        b.Entity<Folder>(e => { e.Property(x => x.Name).HasMaxLength(150).IsRequired(); e.Property(x => x.RowVersion).IsRowVersion(); e.HasOne(x => x.ParentFolder).WithMany(x => x.Children).HasForeignKey(x => x.ParentFolderId).OnDelete(DeleteBehavior.Restrict); e.HasIndex(x => x.ParentFolderId); e.HasIndex(x => new { x.ParentFolderId, x.Name, x.IsDeleted }); e.HasQueryFilter(x => !x.IsDeleted); });
        b.Entity<Document>(e => { e.Property(x => x.Name).HasMaxLength(250).IsRequired(); e.Property(x => x.RowVersion).IsRowVersion(); e.HasIndex(x => x.Name); e.HasIndex(x => x.FolderId); e.HasIndex(x => x.AreaId); e.HasIndex(x => x.ProcessId); e.HasQueryFilter(x => !x.IsDeleted); });
        b.Entity<DocumentVersion>(e => { e.Property(x => x.Sha256).HasMaxLength(64).IsRequired(); e.Property(x => x.RelativePath).HasMaxLength(500).IsRequired(); e.HasIndex(x => new { x.DocumentId, x.VersionNumber }).IsUnique(); e.HasQueryFilter(x => !x.Document.IsDeleted); });
        b.Entity<Permission>(e => { e.HasIndex(x => new { x.SubjectType, x.SubjectId, x.ResourceType, x.ResourceId }); e.Property(x => x.SubjectId).HasMaxLength(450); });
        b.Entity<AuditEntry>(e => { e.HasKey(x => x.Id); e.Property(x => x.Action).HasMaxLength(100); e.Property(x => x.EntityName).HasMaxLength(100); e.HasIndex(x => x.TimestampUtc); e.HasIndex(x => x.UserId); e.HasIndex(x => x.EntityName); });
    }
}
