using BloodBankManagementSystem.Models;
using BloodBankManagementSystem.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace BloodBankManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _userService.EmailExistsAsync(model.Email))
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View(model);
            }

            // Only Donor and Hospital can register themselves
            if (model.Role != "Donor" && model.Role != "Hospital")
            {
                ModelState.AddModelError("Role", "Invalid registration role.");
                return View(model);
            }

            await _userService.RegisterUserAsync(model);

            TempData["SuccessMessage"] =
                "Registration successful. Please login.";

            return RedirectToAction("Login");
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userService.GetUserByEmailAsync(model.Email);

            if (user == null || !user.IsActive)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            var validPassword =
                await _userService.ValidatePasswordAsync(
                    model.Email,
                    model.Password);

            if (!validPassword)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(
                claims,
                "CookieAuth");

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                "CookieAuth",
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                });

            // Redirect based on role
            if (user.Role == "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            if (user.Role == "Staff")
            {
                return RedirectToAction("Index", "Home");
            }

            if (user.Role == "Hospital")
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");

            return RedirectToAction("Login");
        }

        // GET: /Account/AccessDenied
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}