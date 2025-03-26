// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using EF_Implementation.Models;

namespace EF_Implementation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
