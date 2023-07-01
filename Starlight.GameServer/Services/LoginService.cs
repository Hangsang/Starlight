using Serilog;
using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;
using Starlight.Database.Repositories;
using static Starlight.Common.Constants;

namespace Starlight.GameServer.Services
{
    public class LoginService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(LoginService));

        [Handler(Opcode.PlayerGetTokenCsReq, SessionState.Ignored)]
        public static async ValueTask OnPlayerGetToken(Session connection, Memory<byte> payload)
        {
            //var cplrtoken = PlayerGetTokenCsReq.Parser.ParseFrom(payload.Span);
            //if (cplrtoken == null)
            //    return; //Won't work for now bcs broken http

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
        public static async ValueTask OnPlayerLogin(Session connection, Memory<byte> _)
        {
            var plr = connection.Player;

            await connection.SendAsync(
                Opcode.PlayerLoginScRsp,
                new PlayerLoginScRsp
                {
                    BasicInfo = plr.PlayerBasicInfo,
                    Stamina = plr.PlayerBasicInfo.Stamina
                });
        }

        [Handler(Opcode.GetLevelRewardTakenListCsReq)]
        public static async ValueTask OnGetLevelRewardTakenList(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.GetLevelRewardTakenListScRsp);
        }
    }
}