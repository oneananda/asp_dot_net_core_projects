using _015_Policy_based_Authorization.Authorization.Handlers;
using _015_Policy_based_Authorization.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace _015_Policy_based_Authorization
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
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AtLeast21", policy => policy.Requirements.Add(new MinimumAgeRequirement(21)));
            });

            services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }

    }
}
