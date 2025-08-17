using F358.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace F358.Api.Controllers;

[Route("api/[controller]/[action]")]
public class OperationsController : FinancesControllerBase
{
    [HttpGet]
    public IActionResult Index() => Ok();
}