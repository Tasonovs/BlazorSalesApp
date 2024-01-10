namespace BlazorSalesApp.Application.Common.Exceptions;

public abstract class ApiException : Exception
{
    public abstract string Title { get; set; }

    public string Details { get; set; }

    public abstract int Status { get; set; }
}