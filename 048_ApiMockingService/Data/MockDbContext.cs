using Microsoft.EntityFrameworkCore;
using _048_ApiMockingService.Models;

namespace _048_ApiMockingService.Data
{
    public class MockDbContext : DbContext
    {
        public MockDbContext(DbContextOptions<MockDbContext> options) : base(options)
        {
        }

        public DbSet<MockEndpoint> Mocks { get; set; }
    }
}