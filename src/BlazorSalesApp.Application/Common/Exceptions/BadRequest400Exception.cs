using System.Net;

namespace BlazorSalesApp.Application.Common.Exceptions;

public class BadRequest400Exception : ApiException
{
    public BadRequest400Exception() { }

    public BadRequest400Exception(Dictionary<string, string> errors) =>
        Errors = errors;

    public BadRequest400Exception(string filedName, string error) =>
        Errors = new Dictionary<string, string> {{filedName, error}};

    public override string Title { get; set; } = "Bad Request exception";

    public override int Status { get; set; } = (int)HttpStatusCode.BadRequest;

    public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
}