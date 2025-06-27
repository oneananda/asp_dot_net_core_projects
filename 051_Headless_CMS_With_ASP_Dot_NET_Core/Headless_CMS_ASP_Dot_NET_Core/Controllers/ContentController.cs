using _051_Headless_CMS_With_ASP_Dot_NET_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _051_Headless_CMS_With_ASP_Dot_NET_Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly CMSDbContext _db;

        public ContentController(CMSDbContext db) => _db = db;

        [HttpGet("{type}")]
        public async Task<IActionResult> GetAll(string type) =>
            Ok(await _db.Contents.Where(c => c.ContentType == type).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Content content)
        {
            _db.Contents.Add(content);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { type = content.ContentType }, content);
        }
    }
}
