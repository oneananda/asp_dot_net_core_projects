using _034_AddTransient_DeepDive.Repositories.Interfaces;
using _034_AddTransient_DeepDive.Services;
using _034_AddTransient_DeepDive.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _034_AddTransient_DeepDive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public IUserRepository _userRepository { get; }  // Change to public getter

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }
        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var userDetails = _userService.GetUserDetails(id);

            var dataFlowTrace = new
            {
                ControllerRepositoryId = _userRepository.GetInstanceId(),
                ServiceInstanceId = _userService.GetInstanceId(),
                RepositoryInstanceInServiceId = (_userService as UserService)?._userRepository.GetInstanceId() ?? Guid.Empty
            };

            return new JsonResult(new { User = userDetails, InstanceTrace = dataFlowTrace });
        }
    }
}
