using _036_AddScoped_DeepDive.Interfaces;

namespace _036_AddScoped_DeepDive.Services
{
    public class RequestTracker : IRequestTracker
    {
        Guid IRequestTracker.RequestId => Guid.NewGuid();
    }
}
