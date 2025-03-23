using Microsoft.AspNetCore.Mvc;

namespace Login_Portal_WebApp.Controllers
{
    public class SSOConnect : Controller
    {
        public IActionResult Account()
        {
            string isValidatedStr = HttpContext.Session.GetString("IsValidated");
            bool isValidated = false;

            if (isValidatedStr != null)
            {
                // Optionally convert the string to a boolean if stored that way
                bool.TryParse(isValidatedStr, out isValidated);
            }
            return View();
        }
    }
}
