namespace _037_Abstract_Factory_Pattern_DeepDive.PaymentGateways
{
    // PaymentGatewayFactory.cs
    public class PaymentGatewayFactory : IPaymentGatewayFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentGatewayFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPaymentGateway CreatePaymentGateway(string provider)
        {
            return provider.ToLower() switch
            {
                "paypal" => _serviceProvider.GetService<PayPalGateway>(),
                "stripe" => _serviceProvider.GetService<StripeGateway>(),
                _ => throw new ArgumentException($"Unsupported provider: {provider}")
            };
        }
    }

}
