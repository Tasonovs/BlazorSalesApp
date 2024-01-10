using AutoMapper;
using BlazorSalesApp.Domain.Models.SubElements;
using BlazorSalesApp.SharedApiContracts.SubElements;

namespace BlazorSalesApp.Application.MapperProfiles;

public class SubElementProfile : Profile
{
    public SubElementProfile()
    {
        CreateMap<SubElement, SubElementDto>(MemberList.Destination);
    }
}