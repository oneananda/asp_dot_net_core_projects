using _036_AddScoped_DeepDive.Interfaces;

namespace _036_AddScoped_DeepDive.Services
{
    public class CartServiceSubA : ICartServiceSubA
    {
        private readonly ICartService _cartService;

        public CartServiceSubA(ICartService cartService)
        {
            _cartService = cartService;
        }
        public void AddToCart(string item)
        {
            _cartService.AddItem($"CartServiceSubA added: {item}");
        }
    }
}
