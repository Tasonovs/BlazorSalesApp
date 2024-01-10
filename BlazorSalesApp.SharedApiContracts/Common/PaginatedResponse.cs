namespace BlazorSalesApp.SharedApiContracts.Common;

public class PaginatedResponse<T>
{
    /// <summary>
    /// Page Number 
    /// </summary>
    public int PageNumber { get; set; }
        
    /// <summary>
    /// Page Size
    /// </summary>
    public int PageSize { get; set; }
        
    /// <summary>
    /// Total Pages Count
    /// </summary>
    public int TotalPagesCount { get; set; }
        
    /// <summary>
    /// Total Items Count
    /// </summary>
    public int TotalItemsCount { get; set; }
        
    /// <summary>
    /// Has Previous Page
    /// </summary>
    public bool HasPrevPage { get; set; }
        
    /// <summary>
    /// Has Next Page
    /// </summary>
    public bool HasNextPage { get; set; }

    public IEnumerable<T> Items { get; set; }
}