namespace _014_RequestDelegate_Implementation.Middleware
{
    public class NoOpMiddleware
    {
        private readonly RequestDelegate _next;

        public NoOpMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // No specific processing on the request

            // Call the next middleware
            await _next(context);
        }
    }
}
