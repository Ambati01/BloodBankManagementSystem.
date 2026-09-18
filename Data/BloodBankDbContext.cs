using Microsoft.EntityFrameworkCore;
using BloodBankManagementSystem.Models;
namespace BloodBankManagementSystem.Data
{
    public class BloodBankDbContext: DbContext
    {
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Donor> Donors { get; set; }

        public DbSet<BloodStock> BloodStocks { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
    }
}
