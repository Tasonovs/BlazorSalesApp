using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorSalesApp.Application.Common.Extensions;
using BlazorSalesApp.Domain.Models.Orders;
using BlazorSalesApp.SharedApiContracts.Common;
using BlazorSalesApp.SharedApiContracts.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Queries.Orders.GetOrderById;

public class GetOrderByIdHandler : IRequestHandler<GetByIdRequest<OrderDto>, OrderDto>
{
    private readonly DbContext _dbContext;
    private readonly IMapper _mapper;

    public GetOrderByIdHandler(DbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<OrderDto> Handle(GetByIdRequest<OrderDto> request, CancellationToken cancellationToken)
    {
        var responseData = await _dbContext.Set<Order>()
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .FirstAsync(order => order.Id == request.Id, cancellationToken);

        return responseData;
    }
}