using HttpServer.Controllers;
using Microsoft.AspNetCore.Builder;

namespace HttpServer;

internal class HttpServer
{
    private static async Task Main()
    {
        var builder = WebApplication.CreateBuilder();

        var app = builder.Build();

        app.UsePathBase("/");
        app.Urls.Add($"http://*:{80}");
        app.Urls.Add($"https://*:{443}");

        DispatchController.AddHandlers(app);
        AccountController.AddHandlers(app);

        await app.RunAsync();
    }
}