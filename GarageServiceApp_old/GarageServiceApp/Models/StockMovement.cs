using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GarageServiceApp.Models
{
    public class StockMovement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SparePartId { get; set; }

        [ForeignKey("SparePartId")]
        public virtual SparePart SparePart { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [StringLength(20)]
        public string MovementType { get; set; } // IN, OUT, ADJUSTMENT

        [StringLength(200)]
        public string Reason { get; set; }

        [StringLength(100)]
        public string Reference { get; set; }

        public DateTime MovementDate { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string CreatedBy { get; set; }
    }
}
