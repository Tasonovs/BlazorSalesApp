using BlazorSalesApp.SharedApiContracts.Windows;
using FluentValidation;

namespace BlazorSalesApp.Application.Commands.Common.Validation;

public class EditWindowValidator : AbstractValidator<EditWindowRequest>
{
    public EditWindowValidator(EditSubElementValidator subElementValidator)
    {
        RuleFor(request => request.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .MinimumLength(1);

        RuleForEach(request => request.SubElements)
            .SetValidator(subElementValidator);
    }
}