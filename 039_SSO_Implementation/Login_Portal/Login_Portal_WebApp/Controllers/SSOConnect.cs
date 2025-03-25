using Login_Portal_WebApp.Models;
using Login_Portal_WebApp.Service;
using Microsoft.AspNetCore.Http;
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

            var userName = HttpContext.Session.GetString("UserName");
            var role = HttpContext.Session.GetString("Role");
            var token = JwtManager.GenerateToken(userName, role);

            //return Redirect($"https://localhost:7209/Home/Login?Token={token}");
            return View();
        }
    }
}
