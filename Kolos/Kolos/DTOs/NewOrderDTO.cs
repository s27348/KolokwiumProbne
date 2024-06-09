namespace Kolokwium.DTOs;

public class NewOrderDTO
{
    public int EmployeeID { get; set; }
    public DateTime AcceptedAt { get; set; }
    public string? Comments { get; set; } = null;
    public ICollection<NewOrderPastryDTO> Pastries { get; set; } = new List<NewOrderPastryDTO>();
}

public class NewOrderPastryDTO
{
    public string Name { get; set; } = null!;
    public int Amount { get; set; }
    public string? Comments { get; set; }
}