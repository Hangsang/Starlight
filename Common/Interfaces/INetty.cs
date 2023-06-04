using Common.Network.Tcp;

namespace Common.Interfaces
{
    public interface INetty
    {
        void ChannelActive(Connection session);

        void ChannelInactive(Connection session);

        Task ChannelRead(Connection session, object output);

        void ExceptionCaught(Connection session, Exception exception);
    }
}