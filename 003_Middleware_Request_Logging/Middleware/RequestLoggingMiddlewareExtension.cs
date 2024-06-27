using System.Runtime.CompilerServices;

namespace _003_Middleware_Request_Logging.Middleware
{
    public static class RequestLoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
