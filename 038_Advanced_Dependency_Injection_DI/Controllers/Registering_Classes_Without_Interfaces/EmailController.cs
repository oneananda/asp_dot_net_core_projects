using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _038_Advanced_Dependency_Injection_DI.Controllers.Registering_Classes_Without_Interfaces
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailSender _emailSender;

        public EmailController(EmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public IActionResult Send(string email, string message)
        {
            _emailSender.SendEmail(email, message);
            return Ok();
        }
    }

}
