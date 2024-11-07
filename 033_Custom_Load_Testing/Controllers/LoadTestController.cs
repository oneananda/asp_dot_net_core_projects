using Microsoft.AspNetCore.Mvc;

namespace _033_Custom_Load_Testing.Controllers
{
    public class LoadTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
