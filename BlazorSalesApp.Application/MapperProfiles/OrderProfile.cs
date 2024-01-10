using AutoMapper;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.SharedApiContracts.Orders;

namespace BlazorSalesApp.Application.MapperProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>(MemberList.Destination);
    }
}