using DotNetty.Handlers.Timeout;
using Server.Interfaces;
using Server.Packet;

namespace Server.Network.TCP
{
    public class Handler : INetty
    {
        public Handler()
        { }

        public void ChannelActive(Connection session)
        {
            var connection = new Session();
            session.Register(connection);
        }

        public void ChannelInactive(Connection session)
        {
            session.Channel.CloseAsync();

            if (session is IDisposable disposableSession)
            {
                disposableSession.Dispose();
            }
        }

        public async Task ChannelRead(Connection session, object output)
        {
            if (session.mConnection.mKicked || !session.Channel.Active)
                return;

            if (output is HsrPacket message)
            {
                NetworkProcessor.Invoke(message, session);
            }
            else
            {
                await session.mConnection.DisconnectAsync();
                if (session.mConnection is IDisposable disposableConnection)
                {
                    disposableConnection.Dispose();
                }
            }
        }

        public void ExceptionCaught(Connection session, Exception exception)
        {
            if (exception is ReadTimeoutException)
                Console.WriteLine($"Read timeout excp by {session?.RemoteAddress}");

            Console.WriteLine(exception.Message);
            session?.Channel.CloseAsync();
        }
    }
}