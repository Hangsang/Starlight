using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Unsorted;

namespace Server.Services
{
    public class BagService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(BagService));

        [Handler(Opcode.GetBagCsReq)]
        public static async Task OnGetBag(TcpSession session, Memory<byte> _)
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