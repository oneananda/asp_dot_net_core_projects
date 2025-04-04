using _042_AddSingleton_Deep_Dive.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _042_AddSingleton_Deep_Dive.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuidController : ControllerBase
    {
        private readonly IGuidService _guidService;

        public GuidController(IGuidService guidService)
        {
            _guidService = guidService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Guid = _guidService.GetGuid() });
        }
    }
}
