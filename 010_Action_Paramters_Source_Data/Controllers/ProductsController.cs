using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Reflection;
using System.Data.Common;
using System.Numerics;
using Microsoft.AspNetCore.WebUtilities;
using System.Reflection.PortableExecutable;

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
        /*
        FromForm
        Binds a parameter to data from posted form data.
        Used when submitting form data, often with enctype="multipart/form-data".
        */
        [HttpPost("upload")]
        public IActionResult UploadFile([FromForm] IFormFile file, [FromForm] string description)
        {
            // Access file and description from the form data
            return Ok();
        }
        /*
        FromHeader
        Binds a parameter to a specified request header.
        */
        [HttpGet("header")]
        public IActionResult GetFromHeader([FromHeader(Name = "X-Custom-Header")] string customHeader)
        {
            // Access the X-Custom-Header value from the request headers
            return Ok(customHeader);
        }
        /*
        FromKeyedServices
        Binds a parameter to a service registered with a specific key. 
        This attribute is available in ASP.NET Core 8.0 and later.
        This will be explained in detail in an exclusive project
        */
        [HttpGet("keyed")]
        public IActionResult GetKeyedService([FromKeyedServices("myKey")] IMyService myService)
        {
            // Use the myService which is registered with the key "myKey"
            return Ok();
        }

        /*
        FromRoute
        Binds a parameter to data in the route.
        */
        [HttpGet("products/{id}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            // Example logic to get product by id
            var product = GetProductById(id);
            return Ok(product);
        }
        private string GetProductById(int id)
        {
            // Dummy data 
            return $"Product {id}";
        }

        /*
        FromServices
        Binds a parameter to a service from the dependency injection container.
        This will be explained in detail in an exclusive project
        */

        [HttpGet("service")]
        public IActionResult GetFromService([FromServices] IMyService myService)
        {
            // Example logic to use the service
            return Ok(myService.GetData());
        }
    }
}
