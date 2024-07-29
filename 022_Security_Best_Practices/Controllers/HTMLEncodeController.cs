using Microsoft.AspNetCore.Mvc;

namespace _022_Security_Best_Practices.Controllers
{
    public class HTMLEncodeController : Controller
    {
        // Automatic Encoding:
        // Razor views automatically HTML-encode any data that is output.
        public IActionResult Index()
        {
            var input = "<script>alert('XSS');</script>"; // Example input that could come from a user
            ViewData["Input"] = input;
            return View();
        }
    }
}
