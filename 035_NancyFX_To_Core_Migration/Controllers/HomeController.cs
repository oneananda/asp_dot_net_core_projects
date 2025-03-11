using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _035_NancyFX_To_Core_Migration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from ASP.NET Core!");
        }
    }
}
