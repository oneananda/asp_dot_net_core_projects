using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CQRS.Application.Commands;
using CQRS.Application.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace CQRS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly CreateProductCommandHandler _createHandler;
        private readonly GetProductByIdQueryHandler _getHandler;
        private readonly GetAllProductsHandler _getAllHandler;
        private readonly UpdateProductCommandHandler _updateHandler;
        public ProductsController(CreateProductCommandHandler createHandler,
            GetProductByIdQueryHandler getHandler, 
            GetAllProductsHandler getAllHandler, 
            UpdateProductCommandHandler updateHandler)
        {
            _createHandler = createHandler;
            _getHandler = getHandler;
            _getAllHandler = getAllHandler;
            _updateHandler = updateHandler;
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
            var product = await _getAllHandler.Handle(query);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            try
            {
                await _updateHandler.Handle(command);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
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
