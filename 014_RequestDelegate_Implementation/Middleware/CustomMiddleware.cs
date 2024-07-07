namespace _014_RequestDelegate_Implementation.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Do something with the request before calling the next middleware
            Console.WriteLine($"Handling request in CustomMiddleware");

            await _next(context);

            // Do something with the response after calling the next middleware
            Console.WriteLine($"Finished handling request in CustomMiddleware");
        }
    }
}
