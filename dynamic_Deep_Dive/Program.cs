namespace dynamic_Deep_Dive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Basic dynamic typing 

            dynamic name = "Alice";
            Console.WriteLine(name.Length); // Resolved at runtime

            Console.WriteLine("Dyanamic Deep Dive!");
        }
    }
}
