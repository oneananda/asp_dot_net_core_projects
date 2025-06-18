using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace auth_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        [HttpPost("strings")]
        public IActionResult ValidateStrings([FromBody] List<string> values)
        {
            if (values == null || !values.Any())
                return BadRequest("Input list cannot be empty.");

            // Example: Validate that each string is not null/empty and matches a pattern (alphanumeric, min 3 chars)
            var invalidItems = values
                .Select((value, index) => new { value, index })
                .Where(x => string.IsNullOrWhiteSpace(x.value) || !Regex.IsMatch(x.value, @"^[a-zA-Z0-9]{3,}$"))
                .Select(x => x.index)
                .ToList();

            if (invalidItems.Any())
                return BadRequest(new { message = "Validation failed.", invalidIndexes = invalidItems });

            return Ok(new { message = "All strings are valid." });
        }
    }
}