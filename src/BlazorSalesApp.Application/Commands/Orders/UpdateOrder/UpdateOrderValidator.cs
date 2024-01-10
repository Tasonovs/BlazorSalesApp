using BlazorSalesApp.Application.Commands.Common.Validation;
using BlazorSalesApp.Application.Common;
using BlazorSalesApp.Application.Common.Validation;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.SharedApiContracts.Orders;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Commands.Orders.UpdateOrder;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderRequest>
{
    public UpdateOrderValidator(DbContext dbContext, EditWindowValidator windowValidator)
    {
        RuleFor(it => it.Id)
            .MustAsync((value, token) => dbContext.Set<Order>()
                .AnyAsync(it => it.Id == value, token))
            .WithMessage(ValidationMessages.EntityNotExist);
        
        RuleFor(request => request.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(request => request.StateId)
            .MustBeExistingLookupAsync(dbContext.Set<OrderStateLookup>());

        RuleForEach(request => request.Windows)
            .SetValidator(windowValidator);
    }
}