using Microsoft.AspNetCore.Mvc;

namespace Company.BFF.Controllers;

[ApiController]
public class BffController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Index()
    {
        return Ok(new { message = "Company BFF is running" });
    }
}
