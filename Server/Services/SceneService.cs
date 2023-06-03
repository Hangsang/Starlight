using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Packet;

namespace Server.Services
{
    public class SceneService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(SceneService));

        [Handler(Opcode.GetSpringRecoverDataCsReq)]
        public static async Task OnGetSpringRecoverData(Session session, Memory<byte> _)
        {
            var spring = new GetSpringRecoverDataScRsp
            {
                HGPHPJMOIHK = new HCMHCAPMDNO
                {
                    JLLDBGGMCOD = 1000,
                    OJFODJFDBOC = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                },

                JJPFKBLEJAF = new LCIKOENMNNP
                {
                    IsAutoRecover = true,
                    TotalRecoverPercentage = 10000
                }
            };

            await session.SendAsync(Opcode.GetSpringRecoverDataScRsp, spring);
        }

        [Handler(Opcode.GetCurSceneInfoCsReq)]
        public static async Task OnGetCurSceneInfo(Session session, Memory<byte> _)
        {
            var s = new GetCurSceneInfoScRsp
            {
                SceneInfo = new HCFBMEBDAEG()
            };

            s.SceneInfo.RaidGameMode = 2;
            s.SceneInfo.CPADEJILABD.AddRange(new uint[] { 105, 116, 26, 108, 38, 39, 21, 106, 99, 101, 16, 98, 100, 71, 31 });
            s.SceneInfo.CurMapEntryID = 2000301;
            s.SceneInfo.CurrWorldID = 101;
            s.SceneInfo.FloorID = 20003001;
            s.SceneInfo.HOCBBLHJJNI = 1;
            /*
            s.SceneInfo.IEKMNLCNKIM.Add(new SceneEntityInfo
            {
                Actor = new LDPLDBBEHFP { BelongAvatarID = 1001, CharacterAvatarType = AvatarType.AvatarFormalType },
                EntityId = 1050367,
                Motion = new OEFEOGHDJIO
                {
                    IBFIEOOEPOM = new NPLFPMKFPMD { EDIABGLFJEN = 262000 },
                    ONOEPJLAFJC = new NPLFPMKFPMD { EDIABGLFJEN = 1430, IsPatched = 15998, NNEGNBCLLEN = 3100 }
                }
            });
            */

            s.SceneInfo.JHNMDMEHBII = 1057779;
            s.SceneInfo.PlaneID = 20003;
            s.SceneInfo.OMGOOLPICCA.AddRange(new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

            await session.SendAsync(Opcode.GetCurSceneInfoScRsp, s);
        }

        [Handler(Opcode.GetCurBattleInfoCsReq)]
        public static async Task OnGetCurBattleInfo(Session session, Memory<byte> _)
        {
            await session.SendAsync(Opcode.GetCurBattleInfoScRsp, new GetCurBattleInfoScRsp { HPHIMJAJANJ = BattleEnd.Win, MEGJDKGGEOJ = new BOGGPAELPEP { WorldLevel = 6 }, PFBEFHCDPIP = 20003222 });
        }

        [Handler(Opcode.GetSceneMapInfoCsReq)]
        public static async Task OnGetSceneMapInfo(Session session, Memory<byte> _)
        {
            var mapInfo = new GetSceneMapInfoScRsp();
            mapInfo.FCAEFKDNDNB.AddRange(new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
            mapInfo.CurMapEntryID = 2000301;
            await session.SendAsync(Opcode.GetSceneMapInfoScRsp, mapInfo);
            //await session.SendAsync(Opcode.GetCurBattleInfoScRsp, new GetCurBattleInfoScRsp { HPHIMJAJANJ = BattleEnd.Win, MEGJDKGGEOJ = new BOGGPAELPEP { WorldLevel = 6 }, PFBEFHCDPIP = 20003222 });
        }
    }
}