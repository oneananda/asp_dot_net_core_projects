using CQRS.Domain.Entities;
using CQRS.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Queries
{
    public class GetProductByIdQueryHandler
    {
        private readonly ProductRepository _repository;

        public GetProductByIdQueryHandler(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery query)
        {
            return await _repository.GetByIdAsync(query.Id);
        }
    }
}
