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

        var a = await PlayerRepository.CountAll().ConfigureAwait(false);
        if (a == 0)
        {
            await PlayerRepository.InsertOne(new Database.MongoDb.Entities.PlayerEntity
            {
                UID = 1,
                Banned = true,
                PlayerBasicInfo = new BEPIDFNIMLN
                {
                    NickName = "Hang"
                }
            }).ConfigureAwait(false);
        }

        MessageManager.Instance.Initialize();

        ServiceProvider = new ServiceCollection()
            .AddSingleton<Bootstrap>()
            .AddSingleton<INetty, NettyServerHandler>()
            .BuildServiceProvider();

        Bootstrap = GetServices<Bootstrap>();
        await Bootstrap.BindAsync();

        for (int i = 0; i < 100; i++)
        {
            await Bootstrap.ConnectToServer();
            Log.Logger.Warning(i.ToString());
        }

        while (true)
            Console.ReadLine();
    }

    private static T GetServices<T>()
    {
        return ServiceProvider.GetService<T>();
    }
}