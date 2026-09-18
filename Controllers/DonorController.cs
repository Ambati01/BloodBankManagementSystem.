using Microsoft.AspNetCore.Mvc;
using BloodBankManagementSystem.Services;
using BloodBankManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BloodBankManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,Staff,Hospital,Donor")]
    public class DonorController : Controller
    {
        private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        // =====================================================
        // VIEW DONORS
        // Admin / Staff / Hospital -> View all donors
        // Donor -> View only own profile
        // =====================================================

        [HttpGet]
        public IActionResult Index()
        {
            // Donor can see only their own profile
            if (User.IsInRole("Donor"))
            {
                var email = User.FindFirstValue(ClaimTypes.Email);

                if (string.IsNullOrEmpty(email))
                {
                    return Unauthorized();
                }

                var donor = _donorService
                    .GetAllDonors()
                    .FirstOrDefault(d =>
                        !string.IsNullOrEmpty(d.Email) &&
                        d.Email.Equals(
                            email,
                            StringComparison.OrdinalIgnoreCase));

                if (donor == null)
                {
                    return NotFound("Donor profile not found.");
                }

                return View(new List<Donor> { donor });
            }

            // Admin, Staff and Hospital can see all donors
            var donors = _donorService.GetAllDonors();

            return View(donors);
        }


        // =====================================================
        // CREATE DONOR
        // Only Admin and Staff
        // =====================================================

        [Authorize(Roles = "Admin,Staff")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Staff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Donor donor)
        {
            if (!ModelState.IsValid)
            {
                return View(donor);
            }

            _donorService.AddDonor(donor);

            return RedirectToAction(nameof(Index));
        }


        // =====================================================
        // EDIT DONOR
        // Admin / Staff -> Edit any donor
        // Donor -> Edit only own profile
        // =====================================================

        [Authorize(Roles = "Admin,Staff,Donor")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var donor = _donorService.GetDonorById(id);

            if (donor == null)
            {
                return NotFound();
            }

            // Donor can edit only their own profile
            if (User.IsInRole("Donor"))
            {
                var email = User.FindFirstValue(ClaimTypes.Email);

                if (string.IsNullOrEmpty(email))
                {
                    return Unauthorized();
                }

                if (!string.Equals(
                    donor.Email,
                    email,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return Forbid();
                }
            }

            return View(donor);
        }

        [Authorize(Roles = "Admin,Staff,Donor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Donor donor)
        {
            if (!ModelState.IsValid)
            {
                return View(donor);
            }

            // Donor can update only their own profile
            if (User.IsInRole("Donor"))
            {
                var email = User.FindFirstValue(ClaimTypes.Email);

                if (string.IsNullOrEmpty(email))
                {
                    return Unauthorized();
                }

                var existingDonor =
                    _donorService.GetDonorById(donor.DonorId);

                if (existingDonor == null)
                {
                    return NotFound();
                }

                if (!string.Equals(
                    existingDonor.Email,
                    email,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return Forbid();
                }
            }

            _donorService.UpdateDonor(donor);

            return RedirectToAction(nameof(Index));
        }


        // =====================================================
        // DELETE DONOR
        // Only Admin and Staff
        // =====================================================

        [Authorize(Roles = "Admin,Staff")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var donor = _donorService.GetDonorById(id);

            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        [Authorize(Roles = "Admin,Staff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _donorService.DeleteDonor(id);

            return RedirectToAction(nameof(Index));
        }


        // =====================================================
        // SEARCH DONOR
        // Admin / Staff / Hospital
        // =====================================================

        [Authorize(Roles = "Admin,Staff,Hospital")]
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Staff,Hospital")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string bloodGroup)
        {
            var donors =
                _donorService.GetDonorsByBloodGroup(bloodGroup);

            return View("Index", donors);
        }
    }
}