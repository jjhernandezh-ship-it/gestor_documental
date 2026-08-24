using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GDIIECA.Web.Components;
using GDIIECA.Web.Components.Account;
using GDIIECA.Application;
using GDIIECA.Infrastructure;
using GDIIECA.Infrastructure.Data;
using GDIIECA.Infrastructure.Identity;
using GDIIECA.Application.Interfaces;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequiredLength = 12;
        options.Lockout.MaxFailedAccessAttempts = 5;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthentication();
app.Use(async (context, next) =>
{
    if (context.User.Identity?.IsAuthenticated == true)
    {
        var path = context.Request.Path;
        var allowed = path.StartsWithSegments("/Account/ForceChangePassword")
            || path.StartsWithSegments("/Account/Logout")
            || path.StartsWithSegments("/_blazor")
            || path.StartsWithSegments("/_framework")
            || Path.HasExtension(path.Value);
        if (!allowed)
        {
            var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
            var user = await userManager.GetUserAsync(context.User);
            if (user?.MustChangePassword == true)
            {
                context.Response.Redirect("/Account/ForceChangePassword");
                return;
            }
        }
    }
    await next();
});
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();
app.MapGet("/login", () => Results.Redirect("/Account/Login"));
app.MapGet("/api/files/{versionId:guid}", async (Guid versionId, ClaimsPrincipal principal, IDocumentService documents, CancellationToken ct) =>
{
    var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
    if (userId is null) return Results.Unauthorized();
    var file = await documents.OpenVersionAsync(versionId, userId, ct);
    return Results.File(file.Content, file.MimeType, file.FileName, enableRangeProcessing: true);
}).RequireAuthorization();

if (builder.Configuration.GetValue<bool>("InitialAdmin:SeedOnStartup"))
    await app.Services.SeedIdentityAsync(builder.Configuration);

app.Run();
