namespace GDIIECA.Infrastructure.FileStorage;

public sealed class FileStorageOptions
{
    public const string SectionName = "FileStorage";
    public string RootPath { get; set; } = "App_Data/Documents";
    public int MaxFileSizeMB { get; set; } = 100;
    public string[] AllowedExtensions { get; set; } = [".pdf", ".jpg", ".jpeg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".xlsm", ".ppt", ".pptx", ".zip"];
}
