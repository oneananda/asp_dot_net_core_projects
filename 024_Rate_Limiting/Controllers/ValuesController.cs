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
            var clientIp = HttpContext.Connection.RemoteIpAddress?.ToString();
            var cacheKey = $"{clientIp}:{DateTime.UtcNow.Minute}";

            return Ok($"Client Ip: {clientIp}, Current Minute {DateTime.UtcNow.Minute}, Hit count : {_requestDataService.GetRequestCount(cacheKey)}");
        }
    }
}
