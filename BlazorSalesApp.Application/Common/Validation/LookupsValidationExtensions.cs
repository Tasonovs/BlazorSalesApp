using BlazorSalesApp.Domain.Models.Common;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Common.Validation;

public static class LookupsValidationExtensions
{
    public static IRuleBuilderOptions<T, long> MustBeExistingLookupAsync<T, TLookupEntity>(
        this IRuleBuilder<T, long> ruleBuilder,
        IQueryable<TLookupEntity> dbSetQuery)
        where TLookupEntity: IHasId =>
        ruleBuilder
            .MustAsync((value, token) => dbSetQuery.AsQueryable()
                .AnyAsync(lookup => lookup.Id == value, token))
            .WithMessage(ValidationMessages.EntityNotExist);

    public static IRuleBuilderOptions<T, long?> MustBeExistingLookupAsync<T, TLookupEntity>(
        this IRuleBuilder<T, long?> ruleBuilder,
        IQueryable<TLookupEntity> dbSetQuery)
        where TLookupEntity: IHasId =>
        ruleBuilder
            .MustAsync(async (value, token) => value == null
                || await dbSetQuery.AsQueryable().AnyAsync(lookup => lookup.Id == value, token))
            .WithMessage(ValidationMessages.EntityNotExist);

    public static IRuleBuilderOptions<T, TEnum> MustBeExistingEnum<T, TEnum>(
        this IRuleBuilder<T, TEnum> ruleBuilder)
        where TEnum: Enum =>
        ruleBuilder
            .IsInEnum()
            .WithMessage(ValidationMessages.EntityNotExist);
}