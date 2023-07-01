using Starlight.Common.Network;

namespace Starlight.Common.Interfaces
{
    public interface INetty
    {
        void ChannelActive(Connection session);

        void ChannelInactive(Connection session);

        void ChannelRead(Connection session, object output);

        void ExceptionCaught(Connection session, Exception exception);
    }
}