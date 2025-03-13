namespace _036_AddScoped_DeepDive.Interfaces
{
    public interface ICartService
    {
        void AddItem(string item);
        IEnumerable<string> GetItems();
    }
}
