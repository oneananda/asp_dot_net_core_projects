using _011_FromServices_Attribute_Multi_Services.Interfaces;

namespace _011_FromServices_Attribute_Multi_Services.Modal
{
    public class ServiceB : IServiceB
    {
        public string GetDataB()
        {
            return "Data from Service B";
        }
    }
}
