using System.Text.Json;
using System.Text.RegularExpressions;
using BlazorSalesApp.Application.Common.Exceptions;

namespace BlazorSalesApp.Api.Startup;

internal sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            if (e is ApiException || e.InnerException is ApiException)
            {
                var apiException = (ApiException)(e.InnerException is ApiException ? e.InnerException : e);
                _logger.LogWarning(apiException, "API Error: {Title}", apiException.Title);
                await HandleExceptionAsync(context, apiException);
            }
            else
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var statusCode = GetStatusCode(exception);
        httpContext.Response.StatusCode = statusCode;

        var response = new
        {
            title = GetTitle(exception),
            status = statusCode,
            errors = GetErrors(exception)
        };

        const string jsonContentType = "application/json";
        httpContext.Response.ContentType = jsonContentType;
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            ApiException apiException => apiException.Status,
            _ => StatusCodes.Status500InternalServerError
        };

    private static string GetTitle(Exception exception) =>
        exception switch
        {
            ApiException apiException => apiException.Title,
            _ => "Internal Server Error"
        };

    private static IReadOnlyDictionary<string, string>? GetErrors(Exception exception)
    {
        if (exception is BadRequest400Exception validationException)
        {
            return FormatValidationErrors(validationException.Errors);
        }

        return null;
    }

    private static IReadOnlyDictionary<string, string> FormatValidationErrors(Dictionary<string, string> errors)
    {
        return errors.ToDictionary(
            x => string.Join(".", x.Key
                .Split('.')
                .Select(propertyName => char.ToLower(propertyName[0]) + propertyName[1..])
                .ToArray()),
            x => Regex.Replace(
                x.Value.Replace("'Field ", "Field '"),
                "\\.$",
                ""));
    }
}
