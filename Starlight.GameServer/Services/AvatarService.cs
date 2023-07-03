using Serilog;
using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;

namespace Starlight.GameServer.Services
{
    public class AvatarService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(AvatarService));

        [Handler(Opcode.GetAvatarDataCsReq)]
        public static async ValueTask OnGetFriendListInfo(Session session, Memory<byte> _)
        {
            var chars = new uint[] {1001,1002,1003,1004,1005,1006,1008,1009,1013,
            1101,1102,1103,1104,1105,1106,1107,1108,1109,1201,1202,1203,1204,1206,1209,1211,8001,8002,8003,8004};

            var av = new GetAvatarDataScRsp
            {
                IsAll = true
            };

            for (int i = 0; i < chars.Length; i++)
            {
                av.AvatarList.Add(new Avatar
                { 
                    BaseAvatarId = chars[i],
                    FirstMetTimeStamp = (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 999,
                    Level = 90,
                    Rank = 6, //Eidolon
                });
            }

            await session.SendAsync(Opcode.GetAvatarDataScRsp, av);
        }
    }
}