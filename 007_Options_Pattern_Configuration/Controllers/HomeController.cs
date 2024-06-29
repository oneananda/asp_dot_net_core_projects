using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _007_Options_Pattern_Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyAppSettings _myAppSettings;

        public HomeController(IOptions<MyAppSettings> myAppSettings)
        {
            _myAppSettings = myAppSettings.Value;
        }
        public IActionResult Index()
        {
            ViewBag.APIUrl = _myAppSettings.APIUrl;
            ViewBag.APIKey = _myAppSettings.APIKey;            
            return View();
        }
    }
}
