using BlazorSalesApp.SharedApiContracts.Common;
using Microsoft.EntityFrameworkCore;

namespace BlazorSalesApp.Application.Common.Extensions;

public static class QueryableExtensions
{
    /// <summary>
    /// NOTE : always make sure that your ordering is fully unique.
    /// For example, if results are ordered only by date, but there can be multiple results with the same date,
    /// then results could be skipped when paginating as they're ordered differently across two paginating queries.
    /// Ordering by both date and ID (or any other unique property or combination of properties)
    /// makes the ordering fully unique and avoids this problem.
    /// </summary>
    public static async Task<PaginatedResponse<TItems>> ToPaginationResultAsync<TItems>(
        this IQueryable<TItems> query,
        PaginatedRequest<TItems> request,
        CancellationToken cancellationToken)
    {
        var count = await query.CountAsync(cancellationToken);
        var totalPages = (int) Math.Ceiling(count / (double) request.PageSize);
        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedResponse<TItems>
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalPagesCount = totalPages,
            TotalItemsCount = count,
            HasPrevPage = request.PageNumber > 1,
            HasNextPage = request.PageNumber < totalPages,
            Items = items,
        };
    }
}