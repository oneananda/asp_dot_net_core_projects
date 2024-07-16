using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _020_Caching_Strategies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        [HttpGet("response-caching")]
        [ResponseCache(Duration =60)]
        public IActionResult GetResponseCachedData()
        {            
            return Ok(string.Empty);
        }
    }
}
