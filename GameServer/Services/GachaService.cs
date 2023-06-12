using Amazon.Runtime.Internal;
using Common.Attributes;
using Common.Database.MongoDb.Repositories;
using Common.Network.Tcp;
using Common.Packet;
using Serilog;
using static Common.Unsorted.Constants;

namespace GameServer.Services
{
    public class GachaService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(GachaService));

        [Handler(Opcode.GetGachaInfoCsReq)]
        public static async Task OnGetGachaInfo(Session session, Memory<byte> _)
        {
            await session.SendCmdId(Opcode.GetGachaInfoScRsp);
        }
    }
}