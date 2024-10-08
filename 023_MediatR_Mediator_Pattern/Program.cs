
using System.Reflection;
using MediatR;

namespace _023_MediatR_Mediator_Pattern
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

            MediatRServiceConfiguration mediatRServiceConfiguration = new MediatRServiceConfiguration();

            // Register MediatR services
            builder.Services.AddMediatR(mediatRServiceConfiguration);

            // Register MediatR services with custom configuration
            //var mediatRServiceConfiguration = new MediatRServiceConfiguration();
            //builder.Services.AddMediatR(cfg => cfg.Using(mediatRServiceConfiguration), typeof(Startup).Assembly);

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
