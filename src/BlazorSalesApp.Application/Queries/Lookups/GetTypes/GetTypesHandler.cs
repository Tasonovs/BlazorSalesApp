using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorSalesApp.Domain.Models.SubElements;
using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Lookups;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Queries.Lookups.GetTypes;

public class GetTypesHandler : IRequestHandler<GetTypesRequest, List<LookupViewModel>>
{
    private readonly DbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTypesHandler(DbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<LookupViewModel>> Handle(GetTypesRequest request, CancellationToken cancellationToken)
    {
        var responseData = await _dbContext.Set<SubElementTypeLookup>()
            .ProjectTo<LookupViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return responseData;
    }
}