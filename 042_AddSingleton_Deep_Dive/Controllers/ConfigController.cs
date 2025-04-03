using _042_AddSingleton_Deep_Dive.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _042_AddSingleton_Deep_Dive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly AppSettings _settings;

        public ConfigController(AppSettings settings)
        {
            _settings = settings;
        }

        [HttpGet("name")]
        public IActionResult GetAppName()
        {
            return Ok(new { AppName = _settings.AppName });
        }
    }
}
