using _036_AddScoped_DeepDive.Interfaces;

namespace _036_AddScoped_DeepDive.Services
{
    public class CartServiceSubB : ICartServiceSubB
    {
        private readonly ICartService _cartService;
        public CartServiceSubB(ICartService cartService)
        {
            _cartService = cartService;
        }

        public void AddToCart(string item)
        {
            _cartService.AddItem($"CartServiceSubB Added: {item} Guid: {_cartService.Guid}");
        }
    }
}
