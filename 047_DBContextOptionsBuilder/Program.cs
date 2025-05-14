
using _047_DBContextOptionsBuilder.Services;

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
