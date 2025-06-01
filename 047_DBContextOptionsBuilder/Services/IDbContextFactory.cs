namespace _047_DBContextOptionsBuilder.Services
{
    public interface IDbContextFactory
    {
        MyDbContext Create(string connectionString);
    }
}
