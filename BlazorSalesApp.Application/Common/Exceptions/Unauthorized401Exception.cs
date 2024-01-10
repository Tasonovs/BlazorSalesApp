using System.Net;

namespace BlazorSalesApp.Application.Common.Exceptions;

public class Unauthorized401Exception : ApiException
{
    public override string Title { get; set; } = "Unauthorized exception";

    public override int Status { get; set; } = (int)HttpStatusCode.Unauthorized;
}