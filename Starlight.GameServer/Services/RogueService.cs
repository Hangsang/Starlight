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
        public static async Task OnGetRogueScoreRewardInfo(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.GetRogueScoreRewardInfoScRsp);
        }
    }
}