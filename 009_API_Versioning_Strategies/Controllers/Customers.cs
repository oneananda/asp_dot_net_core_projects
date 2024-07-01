using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _009_API_Versioning_Strategies.Controllers
{
    // Header Versioning
    [Route("api/customers")]
    [ApiController]
    public class Customers : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromHeader(Name = "api-version")] string apiVersion)
        {
            if (apiVersion == "1,0")
                return Ok("This is version 1.0");
            else if (apiVersion == "2.0")
                return Ok("This is version 2.0");
            else
                return BadRequest("Invalid version");
        }
    }
}
