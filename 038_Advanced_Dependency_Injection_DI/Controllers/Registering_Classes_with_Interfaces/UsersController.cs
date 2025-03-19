using _038_Advanced_Dependency_Injection_DI.Common;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Interfaces;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace _038_Advanced_Dependency_Injection_DI.Controllers.Registering_Classes_with_Interfaces
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RCIAppDbContext _context;
        private readonly IUserService _userService;

        public UsersController(RCIAppDbContext rCIAppDbContext, IUserService userService)
        {
            _userService = userService;
            _context = rCIAppDbContext;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _userService.CreateUser(user);
            _context.SaveChangesAsync();
            return Ok(new { AddedUser = user, AllUsers = _userService.GetUsersAsync() });
        }
    }
}
