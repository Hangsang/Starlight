using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Server.Database.MongoDb;
using Server.Database.MongoDb.Repositories;
using Server.Interfaces;
using Server.Network.Tcp.Netty;
using Server.Network.TCP;
using Server.Unsorted;
using Server.Utils;

namespace Server;

class Server
{
    private static Bootstrap? Bootstrap { get; set; }
    private static ServiceProvider? ServiceProvider { get; set; }

    static async Task Main()
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
            await PlayerRepository.InsertOne(new Database.MongoDb.Entities.PlayerEntity
            {
                UID = 1,
                PlayerBasicInfo = new BEPIDFNIMLN
                {
                    NickName = "Hang",
                    Level = 70,
                    WorldLevel = 6
                }
            });
        }

        MessageManager.Instance.Initialize();

        ServiceProvider = new ServiceCollection()
            .AddSingleton<Bootstrap>()
            .AddSingleton<INetty, NettyServerHandler>()
            .BuildServiceProvider();

        Bootstrap = GetServices<Bootstrap>();
        await Bootstrap.BindAsync();

        while (true)
            Console.ReadLine();
    }

    private static T GetServices<T>()
    {
        return ServiceProvider.GetService<T>();
    }
}