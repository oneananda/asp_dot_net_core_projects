using _036_AddScoped_DeepDive.Models.DBContextExample;
using _036_AddScoped_DeepDive.Services.DBContextExample;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _036_AddScoped_DeepDive.Controllers.DBContextExample
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ProductRepository _productRepo;

        public ProductsController(
            AppDbContext context,
            ProductRepository productRepo)
        {
            _context = context;
            _productRepo = productRepo;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(string productName)
        {
            var product = new Product { Name = productName };
            _productRepo.Add(product);

            // Saving changes once
            await _context.SaveChangesAsync();

            return Ok(product);
        }
    }
}
