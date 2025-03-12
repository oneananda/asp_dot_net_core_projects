using _036_AddScoped_DeepDive.Interfaces;

namespace _036_AddScoped_DeepDive.Services
{
    public class ServiceB : IServiceB
    {
        private readonly IRequestTracker _requestTracker;
        public ServiceB(IRequestTracker requestTracker)
        {
            _requestTracker = requestTracker;
        }

        public string PrintRequestId()
        {
            return $"ServiceB: {_requestTracker.RequestId}";
        }
    }
}
