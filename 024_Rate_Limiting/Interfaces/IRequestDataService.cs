namespace _024_Rate_Limiting.Interfaces
{
    public interface IRequestDataService
    {
        int GetRequestCount(string key);
        void IncrementRequestCount(string key);
    }
}
