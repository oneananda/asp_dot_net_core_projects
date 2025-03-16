namespace _037_Abstract_Factory_Pattern_DeepDive.PaymentGateways
{
    public interface IPaymentGatewayFactory
    {
        IPaymentGateway CreatePaymentGateway(string provider);
    }
}
