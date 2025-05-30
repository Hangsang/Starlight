// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: GetQuestDataScRsp.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from GetQuestDataScRsp.proto</summary>
public static partial class GetQuestDataScRspReflection {

  #region Descriptor
  /// <summary>File descriptor for GetQuestDataScRsp.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static GetQuestDataScRspReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChdHZXRRdWVzdERhdGFTY1JzcC5wcm90byJeChFHZXRRdWVzdERhdGFTY1Jz",
          "cBITCgtJSkZGTU1PTUxBQhgPIAEoDRIfCgtNREFOSktFR09ORhgFIAMoCzIK",
          "LlF1ZXN0RGF0YRITCgtCTk5PTUlCREhBQRgLIAEoDSJ7CglRdWVzdERhdGES",
          "HQoHX1N0YXR1cxgJIAEoDjIMLlF1ZXN0U3RhdHVzEhgKEF9DdXJyZW50UHJv",
          "Z3Jlc3MYAyABKA0SCgoCaWQYASABKA0SFAoMYWNoaWV2ZWRUaW1lGAQgASgD",
          "EhMKC0xBQlBMSUhQQk1CGAogAygNKmMKC1F1ZXN0U3RhdHVzEg4KClFVRVNU",
          "X05PTkUQABIPCgtRVUVTVF9ET0lORxABEhAKDFFVRVNUX0ZJTklTSBACEg8K",
          "C1FVRVNUX0NMT1NFEAMSEAoMUVVFU1RfREVMRVRFEARiBnByb3RvMw=="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(new[] {typeof(global::QuestStatus), }, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::GetQuestDataScRsp), global::GetQuestDataScRsp.Parser, new[]{ "IJFFMMOMLAB", "MDANJKEGONF", "BNNOMIBDHAA" }, null, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::QuestData), global::QuestData.Parser, new[]{ "Status", "CurrentProgress", "Id", "AchievedTime", "LABPLIHPBMB" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Enums
public enum QuestStatus {
  [pbr::OriginalName("QUEST_NONE")] QuestNone = 0,
  [pbr::OriginalName("QUEST_DOING")] QuestDoing = 1,
  [pbr::OriginalName("QUEST_FINISH")] QuestFinish = 2,
  [pbr::OriginalName("QUEST_CLOSE")] QuestClose = 3,
  [pbr::OriginalName("QUEST_DELETE")] QuestDelete = 4,
}

#endregion

#region Messages
public sealed partial class GetQuestDataScRsp : pb::IMessage<GetQuestDataScRsp>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<GetQuestDataScRsp> _parser = new pb::MessageParser<GetQuestDataScRsp>(() => new GetQuestDataScRsp());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<GetQuestDataScRsp> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::GetQuestDataScRspReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public GetQuestDataScRsp() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public GetQuestDataScRsp(GetQuestDataScRsp other) : this() {
    iJFFMMOMLAB_ = other.iJFFMMOMLAB_;
    mDANJKEGONF_ = other.mDANJKEGONF_.Clone();
    bNNOMIBDHAA_ = other.bNNOMIBDHAA_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public GetQuestDataScRsp Clone() {
    return new GetQuestDataScRsp(this);
  }

  /// <summary>Field number for the "IJFFMMOMLAB" field.</summary>
  public const int IJFFMMOMLABFieldNumber = 15;
  private uint iJFFMMOMLAB_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public uint IJFFMMOMLAB {
    get { return iJFFMMOMLAB_; }
    set {
      iJFFMMOMLAB_ = value;
    }
  }

  /// <summary>Field number for the "MDANJKEGONF" field.</summary>
  public const int MDANJKEGONFFieldNumber = 5;
  private static readonly pb::FieldCodec<global::QuestData> _repeated_mDANJKEGONF_codec
      = pb::FieldCodec.ForMessage(42, global::QuestData.Parser);
  private readonly pbc::RepeatedField<global::QuestData> mDANJKEGONF_ = new pbc::RepeatedField<global::QuestData>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<global::QuestData> MDANJKEGONF {
    get { return mDANJKEGONF_; }
  }

  /// <summary>Field number for the "BNNOMIBDHAA" field.</summary>
  public const int BNNOMIBDHAAFieldNumber = 11;
  private uint bNNOMIBDHAA_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public uint BNNOMIBDHAA {
    get { return bNNOMIBDHAA_; }
    set {
      bNNOMIBDHAA_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as GetQuestDataScRsp);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(GetQuestDataScRsp other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (IJFFMMOMLAB != other.IJFFMMOMLAB) return false;
    if(!mDANJKEGONF_.Equals(other.mDANJKEGONF_)) return false;
    if (BNNOMIBDHAA != other.BNNOMIBDHAA) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (IJFFMMOMLAB != 0) hash ^= IJFFMMOMLAB.GetHashCode();
    hash ^= mDANJKEGONF_.GetHashCode();
    if (BNNOMIBDHAA != 0) hash ^= BNNOMIBDHAA.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    mDANJKEGONF_.WriteTo(output, _repeated_mDANJKEGONF_codec);
    if (BNNOMIBDHAA != 0) {
      output.WriteRawTag(88);
      output.WriteUInt32(BNNOMIBDHAA);
    }
    if (IJFFMMOMLAB != 0) {
      output.WriteRawTag(120);
      output.WriteUInt32(IJFFMMOMLAB);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    mDANJKEGONF_.WriteTo(ref output, _repeated_mDANJKEGONF_codec);
    if (BNNOMIBDHAA != 0) {
      output.WriteRawTag(88);
      output.WriteUInt32(BNNOMIBDHAA);
    }
    if (IJFFMMOMLAB != 0) {
      output.WriteRawTag(120);
      output.WriteUInt32(IJFFMMOMLAB);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (IJFFMMOMLAB != 0) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(IJFFMMOMLAB);
    }
    size += mDANJKEGONF_.CalculateSize(_repeated_mDANJKEGONF_codec);
    if (BNNOMIBDHAA != 0) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(BNNOMIBDHAA);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(GetQuestDataScRsp other) {
    if (other == null) {
      return;
    }
    if (other.IJFFMMOMLAB != 0) {
      IJFFMMOMLAB = other.IJFFMMOMLAB;
    }
    mDANJKEGONF_.Add(other.mDANJKEGONF_);
    if (other.BNNOMIBDHAA != 0) {
      BNNOMIBDHAA = other.BNNOMIBDHAA;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 42: {
          mDANJKEGONF_.AddEntriesFrom(input, _repeated_mDANJKEGONF_codec);
          break;
        }
        case 88: {
          BNNOMIBDHAA = input.ReadUInt32();
          break;
        }
        case 120: {
          IJFFMMOMLAB = input.ReadUInt32();
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 42: {
          mDANJKEGONF_.AddEntriesFrom(ref input, _repeated_mDANJKEGONF_codec);
          break;
        }
        case 88: {
          BNNOMIBDHAA = input.ReadUInt32();
          break;
        }
        case 120: {
          IJFFMMOMLAB = input.ReadUInt32();
          break;
        }
      }
    }
  }
  #endif

}

public sealed partial class QuestData : pb::IMessage<QuestData>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<QuestData> _parser = new pb::MessageParser<QuestData>(() => new QuestData());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<QuestData> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::GetQuestDataScRspReflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public QuestData() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public QuestData(QuestData other) : this() {
    Status_ = other.Status_;
    CurrentProgress_ = other.CurrentProgress_;
    id_ = other.id_;
    achievedTime_ = other.achievedTime_;
    lABPLIHPBMB_ = other.lABPLIHPBMB_.Clone();
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public QuestData Clone() {
    return new QuestData(this);
  }

  /// <summary>Field number for the "_Status" field.</summary>
  public const int StatusFieldNumber = 9;
  private global::QuestStatus Status_ = global::QuestStatus.QuestNone;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public global::QuestStatus Status {
    get { return Status_; }
    set {
      Status_ = value;
    }
  }

  /// <summary>Field number for the "_CurrentProgress" field.</summary>
  public const int CurrentProgressFieldNumber = 3;
  private uint CurrentProgress_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public uint CurrentProgress {
    get { return CurrentProgress_; }
    set {
      CurrentProgress_ = value;
    }
  }

  /// <summary>Field number for the "id" field.</summary>
  public const int IdFieldNumber = 1;
  private uint id_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public uint Id {
    get { return id_; }
    set {
      id_ = value;
    }
  }

  /// <summary>Field number for the "achievedTime" field.</summary>
  public const int AchievedTimeFieldNumber = 4;
  private long achievedTime_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long AchievedTime {
    get { return achievedTime_; }
    set {
      achievedTime_ = value;
    }
  }

  /// <summary>Field number for the "LABPLIHPBMB" field.</summary>
  public const int LABPLIHPBMBFieldNumber = 10;
  private static readonly pb::FieldCodec<uint> _repeated_lABPLIHPBMB_codec
      = pb::FieldCodec.ForUInt32(82);
  private readonly pbc::RepeatedField<uint> lABPLIHPBMB_ = new pbc::RepeatedField<uint>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<uint> LABPLIHPBMB {
    get { return lABPLIHPBMB_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as QuestData);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(QuestData other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Status != other.Status) return false;
    if (CurrentProgress != other.CurrentProgress) return false;
    if (Id != other.Id) return false;
    if (AchievedTime != other.AchievedTime) return false;
    if(!lABPLIHPBMB_.Equals(other.lABPLIHPBMB_)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (Status != global::QuestStatus.QuestNone) hash ^= Status.GetHashCode();
    if (CurrentProgress != 0) hash ^= CurrentProgress.GetHashCode();
    if (Id != 0) hash ^= Id.GetHashCode();
    if (AchievedTime != 0L) hash ^= AchievedTime.GetHashCode();
    hash ^= lABPLIHPBMB_.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Id != 0) {
      output.WriteRawTag(8);
      output.WriteUInt32(Id);
    }
    if (CurrentProgress != 0) {
      output.WriteRawTag(24);
      output.WriteUInt32(CurrentProgress);
    }
    if (AchievedTime != 0L) {
      output.WriteRawTag(32);
      output.WriteInt64(AchievedTime);
    }
    if (Status != global::QuestStatus.QuestNone) {
      output.WriteRawTag(72);
      output.WriteEnum((int) Status);
    }
    lABPLIHPBMB_.WriteTo(output, _repeated_lABPLIHPBMB_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Id != 0) {
      output.WriteRawTag(8);
      output.WriteUInt32(Id);
    }
    if (CurrentProgress != 0) {
      output.WriteRawTag(24);
      output.WriteUInt32(CurrentProgress);
    }
    if (AchievedTime != 0L) {
      output.WriteRawTag(32);
      output.WriteInt64(AchievedTime);
    }
    if (Status != global::QuestStatus.QuestNone) {
      output.WriteRawTag(72);
      output.WriteEnum((int) Status);
    }
    lABPLIHPBMB_.WriteTo(ref output, _repeated_lABPLIHPBMB_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (Status != global::QuestStatus.QuestNone) {
      size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Status);
    }
    if (CurrentProgress != 0) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(CurrentProgress);
    }
    if (Id != 0) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Id);
    }
    if (AchievedTime != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(AchievedTime);
    }
    size += lABPLIHPBMB_.CalculateSize(_repeated_lABPLIHPBMB_codec);
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(QuestData other) {
    if (other == null) {
      return;
    }
    if (other.Status != global::QuestStatus.QuestNone) {
      Status = other.Status;
    }
    if (other.CurrentProgress != 0) {
      CurrentProgress = other.CurrentProgress;
    }
    if (other.Id != 0) {
      Id = other.Id;
    }
    if (other.AchievedTime != 0L) {
      AchievedTime = other.AchievedTime;
    }
    lABPLIHPBMB_.Add(other.lABPLIHPBMB_);
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 8: {
          Id = input.ReadUInt32();
          break;
        }
        case 24: {
          CurrentProgress = input.ReadUInt32();
          break;
        }
        case 32: {
          AchievedTime = input.ReadInt64();
          break;
        }
        case 72: {
          Status = (global::QuestStatus) input.ReadEnum();
          break;
        }
        case 82:
        case 80: {
          lABPLIHPBMB_.AddEntriesFrom(input, _repeated_lABPLIHPBMB_codec);
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 8: {
          Id = input.ReadUInt32();
          break;
        }
        case 24: {
          CurrentProgress = input.ReadUInt32();
          break;
        }
        case 32: {
          AchievedTime = input.ReadInt64();
          break;
        }
        case 72: {
          Status = (global::QuestStatus) input.ReadEnum();
          break;
        }
        case 82:
        case 80: {
          lABPLIHPBMB_.AddEntriesFrom(ref input, _repeated_lABPLIHPBMB_codec);
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code
