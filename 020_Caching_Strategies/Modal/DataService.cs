using System.Linq.Expressions;

namespace _020_Caching_Strategies.Modal
{
    public class DataService : IDataService
    {
        public LargeDataSet GetData()
        {
            // Simulate data fetching from a database or an external API

            LargeDataSet largeDataSet = new LargeDataSet();
            largeDataSet.DataId = 1;
            largeDataSet.Name = "Name";
            largeDataSet.Guids = GetLargeGuids();
            largeDataSet.DateCreated = DateTime.Now;
            return largeDataSet;

            //return "This is some data fetched from the database.";
        }

        private List<string> GetLargeGuids()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(i.ToString() + "_" + Guid.NewGuid().ToString("N"));
            }
            return list;
        }
    }
}
