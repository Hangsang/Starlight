using Serilog;
using Server.Interfaces;
using Server.Packet;

namespace Server.Network.TCP
{
    public class TcpHandler : INetty
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(TcpHandler));

        public void ChannelActive(Connection session)
        {
            var connection = new TcpSession();
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
                NetworkProcessor.Invoke(message, session);
            }
            else
            {
                Logger.Error($"Error occurred at dotnetty channelread function by {session.RemoteAddress}");
                await session.mConnection.KickAsync();
                return;
            }
        }

        public async Task ExceptionCaught(Connection session, Exception exception)
        {
            Logger.Error($"Exception at dotnetty handler class by {session.RemoteAddress}");
            await session.mConnection.KickAsync();
            return;
        }
    }
}