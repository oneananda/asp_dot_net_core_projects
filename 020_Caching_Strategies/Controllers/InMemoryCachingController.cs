using _020_Caching_Strategies.Modal;
using _020_Caching_Strategies.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace _020_Caching_Strategies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InMemoryCachingController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDataService _dataService;
        public InMemoryCachingController(IMemoryCache memoryCache, IDataService dataService)
        {
            _memoryCache = memoryCache;
            _dataService = dataService;
        }         

        [HttpGet("in-memory-caching")]
        public IActionResult GetInMemoryCachedData()
        {
            var cacheKey = "in-memory-cache-key";
            if (!_memoryCache.TryGetValue(cacheKey, out LargeDataSet cachedData))
            {
                cachedData = _dataService.GetData();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));

                _memoryCache.Set(cacheKey, cachedData, cacheEntryOptions);
            }

            return Ok(cachedData);
        }

    }
}
