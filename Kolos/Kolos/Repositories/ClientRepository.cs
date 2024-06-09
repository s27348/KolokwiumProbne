using Kolokwium.Context;
using Kolokwium.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly KolokwiumContext _context;

    public ClientRepository(KolokwiumContext context)
    {
        _context = context;
    }
    
    public async Task AddNewOrder(Order order)
    {
        await _context.AddAsync(order);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Pastry?> GetPastryByName(string name)
    {
        return await _context.Pastries.FirstOrDefaultAsync(e => e.Name == name);
    }

    public async Task AddOrderPastries(IEnumerable<OrderPastry> orderPastries)
    {
        await _context.AddRangeAsync(orderPastries);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> ClientExists(int idClient)
    {
        return await _context.Clients.AnyAsync(x => x.IdClient == idClient);
    }
}