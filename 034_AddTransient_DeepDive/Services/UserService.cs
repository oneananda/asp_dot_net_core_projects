using _034_AddTransient_DeepDive.DTOs;
using _034_AddTransient_DeepDive.Models;
using _034_AddTransient_DeepDive.Repositories.Interfaces;
using _034_AddTransient_DeepDive.Services.Interfaces;

namespace _034_AddTransient_DeepDive.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        private readonly Guid _instanceId;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _instanceId = Guid.NewGuid();
        }

        public Guid GetInstanceId() => _instanceId;

        public UserDto GetUserDetails(int userId)
        {
            var user = new User() { Id = userId, Name = Guid.NewGuid().ToString() };// _userRepository.GetUserById(userId);
            return new UserDto { Id = user.Id, FullName = user.Name };
        }
    }
}
