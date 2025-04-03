namespace _042_AddSingleton_Deep_Dive.Services
{
    public class GuidService : IGuidService
    {
        private readonly Guid _guid;

        public GuidService(Guid guid)
        {
            _guid = guid;
        }

        public Guid GetGuid() => _guid;
    }
}
