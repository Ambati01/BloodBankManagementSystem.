using BloodBankManagementSystem.Models;
namespace BloodBankManagementSystem.Services
{
    public interface IBloodStockService
    {
        List<BloodStock> GetAll();
        BloodStock GetById(int id);
        void Add(BloodStock bloodStock);
        void Update(BloodStock bloodStock);
        void Delete(int id);
    }
}
