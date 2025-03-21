using Login_Portal_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Login_Portal_WebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // In a real application, validate against your user store (e.g., database)
                if (model.UserName == "admin" && model.Password == "password")
                {
                    // Set the auth cookie
                    //FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    // Redirect to the returnUrl if it's valid, otherwise to Home/Index
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }
        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
  
    }
}
