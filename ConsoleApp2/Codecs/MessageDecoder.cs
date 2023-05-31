using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Serilog;
using Server.Network.TCP;
using Server.Packet;
using Server.Unsorted;
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
        private byte[] mBuffer;

        //static readonly List<Opcode> BANNED_PACKETS;
        private static readonly List<Opcode> READABLE_PACKETS = new()
        { Opcode.PlayerGetTokenCsReq, Opcode.GetMissionStatusCsReq, Opcode.SyncClientResVersionCsReq,
          Opcode.UnlockTutorialGuideCsReq, Opcode.FinishTutorialGuideCsReq, Opcode.PlayerHeartbeatCsReq, Opcode.DoGachaReq };

        public MessageDecoder(Connection connection)
        {
            mTcpConnection = connection;
        }

        protected override void Decode(IChannelHandlerContext context, IByteBuffer message, List<object> output)
        {
            try
            {
                if (mTcpConnection.mConnection.mKicked || !context.Channel.Active)
                    return;

                var headMagic = message.GetUnsignedInt(MAGIC_BEGIN_LENGTH);
                if (headMagic != HEAD_MAGIC)
                    return;

                var cmdId = (Opcode)message.GetUnsignedShort(CMD_BEGIN_LENGTH);
                if (!READABLE_PACKETS.Contains(cmdId)) //Not necessary to read the whole data
                {
                    var justCmd = new HsrPacket(new HsrHeader { CmdId = (ushort)cmdId }, Memory<byte>.Empty, 0);
                    output.Add(justCmd);
                    return;
                }

                var metaLen = message.GetUnsignedShort(METALEN_BEGIN_LENGTH);
                var bodyLen = message.GetInt(BODYLEN_BEGIN_LENGTH);

                if (message.ReadableBytes != DATA_BEGIN_LENGTH + metaLen + bodyLen + sizeof(uint))
                    return;

                mBuffer = ArrayPool<byte>.Shared.Rent(bodyLen);
                message.GetBytes(DATA_BEGIN_LENGTH + metaLen, mBuffer, 0, bodyLen);

                var hsrHeader = new HsrHeader { HeadMagic = headMagic, CmdId = (ushort)cmdId, MetaLen = metaLen, BodyLen = (uint)bodyLen };
                var wholeData = new HsrPacket(hsrHeader, mBuffer.AsMemory(0, bodyLen), 0);
                output.Add(wholeData);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occurred during decoding");
                mTcpConnection?.mConnection?.DisconnectAsync();
            }
            finally
            {
                if (mBuffer != null)
                    ArrayPool<byte>.Shared.Return(mBuffer);
            }
        }
    }
}