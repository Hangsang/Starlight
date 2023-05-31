using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Unsorted;

namespace Server.Services
{
    public class RaidService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(RaidService));

        [Handler(Opcode.GetRaidInfoCsReq)]
        public static async Task OnGetRaidInfo(Session session, Memory<byte> _)
        {
            await session.SendAsync(Opcode.GetRaidInfoScRsp, new GetRaidInfoScRsp());
        }
    }
}