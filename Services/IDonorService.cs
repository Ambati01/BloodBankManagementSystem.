using BloodBankManagementSystem.Models;
namespace BloodBankManagementSystem.Services
{
    public interface IDonorService
    {
        List<Donor> GetAllDonors();
        Donor GetDonorById(int id);
        void AddDonor(Donor donor);
        void UpdateDonor(Donor donor);
        void DeleteDonor(int id);
        List<Donor> GetDonorsByBloodGroup(string bloodGroup);

    }
}
