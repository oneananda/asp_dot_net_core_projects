namespace _014_RequestDelegate_Implementation.Middleware
{
    public class ShortCircuitMiddleware
    {
        private readonly RequestDelegate _next;
        public ShortCircuitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Short-circuit the pipeline and generate a response
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Forbidden");

            // Does not call the next middleware
        }
    }
}
