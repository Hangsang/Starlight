using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;
using Serilog;

namespace GameServer.Services
{
    public class BagService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(BagService));

        [Handler(Opcode.GetBagCsReq)]
        public static async Task OnGetBag(Session session, Memory<byte> _)
        {
            var bagRsp = new GetBagScRsp();
            bagRsp.GMPOJOGNPDI.Add(new KFCHDBDIPLK
            {
                MJFFFJOEPKJ = 102,
                Count = 1000000,
            });

            await session.SendAsync(Opcode.GetBagScRsp, bagRsp);
        }
    }
}