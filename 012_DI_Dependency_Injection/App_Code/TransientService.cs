using _012_DI_Dependency_Injection.Interfaces;

namespace _012_DI_Dependency_Injection.App_Code
{
    public class TransientService : ITransientService
    {
        public string GetOperationID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
