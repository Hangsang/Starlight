using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;
using Serilog;

namespace GameServer.Services
{
    public class LineupService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(LineupService));

        [Handler(Opcode.GetAllLineupDataCsReq)]
        public static async Task OnGetAllLineupData(Session session, Memory<byte> _)
        {
            var line = new GetAllLineupDataScRsp();
            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            line.JKMFKKCEOIL[0].NLDDFJCAHIA.Add(new KAFAEJMPIPK
            {
                CharacterAvatarType = AvatarType.AvatarFormalType,
                Id = 1006,
                PEHLPPIINLH = 10000
            });
            line.JKMFKKCEOIL[0].NLDDFJCAHIA.Add(new KAFAEJMPIPK
            {
                Id = 1001,
                PEHLPPIINLH = 10000,
                Slot = 1
            });

            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                Index = 1,
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                Index = 2,
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                Index = 3,
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                Index = 4,
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            line.JKMFKKCEOIL.Add(new LLNCPDNOJJL
            {
                Index = 5,
                JMHCBMEHIGN = 3,
                MPNEADOMPJG = 3,
            });
            await session.SendAsync(Opcode.GetAllLineupDataScRsp, line);
        }

        [Handler(Opcode.GetCurLineupDataCsReq)]
        public static async Task OnGetCurLineupData(Session session, Memory<byte> _)
        {
            var lineupRsp = new GetCurLineupDataScRsp();
            await session.SendAsync(Opcode.GetCurLineupDataScRsp, lineupRsp);
        }
    }
}