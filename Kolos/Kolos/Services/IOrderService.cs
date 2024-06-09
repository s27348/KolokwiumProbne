using Kolokwium.Entities;

namespace Kolokwium.Services;

public interface IOrderService
{
    public Task<ICollection<Order>> GetOrdersData(string? clientLastName);
}