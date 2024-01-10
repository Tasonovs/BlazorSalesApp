using AutoMapper;
using BlazorSalesApp.Application.Common.Extensions;
using BlazorSalesApp.Domain.Models.SubElements;
using BlazorSalesApp.SharedApiContracts.SubElements;

namespace BlazorSalesApp.Application.MapperProfiles;

public class SubElementProfile : Profile
{
    public SubElementProfile()
    {
        CreateMap<SubElement, SubElementDto>(MemberList.Destination);
        
        CreateMap<EditSubElementRequest, SubElement>(MemberList.Destination)
            .IgnoreAuditProperties()
            .ForMember(dest => dest.Type, cfg => cfg.Ignore());
    }
}