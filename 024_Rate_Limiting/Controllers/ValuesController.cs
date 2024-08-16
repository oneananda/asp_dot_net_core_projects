using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _024_Rate_Limiting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController() { }

        [HttpGet("getvalues")]
        public IActionResult GetValues()
        {
            // Write the logic to access product and page from the query string
            return Ok();
        }
    }
}
