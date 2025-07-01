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

            dynamic json = JsonConvert.DeserializeObject("{ \"Name\": \"John\", \"Age\": 30 }");
            Console.WriteLine(json.Name); // No model class required

            #endregion
        }
    }
}
