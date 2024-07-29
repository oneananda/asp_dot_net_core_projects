using _022_Security_Best_Practices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _022_Security_Best_Practices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // Automatic Encoding:
        // Razor views automatically HTML-encode any data that is output.
        public IActionResult Index()
        {
            var input = "<script>alert('XSS');</script>"; // Example input that could come from a user
            ViewData["Input"] = input;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
