using Serilog;
using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;

namespace GameServer.Services
{
    public class PlayerService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(PlayerService));

        [Handler(Opcode.GetPlayerBoardDataCsReq)]
        public static async Task OnGetPlayerBoardData(Session session, Memory<byte> _)
        {
            var boardRsp = new GetPlayerBoardDataScRsp { HeadIconID = 201102, Signature = "OROSPU COCUGU", KDAJJKIIPLM = new NGBMENDMBIG(), ONMLBBNNHPK = 1102 };
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
            await session.SendAsync(Opcode.PlayerHeartbeatScRsp,
                new LNLHNPDBEAD { NowMsTimeStamp = a.FGNIIAHNCCM, FOFKDPCKJOP = (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds(), IDLEBBNEPGA = new AAIBPJCPOIL() });
        }
    }
}