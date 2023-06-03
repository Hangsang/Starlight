using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;
using Server.Network.TCP;

namespace Server.Network.Tcp.Netty
{
    public class NettyTimeout : IdleStateHandler
    {
        private readonly Connection mConnection;

        public NettyTimeout(Connection connection, int readerIdleTimeSeconds, int writerIdleTimeSeconds, int allIdleTimeSeconds)
            : base(readerIdleTimeSeconds, writerIdleTimeSeconds, allIdleTimeSeconds)
        {
            mConnection = connection;
        }

        protected override void ChannelIdle(IChannelHandlerContext context, IdleStateEvent idleStateEvent)
        {
            try {
                mConnection.DeRegister(true);
            }
            catch (Exception ex) {
                //Ignored
            }
        }
    }
}