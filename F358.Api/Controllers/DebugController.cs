using System.Text;
using F358.Api.Controllers.Base;
using F358.Api.Options;
using Microsoft.AspNetCore.Mvc;
using F358.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

#if DEBUG
namespace F358.Api.Controllers;

[Route("v1/[controller]/[action]")]
public class DebugController : FinancesControllerBase
{
    [HttpGet]
    public IActionResult TestConnection() => Ok();

    [HttpGet]
    public IActionResult TestQueryParams(
        [FromQuery] string param
    ) => Ok(param);

    [HttpGet]
    public IActionResult Test(
        [FromServices] IOptions<Secrets> options)
    {
        return Ok("res: "+ options.Value.UserServiceApiKey);
    }

    [HttpGet]
    [Authorize]
    public IActionResult TestAuth() => Ok();
}


#endif