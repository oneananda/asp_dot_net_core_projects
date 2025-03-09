using _034_AddTransient_DeepDive.DTOs;

namespace _034_AddTransient_DeepDive.Services.Interfaces
{
    // Business Layer
    public interface IUserService
    {
        Guid GetInstanceId();
        UserDto GetUserDetails(int userId);
    }
}
