using BloodBankManagementSystem.Models;

namespace BloodBankManagementSystem.Services
{
    public interface IBloodRequestService
    {
        List<BloodRequest> GetAll();

        BloodRequest GetById(int id);

        void Add(BloodRequest request);

        void Update(BloodRequest request);

        void Delete(int id);
        void ApproveRequest(int requestId);
    }
}