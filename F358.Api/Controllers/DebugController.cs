using F358.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
    [Authorize]
    public IActionResult TestAuth() => Ok();
}


#endif