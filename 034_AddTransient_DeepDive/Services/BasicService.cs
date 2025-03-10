using _034_AddTransient_DeepDive.DTOs;
using _034_AddTransient_DeepDive.Models;
using _034_AddTransient_DeepDive.Services.Interfaces;

namespace _034_AddTransient_DeepDive.Services
{
    public class BasicService : IBasicService
    {
        private readonly Guid _instanceId;

        public BasicService()
        {
            _instanceId = Guid.NewGuid();
        }
        public Basic GetBasicDetails(int Id)
        {
            return new Basic { Id = Id, Name = Guid.NewGuid().ToString() };
        }

        public Guid GetInstanceId()
        {
            return _instanceId;
        }
    }
}
