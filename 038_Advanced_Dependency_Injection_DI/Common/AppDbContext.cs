using Microsoft.EntityFrameworkCore;

namespace _038_Advanced_Dependency_Injection_DI.Common
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
