using System.Text.Json;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SimpleECommerce.Application;
using SimpleECommerce.Application.Exceptions;

namespace SimpleECommerce.WebAPI.Middlewares;

public static class ExceptionHandler
{
    public static async Task HandleExceptionAsync(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                context.Response.ContentType = "application/json";
                var (statusCode, code, clientMessage) = GetExceptionDetails(exception);

                string message = statusCode == 400 || statusCode == 404
                    ? clientMessage
                    : ErrorMessages.ErrorOccured;

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    statusCode,
                    code,
                    message
                }));

                string logData = JsonSerializer.Serialize(new
                {
                    statusCode,
                    clientMessage,
                    stackTrace = exception.StackTrace
                });
                Log.Error($"Something went wrong: {logData}");
            }
        });
        await Task.CompletedTask;
    }

    private static (int, string, string) GetExceptionDetails(Exception exception) => exception switch
    {
        NotFoundException exp => (StatusCodes.Status404NotFound, exp.Code, exception.Message),
        BadRequestException exp => (StatusCodes.Status400BadRequest, exp.Code, exception.Message),
        ValidationException => (StatusCodes.Status400BadRequest, "VALIDATION_EXCEPTION", exception.Message),
        DbUpdateException => (StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_EXCEPTION",
            exception.InnerException?.Message),
        _ => (StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_EXCEPTION", exception.Message)
    };
}