using Serilog;
using Starlight.Common.Interfaces;
using Starlight.Common.Packet;

namespace Starlight.Common.Network.Netty
{
    public class NettyServerHandler : INetty
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(NettyServerHandler));

        public void ChannelActive(Connection session)
        {
            var connection = new Session();
            session.Register(connection);
        }

        public void ChannelInactive(Connection session)
        {
            session.DeRegister();
        }

        public async Task ChannelRead(Connection session, object output)
        {
            if (session == null)
                return;

            if (session.mConnection == null || session.mConnection.mKicked || !session.Channel.Active)
                return;

            if (output is HsrPacket message)
            {
                PacketProcessor.Invoke(message, session);
            }
            else
            {
                await session.mConnection.KickAsync(true);
            }
        }

        public void ExceptionCaught(Connection session, Exception exception)
        {
            Logger.Error($"Exception in NettyServerHandler {session.RemoteAddress}");
            session?.mConnection.KickAsync(true);
        }
    }
}