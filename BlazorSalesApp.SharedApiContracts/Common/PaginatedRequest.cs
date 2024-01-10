using MediatR;

namespace BlazorSalesApp.SharedApiContracts.Common;

public class PaginatedRequest<TItem> : IRequest<PaginatedResponse<TItem>>
{
    /// <summary>
    /// Page Number
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// Page Size
    /// </summary>
    public int PageSize { get; set; } = 10;
}