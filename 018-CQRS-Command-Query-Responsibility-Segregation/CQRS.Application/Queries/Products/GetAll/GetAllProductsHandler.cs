using CQRS.Domain.Entities;
using CQRS.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Queries.Products.GetAll
{  
    public class GetAllProductsHandler
    {
        private readonly ProductRepository _repository;
        public GetAllProductsHandler(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> Handle(GetAllProducts query)
        {
            return await _repository.GetAllAsync();
        }
    }
}
