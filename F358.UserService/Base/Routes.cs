using System.Diagnostics.CodeAnalysis;
using F358.UserService.Core;
using F358.UserService.Dto;

namespace F358.UserService.Base;

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