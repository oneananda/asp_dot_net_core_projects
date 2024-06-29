using _008_Options_Pattern_Complex_Type_Configuration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _008_Options_Pattern_Complex_Type_Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MyComplexAppSettings _complexAppSettings;
        private readonly MyAppSettings _myAppSettings;

        public HomeController(ILogger<HomeController> logger, MyAppSettings myAppSettings, MyComplexAppSettings myComplexAppSettings  )
        {
            _logger = logger;
            _myAppSettings = myAppSettings;
            _complexAppSettings = myComplexAppSettings;
        }

        public IActionResult Index()
        {
            ViewBag.ComplexAppSettings = _complexAppSettings;
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
