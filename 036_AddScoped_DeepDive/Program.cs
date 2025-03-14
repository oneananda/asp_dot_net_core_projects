
using _036_AddScoped_DeepDive.Interfaces;
using _036_AddScoped_DeepDive.Services;

namespace _036_AddScoped_DeepDive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<IRequestTracker, RequestTracker>();
            builder.Services.AddScoped<IServiceA, ServiceA>();
            builder.Services.AddScoped<IServiceB, ServiceB>();

            builder.Services.AddScoped<ExampleService2>();

            builder.Services.AddScoped<ICartService, CartService>();

            builder.Services.AddScoped<ICartServiceSubB, CartServiceSubB>();
            builder.Services.AddScoped<ICartServiceSubA, CartServiceSubA>();

            builder.Services.AddControllers();
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
