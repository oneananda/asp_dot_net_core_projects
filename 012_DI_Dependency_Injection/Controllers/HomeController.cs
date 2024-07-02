using _012_DI_Dependency_Injection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _012_DI_Dependency_Injection.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMyService _myService;
        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;
        private readonly ISingletonService _singletonService;

        public HomeController(IMyService myService, ITransientService transientService, IScopedService scopedService, ISingletonService singletonService)
        {
            _myService = myService;
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
        }

        /// <summary>
        /// Handles HTTP GET requests to the Index endpoint.
        /// </summary>
        /// <returns>An IActionResult containing an anonymous object with various service operation IDs.</returns>
        public IActionResult Index()
        {
            // Create a dynamic object to hold the response data.
            dynamic returnObj = new System.Dynamic.ExpandoObject();


            // Retrieve a message from the _myService.
            var message = _myService.GetMessage();

            returnObj.message = message;

            // Add the operation ID from the transient service to the dynamic object.
            returnObj.Transient = _transientService.GetOperationID();

            // Add the operation ID from the scoped service to the dynamic object.
            returnObj.Scoped = _scopedService.GetOperationID();

            // Add the operation ID from the singleton service to the dynamic object.
            returnObj.Singleton = _singletonService.GetOperationID();

            // Return an OK (200) response with the constructed object.
            return Ok(returnObj);
        }
    }
}
