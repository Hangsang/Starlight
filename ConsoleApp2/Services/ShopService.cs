using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Unsorted;

namespace Server.Services
{
    public class ShopService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(ShopService));

        [Handler(Opcode.QueryProductInfoCsReq)]
        public static async Task OnQueryProductInfo(TcpSession session, Memory<byte> _)
        {
            await session.SendAsync(Opcode.QueryProductInfoScRsp, new QueryProductInfoScRsp());

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
    }
}