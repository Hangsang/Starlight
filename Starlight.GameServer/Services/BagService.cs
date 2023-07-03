using Serilog;
using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;

namespace Starlight.GameServer.Services
{
    public class BagService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(BagService));

        [Handler(Opcode.GetBagCsReq)]
        public static async ValueTask OnGetFriendListInfo(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.GetBagScRsp);
        }
    }
}