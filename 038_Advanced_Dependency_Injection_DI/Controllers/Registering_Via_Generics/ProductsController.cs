using _038_Advanced_Dependency_Injection_DI.Registering_Via_Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _038_Advanced_Dependency_Injection_DI.Controllers.Registering_Via_Generics
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _productRepo;

        public ProductsController(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productRepo.Add(product);
            return Ok();
        }
    }
}
