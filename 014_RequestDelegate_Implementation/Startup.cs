using _014_RequestDelegate_Implementation.Extensions;
using _014_RequestDelegate_Implementation.Middleware;

namespace _014_RequestDelegate_Implementation
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();



            // NoOpMiddleware - Does nothing other than pass the control to next middleware

            app.Use(async (context, next) =>
            {
                var noOpMiddleware = new NoOpMiddleware(next);
                await noOpMiddleware.InvokeAsync(context);
            });

            // Short-circuiting the middleware
            // To see Short-circuiting  uncomment the following line
            /*
            app.Use(async (context, next) =>
            {
                var shortCircuitMiddleware = new ShortCircuitMiddleware(next);
                await shortCircuitMiddleware.InvokeAsync(context);
            });
            */

            // Calling the Extenstion method
            app.UseCustomMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
