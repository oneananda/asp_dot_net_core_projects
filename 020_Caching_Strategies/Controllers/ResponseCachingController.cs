using _020_Caching_Strategies.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _020_Caching_Strategies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseCachingController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IDataService _dataService;

        public ResponseCachingController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("basic-response-caching")]
        [ResponseCache(Duration = 60)]
        public IActionResult GetResponseCachedData()
        {
            var returnData = _dataService.GetData();
            return Ok(string.Empty);
        }

        // Caches responses based on the value of the 'id' query string parameter
        [HttpGet("response-caching-query")]
        [ResponseCache(Duration = 60, VaryByQueryKeys = new[] { "id" })]
        public IActionResult GetResponseCachedDataByQuery([FromQuery] int id)
        {
            var data = _dataService.GetDataById(id);
            return Ok(data);
        }

        // Caches responses based on the value of the 'X-Custom-Header' request header
        [HttpGet("response-caching-header")]
        [ResponseCache(Duration = 60, VaryByHeader = "X-Custom-Header")]
        public IActionResult GetResponseCachedDataByHeader()
        {
            var data = _dataService.GetData();
            return Ok(data);
        }

        //// Caches responses based on the value of the 'session-id' cookie
        //[HttpGet("response-caching-cookie")]
        //[ResponseCache(Duration = 60, VaryByQueryKeys = "session-id")]
        //public IActionResult GetResponseCachedDataByCookie()
        //{
        //    var data = _dataService.GetData();
        //    return Ok(data);
        //}
    }
}
