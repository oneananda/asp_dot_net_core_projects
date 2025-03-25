using Main_Portal_WebApp.Models;
using Main_Portal_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;


namespace Main_Portal_WebApp.Controllers
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
            return View();
        }

        [HttpGet]
        public IActionResult Login(string token)
        {
            var principal = JwtValidator.ValidateToken(token);
            if (principal == null)
            {
               //return new HttpStatusCodeResult(401, "Invalid or expired token");
            }

            var userName = principal.Identity.Name;
            var role = principal.FindFirst(ClaimTypes.Role)?.Value;

            TempData["UserName"] = userName;
            TempData["Role"] = role;

            // Optional: Set auth cookie or session
            //HttpContext.Session.SetString("User", username);
            //Session["Role"] = role;

            //return Content($"Welcome {username}! Your role is {role}");
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
