using _036_AddScoped_DeepDive.Interfaces;

namespace _036_AddScoped_DeepDive.Services
{
    public class ServiceA : IServiceA
    {
        private readonly IRequestTracker _requestTracker;
        public ServiceA(IRequestTracker requestTracker)
        {
            _requestTracker = requestTracker;
        }
        public string PrintRequestId()
        {
            return $"ServiceA: {_requestTracker.RequestId}";
        }
    }
}
