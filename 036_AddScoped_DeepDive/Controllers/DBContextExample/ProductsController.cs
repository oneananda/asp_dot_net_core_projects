using _036_AddScoped_DeepDive.Models.DBContextExample;
using _036_AddScoped_DeepDive.Services.DBContextExample;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _036_AddScoped_DeepDive.Controllers.DBContextExample
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(string productName)
        {
            var product = new Product { Name = productName };
            _productRepo.Add(product);

            // Saving changes once
            await _context.SaveChangesAsync();

            return Ok(new { AddedProduct = product, AllProducts = _productRepo.GetProductsAsync() });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepo.GetProductsAsync();
            return Ok(products);
        }
    }
}
