using _036_AddScoped_DeepDive.Models.DBContextExample;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _036_AddScoped_DeepDive.Services.DBContextExample
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
