using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GarageServiceApp.Models
{
    public class ServiceDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ServiceReceivedId { get; set; }

        [ForeignKey("ServiceReceivedId")]
        public virtual ServiceReceived? ServiceReceived { get; set; }


        [Required]
        [StringLength(200)]
        public string ServiceName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; } = 1;

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }

        public int ActualHours { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "PENDING"; // PENDING, IN_PROGRESS, COMPLETED

        public DateTime? StartedDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [StringLength(100)]
        public string TechnicianName { get; set; }

        [StringLength(1000)]
        public string WorkNotes { get; set; }

    }
}
