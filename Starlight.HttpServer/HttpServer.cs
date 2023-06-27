using Microsoft.AspNetCore.Builder;
using Starlight.HttpServer.Controllers;

namespace Starlight.HttpServer;

class HttpServer
{
    static async Task Main()
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