using _036_AddScoped_DeepDive.Interfaces.DBContextExample;
using _036_AddScoped_DeepDive.Models.DBContextExample;
using Microsoft.EntityFrameworkCore;

namespace _036_AddScoped_DeepDive.Services.DBContextExample
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);

            return Task.CompletedTask;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
