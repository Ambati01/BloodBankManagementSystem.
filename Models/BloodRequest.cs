using System.ComponentModel.DataAnnotations;

namespace BloodBankManagementSystem.Models
{
    public class BloodRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public string PatientName { get; set; }

        [Required]
        public string HospitalName { get; set; }

        [Required]
        public string BloodGroup { get; set; }

        [Required]
        public int UnitsRequired { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";
    }
}