using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;
using Serilog;

namespace GameServer.Services
{
    public class RogueService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(RogueService));

        [Handler(Opcode.GetRogueScoreRewardInfoCsReq)]
        public static async Task OnGetRogueScoreRewardInfo(Session session, Memory<byte> _)
        {
            var b = new GetRogueScoreRewardInfoScRsp
            {
                ELBKFCDJPGF = new IMLOGEMOJMI
                {
                    HasTakenInitialScore = true,
                    PoolID = 23,
                    PoolRefreshed = true
                }
            };
            await session.SendAsync(Opcode.GetRogueScoreRewardInfoScRsp, b);
        }

        [Handler(Opcode.GetRogueInfoCsReq)]
        public static async Task OnGetRogueInfo(Session session, Memory<byte> _)
        {
            await session.SendAsync(Opcode.GetRogueInfoScRsp, new GetRogueInfoScRsp());
        }
    }
}