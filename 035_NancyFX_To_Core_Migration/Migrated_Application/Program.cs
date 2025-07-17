using Nancy;
using Nancy.Owin;

namespace _035_NancyFX_To_Core_Migration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<NancyFx_Class>();

            var app = builder.Build();

            // Using Minimal API Approach
            app.MapGet("/", () => "Hello from ASP.NET Core via NancyFx!");

            app.MapGet("/greet/{name}", (string name) => $"Hello, {name} via NancyFx!");

          

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
