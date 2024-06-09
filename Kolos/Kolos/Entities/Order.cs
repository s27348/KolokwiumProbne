using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Entities;

public class Order
{
    [Key]
    public int IdOrder { get; set; }
    [Required]
    public DateTime AcceptedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    public string? Comments { get; set; }
    public int ClientId { get; set; }
    public int EmployeeId { get; set; }
    [ForeignKey(nameof(ClientId))] 
    public Client Client { get; set; }
    [ForeignKey(nameof(EmployeeId))] 
    public Employee Employee { get; set; }

    public ICollection<OrderPastry> OrderPastries { get; set; }
}