using _034_AddTransient_DeepDive.Models;
using _034_AddTransient_DeepDive.Repositories.Interfaces;

namespace _034_AddTransient_DeepDive.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Guid _instanceId;

        public UserRepository()
        {
            _instanceId = Guid.NewGuid();
        }

        public Guid GetInstanceId() => _instanceId;

        public User GetUserById(int userId)
        {
            // Mocked user data retrieval logic
            return new User { Id = userId, Name = "John Doe" };
        }
    }
}
