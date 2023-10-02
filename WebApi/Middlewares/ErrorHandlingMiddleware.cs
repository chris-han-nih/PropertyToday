namespace WebApi.Middlewares;

using System.Net;
using System.Text.Json;
using Application.Exceptions;
using Application.Models;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var error = new Error();
            
            switch (ex)
            {
                case CustomValidationException validationException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    error.FriendlyMessage = validationException.Message;
                    error.ErrorMessages = validationException.ErrorMessages;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    error.FriendlyMessage = "Something went wrong";
                    error.ErrorMessages = new List<string> { ex.Message };
                    break;
            }
            var result = JsonSerializer.Serialize(error);
            await response.WriteAsync(result);
        }
    }
}
