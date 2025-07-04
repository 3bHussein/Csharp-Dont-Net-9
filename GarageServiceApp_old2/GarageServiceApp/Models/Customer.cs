using System.ComponentModel.DataAnnotations;

namespace GarageServiceApp.Models
{
    public class Customer
    {
        [Key] public int Id { get; set; }
        [Required][StringLength(100)] public string Name { get; set; }
 
        [StringLength(200)] public string Email { get; set; }
        [StringLength(20)] public string Phone { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
 
        [StringLength(500)] public string Note { get; set; }

        public ICollection<ServiceReceived> ServiceReceiveds { get; set; }

    }
}