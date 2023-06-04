using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;

namespace GameServer.Services
{
    public class AvatarService
    {
        [Handler(Opcode.GetAvatarDataCsReq)]
        public static async Task OnGetAvatarData(Session session, Memory<byte> _)
        {
            var chars = new uint[] {1001,1002,1003,1004,1005,1006,1008,1009,1013,
            1101,1102,1103,1104,1105,1106,1107,1108,1109,1201,1202,1203,1204,1206,1209,1211,8001,8002,8003,8004};

            var av = new GetAvatarDataScRsp
            {
                APEAJOEOKGB = true
            };

            for (int i = 0; i < chars.Length; i++)
            {
                av.NLDDFJCAHIA.Add(new MODMGOPBHIM
                {
                    BelongAvatarID = chars[i],
                    FirstMetTimeStamp = (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 999,
                    Level = 90,
                    Rank = 6, //Eidolon,
                    CurrentExp = 0,
                    EquipmentUID = 0,
                    Promotion = 0
                });
            }

            /*
            //Traces
            av.NLDDFJCAHIA[0].NMDCNDKFKNO.Add(new FMBNCLLOGPO
            {
                Level = 1,
                PointID = 1001001
            });
            av.NLDDFJCAHIA[0].NMDCNDKFKNO.Add(new FMBNCLLOGPO
            {
                Level = 1,
                PointID = 1001002
            });
            av.NLDDFJCAHIA[0].NMDCNDKFKNO.Add(new FMBNCLLOGPO
            {
                Level = 1,
                PointID = 1001003
            });
            av.NLDDFJCAHIA[0].NMDCNDKFKNO.Add(new FMBNCLLOGPO
            {
                Level = 1,
                PointID = 1001004
            });
            av.NLDDFJCAHIA[0].NMDCNDKFKNO.Add(new FMBNCLLOGPO
            {
                Level = 1,
                PointID = 1001007
            });
            */

            await session.SendAsync(Opcode.GetAvatarDataScRsp, av);
        }
    }
}