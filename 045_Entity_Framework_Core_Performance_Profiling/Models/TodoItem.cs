namespace _045_Entity_Framework_Core_Performance_Profiling.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public bool IsDone { get; set; }
    }
}
