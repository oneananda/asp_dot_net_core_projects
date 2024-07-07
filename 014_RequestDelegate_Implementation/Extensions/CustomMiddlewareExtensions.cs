using _014_RequestDelegate_Implementation.Middleware;
using Microsoft.AspNetCore.Builder;

namespace _014_RequestDelegate_Implementation.Extensions
{
    public static class CustomMiddlewareExtensions
    {
        /// <summary>
        /// Extension method to add the CustomMiddleware to the application's request pipeline.
        /// </summary>
        /// <param name="app">The IApplicationBuilder instance.</param>
        /// <returns>The IApplicationBuilder instance with the CustomMiddleware added to the pipeline.</returns>
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            // Adds the CustomMiddleware to the application's request pipeline.
            return app.UseMiddleware<CustomMiddleware>();
        }
    }

}
