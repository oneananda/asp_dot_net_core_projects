using System.Dynamic;

namespace dynamic_Deep_Dive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Basic exampls
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

            // Runtime method call on dynamic object

            dynamic obj = new ExpandoObject();
            obj.SayHello = new Action(() => Console.WriteLine("Hello from dynamic!"));
            obj.SayHello();

            #endregion


            Console.WriteLine("Dyanamic Deep Dive!");
        }
    }
}
