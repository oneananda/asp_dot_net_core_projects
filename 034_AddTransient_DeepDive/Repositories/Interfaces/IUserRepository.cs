using _034_AddTransient_DeepDive.Models;

namespace _034_AddTransient_DeepDive.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Guid GetInstanceId();
        User GetUserById(int userId);

    }
}
