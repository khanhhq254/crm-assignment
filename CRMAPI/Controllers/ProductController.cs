using CRMAPI.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CRMAPI.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ApiControllerBase
{
    /// <summary>
    /// Get product and price from PIM
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetProductFromPIM()
    {
        var result=  await Mediator.Send(new GetProductInfoFromPIMQuery());
        return Ok(result);
    }
}