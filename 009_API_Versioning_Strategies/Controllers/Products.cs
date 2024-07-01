using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _009_API_Versioning_Strategies.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class Products : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] string apiVersion)
        {
            if (apiVersion == "1,0")
            {
                return Ok("This is version 1.0");
            }
            else if (apiVersion == "2.0")
            {
                return Ok("This is version 2.0");
            }
            else
            {
                return BadRequest("Invalid version");
            }
        }
    }
}
