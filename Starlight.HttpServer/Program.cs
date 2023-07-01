using Microsoft.AspNetCore.Builder;
using Starlight.Database;
using Starlight.HttpServer.Endpoints;

internal class Program
{
    private static void Main()
    {
        var builder = WebApplication.CreateBuilder();
        var app = builder.Build();

        app.UsePathBase("/");
        app.Urls.Add($"http://*:{80}");
        app.Urls.Add($"https://*:{443}");

        Driver.Start($"mongodb://127.0.0.1:27017");

        Miscellaneous.MapSdkApiEndpoints(app);
        Login.MapLoginEndpoints(app);
        Dispatch.MapRegionalDispatchEndpoints(app);
        Config.MapConfigEndpoints(app);

        app.Run();
    }
}