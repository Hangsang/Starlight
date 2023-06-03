using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Packet;

namespace Server.Services
{
    public class ExpeditionService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(ExpeditionService));

        [Handler(Opcode.GetExpeditionDataCsReq)]
        public static async Task OnGetExpeditionData(Session session, Memory<byte> _)
        {
            await session.SendAsync(Opcode.GetExpeditionDataScRsp, new GetExpeditionDataScRsp());
        }
    }
}