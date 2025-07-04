using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GarageServiceApp.Models
{
    public class ServiceType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Category { get; set; } // ENGINE, BRAKE, ELECTRICAL, TRANSMISSION, etc.

        [Column(TypeName = "decimal(10,2)")]
        public decimal BasePrice { get; set; }

        public int EstimatedHours { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();
    }
}
