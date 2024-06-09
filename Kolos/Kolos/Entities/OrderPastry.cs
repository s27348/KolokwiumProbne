using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Entities;

[Table("Order_Pastry")]
[PrimaryKey(nameof(IdOrder), nameof(IdPastry))]
public class OrderPastry
{
    public int IdOrder { get; set; }
    public int IdPastry { get; set; }
    [Required]
    public int Amount { get; set; }
    [MaxLength(300)]
    public string? Comments { get; set; }
    
    [ForeignKey(nameof(IdOrder))]
    public Order Order { get; set; }
    [ForeignKey(nameof(IdPastry))]
    public Pastry Pastry { get; set; }
}