using _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _038_Advanced_Dependency_Injection_DI.Controllers.Registering_Classes_with_Interfaces
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create(string userName)
        {
            _userService.CreateUser(userName);
            return Ok();
        }
    }
}
