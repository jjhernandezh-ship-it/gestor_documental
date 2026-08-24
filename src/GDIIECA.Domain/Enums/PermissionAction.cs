namespace GDIIECA.Domain.Enums;

[Flags]
public enum PermissionAction
{
    None = 0, View = 1, Download = 2, Create = 4, Edit = 8, Delete = 16, Administer = 32
}

public enum PermissionEffect { Allow, Deny }
public enum PermissionSubjectType { User, Role, Area }
public enum PermissionResourceType { Folder, Document }
