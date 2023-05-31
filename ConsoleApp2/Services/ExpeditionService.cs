using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Unsorted;

namespace Server.Services
{
    public class ExpeditionService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(ExpeditionService));

        [Handler(Opcode.GetExpeditionDataCsReq)]
        public static async Task OnGetExpeditionData(TcpSession session, Memory<byte> _)
        {
            await session.SendAsync(Opcode.GetExpeditionDataScRsp, new GetExpeditionDataScRsp());
        }
    }
}