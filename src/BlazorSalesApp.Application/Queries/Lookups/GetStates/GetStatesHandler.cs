using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Lookups;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Queries.Lookups.GetStates;

public class GetStatesHandler : IRequestHandler<GetStatesRequest, List<LookupViewModel>>
{
    private readonly DbContext _dbContext;
    private readonly IMapper _mapper;

    public GetStatesHandler(DbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<LookupViewModel>> Handle(GetStatesRequest request, CancellationToken cancellationToken)
    {
        var responseData = await _dbContext.Set<OrderStateLookup>()
            .ProjectTo<LookupViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return responseData;
    }
}