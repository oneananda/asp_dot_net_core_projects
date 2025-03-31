using Microsoft.AspNetCore.Mvc;

namespace Database_Per_Tenant.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
