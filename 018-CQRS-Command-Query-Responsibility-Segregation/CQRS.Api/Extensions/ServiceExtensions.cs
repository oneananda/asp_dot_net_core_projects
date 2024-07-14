using CQRS.Application.Commands;
using CQRS.Application.Queries;
using CQRS.Infrastructure.Repositories;

namespace CQRS.Api.Extensions
{
    public static class ServiceExtensions
    {
        // Grouping all the services related object instantiation to a separate extension method
        public static void AddProductServices(this IServiceCollection services)
        {
            services.AddScoped<ProductRepository>();
            services.AddScoped<CreateProductCommandHandler>();
            services.AddScoped<GetProductByIdQueryHandler>();
            services.AddScoped<GetAllProductsHandler>();
            services.AddScoped<UpdateProductCommandHandler>();
        }
    }
}
