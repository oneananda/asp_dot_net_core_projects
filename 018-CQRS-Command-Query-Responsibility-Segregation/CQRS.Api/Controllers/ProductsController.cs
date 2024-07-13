using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CQRS.Application.Commands;
using CQRS.Application.Queries;

namespace CQRS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly CreateProductCommandHandler _createHandler;
        private readonly GetProductByIdQueryHandler _getHandler;

        public ProductsController(CreateProductCommandHandler createHandler, GetProductByIdQueryHandler getHandler)
        {
            _createHandler = createHandler;
            _getHandler = getHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _createHandler.Handle(command);
            return Ok();
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
