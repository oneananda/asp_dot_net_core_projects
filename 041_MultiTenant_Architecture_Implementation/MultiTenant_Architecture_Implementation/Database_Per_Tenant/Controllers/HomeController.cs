using Database_Per_Tenant.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Database_Per_Tenant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var isValidated = HttpContext.Session.GetString("IsValidated");

            if (isValidated != null)
            {
                if (isValidated == "True")
                {
                    var userName = HttpContext.Session.GetString("UserName");
                    TempData["UserName"] = userName;
                    TempData["IsValidated"] = true;
                }
                else if (isValidated == "False")
                {
                    TempData["IsValidated"] = false;
                }
            }
            else
            {
                TempData["IsValidated"] = false;
            }

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
