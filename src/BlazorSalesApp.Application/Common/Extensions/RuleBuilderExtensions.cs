using BlazorSalesApp.Application.Common.Exceptions;
using FluentValidation;

namespace BlazorSalesApp.Application.Common.Extensions;

public static class RuleBuilderExtensions
{
    public static IRuleBuilderOptionsConditions<T, TProperty> Throw<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        Func<TProperty, bool> predicate,
        ApiException exception) =>
        ruleBuilder
            .Custom((it, _) =>
            {
                if (predicate(it))
                {
                    return;
                }
                
                throw exception;
            });

    public static IRuleBuilderOptionsConditions<T, TProperty> ThrowAsync<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        Func<TProperty, CancellationToken, Task<bool>> predicate,
        ApiException exception) =>
        ruleBuilder
            .CustomAsync(async (it, _, cancellationToken) =>
            {
                var result = await predicate(it, cancellationToken);
                if (result)
                {
                    return;
                }
                
                throw exception;
            });
}