using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _015_Policy_based_Authorization.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IAuthorizationHandler _authorizationHandler;
        public PolicyController(IAuthorizationHandler authorizationHandler)
        {
            _authorizationHandler = authorizationHandler;
        }
        [Authorize(Policy = "AtLeast21")]
        public IActionResult RestrictedAction()
        {
            return Ok("You are at least 21 years old.");
        }
    }
}
