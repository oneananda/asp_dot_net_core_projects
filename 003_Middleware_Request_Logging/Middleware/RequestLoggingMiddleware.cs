using System.Diagnostics;

namespace _003_Middleware_Request_Logging.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate requestDelegate, ILogger<RequestLoggingMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
            await _requestDelegate(context);
        }
    }
}
