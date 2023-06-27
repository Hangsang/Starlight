using Serilog;
using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;
using Starlight.Database.Repositories;
using static Starlight.Common.Unsorted.Constants;

namespace Starlight.GameServer.Services
{
    public class LoginService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(LoginService));

        [Handler(Opcode.PlayerGetTokenCsReq, SessionState.Ignored)]
        public static async Task OnPlayerGetToken(Session connection, Memory<byte> payload)
        {
            var cplrtoken = PlayerGetTokenCsReq.Parser.ParseFrom(payload.Span);
            if (cplrtoken == null)
                return;

            var plr = await PlayerRepository.FirstOrDefault(x => x.UID == 1);
            if (plr == null)
                return;

            var splrtoken = new PlayerGetTokenScRsp();
            if (plr.Banned)
                splrtoken.MValue = 1013;

            connection.mPlayer = plr;
            splrtoken.UID = plr.UID;

            await connection.SendAsync(Opcode.PlayerGetTokenScRsp, splrtoken);
        }

        [Handler(Opcode.PlayerLoginCsReq)]
        public static async Task OnPlayerLogin(Session connection, Memory<byte> _)
        {
            var plr = connection.mPlayer;

            await connection.SendAsync(
                Opcode.PlayerLoginScRsp,
                new PlayerLoginScRsp
                {
                    PlayerInfo = plr.PlayerBasicInfo,
                    Stamina = plr.PlayerBasicInfo.Stamina,
#if DEBUG
                    Version = "4365933-V1.1Live",
                    Platform = "hoyoverse_PC",
                    CurTimezone = 1,
                    CurEpoch = (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds()
#endif
                });
        }

        [Handler(Opcode.GetLevelRewardTakenListCsReq)]
        public static async Task OnGetLevelRewardTakenList(Session session, Memory<byte> _)
        {
            //await session.SendCmdId(Opcode.GetLevelRewardTakenListScRsp);
        }
    }
}