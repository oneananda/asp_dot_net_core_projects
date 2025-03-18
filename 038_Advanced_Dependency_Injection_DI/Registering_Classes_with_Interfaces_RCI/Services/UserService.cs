using _038_Advanced_Dependency_Injection_DI.Common;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Interfaces;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Models;
using System;

namespace _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Services
{
    public class UserService : IUserService
    {
        private readonly RCIAppDbContext _context;

        public UserService(RCIAppDbContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }
    }
}
