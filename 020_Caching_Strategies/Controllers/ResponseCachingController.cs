using _020_Caching_Strategies.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _020_Caching_Strategies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseCachingController : ControllerBase
    {
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
            return Ok(returnData);
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
        // Test this with Swagger / Postman with different headers
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

        // Conditional response caching based on a custom condition
        // If the current time is between 6 AM and 9:59 AM (i.e., hours greater than 5 and less than 10),
        // it sets a Cache-Control header for the response.
        [HttpGet("conditional-response-caching")]
        public IActionResult GetConditionalResponseCachedData()
        {
            if (DateTime.Now.Hour > 5 && DateTime.Now.Hour < 10)
            {
                Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                {
                    MaxAge = TimeSpan.FromSeconds(30)
                };
            }

            var data = _dataService.GetData();
            return Ok(data);
        }
    }


}
