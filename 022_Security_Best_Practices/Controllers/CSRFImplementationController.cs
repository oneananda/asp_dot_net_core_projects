using Microsoft.AspNetCore.Mvc;

namespace _022_Security_Best_Practices.Controllers
{
    public class CSRFImplementationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(string message)
        {
            // Process the message
            return RedirectToAction("Index");
        }
    }
}
