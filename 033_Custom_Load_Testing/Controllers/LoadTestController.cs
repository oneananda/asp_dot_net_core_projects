using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _033_Custom_Load_Testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadTestController : ControllerBase
    {
        public IActionResult GetValues()
        {
            return Ok();
        }
    }
}
