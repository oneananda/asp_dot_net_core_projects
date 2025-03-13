using _036_AddScoped_DeepDive.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _036_AddScoped_DeepDive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Example2Controller : ControllerBase
    {
        private readonly ExampleService2 _service1;
        private readonly ExampleService2 _service2;

        public Example2Controller(ExampleService2 service1, ExampleService2 service2)
        {
            _service1 = service1;
            _service2 = service2;
        }

        [HttpGet("scoped-demo")]
        public IActionResult Get()
        {
            Console.WriteLine($"Scoped Service ID1: {_service1.Id}");
            Console.WriteLine($"Scoped Service ID2: {_service2.Id}");

            return Ok(new { Service1Id = _service1.Id, Service12d = _service2.Id });
        }
    }
}
