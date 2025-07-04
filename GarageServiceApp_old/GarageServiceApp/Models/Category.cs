using System.ComponentModel.DataAnnotations;

namespace GarageServiceApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<SparePart> SpareParts { get; set; } = new List<SparePart>();
    }
}
