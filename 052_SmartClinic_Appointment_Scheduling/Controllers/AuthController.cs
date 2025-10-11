using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartClinic.DTOs;
using SmartClinic.Services;

namespace SmartClinic.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public ActionResult<AuthResponse> Login([FromBody] LoginRequest request)
    {
        var result = _authService.Authenticate(request);
        if (!result.Success)
        {
            return Unauthorized(result.ErrorMessage);
        }

        return Ok(result.Value);
    }
}
