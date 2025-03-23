using Microsoft.AspNetCore.Mvc;

namespace Login_Portal_WebApp.Controllers
{
    public class SSOConnect : Controller
    {
        public IActionResult Account()
        {
            return View();
        }
    }
}
