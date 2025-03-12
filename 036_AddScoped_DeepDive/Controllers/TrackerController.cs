using _036_AddScoped_DeepDive.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _036_AddScoped_DeepDive.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private readonly IRequestTracker _tracker;
        public TrackerController(IRequestTracker tracker)
        {
            _tracker = tracker;
        }
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine($"TrackerController: {_tracker.RequestId}");

            return Ok(new { ControllerRequestId  =  _tracker.RequestId });
        }
    }
}
