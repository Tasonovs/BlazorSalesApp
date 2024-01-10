using System.Net;

namespace BlazorSalesApp.Application.Common.Exceptions;

public class Forbidden403Exception : ApiException
{
    public override string Title { get; set; } = "Forbidden exception";

    public override int Status { get; set; } = (int)HttpStatusCode.Forbidden;
}