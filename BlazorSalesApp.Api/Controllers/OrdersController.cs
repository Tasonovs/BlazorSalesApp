using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSalesApp.Api.Controllers;

[ApiController]
[Route("/api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<PaginatedResponse<OrderDto>> GetOrders([FromQuery] PaginatedRequest<OrderDto> request) =>
        _mediator.Send(request);
}