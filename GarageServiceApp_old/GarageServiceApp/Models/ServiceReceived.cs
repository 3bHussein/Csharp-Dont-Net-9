using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GarageServiceApp.Models
{
    public class ServiceReceived
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string CarMake { get; set; }

        [Required]
        [StringLength(20)]
        public string CarModel { get; set; }

        [Required]
        public int CarYear { get; set; }

        [StringLength(20)]
        public string LicensePlate { get; set; }

        [StringLength(50)]
        public string VIN { get; set; }

        [Required]
        [StringLength(1000)]
        public string StateBeforeRepair { get; set; }

        [StringLength(2000)]
        public string CustomerComplaint { get; set; }

        [StringLength(1000)]
        public string InitialDiagnosis { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "RECEIVED"; // RECEIVED, IN_PROGRESS, COMPLETED, DELIVERED, CANCELLED

        [Column(TypeName = "decimal(10,2)")]
        public decimal EstimatedCost { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ActualCost { get; set; }

        public DateTime ReceivedDate { get; set; } = DateTime.Now;

        public DateTime? CompletedDate { get; set; }

        public DateTime? DeliveredDate { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        [StringLength(100)]
        public string TechnicianName { get; set; }

        // Navigation properties
        public virtual ICollection<CarPhoto> CarPhotos { get; set; } = new List<CarPhoto>();
        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();
    }
}
