using AutoMapper;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Commands.Orders.CreateOrder;

public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, EntityIdResponse>
{
    private readonly DbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateOrderHandler(DbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<EntityIdResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var orderEntity = _mapper.Map<Order>(request);

        _dbContext.Set<Order>().Add(orderEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new EntityIdResponse { Id = orderEntity.Id };
    }
}