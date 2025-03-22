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
        public ActionResult Login(User model, string returnUrl = "Home")
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
                    TempData["IsValidated"] = true;
                    HttpContext.Session.SetString("IsValidated", "True");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["IsValidated"] = false;
                    HttpContext.Session.SetString("IsValidated", "False");
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            else
            {
                HttpContext.Session.SetString("IsValidated", "False");
                TempData["IsValidated"] = false;
                IterateModel();
            }
            return View(model);
        }

        private void IterateModel()
        {
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    System.Diagnostics.Debug.WriteLine($"Key: {state.Key}, Error: {error.ErrorMessage}");
                }
            }
        }

        // POST: /Account/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            TempData["Message"] = "Logged out!";
            TempData["IsValidated"] = false;
            HttpContext.Session.SetString("IsValidated", "False");
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
