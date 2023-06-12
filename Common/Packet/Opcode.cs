namespace Common.Packet;

public enum Opcode : ushort
{
    None = 0,
    PlayerGetTokenCsReq = 87,
    PlayerGetTokenScRsp = 79,
    PlayerLoginCsReq = 69,
    PlayerLoginScRsp = 19,
    GetMissionStatusCsReq = 1206,
    GetMissionStatusScRsp = 1259,
    GetLevelRewardTakenListCsReq = 85,
    GetLevelRewardTakenListScRsp = 16,
    GetRogueInfoCsReq = 1856,
    GetGachaInfoCsReq = 1969,
    QueryProductInfoCsReq = 9,
    GetQuestDataCsReq = 969,
}