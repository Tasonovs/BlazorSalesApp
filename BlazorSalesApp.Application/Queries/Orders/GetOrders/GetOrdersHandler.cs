using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorSalesApp.Application.Common.Extensions;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Queries.Orders.GetOrders;

public class GetOrdersHandler : IRequestHandler<PaginatedRequest<OrderDto>, PaginatedResponse<OrderDto>>
{
    private readonly DbContext _dbContext;
    private readonly IMapper _mapper;

    public GetOrdersHandler(DbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedResponse<OrderDto>> Handle(PaginatedRequest<OrderDto> request, CancellationToken cancellationToken)
    {
        var responseData = await _dbContext.Set<Order>()
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .ToPaginationResultAsync(request, cancellationToken);

        return responseData;
    }
}