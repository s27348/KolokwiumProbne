using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Entities;

public class Client
{
    [Key]
    public int IdClient { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    public ICollection<Order> Orders { get; set; }
}