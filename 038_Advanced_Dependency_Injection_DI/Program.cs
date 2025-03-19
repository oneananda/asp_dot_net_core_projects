
using _038_Advanced_Dependency_Injection_DI.Common;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Interfaces;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace _038_Advanced_Dependency_Injection_DI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Registering_Classes_with_Interfaces
            builder.Services.AddScoped<IUserService, UserService>();

            var sqlLiteConnection = new SqliteConnection("Filename=:memory:");
            sqlLiteConnection.Open();

            builder.Services.AddDbContext<RCIAppDbContext>(options =>
            {
                options.UseSqlite(sqlLiteConnection);
            });

            // Create a service provider to retrieve the DbContext instance
            var serviceProvider = builder.Services.BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<RCIAppDbContext>();
            context.Database.EnsureCreated();


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
