using Common.Packet;
using Common.Unsorted;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System;
using System.Buffers;
using System.Collections.Concurrent;

namespace Common.Codecs
{
    public class MessageDecoder : MessageToMessageDecoder<IByteBuffer>
    {
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

                var metaLen = message.GetUnsignedShort(Constants.METALEN_BEGIN_LENGTH);
                var bodyLen = message.GetInt(Constants.BODYLEN_BEGIN_LENGTH);
                if (bodyLen < 4)
                {
                    var justCmd = new HsrPacket(new HsrHeader { CmdId = (ushort)cmdId }, Memory<byte>.Empty, 0);
                    output.Add(justCmd);
                    return;
                }
                else
                {
                    var mBuffer = ArrayPool<byte>.Shared.Rent(bodyLen);
                    message.GetBytes(Constants.DATA_BEGIN_LENGTH + metaLen, mBuffer, 0, bodyLen);

                    var hsrHeader = new HsrHeader
                    {
                        HeadMagic = headMagic,
                        CmdId = (ushort)cmdId,
                        MetaLen = metaLen,
                        BodyLen = (uint)bodyLen
                    };

                    var mData = new HsrPacket(hsrHeader, mBuffer, 0);
                    output.Add(mData);
                    ArrayPool<byte>.Shared.Return(mBuffer, true);
                }
            }
            catch (Exception ex)
            { }
        }
    }
}