using GDIIECA.Application.Interfaces;
using GDIIECA.Infrastructure.Data;
using GDIIECA.Infrastructure.FileStorage;
using GDIIECA.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GDIIECA.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Falta ConnectionStrings:DefaultConnection. " +
                "En desarrollo usa dotnet user-secrets; en producción define ConnectionStrings__DefaultConnection.");
        services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connection)); services.AddOptions<FileStorageOptions>().Bind(configuration.GetSection(FileStorageOptions.SectionName)).Validate(x => x.MaxFileSizeMB > 0, "MaxFileSizeMB debe ser positivo.").ValidateOnStart();
        services.AddScoped<IAreaService, AreaService>(); services.AddScoped<IProcessService, ProcessService>(); services.AddScoped<IFolderService, FolderService>(); services.AddScoped<IDocumentService, DocumentService>(); services.AddScoped<IUserService, UserService>(); services.AddScoped<IPermissionService, PermissionService>(); services.AddScoped<IAuditService, AuditService>(); services.AddSingleton<IFileStorageService, LocalFileStorageService>(); return services;
    }
}
