using AutoMapper;
using BlazorSalesApp.Application.Common.Extensions;
using BlazorSalesApp.Domain.Models.Windows;
using BlazorSalesApp.SharedApiContracts.Windows;

namespace BlazorSalesApp.Application.MapperProfiles;

public class WindowProfile : Profile
{
    public WindowProfile()
    {
        CreateMap<Window, WindowDto>(MemberList.Destination);
        
        CreateMap<EditWindowRequest, Window>(MemberList.Destination)
            .IgnoreAuditProperties();
    }
}