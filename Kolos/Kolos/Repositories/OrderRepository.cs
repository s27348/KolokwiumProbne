using Kolokwium.Context;
using Kolokwium.DTOs;
using Kolokwium.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly KolokwiumContext _context;

    public OrderRepository(KolokwiumContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Order>> GetOrdersData(string? clientLastName)
    {
        return await _context.Orders
            .Include(e => e.Client)
            .Include(e => e.OrderPastries)
            .ThenInclude(e => e.Pastry)
            .Where(e => clientLastName == null || e.Client.LastName == clientLastName)
            .ToListAsync();
    }
}