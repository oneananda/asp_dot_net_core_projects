using _012_DI_Dependency_Injection.Interfaces;

namespace _012_DI_Dependency_Injection.App_Code
{
    public class MyService : IMyService
    {
        public string GetMessage()
        {
            return "Hello from MyService!";
        }
    }
}
