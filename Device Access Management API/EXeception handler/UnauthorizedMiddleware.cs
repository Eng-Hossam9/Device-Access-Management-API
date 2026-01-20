using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class UnauthorizedMiddleware
{
    private readonly RequestDelegate _next;

    public UnauthorizedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == 401)
        {
            await WriteResponse(context, "Unauthorized");
        }
        else if (context.Response.StatusCode == 403)
        {
            await WriteResponse(context, "Forbidden");
        }
    }

    private async Task WriteResponse(HttpContext context, string message)
    {
        context.Response.ContentType = "application/json";

        var response = new
        {
            success = false,
            message = message,
            data = (object)null
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response)
        );
    }
}
