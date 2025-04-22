using _045_Entity_Framework_Core_Performance_Profiling.Models;
using Microsoft.EntityFrameworkCore;

namespace _045_Entity_Framework_Core_Performance_Profiling.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        { }

        public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    }
}
