using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;
using Serilog;

namespace GameServer.Services
{
    public class ShopService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(ShopService));

        [Handler(Opcode.QueryProductInfoCsReq)]
        public static async Task OnQueryProductInfo(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.QueryProductInfoScRsp);
        }
    }
}