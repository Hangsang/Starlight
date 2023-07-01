using Serilog;
using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;

namespace Starlight.GameServer.Services
{
    public class ShopService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(ShopService));

        [Handler(Opcode.QueryProductInfoCsReq)]
        public static async ValueTask OnQueryProductInfo(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.QueryProductInfoScRsp);
        }
    }
}