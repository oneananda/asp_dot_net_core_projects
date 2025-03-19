using _038_Advanced_Dependency_Injection_DI.Common;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Interfaces;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Models;
using Microsoft.EntityFrameworkCore;
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
        public Task CreateUser(User user)
        {
            _context.Users.Add(user);
            return Task.CompletedTask;
        }

        public async Task<List<User>> GetUsersAsync()
        {            
            return await _context.Users.ToListAsync();
        }
    }
}
