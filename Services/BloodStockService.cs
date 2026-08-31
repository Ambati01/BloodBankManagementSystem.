using BloodBankManagementSystem.Models;
using BloodBankManagementSystem.Data;
namespace BloodBankManagementSystem.Services
{
    public class BloodStockService: IBloodStockService
    {
        private readonly BloodBankDbContext _context;
        public BloodStockService(BloodBankDbContext context)
        {
            _context = context;
        }
        public List<BloodStock> GetAll()
        {
            return _context.BloodStocks.ToList();
        }
        public BloodStock GetById(int id)
        {
            return _context.BloodStocks.Find(id);
        }
        public void Add(BloodStock stock)
        {
            var existingStock = _context.BloodStocks
                .FirstOrDefault(x => x.BloodGroup == stock.BloodGroup);

            if (existingStock != null)
            {
                existingStock.UnitsAvailable += stock.UnitsAvailable;

                _context.BloodStocks.Update(existingStock);
            }
            else
            {
                _context.BloodStocks.Add(stock);
            }

            _context.SaveChanges();
        }
        public void Update(BloodStock bloodStock)
        {
            _context.BloodStocks.Update(bloodStock);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var stock = _context.BloodStocks.Find(id);

            if (stock != null)
            {
                _context.BloodStocks.Remove(stock);
                _context.SaveChanges();
            }
        }
    }
}
