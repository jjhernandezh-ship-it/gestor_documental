using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GDIIECA.Infrastructure.Identity;

public static class IdentitySeeder
{
    public static async Task SeedIdentityAsync(this IServiceProvider services, IConfiguration configuration)
    {
        using var scope = services.CreateScope(); var roles = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(); var users = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        foreach (var role in new[] { "Administrador", "Usuario" }) if (!await roles.RoleExistsAsync(role)) await roles.CreateAsync(new IdentityRole(role));
        var email = configuration["InitialAdmin:Email"]; var password = configuration["InitialAdmin:Password"];
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || await users.FindByEmailAsync(email) is not null) return;
        var user = new ApplicationUser { UserName = email.Trim().ToLowerInvariant(), Email = email.Trim().ToLowerInvariant(), EmailConfirmed = true, FirstName = configuration["InitialAdmin:FirstName"] ?? "Administrador", LastName = configuration["InitialAdmin:LastName"] ?? "Inicial" };
        var result = await users.CreateAsync(user, password); if (!result.Succeeded) throw new InvalidOperationException("No se pudo crear el administrador inicial: " + string.Join(" ", result.Errors.Select(x => x.Description))); await users.AddToRoleAsync(user, "Administrador");
    }
}
