using System.Net;

namespace BlazorSalesApp.Application.Common.Exceptions;

public class NotFound404Exception : ApiException
{
    public override string Title { get; set; } = "Not found";

    public override int Status { get; set; } = (int)HttpStatusCode.NotFound;
}