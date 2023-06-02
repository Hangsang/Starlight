using Serilog;
using Server.Attributes;
using Server.Network.TCP;
using Server.Packet;

namespace Server.Services
{
    public class MissionService
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(MissionService));

        [Handler(Opcode.GetMissionStatusCsReq)]
        public static async Task OnGetMissionStatus(Session session, Memory<byte> payload)
        {
            var request = GetMissionStatusCsReq.Parser.ParseFrom(payload.Span);
            if (request == null)
            {
                Logger.Error("Could not parse data of GetMissionStatusCsReq");
                return;
            }

            var response = new GetMissionStatusScRsp();
            foreach (var _sub in request.SubMissions)
            {
                response.SubMissionStatusList.Add(new MissionData { Id = _sub, Status = MissionStatus.MissionFinish });
            }
            foreach (var _event in request.EventMissions)
            {
                response.MissionEventStatusList.Add(new MissionData { Id = _event, Status = MissionStatus.MissionFinish });
            }
            foreach (var _unfinish in request.UnFinishedMissions)
            {
                response.FinishedMainMissionIdList.Add(_unfinish);
            }

            await session.SendAsync(Opcode.GetMissionStatusScRsp, response);
        }

        [Handler(Opcode.GetMissionEventDataCsReq)]
        public static Task OnGetMissionEventData(Session session, Memory<byte> _)
        {
            return session.SendAsync(Opcode.GetMissionEventDataScRsp, new GetMissionEventDataScRsp());
        }
    }
}