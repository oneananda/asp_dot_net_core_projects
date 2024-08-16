using _024_Rate_Limiting.Interfaces;
using System.Collections.Concurrent;

namespace _024_Rate_Limiting.Services
{
    public class RequestDataService : IRequestDataService
    {
        private readonly ConcurrentDictionary<string,int> _requestCounts = new();
        public RequestDataService() { }
        public int GetRequestCount(string key)
        {
           _requestCounts.TryGetValue(key, out var count);
            return count;
        }

        public void IncrementRequestCount(string key)
        {
            _requestCounts.AddOrUpdate(key, 1, (k, v) => v + 1);
        }
    }
}
