namespace Celeste.Identity.Application;

using Celeste.Identity.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

/// <summary>
///     Exception handling middleware that captures exceptions and converts them to appropriate HTTP responses.
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    /// <summary>
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    ///     Invokes the middleware to handle exceptions during HTTP request processing.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            _logger.LogWarning(ex, $"Resource not found : Field : '{ex.Field}' - Value : '{ex.Value}'");
            await WriteErrorResponse(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (BadRequestException ex)
        {
            _logger.LogWarning(ex, $"Bad request : '{ex.Message}'.");
            await WriteErrorResponse(context, HttpStatusCode.BadRequest, ex.Message);
        }
        //catch (UnauthorizedException ex)
        //{
        //    _logger.LogWarning(ex, "Unauthorized access.");
        //    await WriteErrorResponse(context, HttpStatusCode.Unauthorized, ex.Message);
        //}
        //catch (ForbiddenException ex)
        //{
        //    _logger.LogWarning(ex, "Forbidden request.");
        //    await WriteErrorResponse(context, HttpStatusCode.Forbidden, ex.Message);
        //}
        catch (ArgumentNullException ex)
        {
            _logger.LogWarning(ex, "Missing required argument.");
            var msg = !string.IsNullOrWhiteSpace(ex.ParamName)
                ? $"Missing required parameter: {ex.ParamName}."
                : ex.Message;
            await WriteErrorResponse(context, HttpStatusCode.BadRequest, msg);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, $"Bad request : '{ex.Message}'.");
            await WriteErrorResponse(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception.");
            await WriteErrorResponse(context, HttpStatusCode.InternalServerError, "An unexpected error occurred.");
        }
    }

    private static async Task WriteErrorResponse(
        HttpContext context,
        HttpStatusCode statusCode,
        string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var payload = new
        {
            status = (int)statusCode,
            error = message,
            timestamp = DateTime.UtcNow
        };

        var json = JsonSerializer.Serialize(payload, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(json);
    }
}
