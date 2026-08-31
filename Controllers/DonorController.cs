using Microsoft.AspNetCore.Mvc;
using BloodBankManagementSystem.Services;
using BloodBankManagementSystem.Models;
using BloodBankManagementSystem.Data;


namespace BloodBankManagementSystem.Controllers
{
    public class DonorController : Controller
    {
       private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        //Display Add Donor Form
        public IActionResult Create()
        {
            return View();
        }

        //save open
        [HttpPost]
        public IActionResult Create(Donor donor)
        {
            if (ModelState.IsValid)  //Model lo unna validations anni pass ayithe data save cheyyi.
            {
                _donorService.AddDonor(donor);   //Service layer ni call chesthundi.
                return RedirectToAction("Index");  //Save ayyaka donor list page ki velthundi.
            }
            return View(donor);
        }

        //display all donors
        public IActionResult Index()
        {
            var donors = _donorService.GetAllDonors();
            return View(donors);
        }

        //update donor details
        public IActionResult Edit(int id)
        {
            var donor = _donorService.GetDonorById(id);
            if (donor == null)
            {
                return NotFound();
            }
            return View(donor);
        }

        [HttpPost]
        public IActionResult Edit(Donor donor)
        {
            if (ModelState.IsValid)
            {
                _donorService.UpdateDonor(donor);
                return RedirectToAction("Index");
            }
            return View(donor);
        }

        //delete donor details
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
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _donorService.DeleteDonor(id);
            return RedirectToAction("Index");
        }

        //search donor by blood group
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string bloodGroup)
        {
            var donors = _donorService.GetDonorsByBloodGroup(bloodGroup);
            return View("Index", donors);
        }
    }
}
