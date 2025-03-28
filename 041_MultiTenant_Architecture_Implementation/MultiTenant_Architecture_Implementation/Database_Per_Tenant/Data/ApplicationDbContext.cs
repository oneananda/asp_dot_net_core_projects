using Database_Per_Tenant.Models;
using Microsoft.EntityFrameworkCore;

namespace Database_Per_Tenant.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<User> Products { get; set; }
    }
}
