using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;

namespace _046_OpenTelemetry_Tracing_and_Metrics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Add OpenTelemetry Tracing
            builder.Services.AddOpenTelemetryTracing(builder => builder
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("MyAspNetCoreService"))
                .AddAspNetCoreInstrumentation() // This adds automatic instrumentation for HTTP requests in ASP.NET Core
                .AddHttpClientInstrumentation() // Adds automatic instrumentation for HTTP client calls
                .AddPrometheusExporter()); // Exports traces to Prometheus (for visualization in Grafana)



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
