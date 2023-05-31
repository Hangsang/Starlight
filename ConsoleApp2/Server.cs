using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Server.Interfaces;
using Server.Network.Tcp.Netty;
using Server.Network.TCP;
using Server.Unsorted;
using Server.Utils;

namespace Server;

public class Server
{
    private static Bootstrap? Bootstrap { get; set; }
    private static ServiceProvider? ServiceProvider { get; set; }

    public static async Task Main()
    {
        Console.Title = "Honkai: Star Rail - Game Server";

        Log.Logger = new LoggerConfiguration()
            .Enrich.With<ContextEnricher>()
            .WriteTo.Async(console => console.Console(outputTemplate: "[{Level:u3}] |{SrcContext}| {Message}{NewLine}{Exception}"))
#if DEBUG
            .MinimumLevel.Verbose()
#else
            .MinimumLevel.Information()
#endif
            .CreateLogger();

        var Logger = Log.ForContext(Serilog.Core.Constants.SourceContextPropertyName, nameof(Server));

        ServiceProvider = new ServiceCollection()
            .AddSingleton<Bootstrap>()
            .AddSingleton<INetty, NettyServerHandler>()
            .BuildServiceProvider();

        Bootstrap = GetServices<Bootstrap>();
        await Bootstrap.BindAsync();

        MessageManager.Instance.Initialize();

        while (true) Console.ReadLine();
    }

    private static T GetServices<T>()
    {
        return ServiceProvider.GetService<T>();
    }
}