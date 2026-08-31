using BloodBankManagementSystem.Data;
using BloodBankManagementSystem.Models;

namespace BloodBankManagementSystem.Services
{
    public class BloodRequestService : IBloodRequestService
    {
        private readonly BloodBankDbContext _context;

        public BloodRequestService(BloodBankDbContext context)
        {
            _context = context;
        }

        public List<BloodRequest> GetAll()
        {
            return _context.BloodRequests.ToList();
        }

        public BloodRequest GetById(int id)
        {
            return _context.BloodRequests.Find(id);
        }

        public void Add(BloodRequest request)
        {
            _context.BloodRequests.Add(request);
            _context.SaveChanges();
        }

        public void Update(BloodRequest request)
        {
            _context.BloodRequests.Update(request);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var request = _context.BloodRequests.Find(id);

            if (request != null)
            {
                _context.BloodRequests.Remove(request);
                _context.SaveChanges();
            }
        }

        public void ApproveRequest(int requestId)
        {
            var request = _context.BloodRequests
                                  .FirstOrDefault(r => r.RequestId == requestId);

            if (request == null)
                return;

            // Already approved
            if (request.Status == "Approved")
            {
                throw new Exception("This request has already been approved.");
            }

            var stock = _context.BloodStocks
                                .FirstOrDefault(s => s.BloodGroup == request.BloodGroup);

            if (stock == null)
            {
                throw new Exception("Blood group not available.");
            }

            if (stock.UnitsAvailable < request.UnitsRequired)
            {
                throw new Exception("Insufficient Blood Stock.");
            }

            stock.UnitsAvailable -= request.UnitsRequired;

            request.Status = "Approved";

            _context.SaveChanges();
        }
    }
}