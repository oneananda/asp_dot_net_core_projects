namespace _020_Caching_Strategies.Modal
{
    public interface IDataService
    {
        public LargeDataSet GetData();

        public LargeDataSet GetDataById(int id);
    }
}
