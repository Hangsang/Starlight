using Serilog;
using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;

namespace Starlight.GameServer.Services
{
    public class LineupService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(LineupService));

        [Handler(Opcode.GetAllLineupCsReq)]
        public static async ValueTask OnGetAllLineup(Session session, Memory<byte> _)
        {
            var line = new GetAllLineupDataScRsp();
            line.LineupList.Add(new LineupInfo
            {
                Index = 1,
                OFBGPOAIAJL = 3,
                MGOBBGBBFJF = 3,
                LeaderSlot = 3
            });

            line.LineupList[0].AvatarList.Add(new LineupAvatar
            {
                AvatarType = AvatarType.AvatarFormalType,
                Id = 1006,
                Hp = 10000
            });

            line.LineupList[0].AvatarList.Add(new LineupAvatar
            {
                Slot = 1,
                Id = 1001,
                Hp = 10000
            });

            line.LineupList.Add(new LineupInfo
            {
                Index = 2,
                OFBGPOAIAJL = 3,
                MGOBBGBBFJF = 3,
                LeaderSlot = 3
            });

            line.LineupList.Add(new LineupInfo
            {
                Index = 3,
                OFBGPOAIAJL = 3,
                MGOBBGBBFJF = 3,
                LeaderSlot = 3
            });

            line.LineupList.Add(new LineupInfo
            {
                Index = 4,
                OFBGPOAIAJL = 3,
                MGOBBGBBFJF = 3,
                LeaderSlot = 3
            });

            line.LineupList.Add(new LineupInfo
            {
                Index = 5,
                OFBGPOAIAJL = 3,
                MGOBBGBBFJF = 3,
                LeaderSlot = 3
            });

            await session.SendAsync(Opcode.GetAllLineupScRsp, line);
        }

        [Handler(Opcode.GetCurLineupCsReq)]
        public static async ValueTask OnGetCurLineup(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.GetCurLineupScRsp);
        }
    }
}