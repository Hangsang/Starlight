using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Packet;

namespace Server.Services
{
    public class ChallengeService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(ChallengeService));

        [Handler(Opcode.GetChallengeCsReq)]
        public static async Task OnGetChallenge(Session session, Memory<byte> _)
        {
            await session.SendAsync(Opcode.GetChallengeScRsp, new GetChallengeScRsp());
        }
    }
}