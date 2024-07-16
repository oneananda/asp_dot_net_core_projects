namespace _020_Caching_Strategies.Modal
{
    public class LargeDataSet
    {
        public LargeDataSet() { }

        public int DataId { get; set; }
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
        public List<string> Guids { get; set; }
    }
}
