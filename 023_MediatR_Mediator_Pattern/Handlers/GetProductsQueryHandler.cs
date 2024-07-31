namespace _023_MediatR_Mediator_Pattern.Handlers
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using _023_MediatR_Mediator_Pattern.Models;
    using _023_MediatR_Mediator_Pattern.Requests;

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        public Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product A", Price = 10.0M },
            new Product { Id = 2, Name = "Product B", Price = 20.0M },
            new Product { Id = 3, Name = "Product C", Price = 30.0M }
        };
            return Task.FromResult(products);
        }
    }

}
