using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;
using Serilog;

namespace GameServer.Services
{
    public class TutorialService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(TutorialService));

        [Handler(Opcode.GetTutorialCsReq)]
        private static async Task OnGetTutorial(Session session, Memory<byte> _)
        {
            //Guide menu shit
        }

        [Handler(Opcode.GetTutorialGuideCsReq)]
        private static async Task OnGetTutorialGuide(Session session, Memory<byte> _)
        {
            var tutorial = new GetTutorialGuideScRsp();
            await session.SendAsync(Opcode.GetTutorialGuideScRsp, tutorial);
        }

        [Handler(Opcode.UnlockTutorialGuideCsReq)]
        private static async Task OnUnlockTutorialGuide(Session session, Memory<byte> payload)
        {
            var unlockTut = UnlockTutorialGuideCsReq.Parser.ParseFrom(payload.Span);
            if (unlockTut == null) return;

            var b = new UnlockTutorialGuideScRsp
            {
                TutorialGuide = new TutorialGuide()
            };
            b.TutorialGuide.Status = TutorialStatus.TutorialFinish;
            b.TutorialGuide.Id = unlockTut.GroupID;
            await session.SendAsync(Opcode.UnlockTutorialGuideScRsp, b);
        }

        [Handler(Opcode.FinishTutorialGuideCsReq)]
        public static async Task OnFinishTutorialGuide(Session session, Memory<byte> payload)
        {
            var finishTutGuide = FinishTutorialGuideCsReq.Parser.ParseFrom(payload.Span);
            if (finishTutGuide == null) return;

            var _b = new FinishTutorialGuideScRsp
            {
                Reward = new ItemList(),
                TutorialGuide = new TutorialGuide()
            };

            _b.TutorialGuide.Id = finishTutGuide.GroupID;
            _b.TutorialGuide.Status = TutorialStatus.TutorialFinish;
            _b.Reward.ItemList_.Add(new Item { ItemId = 1, Num = 1 });
            await session.SendAsync(Opcode.FinishTutorialGuideScRsp, _b);
        }
    }
}