using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Windows;
using MediatR;

namespace BlazorSalesApp.SharedApiContracts.Orders;

public class CreateOrderRequest : IRequest<EntityIdResponse>
{
    public string Name { get; set; }

    public long StateId { get; set; }

    public List<EditWindowRequest> Windows { get; set; }
}