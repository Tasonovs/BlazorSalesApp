using BlazorSalesApp.Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace BlazorSalesApp.Api.Startup;

public class CustomValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public CustomValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var errorsDictionary = _validators
            .Select(async validator =>
                await validator.ValidateAsync(
                    context.InstanceToValidate,
                    cancellationToken))
            .SelectMany(task => task.Result.Errors)
            .Where(validationFailure => validationFailure != null)
            .GroupBy(
                validationFailure => validationFailure.PropertyName,
                validationFailure => validationFailure.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(
                item => item.Key,
                item => string.Join("\n", item.Values));

        if (errorsDictionary.Any())
        {
            throw new BadRequest400Exception { Errors = errorsDictionary };
        }

        return await next();
    }
}