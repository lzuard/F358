using F358.Api.Base;
using F358.Api.Options;
using F358.Shared.Model.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace F358.Api.Controllers;

[Route("v1/[controller]/[action]")]
public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] NewUserRequest newUserDto,
        [FromServices] IOptions<UserServiceOptions> options,
        CancellationToken ct)
    {
        var client = new FinancesClient<UserServiceOptions>(options);
        var endpoint = options.Value.EndpointRegister;
        
        ArgumentNullException.ThrowIfNull(endpoint);
        return Ok(await client.PostDefaultResultAsync(endpoint, newUserDto, ct));
    }

    [HttpPost]
    public async Task<IActionResult> Login(
        [FromBody] LoginUserRequest loginRequest,
        [FromServices] IOptions<UserServiceOptions> options,
        CancellationToken ct)
    {
        var client = new FinancesClient<UserServiceOptions>(options);
        var endpoint = options.Value.EndpointLogin;
        
        ArgumentNullException.ThrowIfNull(endpoint);
        return Ok(await client.PostDefaultResultWithDataAsync<LoginUserRequest,string?>(endpoint, loginRequest, ct));
    }
}