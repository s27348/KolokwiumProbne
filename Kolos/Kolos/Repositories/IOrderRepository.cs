using Kolokwium.DTOs;
using Kolokwium.Entities;

namespace Kolokwium.Repositories;

public interface IOrderRepository
{
    public Task<ICollection<Order>> GetOrdersData(string? clientLastName);
}