using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _009_API_Versioning_Strategies.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        // Media Type Versioning
        [HttpGet]
        public IActionResult Get([FromHeader(Name = "Accept")] string acceptHeader)
        {
            if (acceptHeader.Contains("application/vnd.company.v1+json"))
                return Ok("This is version 1.0");
            else if (acceptHeader.Contains("application/vnd.company.v2+json"))
                return Ok("This is version 2.0");
            else
                return BadRequest("Invalid version");
        }
    }
}
