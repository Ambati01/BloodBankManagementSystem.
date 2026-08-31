using BloodBankManagementSystem.Models;
using BloodBankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace BloodBankManagementSystem.Controllers
{
    public class BloodStockController : Controller
    {
        private readonly IBloodStockService _bloodStockService;
        public BloodStockController(IBloodStockService bloodStockService)
        {
            _bloodStockService = bloodStockService;
        }

        //display all blood stocks
        public IActionResult Index()
        {
            var stocks = _bloodStockService.GetAll();
            return View(stocks);
        }

        //get:create blood stock form
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BloodStock Stock)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bloodStockService.Add(Stock);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }

            return View(Stock);
        }

        //get:edit blood stock form
        public IActionResult Edit(int id)
        {
            var stock = _bloodStockService.GetById(id);
            if (stock == null)
                return NotFound();
            return View(stock);
        }

        //post:edit blood stock form
        [HttpPost]
        public IActionResult Edit(BloodStock stock)
        {
            if (ModelState.IsValid)
            {
                _bloodStockService.Update(stock);
                return RedirectToAction("Index");
            }
            return View(stock);
        }

        //get:delete blood stock
        public IActionResult Delete(int id)
        {
            var stock = _bloodStockService.GetById(id);
            if (stock == null)
                return NotFound();
            return View(stock);
        }

        //post:delete blood stock
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
