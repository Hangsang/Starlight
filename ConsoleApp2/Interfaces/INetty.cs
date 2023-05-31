using Server.Network.TCP;

namespace Server.Interfaces
{
    public interface INetty
    {
        void ChannelActive(Connection session);

        void ChannelInactive(Connection session);

        void ChannelRead(Connection session, object output);

        void ExceptionCaught(Connection session, Exception exception);
    }
}