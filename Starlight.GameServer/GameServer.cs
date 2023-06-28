using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Starlight.Common;
using Starlight.Common.Interfaces;
using Starlight.Common.Network;
using Starlight.Common.Network.Netty;
using Starlight.Common.Unsorted;
using Starlight.Common.Utils;
using Starlight.Database;
using Starlight.Database.Repositories;
using System.Reflection;

namespace Starlight.GameServer;

internal class GameServer
{
    #if DEBUG
    private const string Title = "Starlight Game Server (DEBUG)";
    #else
    private const string Title = "Starlight Game Server (RELEASE)";
    #endif

    private static async Task Main()
    {
        Console.Title = Title;

        Log.Logger = new LoggerConfiguration()
            .Enrich.With<ContextEnricher>()
            .WriteTo.Async(console => console.Console(outputTemplate: "[{Level:u3}] |{SrcContext}| {Message}{NewLine}{Exception}"))
#if DEBUG
            .MinimumLevel.Verbose()
#else
            .MinimumLevel.Information()
#endif
            .CreateLogger();

        Driver.Start($"mongodb://127.0.0.1:27017", Log.ForContext(Serilog.Core.Constants.SourceContextPropertyName, "MongoDB"));

        var a = await PlayerRepository.CountAll();
        if (a == 0)
        {
            await PlayerRepository.InsertOne(new Player
            {
                UID = 1,
                PlayerBasicInfo = new PlayerBasicInfo
                {
                    Nickname = "hecker",
                    Level = 70,
                    WorldLevel = 6,
                    Stamina = 1337,
                    Hcoin = 999999, //Jades
                    Mcoin = 999999 //Credits
                }
            });
        }

        MessageFactory.Instance.Initialize();

        ServiceProvider = new ServiceCollection()
            .AddSingleton<Bootstrap>()
            .AddSingleton<INetty, NettyServerHandler>()
            .BuildServiceProvider();

        SetBootstrap(GetServices<Bootstrap>());
        await GetBootstrap().BindAsync();

        while (true) {
            Console.ReadLine();
        }
    }

    private static T GetServices<T>()
    {
        return ServiceProvider.GetService<T>();
    }

    //???
    private static Bootstrap bootstrap;

    private static Bootstrap GetBootstrap()
    {
        return Bootstrap;
    }

    private static void SetBootstrap(Bootstrap value)
    {
        Bootstrap = value;
    }

    private static ServiceProvider? ServiceProvider { get; set; }
    public static Bootstrap Bootstrap { get => Bootstrap1; set => Bootstrap1 = value; }
    public static Bootstrap Bootstrap1 { get => bootstrap; set => bootstrap = value; }
}