namespace BlazorSalesApp.Domain.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow() =>
        DateTime.UtcNow;
    
    public DateTime UtcToday() =>
        DateTime.UtcNow.Date;
}
