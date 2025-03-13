namespace _036_AddScoped_DeepDive.Services
{
    public class ExampleService2 : IDisposable
    {
        public Guid Id { get; } = Guid.NewGuid();

        public Guid GeneratedId { set; get; }
        public void Dispose()
        {
            GeneratedId = Id;
            Console.WriteLine($"Disposed {Id}");
        }
    }
}
