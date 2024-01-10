using BlazorSalesApp.Application.Common;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Orders;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Queries.Orders.GetOrderById;

public class GetOrderByIdValidator : AbstractValidator<GetByIdRequest<OrderDto>>
{
    public GetOrderByIdValidator(DbContext dbContext)
    {
        RuleFor(it => it.Id)
            .MustAsync((value, token) => dbContext.Set<Order>()
                .AnyAsync(it => it.Id == value, token))
            .WithMessage(ValidationMessages.EntityNotExist);
    }
}