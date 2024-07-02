using _012_DI_Dependency_Injection.Interfaces;

namespace _012_DI_Dependency_Injection.App_Code
{
    public class ScopedService : IScopedService
    {
        private readonly string _operationId;

        public ScopedService()
        {
            _operationId = Guid.NewGuid().ToString();
        }

        public string GetOperationID()
        {
            return _operationId;
        }
    }
}
