using _034_AddTransient_DeepDive.Models;

namespace _034_AddTransient_DeepDive.Services.Interfaces
{
    public interface IBasicService
    {
        Guid GetInstanceId();

        Basic GetBasicDetails(int Id);
    }
}
