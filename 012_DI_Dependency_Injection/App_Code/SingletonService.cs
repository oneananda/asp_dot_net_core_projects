using _012_DI_Dependency_Injection.Interfaces;

namespace _012_DI_Dependency_Injection.App_Code
{
    public class SingletonService : ISingletonService
    {
        private readonly string _operationId;

        public SingletonService()
        {
            _operationId = Guid.NewGuid().ToString();
        }

        public string GetOperationID()
        {
            return _operationId;
        }
    }
}
