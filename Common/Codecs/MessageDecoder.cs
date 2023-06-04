using Common.Packet;
using Common.Unsorted;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System.Buffers;
using System.Collections.Concurrent;

namespace Common.Codecs
{
    public class MessageDecoder : MessageToMessageDecoder<IByteBuffer>
    {
        private readonly ConcurrentQueue<IByteBuffer> mPacketQueue = new();
        private readonly SemaphoreSlim mSemaphore = new(1);
        //private readonly Connection mTcpConnection;

        //public MessageDecoder()
        //{
        //mTcpConnection = connection;
        //}

        protected override void Decode(IChannelHandlerContext context, IByteBuffer message, List<object> output)
        {
            try
            {
                if (!context.Channel.Active)
                    return;

                var headMagic = message.GetUnsignedInt(Constants.MAGIC_BEGIN_LENGTH);
                if (headMagic != Constants.HEAD_MAGIC)
                    return;

                var cmdId = (Opcode)message.GetUnsignedShort(Constants.CMD_BEGIN_LENGTH);

                mPacketQueue.Enqueue(message);

                if (!mSemaphore.Wait(0))
                    return;

                while (mPacketQueue.TryDequeue(out var packet))
                {
                    var metaLen = packet.GetUnsignedShort(Constants.METALEN_BEGIN_LENGTH);
                    var bodyLen = packet.GetInt(Constants.BODYLEN_BEGIN_LENGTH);
                    if (bodyLen < 4)
                    {
                        var justCmd = new HsrPacket(new HsrHeader { CmdId = (ushort)cmdId }, Memory<byte>.Empty, 0);
                        output.Add(justCmd);
                        return;
                    }
                    else
                    {
                        var mBuffer = ArrayPool<byte>.Shared.Rent(bodyLen);
                        packet.GetBytes(Constants.DATA_BEGIN_LENGTH + metaLen, mBuffer, 0, bodyLen);

                        var hsrHeader = new HsrHeader
                        {
                            HeadMagic = headMagic,
                            CmdId = (ushort)cmdId,
                            MetaLen = metaLen,
                            BodyLen = (uint)bodyLen
                        };

                        var mData = new HsrPacket(hsrHeader, mBuffer.AsMemory(0, bodyLen), 0);
                        output.Add(mData);
                    }
                }
            }
            catch (Exception ex)
            { }
            finally
            {
                mSemaphore.Release();
            }
        }
    }
}