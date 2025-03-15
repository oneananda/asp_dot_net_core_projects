using _036_AddScoped_DeepDive.Models.DBContextExample;

namespace _036_AddScoped_DeepDive.Interfaces.DBContextExample
{
    public interface DBContextExample
    {
        Task AddProductAsync(Product product);
    }
}
