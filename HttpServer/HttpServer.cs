using HttpServer.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HttpServer;

internal class HttpServer
{
    private static async Task Main()
    {
        var builder = WebApplication.CreateBuilder();

        var app = builder.Build();

        app.UsePathBase("/");
        //app.Urls.Add($"http://*:{80}");
        app.Urls.Add($"https://*:{443}");

        DispatchController.AddHandlers(app);

        app.UseMiddleware<RequestLoggingMiddleware>();
        await app.RunAsync();
    }

    private class RequestLoggingMiddleware
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
            {
            }
            finally
            {
            }
        }
    }
}