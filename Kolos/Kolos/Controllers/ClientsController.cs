using System.Transactions;
using Kolokwium.DTOs;
using Kolokwium.Entities;
using Kolokwium.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost("{clientID}/orders")]
    public async Task<IActionResult> AddNewOrder(int clientID, NewOrderDTO newOrder)
    {
        if (!await _clientService.ClientExists(clientID))
        {
            return NotFound();
        }

        // if (!await _clientService.EmployeeExists(employeeID))
        // {
        //     return NotFound();
        // }

        var order = new Order()
        {
            ClientId = clientID,
            EmployeeId = newOrder.EmployeeID,
            AcceptedAt = newOrder.AcceptedAt,
            Comments = newOrder.Comments
        };

        var pastries = new List<OrderPastry>();
        foreach (var newPastry in newOrder.Pastries)
        {
            var pastry = await _clientService.GetPastryByName(newPastry.Name);
            if (pastry is null)
            {
                return NotFound();
            }
            pastries.Add(new OrderPastry
            {
                IdPastry = pastry.IdPastry,
                Amount = newPastry.Amount,
                Comments = newPastry.Comments,
                Order = order
            });

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _clientService.AddNewOrder(order);
                await _clientService.AddOrderPastries(pastries);
                
                scope.Complete();
            }
        }
        
        return Created("api/orders", new
             {
                 Id = order.IdOrder,
                 order.AcceptedAt,
                 order.FulfilledAt,
                 order.Comments
             });
    }

}