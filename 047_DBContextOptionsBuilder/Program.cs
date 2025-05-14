
using _047_DBContextOptionsBuilder.Services;
using Microsoft.EntityFrameworkCore;

namespace _047_DBContextOptionsBuilder
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

            builder.Services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer("Server=.;Database=MyDb;Trusted_Connection=True;"));

            //  Enable Sensitive Data Logging and Lazy Loading
            services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer("Server=.;Database=MyDb;Trusted_Connection=True;")
           .EnableSensitiveDataLogging()
           .UseLazyLoadingProxies());

            // Using SQLite for Testing
            var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;

            using var context = new MyDbContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

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
