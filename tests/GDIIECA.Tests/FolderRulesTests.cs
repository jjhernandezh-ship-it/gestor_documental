using GDIIECA.Application.Validation;

namespace GDIIECA.Tests;

public sealed class FolderRulesTests
{
    [Fact] public void RejectsInvalidNames() { Assert.False(FolderRules.IsValidName("  ")); Assert.False(FolderRules.IsValidName("uno/dos")); }
    [Fact] public void DetectsMovingIntoDescendant() { var root=Guid.NewGuid();var child=Guid.NewGuid();var grandchild=Guid.NewGuid();var parents=new Dictionary<Guid,Guid?>{{root,null},{child,root},{grandchild,child}};Assert.True(FolderRules.WouldCreateCycle(root,grandchild,parents));Assert.False(FolderRules.WouldCreateCycle(grandchild,root,parents)); }
}
