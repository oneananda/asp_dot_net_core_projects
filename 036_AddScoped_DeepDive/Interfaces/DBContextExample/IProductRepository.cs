﻿using _036_AddScoped_DeepDive.Models.DBContextExample;

namespace _036_AddScoped_DeepDive.Interfaces.DBContextExample
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<List<Product>> GetProductsAsync();
    }
}
