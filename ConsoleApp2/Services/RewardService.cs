using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Unsorted;

namespace Server.Services
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