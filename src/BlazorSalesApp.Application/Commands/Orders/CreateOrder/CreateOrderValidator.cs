using BlazorSalesApp.Application.Commands.Common.Validation;
using BlazorSalesApp.Application.Common.Validation;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.SharedApiContracts.Orders;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Commands.Orders.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderValidator(DbContext dbContext, EditWindowValidator windowValidator)
    {
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