using E_commerce_Product_Catalog.Service.Commands.OrderManagement;
using E_commerce_Product_Catalog.Service.Commands.OrderManagement.Cancle;
using E_commerce_Product_Catalog.Service.Commands.OrderManagement.Complete;
using E_commerce_Product_Catalog.Service.Commands.OrderManagement.Confirm;
using E_commerce_Product_Catalog.Service.Commands.OrderManagement.placeorder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_commerc.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("place")]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand command)
    {
        var order = await _mediator.Send(command);
        return Ok(order);
    }

    [HttpPost("cancel/{orderId}")]
    public async Task<IActionResult> CancelOrder(Guid orderId)
    {
        await _mediator.Send(new CancelOrderCommand(orderId));
        return NoContent();
    }

    [HttpPost("confirm/{orderId}")]
    public async Task<IActionResult> ConfirmOrder(Guid orderId)
    {
        await _mediator.Send(new ConfirmOrderCommand(orderId));
        return NoContent();
    }

    [HttpPost("complete/{orderId}")]
    public async Task<IActionResult> CompleteOrder(Guid orderId)
    {
        await _mediator.Send(new CompleteOrderCommand(orderId));
        return NoContent();
    }
}