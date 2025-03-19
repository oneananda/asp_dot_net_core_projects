namespace _038_Advanced_Dependency_Injection_DI.Registering_Classes_with_Factory
{
    public class ReportService
    {
        private readonly string _reportType;

        public ReportService(string reportType)
        {
            _reportType = reportType;
        }

        public void Generate()
        {
            // Generate report based on type
        }
    }

}
