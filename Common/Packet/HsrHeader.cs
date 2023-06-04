namespace Common.Packet;

public class HsrHeader
{
    public uint HeadMagic;
    public ushort CmdId;
    public ushort MetaLen;
    public uint BodyLen;
    public uint TailMagic;

    public const int Size = 12;
    public const int PacketTailLen = 4;

    /*
    public void Read(BinaryReader reader)
    {
        HeadMagic = reader.ReadUInt32();
        CmdId = reader.ReadUInt16BE();
        MetaLen = reader.ReadUInt16BE();
        BodyLen = reader.ReadUInt32BE();
    }

    public void Write(BinaryWriter writer)
    {
        writer.Write(HeadMagic);
        writer.WriteUInt16BE(CmdId);
        writer.WriteUInt16BE(MetaLen);
        writer.WriteUInt32BE(BodyLen);
    }
    */
}