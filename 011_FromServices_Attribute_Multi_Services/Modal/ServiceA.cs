using _011_FromServices_Attribute_Multi_Services.Interfaces;

namespace _011_FromServices_Attribute_Multi_Services.Modal
{
    public class ServiceA : IServiceA
    {
        public string GetDataA()
        {
            return "Data from Service A";
        }
    }
}
