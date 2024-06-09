namespace Kolokwium.DTOs;

public class OrderDTO
{
    public DateTime AcceptedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    public string? Comments { get; set; }
    public ICollection<OrderPastryDTO> Pastries { get; set; } = null!;
}

public class OrderPastryDTO
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}