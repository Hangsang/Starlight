using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;
using Serilog;

namespace GameServer.Services
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