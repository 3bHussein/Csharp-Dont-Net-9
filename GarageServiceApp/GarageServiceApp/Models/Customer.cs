using System.ComponentModel.DataAnnotations;

namespace GarageServiceApp.Models
{
    public class Customer
    {
        [Key] public int CustomerId { get; set; }
        [Required][StringLength(100)] public string Name { get; set; }
 
        [StringLength(200)] public string Email { get; set; }
        [StringLength(20)] public string Phone { get; set; }

       

       

    }
}