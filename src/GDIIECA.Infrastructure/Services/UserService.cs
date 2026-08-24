using GDIIECA.Application.Common;
using GDIIECA.Application.DTOs;
using GDIIECA.Application.Interfaces;
using GDIIECA.Application.Validation;
using GDIIECA.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GDIIECA.Infrastructure.Services;

public sealed class UserService(UserManager<ApplicationUser> users, RoleManager<IdentityRole> roles, IAuditService audit) : IUserService
{
    public async Task<PagedResult<UserDto>> ListAsync(int page, int pageSize, CancellationToken ct = default)
    {
        page = Math.Max(1, page); pageSize = Math.Clamp(pageSize, 1, 100); var total = await users.Users.CountAsync(ct); var data = await users.Users.OrderBy(x => x.Email).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct); var result = new List<UserDto>();
        foreach (var u in data) result.Add(new(u.Id, u.Email!, u.FirstName, u.LastName, u.AreaId, u.IsActive, (await users.GetRolesAsync(u)).ToArray())); return new(result, total, page, pageSize);
    }
    public async Task<IReadOnlyList<string>> ListRolesAsync(CancellationToken ct = default) => await roles.Roles.AsNoTracking().Where(x => x.Name != null).OrderBy(x => x.Name).Select(x => x.Name!).ToListAsync(ct);

    public async Task<(bool Success, string? Error)> CreateAsync(CreateUserRequest request, string actorId, CancellationToken ct = default)
    {
        if (!InstitutionalEmailValidator.IsValid(request.Email)) return (false, "El correo debe pertenecer a guanajuato.gob.mx o ieca.edu.mx.");
        var requestedRoles = request.Roles.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
        if (requestedRoles.Length == 0 || requestedRoles.Any(role => !roles.Roles.Any(x => x.NormalizedName == role.ToUpper()))) return (false, "Selecciona un rol válido.");
        var email = InstitutionalEmailValidator.Normalize(request.Email); var user = new ApplicationUser { UserName = email, Email = email, EmailConfirmed = true, FirstName = request.FirstName.Trim(), LastName = request.LastName.Trim(), AreaId = request.AreaId, MustChangePassword = true };
        var result = await users.CreateAsync(user, request.Password); if (!result.Succeeded) return (false, string.Join(" ", result.Errors.Select(x => x.Description)));
        var roleResult = await users.AddToRolesAsync(user, requestedRoles); if (!roleResult.Succeeded) { await users.DeleteAsync(user); return (false, string.Join(" ", roleResult.Errors.Select(x => x.Description))); }
        await audit.RecordAsync("USUARIO_CREADO", nameof(ApplicationUser), user.Id, email, actorId, newValues: new { request.Email, request.FirstName, request.LastName, Roles = requestedRoles }, ct: ct); return (true, null);
    }
    public async Task SetActiveAsync(string id, bool active, string actorId, CancellationToken ct = default) { if (!active && id == actorId) throw new InvalidOperationException("No puedes desactivar tu propia cuenta."); var user = await users.FindByIdAsync(id) ?? throw new InvalidOperationException("Usuario no encontrado."); user.IsActive = active; user.LockoutEnd = active ? null : DateTimeOffset.MaxValue; var result = await users.UpdateAsync(user); if (!result.Succeeded) throw new InvalidOperationException(string.Join(" ", result.Errors.Select(x => x.Description))); await audit.RecordAsync(active ? "USUARIO_ACTIVADO" : "USUARIO_DESACTIVADO", nameof(ApplicationUser), id, user.Email!, actorId, ct: ct); }

    public async Task<(bool Success, string? Error)> ResetPasswordAsync(string id, string temporaryPassword, string actorId, CancellationToken ct = default)
    {
        var user = await users.FindByIdAsync(id); if (user is null) return (false, "Usuario no encontrado.");
        var token = await users.GeneratePasswordResetTokenAsync(user); var result = await users.ResetPasswordAsync(user, token, temporaryPassword);
        if (!result.Succeeded) return (false, string.Join(" ", result.Errors.Select(x => x.Description)));
        user.MustChangePassword = true; user.SecurityStamp = Guid.NewGuid().ToString();
        var update = await users.UpdateAsync(user); if (!update.Succeeded) return (false, string.Join(" ", update.Errors.Select(x => x.Description)));
        await audit.RecordAsync("CONTRASENA_RESTABLECIDA", nameof(ApplicationUser), id, $"Contraseña temporal restablecida para {user.Email}", actorId, ct: ct);
        return (true, null);
    }
}
