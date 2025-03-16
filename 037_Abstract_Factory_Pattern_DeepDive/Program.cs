
using _037_Abstract_Factory_Pattern_DeepDive.PaymentGateways;

namespace _037_Abstract_Factory_Pattern_DeepDive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // PaymentGateways Implementation
            builder.Services.AddScoped<PayPalGateway>();
            builder.Services.AddScoped<StripeGateway>();
            builder.Services.AddScoped<IPaymentGatewayFactory, PaymentGatewayFactory>();


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
