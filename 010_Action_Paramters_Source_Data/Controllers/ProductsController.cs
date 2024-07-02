using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Reflection;
using System.Data.Common;
using System.Numerics;

namespace _010_Action_Paramters_Source_Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /*
        FromQuery
        Binds a parameter to data in the query string.
        */
        [HttpGet("products")]
        public IActionResult GetProducts([FromQuery] string product, [FromQuery] int page = 1)
        {
            // Write the logic to access product and page from the query string
            return Ok();
        }

        /*
        FromBody
        Binds a parameter to data in the request body.Typically used for complex types.
        */
        [HttpPost("products")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            // Access product data from the request body
            return Ok(product);
        }

    }
}
