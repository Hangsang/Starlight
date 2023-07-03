using Serilog;
using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;

namespace Starlight.GameServer.Services
{
    public class RogueService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(RogueService));

        [Handler(Opcode.GetRogueScoreRewardInfoCsReq)]
        public static async ValueTask OnGetRogueScoreRewardInfo(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.GetRogueScoreRewardInfoScRsp);
        }

        [Handler(Opcode.GetRogueHandbookDataCsReq)]
        public static async ValueTask OnGetRogueHandBookData(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.GetRogueHandbookDataScRsp);
        }
    }
}