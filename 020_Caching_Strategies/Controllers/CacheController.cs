using _020_Caching_Strategies.Modal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _020_Caching_Strategies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IDataService _dataService;

        public CacheController(IHttpContextAccessor contextAccessor, IDataService dataService)
        {
            _contextAccessor = contextAccessor;
            _dataService = dataService;
        }

        [HttpGet("response-caching")]
        [ResponseCache(Duration =60)]
        public IActionResult GetResponseCachedData()
        {
            var returnData = _dataService.GetData();
            return Ok(string.Empty);
        }
    }
}
