using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _014_RequestDelegate_Implementation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("Home Processed!");
        }
    }
}
