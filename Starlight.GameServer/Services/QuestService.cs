using Serilog;
using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;

namespace Starlight.GameServer.Services
{
    public class QuestService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(QuestService));

        [Handler(Opcode.GetQuestDataCsReq)]
        public static async ValueTask OnGetQuestData(Session session, Memory<byte> _)
        {
            var a = new GetQuestDataScRsp();
            a.MDANJKEGONF.Add(new QuestData
            {
                CurrentProgress = 1,
                AchievedTime = 1684181546,
                Id = 4040702,
                Status = QuestStatus.QuestClose
            });
            await session.SendAsync(Opcode.GetQuestDataScRsp, a);
        }

        [Handler(Opcode.GetQuestRecordCsReq)]
        public static async ValueTask OnGetQuestRecord(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.GetQuestRecordScRsp);
        }
    }
}