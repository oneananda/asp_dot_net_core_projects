using Microsoft.AspNetCore.Mvc;

namespace _022_Security_Best_Practices.Controllers
{
    public class CounterXSSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
