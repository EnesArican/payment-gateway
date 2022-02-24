namespace Payment.Gateway.Api.Controllers.Middleware;

using System.Net;
using System.Text.Json;
using Payment.Gateway.Api.Client.Utils;
using Payment.Gateway.Api.Dtos;


public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;

        (HttpStatusCode statusCode, string? message) = exception switch
        {
            AppException => (HttpStatusCode.BadRequest, exception.Message),
            HttpRequestException ex when ex.Message.Contains("404") => (HttpStatusCode.NotFound, string.Empty),
            _ => (HttpStatusCode.InternalServerError, string.Empty)
        };

        response.StatusCode = (int)statusCode;

        _logger.LogError(exception.Message);

        if (string.IsNullOrEmpty(message)) return;

        var errorResponse = new ErrorResponse { Message = message };
        var result = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(result);
    }
}