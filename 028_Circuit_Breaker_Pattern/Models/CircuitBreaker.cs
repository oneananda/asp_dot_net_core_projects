namespace _028_Circuit_Breaker_Pattern.Models
{
    public class CircuitBreaker
    {
        private enum State
        {
            Closed,
            Open,
            HalfOpen
        }
    }
}
