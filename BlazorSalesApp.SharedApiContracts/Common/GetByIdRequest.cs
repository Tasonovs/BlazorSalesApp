using MediatR;

namespace BlazorSalesApp.SharedApiContracts.Common;

public class GetByIdRequest<TResponse> : IRequest<TResponse>
{
    public long Id { get; set; }
}