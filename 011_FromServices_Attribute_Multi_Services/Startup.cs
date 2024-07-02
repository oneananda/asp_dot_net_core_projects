using _011_FromServices_Attribute_Multi_Services.Interfaces;
using _011_FromServices_Attribute_Multi_Services.Modal;

namespace _011_FromServices_Attribute_Multi_Services
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IServiceA, ServiceA>();
            services.AddTransient<IServiceB, ServiceB>();
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
