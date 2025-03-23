using Login_Portal_WebApp.App_Code;
using Login_Portal_WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Login_Portal_WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        public AccountController(AuthService authService)
        {
            _authService = authService;
        }
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
                var (isValid, role, message) = _authService.ValidateUser(model.UserName, model.Password);
                if (isValid)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    TempData["IsValidated"] = true;
                    model.Role = role;
                    HttpContext.Session.SetString("Role", role);
                    foreach (var state in ModelState)
                    {
                        HttpContext.Session.SetString(state.Key, state.Value.RawValue.ToString());
                    }
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
            HttpContext.Session.Clear();
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
