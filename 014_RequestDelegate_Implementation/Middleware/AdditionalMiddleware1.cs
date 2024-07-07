namespace _014_RequestDelegate_Implementation.Middleware
{
    public class AdditionalMiddleware1
    {
        private readonly RequestDelegate _next;

        public AdditionalMiddleware1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Handling request in AdditionalMiddleware1");

            await _next(context);

            Console.WriteLine("Finished handling request in AdditionalMiddleware1");
        }
    }
}
