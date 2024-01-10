using AutoMapper;
using BlazorSalesApp.Domain.Models.Common;

namespace BlazorSalesApp.Application.Common.Extensions;

public static class MapperProfileExtensions
{
    public static IMappingExpression<TSource, TDestination> IgnoreAuditProperties<TSource, TDestination>(
        this IMappingExpression<TSource, TDestination> mappingExpression)
        where TDestination : BaseEntity
    {
        return mappingExpression
            .ForMember(dest => dest.CreatedUtc, cfg => cfg.Ignore())
            .ForMember(dest => dest.UpdatedUtc, cfg => cfg.Ignore())
            .ForMember(dest => dest.DeletedUtc, cfg => cfg.Ignore());
    }
}