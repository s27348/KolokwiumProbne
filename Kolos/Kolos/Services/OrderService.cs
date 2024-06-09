using Kolokwium.Context;
using Kolokwium.Entities;
using Kolokwium.Repositories;

namespace Kolokwium.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<ICollection<Order>> GetOrdersData(string? clientLastName)
    {
        return await _orderRepository.GetOrdersData(clientLastName);
    }
}