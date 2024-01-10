namespace BlazorSalesApp.Domain.Models.Common;

public class BaseEntity : IHasId
{
    public long Id { get; set; }
    
    public DateTime CreatedUtc { get; set; }
    
    public DateTime? UpdatedUtc { get; set; }
    
    public DateTime? DeletedUtc { get; set; }
}
