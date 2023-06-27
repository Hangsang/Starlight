namespace Starlight.Common.Packet;

public class HsrPacket
{
    public HsrPacket(HsrHeader header, Memory<byte> data, uint tailMagic)
    {
        HsrHeader = header;
        Data = data;
        TailMagic = tailMagic;
    }

    public HsrHeader HsrHeader { get; set; }
    public Memory<byte> Data { get; set; }
    public uint TailMagic { get; set; }
}