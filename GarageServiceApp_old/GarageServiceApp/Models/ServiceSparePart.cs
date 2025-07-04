using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GarageServiceApp.Models
{
    public class ServiceSparePart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ServiceDetailId { get; set; }

        [ForeignKey("ServiceDetailId")]
        public virtual ServiceDetail ServiceDetail { get; set; }

        [Required]
        public int SparePartId { get; set; }

        [ForeignKey("SparePartId")]
        public virtual SparePart SparePart { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }

        public DateTime UsedDate { get; set; } = DateTime.Now;
    }
}
