using AutoMapper;
using BlazorSalesApp.Domain.Models.Windows;
using BlazorSalesApp.SharedApiContracts.Windows;

namespace BlazorSalesApp.Application.MapperProfiles;

public class WindowProfile : Profile
{
    public WindowProfile()
    {
        CreateMap<Window, WindowDto>(MemberList.Destination);
    }
}