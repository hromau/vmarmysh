using System.Net;
using Newtonsoft.Json;
using vmarmysh.Store;

namespace vmarmysh.API;

public class CustomExceptionMiddleware : IMiddleware
{
    private readonly ApplicationDbContext _dbContext;

    public CustomExceptionMiddleware(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Secure e)
        {
            await WriteResponse(context, e);
        }
        catch (Exception e)
        {
            await WriteResponse(context, e);
        }
    }

    private async Task WriteResponse(HttpContext context, Exception e)
    {
        var logResponse = new ExceptionResponse()
        {
            Type = e.GetType().Name,
            Data = JsonConvert.SerializeObject(e.Message),
            Id = context.Request.HttpContext.TraceIdentifier
        };
        var log = new ExceptionLog()
        {
            Type = e.GetType().Name,
            Text = JsonConvert.SerializeObject(e.Message),
            RequestId = context.Request.HttpContext.TraceIdentifier,
            CreatedAt = DateTime.UtcNow
        };
        await _dbContext.Set<ExceptionLog>().AddAsync(log);
        await _dbContext.SaveChangesAsync();

        var response = JsonConvert.SerializeObject(logResponse);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsync(response);
    }
}