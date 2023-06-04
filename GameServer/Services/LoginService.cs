using Serilog;
using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;
using Common.Database.MongoDb.Repositories;
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
                    BGONHENALMD = plr.PlayerBasicInfo,
                    Stamina = plr.PlayerBasicInfo.Stamina,
                    GHFMCFENPNF = "3967187-V1.0Live",
                    RegisterCPS = "hoyoverse_PC",
                    CurServerTimezone = 1,
                    ServerTimestampMs = (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                });
            await connection.SendAsync(Opcode.UpdateFeatureSwitchScNotify, new UpdateFeatureSwitchScNotify());
            await connection.SendAsync(Opcode.SyncServerSceneChangeNotify, new SyncServerSceneChangeNotify());
            await connection.SendAsync(Opcode.DailyTaskDataScNotify, new DailyTaskDataScNotify());
            await connection.SendAsync(Opcode.RaidInfoNotify, new RaidInfoNotify());
            await connection.SendAsync(Opcode.BattlePassInfoNotify,
                new BattlePassInfoNotify { BattlePassData = 1, PurchaseType = BpTierType.Premium2, Level = 69 });
        }

        [Handler(Opcode.GetLoginActivityCsReq)]
        public static async Task OnGetLoginActivity(Session session, Memory<byte> _)
        { await session.SendAsync(Opcode.GetLoginActivityScRsp, new GetLoginActivityScRsp()); }
    }
}