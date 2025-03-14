using _036_AddScoped_DeepDive.Interfaces;

namespace _036_AddScoped_DeepDive.Services
{
    public class CartService : ICartService
    {
        private readonly List<string> _items = new List<string>();

        public void AddItem(string item)
        {
            _items.Add(item );
        }

        public Guid Guid { get; } = Guid.NewGuid();

        public IEnumerable<string> GetItems() => _items;
    }
}
