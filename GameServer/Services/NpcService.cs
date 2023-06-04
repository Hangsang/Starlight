using Serilog;
using Common.Attributes;
using Common.Network.Tcp;
using Common.Packet;

namespace GameServer.Services
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