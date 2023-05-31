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
            session?.Channel?.CloseAsync();
            session.mConnection = null;
            session = null;
        }

        public void ChannelRead(Connection session, object output)
        {
            if (session == null || !session.Channel.Active)
                return;

            if (session.mConnection == null || session.mConnection.mKicked)
                return;

            if (output is HsrPacket message)
            {
                NetworkProcessor.Invoke(message, session);
            }
            else
            {
                session.Channel.CloseAsync();
                if (session.mConnection is IDisposable disposableConnection)
                {
                    disposableConnection.Dispose();
                }
            }
        }

        public void ExceptionCaught(Connection session, Exception exception)
        {
            session?.Channel?.CloseAsync();
            session.mConnection = null;
            session = null;
        }
    }
}