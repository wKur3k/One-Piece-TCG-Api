using System.Net;
using OnePieceApi.Exceptions;
using OnePieceApi.Models;

namespace OnePieceApi.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (BadRequestException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
        }
        catch (NotFoundException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode code)
    {
        context.Response.StatusCode = (int)code;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = ex.Message
        }.ToString());
    }
}