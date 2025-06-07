using _048_ApiMockingService.Data;

namespace _048_ApiMockingService.Middleware
{
    public class DynamicMockMiddleware
    {
        private readonly RequestDelegate _next;

        public DynamicMockMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context, MockDbContext db)
        {
            var path = context.Request.Path.Value;
            var method = context.Request.Method.ToUpper();

            var mock = db.Mocks.FirstOrDefault(m => m.Path == path && m.Method == method);
            if (mock != null)
            {
                if (mock.DelayMs > 0)
                    await Task.Delay(mock.DelayMs);

                context.Response.StatusCode = mock.StatusCode;
                context.Response.ContentType = mock.ContentType ?? "application/json";
                await context.Response.WriteAsync(mock.ResponseBody);
                return;
            }

            await _next(context);
        }
    }

}
