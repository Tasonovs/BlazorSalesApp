using AutoMapper;
using BlazorSalesApp.Domain.Models.Common;
using BlazorSalesApp.SharedApiContracts.Common;

namespace BlazorSalesApp.Application.MapperProfiles;

public class LookupProfile : Profile
{
    public LookupProfile()
    {
        CreateMap<BaseLookupEntity, LookupViewModel>(MemberList.Destination)
            .IncludeAllDerived();
    }
}