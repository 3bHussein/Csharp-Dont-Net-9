using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GarageServiceApp.Models
{
    public class CarPhoto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ServiceReceivedId { get; set; }

        [ForeignKey("ServiceReceivedId")]
        public virtual ServiceReceived ServiceReceived { get; set; }

        [Required]
        [StringLength(500)]
        public string PhotoPath { get; set; }

        [StringLength(200)]
        public string PhotoDescription { get; set; }

        [Required]
        [StringLength(20)]
        public string PhotoType { get; set; } // BEFORE, DURING, AFTER, DAMAGE, GENERAL

        public DateTime TakenDate { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string TakenBy { get; set; }

        public long FileSize { get; set; }

        [StringLength(50)]
        public string FileExtension { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
