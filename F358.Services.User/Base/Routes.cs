using System.Diagnostics.CodeAnalysis;
using F358.Services.User.Core;
using F358.Services.User.Dto;

namespace F358.Services.User.Base;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Local")]
internal static class Routes
{
    public static void AddRoutes(this WebApplication app)
    {
        app.MapPost("/login", async(
                    LoginDto dto, 
                    AuthService service,
                    CancellationToken ct) => await service.LoginAsync(dto, ct)
        ).WithName("Login");
        
        app.MapPost("/register", async(
                NewUserDto dto, 
                RegistrationService service, 
                CancellationToken ct) => await service.RegisterUserAsync(dto, ct)
        ).WithName("Register");
    }
}