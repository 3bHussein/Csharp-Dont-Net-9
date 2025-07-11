using System.ComponentModel.DataAnnotations;

namespace GarageServiceApp.Models
{
        //this one done 
    public class Customer
    {
        [Key] public int Id { get; set; }
        [Required][StringLength(100)] public string Name { get; set; }
        [StringLength(200)] public string? Email { get; set; }
        [StringLength(20)] public string Phone { get; set; }
        [StringLength(500)] public string? Address { get; set; }
        [StringLength(100)] public string? City { get; set; }
        [StringLength(20)] public string? PostalCode { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdated { get; set; }
        public bool? IsActive { get; set; } = true;      
        // Navigation properties         public virtual ICollection<ServiceReceived> ServiceRecords { get; set; } = new List<ServiceReceived>();                  [NotMapped]         public string FullName => $"{FirstName} {LastName}";     }
    }
}