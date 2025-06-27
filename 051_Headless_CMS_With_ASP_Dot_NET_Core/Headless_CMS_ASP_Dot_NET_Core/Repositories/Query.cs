using _051_Headless_CMS_With_ASP_Dot_NET_Core.Models;

namespace _051_Headless_CMS_With_ASP_Dot_NET_Core.Repositories
{
    public class Query
    {
        [UseDbContext(typeof(CMSDbContext))]
        public IQueryable<Content> GetContents([ScopedService] CMSDbContext db) => db.Contents;
    }
}
