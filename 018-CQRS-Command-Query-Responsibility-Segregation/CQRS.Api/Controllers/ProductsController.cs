using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CQRS.Application.Commands;
using CQRS.Application.Queries;
using CQRS.Application.Queries.Products.GetAll;


namespace CQRS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly CreateProductCommandHandler _createHandler;
        private readonly GetProductByIdQueryHandler _getHandler;
        private readonly GetAllProductsHandler _getAllProductsHandler;

        public ProductsController(CreateProductCommandHandler createHandler, 
            GetProductByIdQueryHandler getHandler, GetAllProductsHandler getAllProductsHandler)
        {
            _createHandler = createHandler;
            _getHandler = getHandler;
            _getAllProductsHandler = getAllProductsHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _createHandler.Handle(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProducts();
            var product = await _getAllProductsHandler.Handle(query);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery { Id = id };
            var product = await _getHandler.Handle(query);
            return Ok(product);
        }
    }
}
