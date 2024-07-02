using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _009_API_Versioning_Strategies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class RegionController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult GetV1() => Ok("This is version 1.0");

        [HttpGet]
        [MapToApiVersion("2.0")]
        public IActionResult GetV2() => Ok("This is version 2.0");
    }
}
