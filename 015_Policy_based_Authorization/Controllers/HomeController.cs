using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _015_Policy_based_Authorization.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("You are at Home!");
        }
    }
}
