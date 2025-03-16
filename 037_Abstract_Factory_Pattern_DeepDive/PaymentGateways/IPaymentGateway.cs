namespace _037_Abstract_Factory_Pattern_DeepDive.PaymentGateways
{
    public interface IPaymentGateway
    {
        Task<string> ProcessPayment(decimal amount);
    }
}
