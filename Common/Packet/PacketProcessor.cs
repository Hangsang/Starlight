using Common.Network.Tcp;
using Common.Unsorted;
using Serilog;

namespace Common.Packet
{
    internal class PacketProcessor
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            "PacketProcessor");

        public static void Invoke(HsrPacket message, Connection session)
        {
            try
            {
                var opcode = message.HsrHeader.CmdId;

                var (attribute, @delegate) = MessageFactory.Instance.GetMessageInformation((Opcode)opcode);
                if (attribute == null)
                {
#if DEBUG
                    Logger.Debug($"Received unhandled message {opcode}(0x{opcode:X})!");
#endif
                    return;
                }
#if DEBUG
                Logger.Debug($"Received message {opcode}(0x{opcode:X})!");
#endif
                @delegate.Invoke(session.mConnection, message.Data);
                return;
            }
            catch (Exception exception)
            {
                Logger.Error(exception.ToString());
                return;
            }
        }
    }
}