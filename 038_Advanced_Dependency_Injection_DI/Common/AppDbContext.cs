using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Models;
using Microsoft.EntityFrameworkCore;

namespace _038_Advanced_Dependency_Injection_DI.Common
{
    public class RCIAppDbContext : DbContext
    {
        public DbSet<User> Products { get; set; }
        public RCIAppDbContext(DbContextOptions<RCIAppDbContext> options) : base(options)
        {
        }
    }
}
