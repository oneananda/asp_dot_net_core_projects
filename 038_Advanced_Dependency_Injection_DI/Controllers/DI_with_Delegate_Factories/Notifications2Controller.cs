using _038_Advanced_Dependency_Injection_DI.DI_with_Delegate_Factories;
using _038_Advanced_Dependency_Injection_DI.Registering_Classes_Without_Interfaces_RCWI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _038_Advanced_Dependency_Injection_DI.Controllers.DI_with_Delegate_Factories
{
    [Route("api/[controller]")]
    [ApiController]
    public class Notifications2Controller : ControllerBase
    {
        private readonly Func<string, EmailSender2> _emailSenderFactory;

        public Notifications2Controller(Func<string, EmailSender2> emailSenderFactory)
        {
            _emailSenderFactory = emailSenderFactory;
        }

        [HttpPost]
        public IActionResult Notify(string email)
        {
            var emailSender = _emailSenderFactory("smtp.example.com");
            emailSender.Send(email, "Hello!");
            return Ok();
        }
    }
}
