using BloodBankManagementSystem.Models;
using BloodBankManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /Admin/ManageUsers
        [HttpGet]
        public async Task<IActionResult> ManageUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            return View(users);
        }

        // POST: /Admin/ChangeRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(int userId, string role)
        {
            var allowedRoles = new[] { "Admin", "Staff", "Hospital", "Donor" };

            if (!allowedRoles.Contains(role))
            {
                TempData["ErrorMessage"] = "Invalid role.";
                return RedirectToAction(nameof(ManageUsers));
            }

            await _userService.UpdateUserRoleAsync(userId, role);

            TempData["SuccessMessage"] = "User role updated successfully.";

            return RedirectToAction(nameof(ManageUsers));
        }

        // POST: /Admin/ToggleStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int userId)
        {
            await _userService.ToggleUserStatusAsync(userId);

            TempData["SuccessMessage"] = "User status updated successfully.";

            return RedirectToAction(nameof(ManageUsers));
        }
        // GET: /Admin/CreateUser
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        // POST: /Admin/CreateUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _userService.EmailExistsAsync(model.Email))
            {
                ModelState.AddModelError(
                    "Email",
                    "Email already exists.");

                return View(model);
            }

            var allowedRoles = new[]
            {
        "Admin",
        "Staff",
        "Hospital",
        "Donor"
    };

            if (!allowedRoles.Contains(model.Role))
            {
                ModelState.AddModelError(
                    "Role",
                    "Invalid role.");

                return View(model);
            }

            await _userService.RegisterUserAsync(model);

            TempData["SuccessMessage"] =
                "User created successfully.";

            return RedirectToAction(nameof(ManageUsers));
        }
    }
}