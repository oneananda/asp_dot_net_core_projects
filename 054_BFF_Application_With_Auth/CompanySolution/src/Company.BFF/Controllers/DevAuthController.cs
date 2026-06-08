using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Company.BFF.Controllers;

public record DevTokenRequest(string Username, string Password);

/// <summary>
/// Development-only endpoint for generating test JWT tokens.
/// Returns 404 in non-Development environments.
/// Credentials are read from DevAuth config (appsettings.Development.json).
/// </summary>
[ApiController]
[Route("dev")]
public class DevAuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly IWebHostEnvironment _env;

    public DevAuthController(IConfiguration config, IWebHostEnvironment env)
    {
        _config = config;
        _env = env;
    }

    /// <summary>
    /// POST { "username": "...", "password": "..." }
    /// Returns a JWT bearer token valid for 8 hours. Development only.
    /// Paste the "swaggerUsage" value into Swagger's Authorize dialog.
    /// </summary>
    [HttpPost("token")]
    public IActionResult GetDevToken([FromBody] DevTokenRequest request)
    {
        if (!_env.IsDevelopment())
            return NotFound();

        var expectedUsername = _config["DevAuth:Username"];
        var expectedPassword = _config["DevAuth:Password"];

        if (request.Username != expectedUsername || request.Password != expectedPassword)
            return Unauthorized(new { message = "Invalid credentials." });

        var key      = _config["Jwt:Key"]!;
        var issuer   = _config["Jwt:Issuer"]!;
        var audience = _config["Jwt:Audience"]!;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("sub",  "dev-user-001"),
            new Claim("name", request.Username),
            new Claim("role", "Developer"),
        };

        var token = new JwtSecurityToken(
            issuer:             issuer,
            audience:           audience,
            claims:             claims,
            expires:            DateTime.UtcNow.AddHours(8),
            signingCredentials: signingCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new
        {
            token         = tokenString,
            expiresInHours = 8,
            swaggerUsage  = $"Bearer {tokenString}"
        });
    }
}
