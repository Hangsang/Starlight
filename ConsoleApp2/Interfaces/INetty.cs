using Server.Network.TCP;

namespace Server.Interfaces
{
    public interface INetty
    {
        void ChannelActive(Connection session);

        void ChannelInactive(Connection session);

        Task ChannelRead(Connection session, object output);

        Task ExceptionCaught(Connection session, Exception exception);
    }
}