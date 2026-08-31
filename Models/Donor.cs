using System.ComponentModel.DataAnnotations;
namespace BloodBankManagementSystem.Models
{
    public class Donor
    {
        [Key]
        public int DonorId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(18, 65)]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        [Required]
        [Phone]
        public string Contact { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime? LastDonation { get; set; }
    }
}
