using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace auth_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        // Define your allowed strings here
        private static readonly HashSet<string> AllowedStrings = new()
        {
            "Alpha",
            "Beta",
            "Gamma",
            "Delta"
        };

        [HttpPost("string")]
        public IActionResult ValidateString([FromBody] string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return BadRequest("Input string cannot be empty.");

            if (!AllowedStrings.Contains(value))
                return BadRequest(new { message = "Validation failed. String is not allowed." });

            return Ok(new { message = "String is valid." });
        }
    }
}