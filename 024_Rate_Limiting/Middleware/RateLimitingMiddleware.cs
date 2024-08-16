using Microsoft.Extensions.Caching.Memory;

namespace _024_Rate_Limiting.Middleware
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());

        private const int MaxRequestsPerMinute = 60;
        private const int TimeWindownInSeconds = 60;

        public RateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var clientIp = context.Connection.RemoteIpAddress?.ToString();

            if (clientIp == null)
            {
                await _next(context);
                return;
            }
        }
    }
}
