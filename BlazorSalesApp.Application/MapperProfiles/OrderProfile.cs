using AutoMapper;
using BlazorSalesApp.Application.Common.Extensions;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.SharedApiContracts.Orders;

namespace BlazorSalesApp.Application.MapperProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>(MemberList.Destination);

        CreateMap<CreateOrderRequest, Order>(MemberList.Destination)
            .IgnoreAuditProperties()
            .ForMember(dest => dest.Id, cfg => cfg.Ignore())
            .ForMember(dest => dest.State, cfg => cfg.Ignore());
    }
}