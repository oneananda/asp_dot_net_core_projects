using _036_AddScoped_DeepDive.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _036_AddScoped_DeepDive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICartServiceSubA _cartServiceSubA;
        private readonly ICartServiceSubB _cartServiceSubB;

        public CartController(ICartService cartService, ICartServiceSubA cartServiceSubA, ICartServiceSubB cartServiceSubB)
        {
            _cartService = cartService;
            _cartServiceSubA = cartServiceSubA;
            _cartServiceSubB = cartServiceSubB;
        }
        [HttpGet("add-items")]
        public IActionResult AddItems()
        {
            _cartService.AddItem("Item from Controller"+ " Generated Guid " + _cartService.Guid);
            _cartServiceSubA.AddToCart("Item from CartServiceSubA");
            _cartServiceSubB.AddToCart("Item from CartServiceSubB");

            var itemsInCart = _cartService.GetItems();

            return Ok(new { Items = itemsInCart });
        }
    }
}
