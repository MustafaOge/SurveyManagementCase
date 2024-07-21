using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = new
        {
            StatusCode = (int)HttpStatusCode.InternalServerError,
            Message = "An unexpected error occurred. Please try again later."
        };

        if (exception is DbUpdateException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            response = new
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "A database error occurred. Please check your data and try again."
            };
        }
        else if (exception is InvalidOperationException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            response = new
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "A logic error occurred. Please try again later."
            };
        }

        // Customize additional cases as needed

        var json = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(json);
    }
}
