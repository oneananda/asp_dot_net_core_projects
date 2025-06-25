using _051_Headless_CMS_With_ASP_Dot_NET_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _051_Headless_CMS_With_ASP_Dot_NET_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly CMSDbContext _db;
        public MediaController(CMSDbContext db)
        {
            _db = db;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var path = Path.Combine("wwwroot/media", file.FileName);
            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            var media = new Media { FileName = file.FileName, Url = $"/media/{file.FileName}", ContentType = file.ContentType };
            _db.Media.Add(media);
            await _db.SaveChangesAsync();
            return Ok(media);
        }

    }
}
