
using Hangfire;
using Hangfire.Storage.SQLite;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace _044_Hangfire_Background_Jobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 2. determine a path for your SQLite file inside the project
            //    here we put it at {contentRoot}/App_Data/hangfire.db
            var dbFolder = Path.Combine(builder.Environment.ContentRootPath, "App_Data");
            Directory.CreateDirectory(dbFolder);
            var sqliteDb = Path.Combine(dbFolder, "hangfire.db");

            builder.Services.AddHangfire(cfg => cfg
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSQLiteStorage(
                // connection string pointing at our file:
                $"Data Source={sqliteDb};Cache=Shared",
                // optional settings (tweak as needed):
                new SQLiteStorageOptions
                {
                    QueuePollInterval = TimeSpan.FromSeconds(15),
                    InvisibilityTimeout = TimeSpan.FromMinutes(5),
                    JobExpirationCheckInterval = TimeSpan.FromHours(1)
                    }
                )                                       
             );

            // Add the Hangfire server
            builder.Services.AddHangfireServer();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseHangfireDashboard("/hangfire");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGet("/", () => "Hangfire + SQLite Demo");

            app.Run();
        }
    }
}
