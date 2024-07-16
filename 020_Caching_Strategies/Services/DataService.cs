using System.Linq.Expressions;
using _020_Caching_Strategies.Modal;

namespace _020_Caching_Strategies.Services
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

        public LargeDataSet GetDataById(int id)
        {
            throw new NotImplementedException();
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
