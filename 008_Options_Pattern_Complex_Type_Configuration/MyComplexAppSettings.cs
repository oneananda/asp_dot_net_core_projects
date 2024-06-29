namespace _008_Options_Pattern_Complex_Type_Configuration
{
    public class MyComplexAppSettings
    {
        public int CustID { get; set; }

        public string? CustName { get; set;}

        public  List<Orders>? CustOrders { get; set; }
    }
}
