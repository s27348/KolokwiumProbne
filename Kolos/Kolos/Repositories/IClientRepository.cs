using Kolokwium.Entities;

namespace Kolokwium.Repositories;

public interface IClientRepository
{
    public Task AddNewOrder(Order order);
    public Task<Pastry?> GetPastryByName(string name);
    public Task AddOrderPastries(IEnumerable<OrderPastry> orderPastries);
    public Task<bool> ClientExists(int idClient);
}