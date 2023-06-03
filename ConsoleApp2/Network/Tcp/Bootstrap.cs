using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Serilog;
using Server.Codecs;
using Server.Interfaces;
using Server.Network.Tcp.Netty;
using System.Net;
using System.Net.Sockets;

namespace Server.Network.TCP;

public class Bootstrap
{
    private static readonly ILogger Logger = Log.ForContext(
        Serilog.Core.Constants.SourceContextPropertyName,
        nameof(Bootstrap));

    public Bootstrap(INetty _netty)
    {
        Boss = new MultithreadEventLoopGroup();
        Worker = new MultithreadEventLoopGroup();
        mBootstrap = new ServerBootstrap().Group(Boss, Worker);
        mBootstrap.Channel<TcpServerSocketChannel>();
        mBootstrap.ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
        {
            var session = new Connection(channel);
            channel.Pipeline.AddLast(new MessageDecoder(session));
            channel.Pipeline.AddLast(new INettyHandler(_netty, session));
            channel.Pipeline.AddLast(new WriteTimeoutHandler(TimeSpan.FromSeconds(15)));
        }))
          .ChildOption(ChannelOption.TcpNodelay, true)
          .ChildOption(ChannelOption.SoKeepalive, true);
    }

    private ServerBootstrap mBootstrap { get; set; }
    private IChannel mChannel { get; set; }

    private IEventLoopGroup Boss { get; set; }
    private IEventLoopGroup Worker { get; set; }

    public async Task BindAsync()
    {
        var endpoint = new IPEndPoint(IPAddress.Any, 22102);
        mChannel = await mBootstrap.BindAsync(endpoint);

#if DEBUG
        Logger.Debug($"TCP game server listening on {endpoint}");
#else
        Logger.Information($"TCP game server listening on {endpoint}");
#endif
    }

    public async Task ShutdownAsync()
    {
        await mChannel.CloseAsync();
        await mBootstrap.Group().ShutdownGracefullyAsync();
    }
}