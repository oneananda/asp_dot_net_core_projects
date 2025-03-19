namespace _038_Advanced_Dependency_Injection_DI.Registering_Multiple_Implementations_Single_Interface
{
    public class StripeGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount) { /* Stripe logic */ }
    }
}
