using BlazorSalesApp.SharedApiContracts.Common;
using FluentValidation;

namespace BlazorSalesApp.Application.Common.Validation;

public class PaginatedRequestValidator<TItem> : AbstractValidator<PaginatedRequest<TItem>>
{
    public PaginatedRequestValidator()
    {
        RuleFor(request => request.PageSize)
            .GreaterThan(0);

        RuleFor(request => request.PageNumber)
            .GreaterThan(0);
    }
}