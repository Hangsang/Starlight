using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Unsorted;

namespace Server.Services
{
    public class MiscService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(MiscService));

        [Handler(Opcode.SyncClientResVersionCsReq)]
        public static async Task OnSyncClientResVersion(TcpSession session, Memory<byte> payload)
        {
            var p = SyncClientResVersionCsReq.Parser.ParseFrom(payload.Span);
            if (p == null) return;
            var v = new LNLMFFDHMOE
            {
                NFJLJJFLJKB = p.CMFAFDDBGFA
            };
            await session.SendAsync(Opcode.SyncClientResVersionScRsp, v);
        }
    }
}