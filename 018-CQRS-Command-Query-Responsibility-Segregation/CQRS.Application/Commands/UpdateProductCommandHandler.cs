using CQRS.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Commands
{
    public class UpdateProductCommandHandler
    {
        private readonly ProductRepository _productRepository;

        public UpdateProductCommandHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateProductCommand updateProductCommand)
        {
            var product = await _productRepository.GetByIdAsync(updateProductCommand.Id);

            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            product.Name = updateProductCommand.Name;
            product.Price = updateProductCommand.Price;

            await _productRepository.UpdateProduct(product);
        }
    }
}
