using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;

namespace Common.Network.Tcp.Netty
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
            try
            {
                if (idleStateEvent.State == IdleState.WriterIdle)
                    mConnection.DeRegister(true);
            }
            catch (Exception ex)
            {
                //Ignored
            }
        }
    }
}