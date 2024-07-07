using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _014_RequestDelegate_Implementation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {

        }

        public IActionResult Index()
        {
            return Ok("Values Processed!");
        }
    }
}
