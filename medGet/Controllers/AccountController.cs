using medGet.Controllers.DbController;
using medGet.Models;
using medGet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace medGet.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager { get; }
        private SignInManager<ApplicationUser> SignInManager { get; }

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = new ApplicationUser()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Contact = model.Contact,
                    Gender = model.Gender,
                    Age = model.Age,
                    Location = model.Location
                };

                var result = await UserManager.CreateAsync(applicationUser, model.Password);
                var result2 = await UserManager.AddToRoleAsync(applicationUser, "User");

                if (result.Succeeded && result2.Succeeded)
                {
                    await SignInManager.SignInAsync(applicationUser, isPersistent: true);
                    return RedirectToAction("Login", "Account");
                }
            }
            return View("Register", "Account");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(model.Username,
                    model.Password,
                    model.RememberMe, false);
                if (result.Succeeded)
                {
                    return View("Index", "home");
                }
            }

            return View("Login","Account");
        }
    }
}
