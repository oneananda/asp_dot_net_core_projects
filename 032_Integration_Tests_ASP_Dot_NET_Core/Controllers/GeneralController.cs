using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _032_Integration_Tests_ASP_Dot_NET_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("General Get!");
        }
    }
}
