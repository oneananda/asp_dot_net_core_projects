namespace _042_AddSingleton_Deep_Dive.Services
{
    public class TimeService : ITimeService
    {
        private readonly DateTime _startTime;

        public TimeService()
        {
            _startTime = DateTime.Now;
        }

        public DateTime GetStartTime() => _startTime;
    }
}
