using _043_HTTP_ClientFactory_and_Resilient_Calls_With_Polly.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace _043_HTTP_ClientFactory_and_Resilient_Calls_With_Polly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly HttpClient _client;
        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("MyApiClient");
        }

        public async Task<User> GetDataAsync()
        {
            // These calls are automatically retried/circuit‑broken as configured
            var response = await _client.GetAsync("/data");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<User>();
        }
    }
}
