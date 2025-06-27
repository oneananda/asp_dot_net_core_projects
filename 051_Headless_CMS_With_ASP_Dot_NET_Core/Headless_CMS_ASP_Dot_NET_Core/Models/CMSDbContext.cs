using Microsoft.EntityFrameworkCore;

namespace _051_Headless_CMS_With_ASP_Dot_NET_Core.Models
{
    public class CMSDbContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }
        public DbSet<Media> Media { get; set; }

        public CMSDbContext(DbContextOptions<CMSDbContext> options) : base(options) { }
    }

}
