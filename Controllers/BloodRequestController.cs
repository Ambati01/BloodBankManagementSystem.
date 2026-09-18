using BloodBankManagementSystem.Models;
using BloodBankManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,Staff,Hospital,Donor")]
    public class BloodRequestController : Controller
    {
        private readonly IBloodRequestService _bloodRequestService;

        public BloodRequestController(IBloodRequestService bloodRequestService)
        {
            _bloodRequestService = bloodRequestService;
        }

        // =====================================================
        // VIEW REQUESTS
        // Admin, Staff, Hospital and Donor
        // =====================================================

        [HttpGet]
        public IActionResult Index()
        {
            var requests = _bloodRequestService.GetAll();

            return View(requests);
        }


        // =====================================================
        // CREATE REQUEST
        // Admin and Hospital
        // =====================================================

        [Authorize(Roles = "Admin,Hospital")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "Admin,Hospital")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BloodRequest request)
        {
            if (ModelState.IsValid)
            {
                _bloodRequestService.Add(request);

                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }


        // =====================================================
        // EDIT REQUEST
        // Admin and Staff
        // =====================================================

        [Authorize(Roles = "Admin,Staff")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var request = _bloodRequestService.GetById(id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }


        [Authorize(Roles = "Admin,Staff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BloodRequest request)
        {
            if (ModelState.IsValid)
            {
                _bloodRequestService.Update(request);

                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }


        // =====================================================
        // DELETE REQUEST
        // Admin and Staff
        // =====================================================

        [Authorize(Roles = "Admin,Staff")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var request = _bloodRequestService.GetById(id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }


        [Authorize(Roles = "Admin,Staff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bloodRequestService.Delete(id);

            return RedirectToAction(nameof(Index));
        }


        // =====================================================
        // APPROVE REQUEST
        // Admin and Staff
        // =====================================================

        [Authorize(Roles = "Admin,Staff")]
        [HttpGet]
        public IActionResult Approve(int id)
        {
            try
            {
                _bloodRequestService.ApproveRequest(id);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}