

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.Enities;

public class AppUser
{
    [Required]
    // public int id { get; set; }
    public string id { get; set; } = Guid.NewGuid().ToString();
    [Required]

    public string? name { get; set; }

    


    
}
