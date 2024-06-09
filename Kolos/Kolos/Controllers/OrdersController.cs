using Kolokwium.DTOs;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;


namespace Kolokwium.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrdersData(string? clientsLastName = null)
    {
        var orders = await _orderService.GetOrdersData(clientsLastName);

        return Ok(orders.Select(e => new OrderDTO()
        {
            AcceptedAt = e.AcceptedAt,
            FulfilledAt = e.FulfilledAt,
            Comments = e.Comments,
            Pastries = e.OrderPastries.Select(p => new OrderPastryDTO()
            {
                Name = p.Pastry.Name,
                Price = p.Pastry.Price,
                Amount = p.Amount
            }).ToList()
        }));
    }
}