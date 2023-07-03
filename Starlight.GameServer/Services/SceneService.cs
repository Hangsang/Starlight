using Serilog;
using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;

namespace Starlight.GameServer.Services
{
    public class SceneService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(SceneService));

        [Handler(Opcode.GetCurSceneInfoCsReq)]
        public static async ValueTask OnGetCurSceneInfo(Session session, Memory<byte> _)
        {
            var curScene = new GetCurSceneInfoScRsp();
            curScene.Scene = new SceneInfo
            {
                LCGHLPHIFEN = 7,
                PlaneId = 80112,
                EntryId = 801120102,
                FloorId = 80112001,
                OCMEFFIFKCF = 101, //worldid
                LeaderEntityId = 1051970,
                HJDDKNECMGL = 1
            };

            curScene.Scene.LightenSectionList.AddRange(new uint[] { 10, 9, 5, 7, 13 });
            curScene.Scene.KPHDHAKGIKN = new IEGJCHIKMKK();
            await session.SendAsync(Opcode.GetCurSceneInfoScRsp, curScene);
        }

        [Handler(Opcode.PlayerLoginFinishCsReq)]
        public static async ValueTask OnPlayerLoginFinish(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.PlayerLoginFinishScRsp);
        }

        [Handler(Opcode.GetCurBattleInfoCsReq)]
        public static async ValueTask OnGetCurBattleInfo(Session session, Memory<byte> _)
        {
            var curBattle = new GetCurBattleInfoScRsp();
            curBattle.LastEndStatus = BattleEndStatus.BattleEndWin;
            curBattle.BattleInfo = new SceneBattleInfo();
            curBattle.BattleInfo.KPHDHAKGIKN = new BLGCOGOCOBE();
            curBattle.BattleInfo.WorldLevel = 6;
            curBattle.StageId = 80130021;
            await session.SendAsync(Opcode.GetCurBattleInfoScRsp, curBattle);
        }
    }
}