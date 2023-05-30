using Serilog;
using Server.Network.TCP;
using Server.Packet;
using Server.Unsorted;

namespace Server.Network
{
    public class NetworkProcessor
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            "Processor");

        public static void Invoke(HsrPacket message, Connection session)
        {
            try
            {
                var opcode = message.HsrHeader.CmdId;

                var (attribute, @delegate) = MessageManager.Instance.GetMessageInformation((Opcode)opcode);
                if (attribute == null)
                {
                    //Logger.Warning($"Received unhandled message {opcode}(0x{opcode:X})!");
                    return;
                }

                //Logger.Information($"Received message {opcode}(0x{opcode:X})!");
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