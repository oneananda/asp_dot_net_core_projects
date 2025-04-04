
using _042_AddSingleton_Deep_Dive.Models;
using _042_AddSingleton_Deep_Dive.Services;

namespace _042_AddSingleton_Deep_Dive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<ITimeService, TimeService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var appSettings = new AppSettings
            {
                AppName = "AddSingleton Deep Dive"
            };
            builder.Services.AddSingleton(appSettings);

            builder.Services.AddSingleton<IGuidService>(provider =>
            {
                var generatedGuid = Guid.NewGuid();
                return new GuidService(generatedGuid);
            });

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
