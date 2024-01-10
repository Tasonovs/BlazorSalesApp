using BlazorSalesApp.Application.Common.Validation;
using BlazorSalesApp.Domain.Models.SubElements;
using BlazorSalesApp.SharedApiContracts.SubElements;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Commands.Common.Validation;

public class EditSubElementValidator : AbstractValidator<EditSubElementRequest>
{
    public EditSubElementValidator(DbContext dbContext)
    {
        RuleFor(request => request.Height)
            .GreaterThanOrEqualTo(100);

        RuleFor(request => request.Width)
            .GreaterThanOrEqualTo(100);

        RuleFor(request => request.TypeId)
            .MustBeExistingLookupAsync(dbContext.Set<SubElementTypeLookup>());
    }
}