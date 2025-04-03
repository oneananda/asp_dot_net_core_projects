using _042_AddSingleton_Deep_Dive.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _042_AddSingleton_Deep_Dive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public TimeController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet("start")]
        public IActionResult GetStartTime()
        {
            return Ok(new { StartTime = _timeService.GetStartTime() });
        }
    }
}
