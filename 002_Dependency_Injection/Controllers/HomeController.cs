using _002_Dependency_Injection.Models;
using _002_Dependency_Injection.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _002_Dependency_Injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IGreetingService _greetingService;

        public HomeController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = _greetingService.Greet("World!");
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
