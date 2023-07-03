using Serilog;
using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;

namespace Starlight.GameServer.Services
{
    public class FriendService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(FriendService));

        [Handler(Opcode.GetFriendListInfoCsReq)]
        public static async ValueTask OnGetFriendListInfo(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.GetFriendListInfoScRsp);
        }
    }
}