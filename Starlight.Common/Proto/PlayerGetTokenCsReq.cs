// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: PlayerGetTokenCsReq.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from PlayerGetTokenCsReq.proto</summary>
public static partial class PlayerGetTokenCsReqReflection {

  #region Descriptor
  /// <summary>File descriptor for PlayerGetTokenCsReq.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static PlayerGetTokenCsReqReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChlQbGF5ZXJHZXRUb2tlbkNzUmVxLnByb3RvIrYBChNQbGF5ZXJHZXRUb2tl",
          "bkNzUmVxEhEKCWNoYW5uZWxJRBgDIAEoDRINCgVUb2tlbhgBIAEoCRITCgtP",
          "UEZOT0xKQ0NKTBgGIAEoDRITCgtEQk5GT0tDSUtLTBgNIAEoDRIUCgxob3lv",
          "dmVyc2VVSUQYDCABKAkSEwoLSEJJSkdEQkFLRUoYDyABKA0SEwoLSkFNQk9D",
          "SU9QSksYBSABKA0SEwoLTUVCQkpDRUVLSkwYCSABKAliBnByb3RvMw=="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::PlayerGetTokenCsReq), global::PlayerGetTokenCsReq.Parser, new[]{ "ChannelID", "Token", "OPFNOLJCCJL", "DBNFOKCIKKL", "HoyoverseUID", "HBIJGDBAKEJ", "JAMBOCIOPJK", "MEBBJCEEKJL" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class PlayerGetTokenCsReq : pb::IMessage<PlayerGetTokenCsReq>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<PlayerGetTokenCsReq> _parser = new pb::MessageParser<PlayerGetTokenCsReq>(() => new PlayerGetTokenCsReq());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<PlayerGetTokenCsReq> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::PlayerGetTokenCsReqReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public PlayerGetTokenCsReq() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public PlayerGetTokenCsReq(PlayerGetTokenCsReq other) : this() {
    channelID_ = other.channelID_;
    token_ = other.token_;
    oPFNOLJCCJL_ = other.oPFNOLJCCJL_;
    dBNFOKCIKKL_ = other.dBNFOKCIKKL_;
    hoyoverseUID_ = other.hoyoverseUID_;
    hBIJGDBAKEJ_ = other.hBIJGDBAKEJ_;
    jAMBOCIOPJK_ = other.jAMBOCIOPJK_;
    mEBBJCEEKJL_ = other.mEBBJCEEKJL_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public PlayerGetTokenCsReq Clone() {
    return new PlayerGetTokenCsReq(this);
  }

  /// <summary>Field number for the "channelID" field.</summary>
  public const int ChannelIDFieldNumber = 3;
  private uint channelID_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public uint ChannelID {
    get { return channelID_; }
    set {
      channelID_ = value;
    }
  }

  /// <summary>Field number for the "Token" field.</summary>
  public const int TokenFieldNumber = 1;
  private string token_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Token {
    get { return token_; }
    set {
      token_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "OPFNOLJCCJL" field.</summary>
  public const int OPFNOLJCCJLFieldNumber = 6;
  private uint oPFNOLJCCJL_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public uint OPFNOLJCCJL {
    get { return oPFNOLJCCJL_; }
    set {
      oPFNOLJCCJL_ = value;
    }
  }

  /// <summary>Field number for the "DBNFOKCIKKL" field.</summary>
  public const int DBNFOKCIKKLFieldNumber = 13;
  private uint dBNFOKCIKKL_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public uint DBNFOKCIKKL {
    get { return dBNFOKCIKKL_; }
    set {
      dBNFOKCIKKL_ = value;
    }
  }

  /// <summary>Field number for the "hoyoverseUID" field.</summary>
  public const int HoyoverseUIDFieldNumber = 12;
  private string hoyoverseUID_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string HoyoverseUID {
    get { return hoyoverseUID_; }
    set {
      hoyoverseUID_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "HBIJGDBAKEJ" field.</summary>
  public const int HBIJGDBAKEJFieldNumber = 15;
  private uint hBIJGDBAKEJ_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public uint HBIJGDBAKEJ {
    get { return hBIJGDBAKEJ_; }
    set {
      hBIJGDBAKEJ_ = value;
    }
  }

  /// <summary>Field number for the "JAMBOCIOPJK" field.</summary>
  public const int JAMBOCIOPJKFieldNumber = 5;
  private uint jAMBOCIOPJK_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public uint JAMBOCIOPJK {
    get { return jAMBOCIOPJK_; }
    set {
      jAMBOCIOPJK_ = value;
    }
  }

  /// <summary>Field number for the "MEBBJCEEKJL" field.</summary>
  public const int MEBBJCEEKJLFieldNumber = 9;
  private string mEBBJCEEKJL_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string MEBBJCEEKJL {
    get { return mEBBJCEEKJL_; }
    set {
      mEBBJCEEKJL_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as PlayerGetTokenCsReq);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(PlayerGetTokenCsReq other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (ChannelID != other.ChannelID) return false;
    if (Token != other.Token) return false;
    if (OPFNOLJCCJL != other.OPFNOLJCCJL) return false;
    if (DBNFOKCIKKL != other.DBNFOKCIKKL) return false;
    if (HoyoverseUID != other.HoyoverseUID) return false;
    if (HBIJGDBAKEJ != other.HBIJGDBAKEJ) return false;
    if (JAMBOCIOPJK != other.JAMBOCIOPJK) return false;
    if (MEBBJCEEKJL != other.MEBBJCEEKJL) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (ChannelID != 0) hash ^= ChannelID.GetHashCode();
    if (Token.Length != 0) hash ^= Token.GetHashCode();
    if (OPFNOLJCCJL != 0) hash ^= OPFNOLJCCJL.GetHashCode();
    if (DBNFOKCIKKL != 0) hash ^= DBNFOKCIKKL.GetHashCode();
    if (HoyoverseUID.Length != 0) hash ^= HoyoverseUID.GetHashCode();
    if (HBIJGDBAKEJ != 0) hash ^= HBIJGDBAKEJ.GetHashCode();
    if (JAMBOCIOPJK != 0) hash ^= JAMBOCIOPJK.GetHashCode();
    if (MEBBJCEEKJL.Length != 0) hash ^= MEBBJCEEKJL.GetHashCode();
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
    if (Token.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Token);
    }
    if (ChannelID != 0) {
      output.WriteRawTag(24);
      output.WriteUInt32(ChannelID);
    }
    if (JAMBOCIOPJK != 0) {
      output.WriteRawTag(40);
      output.WriteUInt32(JAMBOCIOPJK);
    }
    if (OPFNOLJCCJL != 0) {
      output.WriteRawTag(48);
      output.WriteUInt32(OPFNOLJCCJL);
    }
    if (MEBBJCEEKJL.Length != 0) {
      output.WriteRawTag(74);
      output.WriteString(MEBBJCEEKJL);
    }
    if (HoyoverseUID.Length != 0) {
      output.WriteRawTag(98);
      output.WriteString(HoyoverseUID);
    }
    if (DBNFOKCIKKL != 0) {
      output.WriteRawTag(104);
      output.WriteUInt32(DBNFOKCIKKL);
    }
    if (HBIJGDBAKEJ != 0) {
      output.WriteRawTag(120);
      output.WriteUInt32(HBIJGDBAKEJ);
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
    if (Token.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Token);
    }
    if (ChannelID != 0) {
      output.WriteRawTag(24);
      output.WriteUInt32(ChannelID);
    }
    if (JAMBOCIOPJK != 0) {
      output.WriteRawTag(40);
      output.WriteUInt32(JAMBOCIOPJK);
    }
    if (OPFNOLJCCJL != 0) {
      output.WriteRawTag(48);
      output.WriteUInt32(OPFNOLJCCJL);
    }
    if (MEBBJCEEKJL.Length != 0) {
      output.WriteRawTag(74);
      output.WriteString(MEBBJCEEKJL);
    }
    if (HoyoverseUID.Length != 0) {
      output.WriteRawTag(98);
      output.WriteString(HoyoverseUID);
    }
    if (DBNFOKCIKKL != 0) {
      output.WriteRawTag(104);
      output.WriteUInt32(DBNFOKCIKKL);
    }
    if (HBIJGDBAKEJ != 0) {
      output.WriteRawTag(120);
      output.WriteUInt32(HBIJGDBAKEJ);
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
    if (ChannelID != 0) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ChannelID);
    }
    if (Token.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Token);
    }
    if (OPFNOLJCCJL != 0) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(OPFNOLJCCJL);
    }
    if (DBNFOKCIKKL != 0) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(DBNFOKCIKKL);
    }
    if (HoyoverseUID.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(HoyoverseUID);
    }
    if (HBIJGDBAKEJ != 0) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(HBIJGDBAKEJ);
    }
    if (JAMBOCIOPJK != 0) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(JAMBOCIOPJK);
    }
    if (MEBBJCEEKJL.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(MEBBJCEEKJL);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(PlayerGetTokenCsReq other) {
    if (other == null) {
      return;
    }
    if (other.ChannelID != 0) {
      ChannelID = other.ChannelID;
    }
    if (other.Token.Length != 0) {
      Token = other.Token;
    }
    if (other.OPFNOLJCCJL != 0) {
      OPFNOLJCCJL = other.OPFNOLJCCJL;
    }
    if (other.DBNFOKCIKKL != 0) {
      DBNFOKCIKKL = other.DBNFOKCIKKL;
    }
    if (other.HoyoverseUID.Length != 0) {
      HoyoverseUID = other.HoyoverseUID;
    }
    if (other.HBIJGDBAKEJ != 0) {
      HBIJGDBAKEJ = other.HBIJGDBAKEJ;
    }
    if (other.JAMBOCIOPJK != 0) {
      JAMBOCIOPJK = other.JAMBOCIOPJK;
    }
    if (other.MEBBJCEEKJL.Length != 0) {
      MEBBJCEEKJL = other.MEBBJCEEKJL;
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
        case 10: {
          Token = input.ReadString();
          break;
        }
        case 24: {
          ChannelID = input.ReadUInt32();
          break;
        }
        case 40: {
          JAMBOCIOPJK = input.ReadUInt32();
          break;
        }
        case 48: {
          OPFNOLJCCJL = input.ReadUInt32();
          break;
        }
        case 74: {
          MEBBJCEEKJL = input.ReadString();
          break;
        }
        case 98: {
          HoyoverseUID = input.ReadString();
          break;
        }
        case 104: {
          DBNFOKCIKKL = input.ReadUInt32();
          break;
        }
        case 120: {
          HBIJGDBAKEJ = input.ReadUInt32();
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
        case 10: {
          Token = input.ReadString();
          break;
        }
        case 24: {
          ChannelID = input.ReadUInt32();
          break;
        }
        case 40: {
          JAMBOCIOPJK = input.ReadUInt32();
          break;
        }
        case 48: {
          OPFNOLJCCJL = input.ReadUInt32();
          break;
        }
        case 74: {
          MEBBJCEEKJL = input.ReadString();
          break;
        }
        case 98: {
          HoyoverseUID = input.ReadString();
          break;
        }
        case 104: {
          DBNFOKCIKKL = input.ReadUInt32();
          break;
        }
        case 120: {
          HBIJGDBAKEJ = input.ReadUInt32();
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code
