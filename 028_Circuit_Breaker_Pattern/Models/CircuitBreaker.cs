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

        private State _state = State.Closed;
        private int _failureCount = 0;
        private readonly int _failureTheshold;
        private readonly TimeSpan _openTimeOut;
        private DateTime _lastFailureTime;

        private CircuitBreaker(int failureThreshold, TimeSpan openTimeOut)
        {
            _failureTheshold = failureThreshold;
            _openTimeOut = openTimeOut;
        }
    }
}
