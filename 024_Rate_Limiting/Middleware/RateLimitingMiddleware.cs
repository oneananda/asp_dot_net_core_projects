using Microsoft.Extensions.Caching.Memory;

namespace _024_Rate_Limiting.Middleware
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
    }
}
