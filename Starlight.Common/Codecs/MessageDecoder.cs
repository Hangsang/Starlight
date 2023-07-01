using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Starlight.Common.Packet;
using System;
using System.Buffers;

namespace Starlight.Common.Codecs
{
    public class MessageDecoder : MessageToMessageDecoder<IByteBuffer>
    {
        protected override void Decode(IChannelHandlerContext ctx, IByteBuffer message, List<object> output)
        {
            try
            {
                if (message == null)
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

                var mBuffer = ArrayPool<byte>.Shared.Rent(bodyLen);
                message.GetBytes(Constants.DATA_BEGIN_LENGTH + metaLen, mBuffer, 0, bodyLen);

                var hsrHeader = new HsrHeader
                {
                    CmdId = (ushort)cmdId,
                    MetaLen = metaLen,
                    BodyLen = (uint)bodyLen
                };

                var mData = new HsrPacket(hsrHeader, mBuffer.AsMemory(0, bodyLen), 0);
                output.Add(mData);
                ArrayPool<byte>.Shared.Return(mBuffer);
            }
            finally
            {
                //ArrayPool<byte>.Shared.Return(mBuffer);
            }
        }
    }
}