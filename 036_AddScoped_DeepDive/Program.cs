
using _036_AddScoped_DeepDive.Interfaces;
using _036_AddScoped_DeepDive.Services;
using _036_AddScoped_DeepDive.Services.DBContextExample;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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

            builder.Services.AddScoped<ICartServiceSubA, CartServiceSubA>();
            builder.Services.AddScoped<ICartServiceSubB, CartServiceSubB>();

            // Register DbContext as Scoped (default behavior)
            // Important: EF Core DbContext is registered as
            // scoped by default because state consistency
            // is essential during one HTTP request.
            //builder.Services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});
            var sqlLiteConnection = new SqliteConnection("Filename=:memory:");
            sqlLiteConnection.Open();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(sqlLiteConnection);
            });

            // Create a service provider to retrieve the DbContext instance
            var serviceProvider = builder.Services.BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();

            builder.Services.AddScoped<ProductRepository>();

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
