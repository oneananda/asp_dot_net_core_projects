using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_Deep_Dive._02_Intermediate
{
    internal class Medium
    {
        public static void Run()
        {
            #region Medium examples

            // Access JSON properties without model (using Newtonsoft.Json)
            
            dynamic json = JsonConvert.DeserializeObject("{ \"Name\": \"John\", \"Age\": 30 }");
            Console.WriteLine(json.Name); // No model class required


            // Reflection with dynamic fallback

            object person = new { Name = "Jane", Age = 25 };
            dynamic dynPerson = person;
            Console.WriteLine(dynPerson.Name); // Works with anonymous types

            #endregion
        }
    }
}
