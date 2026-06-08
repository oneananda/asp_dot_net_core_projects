using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserMgmt.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = new[]
        {
            new { Id = 1, Name = "John Doe",    Email = "john@example.com" },
            new { Id = 2, Name = "Jane Smith",  Email = "jane@example.com" }
        };

        return Ok(users);
    }
}
