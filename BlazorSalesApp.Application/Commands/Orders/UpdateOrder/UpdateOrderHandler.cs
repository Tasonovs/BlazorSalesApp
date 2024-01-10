using AutoMapper;
using BlazorSalesApp.Application.Common.Extensions;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.Domain.Models.SubElements;
using BlazorSalesApp.Domain.Models.Windows;
using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Commands.Orders.UpdateOrder;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderRequest, EntityIdResponse>
{
    private readonly DbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateOrderHandler(DbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<EntityIdResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        var orderEntity = await GetOrder(request, cancellationToken);

        UpdateOrderValues(orderEntity, request);

        var windows = request.Windows.Select(window => new Window()
        {
            Id = window.Id,
            Name = window.Name,
            QuantityOfWindows = window.QuantityOfWindows,
        })
        .ToList();
        
        orderEntity.Windows = _dbContext.UpdateChildCollection(
            orderEntity.Windows,
            windows,
            window => window.Id);
        
        for (var i = 0; i < orderEntity.Windows.Count; i++)
        {
            var subElements = request.Windows[i].SubElements.Select(subElement => new SubElement
            {
                Id = subElement.Id,
                TypeId = subElement.TypeId,
                Width = subElement.Width,
                Height = subElement.Height,
            })
            .ToList();
            
            orderEntity.Windows[i].SubElements = _dbContext.UpdateChildCollection(
                orderEntity.Windows[i].SubElements,
                subElements,
                w => w.Id);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new EntityIdResponse { Id = request.Id };
    }

    private async Task<Order> GetOrder(UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        var orderEntity = await _dbContext.Set<Order>()
            .Include(order => order.Windows)
            .ThenInclude(window => window.SubElements)
            .FirstAsync(order => order.Id == request.Id, cancellationToken);
        return orderEntity;
    }

    private static void UpdateOrderValues(Order orderEntity, UpdateOrderRequest request)
    {
        orderEntity.Name = request.Name;
        orderEntity.StateId = request.StateId;
    }
}