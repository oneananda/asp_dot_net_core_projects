namespace _051_Headless_CMS_With_ASP_Dot_NET_Core.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string ContentType { get; set; } // e.g., "blog", "page"
        public string Title { get; set; }
        public string Slug { get; set; }
        public string BodyJson { get; set; } // flexible content structure
        public bool IsPublished { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
