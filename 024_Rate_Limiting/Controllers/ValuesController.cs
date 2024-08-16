using _024_Rate_Limiting.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _024_Rate_Limiting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRequestDataService _requestDataService;
        public ValuesController(IRequestDataService requestDataService)
        {
            _requestDataService = requestDataService;
        }

        [HttpGet("get-cache-values")]
        public IActionResult GetCacheValues()
        {
            // Write the logic to access product and page from the query string
            return Ok(_requestDataService);
        }
    }
}
