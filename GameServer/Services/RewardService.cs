using Serilog;
using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;

namespace GameServer.Services
{
    public class RewardService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(RewardService));

        [Handler(Opcode.GetLevelRewardTakenListCsReq)]
        public static async Task OnGetLevelRewardTakenList(Session session, Memory<byte> _)
        {
            await session.SendAsync(Opcode.GetLevelRewardTakenListScRsp, new GetLevelRewardTakenListScRsp());
        }
    }
}