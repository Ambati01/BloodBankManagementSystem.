using BloodBankManagementSystem.Models;
using BloodBankManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,Staff,Hospital,Donor")]
    public class BloodStockController : Controller
    {
        private readonly IBloodStockService _bloodStockService;

        public BloodStockController(IBloodStockService bloodStockService)
        {
            _bloodStockService = bloodStockService;
        }

        // =====================================================
        // VIEW BLOOD STOCK
        // Admin, Staff, Hospital and Donor can view
        // =====================================================

        [HttpGet]
        public IActionResult Index()
        {
            var stocks = _bloodStockService.GetAll();

            return View(stocks);
        }


        // =====================================================
        // CREATE BLOOD STOCK
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
        public IActionResult Create(BloodStock Stock)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bloodStockService.Add(Stock);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }

            return View(Stock);
        }


        // =====================================================
        // EDIT BLOOD STOCK
        // Only Admin and Staff
        // =====================================================

        [Authorize(Roles = "Admin,Staff")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var stock = _bloodStockService.GetById(id);

            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }


        [Authorize(Roles = "Admin,Staff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BloodStock stock)
        {
            if (ModelState.IsValid)
            {
                _bloodStockService.Update(stock);

                return RedirectToAction(nameof(Index));
            }

            return View(stock);
        }


        // =====================================================
        // DELETE BLOOD STOCK
        // Only Admin and Staff
        // =====================================================

        [Authorize(Roles = "Admin,Staff")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var stock = _bloodStockService.GetById(id);

            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }


        [Authorize(Roles = "Admin,Staff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bloodStockService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}