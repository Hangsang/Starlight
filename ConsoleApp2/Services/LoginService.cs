using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Unsorted;
using static Server.Unsorted.Constants;

namespace Server.Services
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
            if (cplrtoken == null) return;

            var splrtoken = new PlayerGetTokenScRsp { UID = 1 };
#if DEBUG
            Logger.Debug(cplrtoken.PPIEAKOMAKD);
            Logger.Debug(splrtoken.ToString());
#endif
            await connection.SendAsync(Opcode.PlayerGetTokenScRsp, splrtoken);
        }

        [Handler(Opcode.PlayerLoginCsReq)]
        public static async Task OnPlayerLogin(Session connection, Memory<byte> _)
        {
            await connection.SendAsync(
                Opcode.PlayerLoginScRsp,
                new PlayerLoginScRsp
                {
                    BGONHENALMD = new BEPIDFNIMLN { NickName = "Hang", Level = 70, HCoin = 10000, SCoin = 10000, WorldLevel = 6 },
                    Stamina = 180,
                    GHFMCFENPNF = "3967187-V1.0Live",
                    RegisterCPS = "hoyoverse_PC",
                    CurServerTimezone = 1,
                    ServerLoginRandomNum = 7235863151202677137,
                    ServerTimestampMs = (ulong)DateTimeOffset.Now.ToUnixTimeSeconds()
                }
            );
#if DEBUG
            await connection.SendAsync(Opcode.UpdateFeatureSwitchScNotify, new UpdateFeatureSwitchScNotify());
            //await connection.SendAsync(Opcode.SyncServerSceneChangeNotify, new SyncServerSceneChangeNotify());
            await connection.SendAsync(Opcode.DailyTaskDataScNotify, new DailyTaskDataScNotify());
            await connection.SendAsync(Opcode.RaidInfoNotify, new RaidInfoNotify());
#endif
            await connection.SendAsync(Opcode.BattlePassInfoNotify, new BattlePassInfoNotify { BattlePassData = 1, PurchaseType = BpTierType.Premium2, Level = 69 });
        }

        [Handler(Opcode.GetLoginActivityCsReq)]
        public static async Task OnGetLoginActivity(Session session, Memory<byte> _)
        {
            await session.SendAsync(Opcode.GetLoginActivityScRsp, new GetLoginActivityScRsp());
        }
    }
}