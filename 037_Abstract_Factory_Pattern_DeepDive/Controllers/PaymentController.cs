using _037_Abstract_Factory_Pattern_DeepDive.PaymentGateways;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _037_Abstract_Factory_Pattern_DeepDive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentGatewayFactory _paymentGatewayFactory;
        public PaymentController(IPaymentGatewayFactory paymentGatewayFactory)
        {
            _paymentGatewayFactory = paymentGatewayFactory;
        }
        [HttpPost("{provider}")]
        public async Task<IActionResult> ProcessPayment(string provider, [FromQuery] decimal amount)
        {
            try
            {
                var gateway = _paymentGatewayFactory.CreatePaymentGateway(provider);
                var result = await gateway.ProcessPayment(amount);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
