﻿namespace Starlight.Common.Network.Netty
{
    public interface INetty
    {
        void ChannelActive(Connection session);

        void ChannelInactive(Connection session);

        Task ChannelRead(Connection session, object output);

        void ExceptionCaught(Connection session, Exception exception);
    }
}