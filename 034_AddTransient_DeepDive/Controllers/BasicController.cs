using _034_AddTransient_DeepDive.Services;
using _034_AddTransient_DeepDive.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _034_AddTransient_DeepDive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        private readonly IBasicService _basicService;
        public BasicController(IBasicService basicService)
        {
            _basicService = basicService;
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var basicDetails = _basicService.GetBasicDetails(id);

            var dataFlowTrace = new
            {                
                // For Transient, this will be keep on changing
                ServiceInstanceId = _basicService.GetInstanceId()
            };

            return new JsonResult(new { Basic = basicDetails, InstanceTrace = dataFlowTrace });
        }
    }
}
