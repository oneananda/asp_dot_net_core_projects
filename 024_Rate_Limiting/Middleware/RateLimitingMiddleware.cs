﻿using Microsoft.Extensions.Caching.Memory;

namespace _024_Rate_Limiting.Middleware
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

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

            var cacheKey = $"{clientIp}:{DateTime.UtcNow.Minute}";   

            if(!_cache.TryGetValue(cacheKey, out int requestCount))
            {
                requestCount = 0;
            }

            if (requestCount >= MaxRequestsPerMinute)
            {
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await context.Response.WriteAsync("Rate limit exceeded, Try again later!");
                return;
            }
            requestCount++;

            _cache.Set(cacheKey, requestCount, TimeSpan.FromSeconds(TimeWindownInSeconds));

            await _next(context);
        }
    }
}
