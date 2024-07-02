using _012_DI_Dependency_Injection.App_Code;
using _012_DI_Dependency_Injection.Interfaces;

namespace _012_DI_Dependency_Injection
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMyService, MyService>();

            services.AddTransient<ITransientService, TransientService>();

            services.AddScoped<IScopedService, ScopedService>();

            services.AddSingleton<ISingletonService, SingletonService>();

            // Add services to the container
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
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
