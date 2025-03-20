
using _038_Advanced_Dependency_Injection_DI.Common;
using _038_Advanced_Dependency_Injection_DI.DI_with_Delegate_Factories;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Interfaces;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Services;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_Without_Interfaces_RCWI;
using _038_Advanced_Dependency_Injection_DI.Registering_Multiple_Implementations_Single_Interface;
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

            builder.Services.AddTransient<EmailSender>();

            builder.Services.AddScoped<PaypalGateway>();
            builder.Services.AddScoped<StripeGateway>();

            // Alternatively, register as IEnumerable:
            builder.Services.AddScoped<IPaymentGateway, PaypalGateway>();
            builder.Services.AddScoped<IPaymentGateway, StripeGateway>();

            // DI Registration (with delegate factory)

            builder.Services.AddTransient<EmailSender2>();
            builder.Services.AddTransient<Func<string, EmailSender2>>(provider => smtpServer =>
            {
                return new EmailSender2(smtpServer);
            });



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
