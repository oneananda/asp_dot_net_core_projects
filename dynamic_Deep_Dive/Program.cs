namespace dynamic_Deep_Dive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Basic dynamic typing 

            dynamic name = "Alice";
            Console.WriteLine(name.Length); // Resolved at runtime

            // Compare var vs dynamic

            var x = "Hello";     // Type resolved at compile time
            dynamic y = "Hello"; // Type resolved at runtime

            // Dynamic with primitive operations
            
            dynamic a = 5;
            dynamic b = 10;
            Console.WriteLine(a + b); // Runtime resolution


            Console.WriteLine("Dyanamic Deep Dive!");
        }
    }
}
