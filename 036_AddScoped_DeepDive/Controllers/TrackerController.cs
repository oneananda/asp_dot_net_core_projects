using _036_AddScoped_DeepDive.Interfaces;
using _036_AddScoped_DeepDive.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _036_AddScoped_DeepDive.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private readonly IRequestTracker _tracker;
        private readonly IServiceA _serviceA;
        private readonly IServiceB _serviceB;
        public TrackerController(IRequestTracker tracker, IServiceA serviceA, IServiceB serviceB)
        {
            _tracker = tracker;
            _serviceA = serviceA;
            _serviceB = serviceB;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { 
                ControllerRequestId  =  _tracker.RequestId, 
                ServiceA = _serviceA.PrintRequestId(),
                ServiceB = _serviceB.PrintRequestId()
            });
        }
    }
}
