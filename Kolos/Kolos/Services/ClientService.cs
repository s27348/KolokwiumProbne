using Kolokwium.Entities;
using Kolokwium.Repositories;

namespace Kolokwium.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    
    public Task AddNewOrder(Order order)
    {
        return _clientRepository.AddNewOrder(order);
    }

    public async Task<Pastry?> GetPastryByName(string name)
    {
        return await _clientRepository.GetPastryByName(name);
    }

    public Task AddOrderPastries(IEnumerable<OrderPastry> orderPastries)
    {
        return AddOrderPastries(orderPastries);
    }
    
    public async Task<bool> ClientExists(int idClient)
    {
        return await _clientRepository.ClientExists(idClient);
    }
}