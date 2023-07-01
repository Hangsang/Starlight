using Serilog;
using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;

namespace Starlight.GameServer.Services
{
    public class GachaService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(GachaService));

        [Handler(Opcode.GetGachaInfoCsReq)]
        public static async ValueTask OnGetGachaInfo(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.GetGachaInfoScRsp);
        }
    }
}