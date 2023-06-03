using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Packet;

namespace Server.Services
{
    public class GachaService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(GachaService));

        [Handler(Opcode.GetGachaInfoCsReq)] //ToDo: From config
        public static async Task OnGetGachaInfo(Session session, Memory<byte> _)
        {
            var gachaInfo = new GetGachaInfoScRsp
            {
                RandomNum = 91
            };

            gachaInfo.MGFPBBAKOMI.Add(new GLIBDFCOMJJ
            {
                GachaID = 2003,
                HistoryURL = "https://google.com",
                EndTimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds() * 2
            });

            //gachaInfo.MGFPBBAKOMI[0].EDBGNPCFHBB.AddRange(new uint[] { 1001, 1202, 1204, 1206 }); //4 stars list
            gachaInfo.MGFPBBAKOMI[0].NFGHMBCIJCD.AddRange(new uint[] { 1102 }); //5 stars list

            await session.SendAsync(Opcode.GetGachaInfoScRsp, gachaInfo);
        }

        [Handler(Opcode.DoGachaReq)] //ToDo: proper gacha pull system
        public static async Task OnDoGacha(Session session, Memory<byte> payload)
        {
            var doGachaReq = DoGachaCsReq.Parser.ParseFrom(payload.Span);
            if (doGachaReq == null) return;
            //if (doGachaReq.Num != 1 || doGachaReq.Num != 10) return;
            Logger.Information(doGachaReq.ToString());
            var doGacha = new DoGachaScRsp
            {
                GachaID = doGachaReq.GachaID,
                MAADKKIJJOC = doGachaReq.RandomNum,
                Num = doGachaReq.Num
            };

            //var chars = new uint[] { 1206 };
            for (int i = 0; i < doGachaReq.Num; i++)
            {
                doGacha.MJDNKCHNADE.Add(new GKIGHAFBNBO
                {
                    ItemId = new Item { ItemId = 1102, Num = 1 },
                    ItemList = new ItemList(),
                    ItemList12 = new ItemList()
                });

                doGacha.MJDNKCHNADE[i].ItemList.ItemList_.Add(new Item { ItemId = 102, Num = 100 });
            }

            await session.SendAsync(Opcode.DoGachaScRsp, doGacha);
        }
    }
}