using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Models;

namespace _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);
    }
}
