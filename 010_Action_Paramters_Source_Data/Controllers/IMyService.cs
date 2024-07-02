namespace _010_Action_Paramters_Source_Data.Controllers
{
    public interface IMyService
    {
        string GetData();
    }

    public class MyService : IMyService
    {
        public string GetData()
        {
            return "Data from MyService";
        }
    }

    public class MyService2 : IMyService
    {
        public string GetData()
        {
            return "Data from MyService";
        }
    }
}