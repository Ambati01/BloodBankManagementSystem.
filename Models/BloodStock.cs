using System.ComponentModel.DataAnnotations;

namespace BloodBankManagementSystem.Models
{
    public class BloodStock
    {
        [Key]
        public int StockId { get; set; }

        [Required]
        public string BloodGroup { get; set; }

        [Required]
        public int UnitsAvailable { get; set; }
    }
}