using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Entities;

public class Employee
{
    [Key]
    public int IdEmployee { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    public ICollection<Order> Orders { get; set; }
}