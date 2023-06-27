namespace Starlight.Common.Packet;

public class HsrHeader
{
    public uint HeadMagic;
    public ushort CmdId;
    public ushort MetaLen;
    public uint BodyLen;
    public uint TailMagic;

    public const int Size = 12;
    public const int PacketTailLen = 4;
}