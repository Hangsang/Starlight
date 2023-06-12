using Amazon.Runtime.Internal;
using Common.Attributes;
using Common.Database.MongoDb.Repositories;
using Common.Network.Tcp;
using Common.Packet;
using Serilog;
using static Common.Unsorted.Constants;

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
            await session.SendCmdId(Opcode.GetRogueScoreRewardInfoScRsp);
        }
    }
}