using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProdMgmt.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = new[]
        {
            new { Id = 1, Name = "Laptop", Price = 75000 },
            new { Id = 2, Name = "Mouse",  Price = 1200  }
        };

        return Ok(products);
    }
}
