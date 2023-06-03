using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Packet;

namespace Server.Services
{
    public class AvatarService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(AvatarService));

        [Handler(Opcode.GetAvatarDataCsReq)]
        public static async Task OnGetAvatarData(Session session, Memory<byte> _)
        {
            var av = new GetAvatarDataScRsp
            {
                APEAJOEOKGB = true
            };
            av.NLDDFJCAHIA.Add(new MODMGOPBHIM
            {
                BelongAvatarID = 1001,
                FirstMetTimeStamp = 1684660059,
                Level = 1,
            });
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

            av.NLDDFJCAHIA.Add(new MODMGOPBHIM
            {
                BelongAvatarID = 1006,
                FirstMetTimeStamp = 1684660059,
                Level = 80
            });

            await session.SendAsync(Opcode.GetAvatarDataScRsp, av);
        }
    }
}