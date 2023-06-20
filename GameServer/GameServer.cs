using Common.Database.MongoDb;
using Common.Database.MongoDb.Repositories;
using Common.Interfaces;
using Common.Network.Tcp;
using Common.Network.Tcp.Netty;
using Common.Unsorted;
using Common.Utils;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace GameServer;

internal class GameServer
{
    private static async Task Main()
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

        Driver.Start($"mongodb://127.0.0.1:27017", Log.ForContext(Serilog.Core.Constants.SourceContextPropertyName, "MongoDB"));

        var a = await PlayerRepository.CountAll();
        if (a == 0)
        {
            await PlayerRepository.InsertOne(new Common.Database.MongoDb.Entities.PlayerEntity
            {
                UID = 1,
                PlayerBasicInfo = new PlayerBasicInfo
                {
                    NickName = "hecker",
                    Level = 70,
                    WorldLevel = 6,
                    Stamina = 1337,
                    HCoin = 999999, //Jades
                    MCoin = 999999 //Credits
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

        while (true)
            Console.ReadLine();
    }

    private static T GetServices<T>()
    {
        return ServiceProvider.GetService<T>();
    }

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