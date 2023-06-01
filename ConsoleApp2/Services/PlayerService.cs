using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Packet;

namespace Server.Services
{
    public class PlayerService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(PlayerService));

        [Handler(Opcode.GetPlayerBoardDataCsReq)]
        public static async Task OnGetPlayerBoardData(Session session, Memory<byte> _)
        {
            var boardRsp = new GetPlayerBoardDataScRsp();
            await session.SendAsync(Opcode.GetPlayerBoardDataScRsp, boardRsp);
        }

        [Handler(Opcode.GetDailyActiveInfoCsReq)]
        public static async Task OnGetDailyActiveInfo(Session session, Memory<byte> _)
        {
            var a = new GetDailyActiveInfoScRsp();
            await session.SendAsync(Opcode.GetDailyActiveInfoScRsp, a);
        }

        [Handler(Opcode.PlayerHeartbeatCsReq)]
        public static async Task OnPlayerHeartbeat(Session session, Memory<byte> payload)
        {
            var a = AKFEAADNDBM.Parser.ParseFrom(payload.Span);
            if (a == null) return;
#if DEBUG
            Logger.Debug($"Received HeartBeat C2S by {session.Address}");
#endif
            Logger.Information(a.ToString());
            await session.SendAsync(Opcode.PlayerHeartbeatScRsp,
                new LNLHNPDBEAD { NowMsTimeStamp = a.FGNIIAHNCCM, FOFKDPCKJOP = (ulong)DateTimeOffset.Now.ToUnixTimeSeconds(), IDLEBBNEPGA = new AAIBPJCPOIL() });
        }
    }
}