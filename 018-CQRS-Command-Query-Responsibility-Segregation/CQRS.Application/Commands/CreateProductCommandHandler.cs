using CQRS.Domain.Entities;
using CQRS.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace CQRS.Application.Commands
{
    public class CreateProductCommandHandler
    {
        private readonly ProductRepository _repository;

        public CreateProductCommandHandler(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProductCommand command)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Price = command.Price
            };

            await _repository.AddAsync(product);
        }
    }
}
