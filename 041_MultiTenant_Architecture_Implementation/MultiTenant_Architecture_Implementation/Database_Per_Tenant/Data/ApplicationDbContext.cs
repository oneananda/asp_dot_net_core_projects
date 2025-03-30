using Database_Per_Tenant.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Database_Per_Tenant.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("TenantTemplate"));
        }


        public DbSet<Client> Client { get; set; }
    }
}
