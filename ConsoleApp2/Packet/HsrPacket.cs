namespace Server.Packet;

public class HsrPacket
{
    public HsrPacket(HsrHeader header, byte[] data, uint tailMagic)
    {
        HsrHeader = header;
        Data = data;
        TailMagic = tailMagic;
    }

    public HsrHeader HsrHeader { get; set; }
    public byte[] Data { get; set; }
    public uint TailMagic { get; set; }
}