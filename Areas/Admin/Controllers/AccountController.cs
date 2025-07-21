using express_website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace express_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;


        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Console.WriteLine("Login attempt with model: " + model.Username);
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });

            ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            System.Diagnostics.Debug.WriteLine("LOGOUT METHOD CALLED");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account", new { area = "Admin" });
        }

    }
}