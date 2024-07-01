using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _009_API_Versioning_Strategies.Controllers
{
    // URL Path Versioning -- V2
    [Route("api/v1/products")]
    [ApiController]
    public class ProductsV2 : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("This is version 2.0");
    }
}
