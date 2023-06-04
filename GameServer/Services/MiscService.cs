using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;
using Serilog;

namespace GameServer.Services
{
    public class MiscService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(MiscService));

        [Handler(Opcode.SyncClientResVersionCsReq)]
        public static async Task OnSyncClientResVersion(Session session, Memory<byte> payload)
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