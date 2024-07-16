using _020_Caching_Strategies.Modal;

namespace _020_Caching_Strategies.Services
{
    public interface IDataService
    {
        public LargeDataSet GetData();

        public LargeDataSet GetDataById(int id);
    }
}
