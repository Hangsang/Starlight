namespace Common.Packet;

public enum Opcode : ushort
{
    None = 0,
    ClientDownloadDataNotify = 64,
    BattlePassInfoNotify = 3069,
    PlayerGetTokenCsReq = 87,
    PlayerGetTokenScRsp = 79,
    PlayerLoginCsReq = 69,
    PlayerLoginScRsp = 19,
    GetMissionStatusCsReq = 1206,
    GetMissionStatusScRsp = 1259,
    GetLevelRewardTakenListCsReq = 85,
    GetLevelRewardTakenListScRsp = 16,
    GetRogueScoreRewardInfoCsReq = 1856,
    GetRogueScoreRewardInfoScRsp = 1803,
    GetGachaInfoCsReq = 1969,
    GetGachaInfoScRsp = 1919,
    QueryProductInfoCsReq = 9,
    QueryProductInfoScRsp = 98,
    GetQuestDataCsReq = 969,
    GetQuestDataScRsp = 919,
    GetQuestRecordCsReq = 988,
    GetQuestRecordScRsp = 999,
    CurSceneInfoReq = 1488,
    CurSceneInfoRsp = 1499,
    CurBattleInfoCsReq = 187,
    CurBattleInfoScRsp = 179,
    GetAvatarDataCsReq = 369,
    GetAvatarDataScRsp = 319,
    GetAllLineupCsReq = 706,
    GetAllLineupScRsp = 759,
    GetCurLineupCsReq = 739,
    GetCurLineupScRsp = 784,
    FriendListScRsp = 2919
}

/*
 * "739": "GetCurLineupDataCsReq",
  "784": "GetCurLineupDataScRsp",

  "706": "GetAllLineupDataCsReq",
  "759": "GetAllLineupDataScRsp",
*/