using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Entities;

public class Pastry
{
    [Key]
    public int IdPastry { get; set; }
    [Required]
    [MaxLength(150)]
    public string Name { get; set; }
    [Required]
    [Precision(10, 2)]
    public decimal Price { get; set; }
    [Required]
    [MaxLength(40)]
    public string Type { get; set; }
    public ICollection<OrderPastry> OrdersPastries { get; set; }
}