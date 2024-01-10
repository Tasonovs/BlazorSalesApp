using BlazorSalesApp.SharedApiContracts.Common;
using MediatR;

namespace BlazorSalesApp.SharedApiContracts.Lookups;

public class GetStatesRequest : IRequest<List<LookupViewModel>>
{
    
}