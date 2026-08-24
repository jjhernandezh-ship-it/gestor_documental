namespace GDIIECA.Application.DTOs;

public sealed record AreaDto(Guid Id, string Name, string? Description, bool IsActive);
public sealed record ProcessDto(Guid Id, string Code, string Name, string? Description, Guid? AreaId, string? AreaName, bool IsActive);
public sealed record FolderDto(Guid Id, string Name, Guid? ParentFolderId, Guid? AreaId, Guid? ProcessId);
public sealed record BreadcrumbDto(Guid Id, string Name);
public sealed record DocumentDto(Guid Id, string Name, string? Description, Guid FolderId, int CurrentVersionNumber, string? Extension, DateTime CreatedAtUtc);
public sealed record DocumentVersionDto(Guid Id, int VersionNumber, string OriginalFileName, string MimeType, long SizeBytes, string Sha256, string? ChangeComment, DateTime CreatedAtUtc);
public sealed record UserDto(string Id, string Email, string FirstName, string LastName, Guid? AreaId, bool IsActive, IReadOnlyList<string> Roles);
public sealed record CreateUserRequest(string Email, string FirstName, string LastName, Guid? AreaId, string Password, IReadOnlyList<string> Roles);
public sealed record DashboardDto(int Documents, int Folders, IReadOnlyList<DocumentDto> RecentDocuments);
