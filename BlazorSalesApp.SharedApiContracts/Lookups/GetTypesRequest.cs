using BlazorSalesApp.SharedApiContracts.Common;
using MediatR;

namespace BlazorSalesApp.SharedApiContracts.Lookups;

public class GetTypesRequest : IRequest<List<LookupViewModel>>
{
    
}