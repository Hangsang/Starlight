using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;
using Serilog;

namespace GameServer.Services
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