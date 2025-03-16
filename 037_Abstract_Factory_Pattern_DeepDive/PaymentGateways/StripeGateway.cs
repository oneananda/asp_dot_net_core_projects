namespace _037_Abstract_Factory_Pattern_DeepDive.PaymentGateways
{
    public class StripeGateway : IPaymentGateway
    {
        public async Task<string> ProcessPayment(decimal amount)
        {
            // Implement Stripe API logic
            await Task.Delay(100); // Simulate API call
            return $"Processed {amount} USD via Stripe.";
        }
    }
}
