
namespace _037_Abstract_Factory_Pattern_DeepDive.PaymentGateways
{
    public class PayPalGateway : IPaymentGateway
    {
        public async Task<string> ProcessPayment(decimal amount)
        {
            // Implement PayPal API logic
            await Task.Delay(100); // Simulate API call
            return $"Processed {amount} USD via PayPal.";
        }
    }
}
