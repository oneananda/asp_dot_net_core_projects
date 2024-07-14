
using CQRS.Api.Extensions;
using CQRS.Application.Commands;
using CQRS.Application.Queries;
using CQRS.Infrastructure.Repositories;
using CQRS.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("CQRSExampleDb"));

            
            // Grouping all the services related object instantiation to a separate extension method
            builder.Services.AddProductServices();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
