using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _047_DBContextOptionsBuilder.Services
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MyDb;Trusted_Connection=True;");
        }

        public DbSet<Product> Products { get; set; }
    }
}
