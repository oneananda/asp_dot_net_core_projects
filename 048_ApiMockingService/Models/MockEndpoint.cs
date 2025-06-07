namespace _048_ApiMockingService.Models
{
    public class MockEndpoint
    {
        public int Id { get; set; }
        public string Method { get; set; } = "GET"; // GET, POST, PUT, DELETE
        public string Path { get; set; } = ""; // e.g., /api/test
        public int StatusCode { get; set; } = 200;
        public string ResponseBody { get; set; } = "{}";
        public string? ContentType { get; set; } = "application/json";
        public int DelayMs { get; set; } = 0; // optional artificial delay
    }

}
