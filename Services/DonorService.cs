using BloodBankManagementSystem.Models;
using BloodBankManagementSystem.Data;
namespace BloodBankManagementSystem.Services
{
    public class DonorService : IDonorService
    {
        private readonly BloodBankDbContext _context;

        public DonorService(BloodBankDbContext context)
        {
            _context = context;
        }
        public List<Donor> GetAllDonors()
        {
            return _context.Donors.ToList();
        }
        public Donor GetDonorById(int id)
        {
            return _context.Donors.Find(id);
        }
        public void AddDonor(Donor donor)
        {
            _context.Donors.Add(donor);
            _context.SaveChanges();
        }
        public void UpdateDonor(Donor donor)
        {
            _context.Donors.Update(donor);
            _context.SaveChanges();
        }
        public void DeleteDonor(int id)
        {
            var donor = _context.Donors.Find(id);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
                _context.SaveChanges();
            }
        }
        public List<Donor> GetDonorsByBloodGroup(string bloodGroup)
        {
            return _context.Donors.Where(d => d.BloodGroup == bloodGroup).ToList();
        }
        

    }
}
