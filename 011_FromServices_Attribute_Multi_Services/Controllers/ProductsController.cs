using _011_FromServices_Attribute_Multi_Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _011_FromServices_Attribute_Multi_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("dataA")]
        public IActionResult GetDataA([FromServices] IServiceA serviceA)
        {
            var data = serviceA.GetDataA();
            return Ok(data);
        }

        [HttpGet("dataB")]
        public IActionResult GetDataB([FromServices] IServiceB serviceB)
        {
            var data = serviceB.GetDataB();
            return Ok(data);
        }
    }
}
