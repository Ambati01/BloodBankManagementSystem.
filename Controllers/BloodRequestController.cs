using BloodBankManagementSystem.Models;
using BloodBankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManagementSystem.Controllers
{
    public class BloodRequestController : Controller
    {
        private readonly IBloodRequestService _bloodRequestService;

        public BloodRequestController(IBloodRequestService bloodRequestService)
        {
            _bloodRequestService = bloodRequestService;
        }

        // Display all requests
        public IActionResult Index()
        {
            var requests = _bloodRequestService.GetAll();
            return View(requests);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Create(BloodRequest request)
        {
            if (ModelState.IsValid)
            {
                _bloodRequestService.Add(request);
                return RedirectToAction("Index");
            }

            return View(request);
        }

        // GET
        public IActionResult Edit(int id)
        {
            var request = _bloodRequestService.GetById(id);

            if (request == null)
                return NotFound();

            return View(request);
        }

        // POST
        [HttpPost]
        public IActionResult Edit(BloodRequest request)
        {
            if (ModelState.IsValid)
            {
                _bloodRequestService.Update(request);
                return RedirectToAction("Index");
            }

            return View(request);
        }

        // GET
        public IActionResult Delete(int id)
        {
            var request = _bloodRequestService.GetById(id);

            if (request == null)
                return NotFound();

            return View(request);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bloodRequestService.Delete(id);
            return RedirectToAction("Index");
        }
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

            return RedirectToAction("Index");
        }
    }
}