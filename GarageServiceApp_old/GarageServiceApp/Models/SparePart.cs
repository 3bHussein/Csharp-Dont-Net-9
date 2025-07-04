using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GarageServiceApp.Models
{
    public class SparePart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string PartNumber { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public int MinimumStock { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(100)]
        public string Supplier { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastUpdated { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<ServiceSparePart> ServiceSpareParts { get; set; } = new List<ServiceSparePart>();
        public virtual ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
    }
}
