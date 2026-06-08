using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.BFF.Controllers;

/// <summary>
/// Fetches swagger.json from each internal service and re-serves it through the BFF port.
/// Protected by [Authorize] — callers must supply a valid JWT to retrieve the spec.
/// The BFF Swagger UI forwards the stored token automatically via its requestInterceptor.
/// </summary>
[ApiController]
[Authorize]
public class SwaggerProxyController : ControllerBase
{
    private readonly IHttpClientFactory _http;
    private readonly IConfiguration _config;

    public SwaggerProxyController(IHttpClientFactory http, IConfiguration config)
    {
        _http = http;
        _config = config;
    }

    [HttpGet("user-mgmt/swagger/v1/swagger.json")]
    public Task<IActionResult> UserMgmtSwagger()
    {
        var address = _config["ReverseProxy:Clusters:userMgmtCluster:Destinations:destination1:Address"]
                      ?? "http://localhost:8081";

        return FetchSwaggerJson(address, "UserMgmt.Api");
    }

    [HttpGet("prod-mgmt/swagger/v1/swagger.json")]
    public Task<IActionResult> ProdMgmtSwagger()
    {
        var address = _config["ReverseProxy:Clusters:prodMgmtCluster:Destinations:destination1:Address"]
                      ?? "http://localhost:8082";

        return FetchSwaggerJson(address, "ProdMgmt.Api");
    }

    private async Task<IActionResult> FetchSwaggerJson(string baseAddress, string serviceName)
    {
        try
        {
            var client = _http.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(5);

            var json = await client.GetStringAsync($"{baseAddress}/swagger/v1/swagger.json");
            return Content(json, "application/json");
        }
        catch (Exception ex)
        {
            return Problem(
                detail: $"Could not reach {serviceName} at {baseAddress}. " +
                        $"Make sure it is running. ({ex.Message})",
                title: $"{serviceName} Swagger unavailable",
                statusCode: StatusCodes.Status503ServiceUnavailable
            );
        }
    }
}
