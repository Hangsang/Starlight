using DotNetty.Transport.Channels;
using Starlight.Common.Interfaces;

namespace Starlight.Common.Network.Netty
{
    public class INettyHandler : ChannelHandlerAdapter
    {
        public INettyHandler(INetty nettyHandler, Connection channel)
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