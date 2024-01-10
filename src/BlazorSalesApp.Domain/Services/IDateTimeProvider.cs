namespace BlazorSalesApp.Domain.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow();

    DateTime UtcToday();
}
