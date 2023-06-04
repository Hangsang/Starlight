using HttpServer.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.UsePathBase("/");
app.Urls.Add($"http://*:{80}");
app.Urls.Add($"https://*:{443}");

Dispatch.AddHandlers(app);

app.UseMiddleware<RequestLoggingMiddleware>();
Console.WriteLine($"HTTP(s) server started on port 80 & 443");
await app.RunAsync();

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        { }
    }
}