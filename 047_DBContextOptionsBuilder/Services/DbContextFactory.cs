using Microsoft.EntityFrameworkCore;

namespace _047_DBContextOptionsBuilder.Services
{
    public class DbContextFactory : IDbContextFactory
    {
        public MyDbContext Create(string connectionString)
        {
            var opts = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer(connectionString)
                .Options;
            return new MyDbContext(opts);
        }
    }
}
