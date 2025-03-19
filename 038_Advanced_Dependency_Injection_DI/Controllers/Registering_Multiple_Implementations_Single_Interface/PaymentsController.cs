using _038_Advanced_Dependency_Injection_DI.Registering_Multiple_Implementations_Single_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _038_Advanced_Dependency_Injection_DI.Controllers.Registering_Multiple_Implementations_Single_Interface
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly PaypalGateway _paypalGateway;
        private readonly StripeGateway _stripeGateway;

        public PaymentsController(PaypalGateway paypalGateway, StripeGateway stripeGateway)
        {
            _paypalGateway = paypalGateway;
            _stripeGateway = stripeGateway;
        }

        [HttpPost("paypal")]
        public IActionResult PaypalPayment(decimal amount)
        {
            _paypalGateway.ProcessPayment(amount);
            return Ok();
        }

        [HttpPost("stripe")]
        public IActionResult StripePayment(decimal amount)
        {
            _stripeGateway.ProcessPayment(amount);
            return Ok();
        }
    }

}
