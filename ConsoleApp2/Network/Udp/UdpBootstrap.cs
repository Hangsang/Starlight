using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System.Net;

namespace Server.Network.UDP;

public class UDPBootstrap
{
    public IChannel Channel { get; set; }
    private Bootstrap Bootstrap { get; set; }

    public EndPoint LocalAddress => Channel.LocalAddress;
    public EndPoint RemoteAddress => Channel.RemoteAddress;

    public string Id => Channel.Id.AsLongText();

    public async Task InitBootstrap()
    {
        var group = new MultithreadEventLoopGroup(Environment.ProcessorCount * 2);

        Bootstrap = new Bootstrap();

        Bootstrap.Group(group)
            .Channel<SocketDatagramChannel>()
            .Handler(new ActionChannelInitializer<IDatagramChannel>(channel =>
            {
                var pipeline = channel.Pipeline;
                pipeline.AddLast(new UdpServerHandler());
            }));

        var endpoint = new IPEndPoint(IPAddress.Any, 22102);
        Channel = await Bootstrap.BindAsync(endpoint);

        Console.WriteLine($"UDP game server listening on {endpoint}");
    }

    public async Task ShutdownAsync()
    {
        await Channel.CloseAsync();
        await Bootstrap.Group().ShutdownGracefullyAsync();
    }
}