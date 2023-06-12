using Common.Attributes;
using Common.Database.MongoDb.Repositories;
using Common.Network.Tcp;
using Common.Packet;
using Serilog;
using static Common.Unsorted.Constants;

namespace GameServer.Services
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

            connection.Player = plr;
            splrtoken.UID = plr.UID;

            await connection.SendAsync(Opcode.PlayerGetTokenScRsp, splrtoken);
        }

        [Handler(Opcode.PlayerLoginCsReq)]
        public static async Task OnPlayerLogin(Session connection, Memory<byte> _)
        {
            var plr = connection.Player;

            await connection.SendAsync(
                Opcode.PlayerLoginScRsp,
                new PlayerLoginScRsp
                {
                    PlayerInfo = plr.PlayerBasicInfo,
                    Stamina = plr.PlayerBasicInfo.Stamina,
                    Version = "4365933-V1.1Live",
                    Platform = "hoyoverse_PC",
                    CurTimezone = 1,
                    CurEpoch = (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                });
        }
    }
}