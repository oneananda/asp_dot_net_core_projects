
using _034_AddTransient_DeepDive.Repositories.Interfaces;
using _034_AddTransient_DeepDive.Repositories;
using _034_AddTransient_DeepDive.Services.Interfaces;
using _034_AddTransient_DeepDive.Services;

namespace _034_AddTransient_DeepDive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();

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
