using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Orders;
using FluentValidation;

namespace BlazorSalesApp.Application.Queries.Orders.GetOrders;

public class GetOrdersValidator : AbstractValidator<PaginatedRequest<OrderDto>>
{
    public GetOrdersValidator()
    {
        RuleFor(request => request.PageSize)
            .GreaterThan(0);
    }
}