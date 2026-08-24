namespace GDIIECA.Application.Validation;

public static class FolderRules
{
    private static readonly char[] Invalid = ['<', '>', ':', '"', '/', '\\', '|', '?', '*'];
    public static bool IsValidName(string? name) => !string.IsNullOrWhiteSpace(name)
        && name.Trim().Length <= 150 && name.IndexOfAny(Invalid) < 0;

    public static bool WouldCreateCycle(Guid folderId, Guid? destinationId, IReadOnlyDictionary<Guid, Guid?> parents)
    {
        var current = destinationId;
        var visited = new HashSet<Guid>();
        while (current is { } id)
        {
            if (id == folderId || !visited.Add(id)) return true;
            current = parents.GetValueOrDefault(id);
        }
        return false;
    }
}
