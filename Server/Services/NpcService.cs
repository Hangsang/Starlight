using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Packet;

namespace Server.Services
{
    public class NpcService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(NpcService));

        [Handler(Opcode.GetNpcStatusCsReq)]
        public static async Task OnGetNpcStatus(Session session, Memory<byte> _)
        {
            await session.SendAsync(Opcode.GetNpcStatusScRsp, new GetNpcStatusScRsp());
        }

        [Handler(Opcode.GetNpcMessageGroupCsReq)]
        public static async Task OnGetNpcMessageGroup(Session session, Memory<byte> _)
        {
            await session.SendAsync(Opcode.GetNpcMessageGroupScRsp, new GetNpcMessageGroupScRsp());
        }
    }
}