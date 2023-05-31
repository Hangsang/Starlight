using DotNetty.Transport.Channels;
using Server.Interfaces;
using Server.Network.TCP;

namespace Server.Network
{
    public class NettyHandler : ChannelHandlerAdapter
    {
        public NettyHandler(INetty nettyHandler, Connection channel)
        {
            mNettyHandler = nettyHandler;
            mChannel = channel;
        }

        private Connection mChannel { get; }
        private INetty mNettyHandler { get; }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            mNettyHandler.ChannelActive(mChannel);
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            mNettyHandler.ChannelInactive(mChannel);
        }

        public override void ChannelRead(IChannelHandlerContext ctx, object output)
        {
            mNettyHandler.ChannelRead(mChannel, output);
        }

        public override void ChannelReadComplete(IChannelHandlerContext ctx)
        {
            ctx.Flush();
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            mNettyHandler.ExceptionCaught(mChannel, exception);
        }
    }
}