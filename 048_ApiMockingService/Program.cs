
using _048_ApiMockingService.Data;
using _048_ApiMockingService.Middleware;

namespace _048_ApiMockingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MockDbContext>(opt => opt.UseSqlite("Data Source=mocks.db"));
            builder.Services.AddControllers();
            var app = builder.Build();

            app.UseMiddleware<DynamicMockMiddleware>(); // Must come BEFORE MapControllers
            app.MapControllers();
            app.Run();


            // Add services to the container.

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
