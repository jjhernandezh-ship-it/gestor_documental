using System.Security.Cryptography;
using GDIIECA.Application.Interfaces;
using Microsoft.Extensions.Options;

namespace GDIIECA.Infrastructure.FileStorage;

public sealed class LocalFileStorageService(IOptions<FileStorageOptions> options) : IFileStorageService
{
    private readonly FileStorageOptions _options = options.Value;

    public async Task<StoredFile> SaveAsync(Stream content, string originalFileName, CancellationToken ct = default)
    {
        var ext = Path.GetExtension(Path.GetFileName(originalFileName)).ToLowerInvariant();
        if (!_options.AllowedExtensions.Contains(ext, StringComparer.OrdinalIgnoreCase)) throw new InvalidOperationException("Tipo de archivo no permitido.");
        var max = (long)_options.MaxFileSizeMB * 1024 * 1024;
        var relative = Path.Combine(DateTime.UtcNow.ToString("yyyy"), DateTime.UtcNow.ToString("MM"), $"{Guid.NewGuid():N}{ext}");
        var root = Path.GetFullPath(_options.RootPath);
        var target = Path.GetFullPath(Path.Combine(root, relative));
        if (!target.StartsWith(root + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)) throw new InvalidOperationException("Ruta inválida.");
        Directory.CreateDirectory(Path.GetDirectoryName(target)!);
        try
        {
            await using var output = new FileStream(target, FileMode.CreateNew, FileAccess.Write, FileShare.None, 81920, true);
            using var hash = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
            var buffer = new byte[81920]; long size = 0; int read;
            while ((read = await content.ReadAsync(buffer, ct)) > 0)
            {
                size += read; if (size > max) throw new InvalidOperationException($"El archivo excede {_options.MaxFileSizeMB} MB.");
                hash.AppendData(buffer, 0, read); await output.WriteAsync(buffer.AsMemory(0, read), ct);
            }
            return new(Path.GetFileName(target), relative, size, Convert.ToHexString(hash.GetHashAndReset()));
        }
        catch { if (File.Exists(target)) File.Delete(target); throw; }
    }

    public Task<Stream> OpenReadAsync(string relativePath, CancellationToken ct = default)
    {
        var root = Path.GetFullPath(_options.RootPath); var path = Path.GetFullPath(Path.Combine(root, relativePath));
        if (!path.StartsWith(root + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)) throw new InvalidOperationException("Ruta inválida.");
        return Task.FromResult<Stream>(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 81920, true));
    }
    public Task DeleteAsync(string relativePath, CancellationToken ct = default) { var root = Path.GetFullPath(_options.RootPath); var path = Path.GetFullPath(Path.Combine(root, relativePath)); if (path.StartsWith(root + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase) && File.Exists(path)) File.Delete(path); return Task.CompletedTask; }
}
