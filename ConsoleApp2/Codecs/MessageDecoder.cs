using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Serilog;
using Server.Network.TCP;
using Server.Packet;
using Server.Unsorted;
using System;
using System.Buffers;

namespace Server.Codecs
{
    public class MessageDecoder : MessageToMessageDecoder<IByteBuffer>
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            "Decoder");

        private const uint HEAD_MAGIC = 0x9D74C714;

        private const int MAGIC_BEGIN_LENGTH = 0;
        private const int CMD_BEGIN_LENGTH = 4;
        private const int METALEN_BEGIN_LENGTH = 6;
        private const int BODYLEN_BEGIN_LENGTH = 8;
        private const int DATA_BEGIN_LENGTH = 12;

        private readonly Connection mTcpConnection;

        public MessageDecoder(Connection connection)
        {
            mTcpConnection = connection;
        }

        protected override void Decode(IChannelHandlerContext context, IByteBuffer message, List<object> output)
        {
            byte[] buffer = null;

            try
            {
                if (mTcpConnection.mConnection.mKicked || !context.Channel.Active)
                    return;

                var headMagic = message.GetUnsignedInt(MAGIC_BEGIN_LENGTH);
                if (headMagic != HEAD_MAGIC)
                    return;

                var cmdId = (Opcode)message.GetUnsignedShort(CMD_BEGIN_LENGTH);
                var metaLen = message.GetUnsignedShort(METALEN_BEGIN_LENGTH);
                var bodyLen = message.GetInt(BODYLEN_BEGIN_LENGTH);

                if (message.ReadableBytes != DATA_BEGIN_LENGTH + metaLen + bodyLen + sizeof(uint))
                    return;

                buffer = ArrayPool<byte>.Shared.Rent(bodyLen);
                message.GetBytes(DATA_BEGIN_LENGTH + metaLen, buffer, 0, bodyLen);

                var hsrHeader = new HsrHeader { HeadMagic = headMagic, CmdId = (ushort)cmdId, MetaLen = metaLen, BodyLen = (uint)bodyLen };
                var wholeData = new HsrPacket(hsrHeader, buffer.AsMemory(0, bodyLen), 0);
                output.Add(wholeData);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occurred during decoding");
                mTcpConnection?.mConnection?.DisconnectAsync();
            }
            finally
            {
                if (buffer != null) // Make sure buffer is not null before returning it to the array pool
                    ArrayPool<byte>.Shared.Return(buffer);
            }
        }

    }
}