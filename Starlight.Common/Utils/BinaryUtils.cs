using System.Text;

namespace Starlight.Common.Utils;

public static class BinaryUtils
{
    public static BinaryReader ToBinaryReader(this Stream @this, bool leaveOpen)
    {
        return new BinaryReader(@this, Encoding.UTF8, leaveOpen);
    }

    public static ushort ReadUInt16BE(this BinaryReader reader)
    {
        var bytes = reader.ReadBytes(2);
        Array.Reverse(bytes);
        return BitConverter.ToUInt16(bytes, 0);
    }

    public static uint ReadUInt32BE(this BinaryReader reader)
    {
        var bytes = reader.ReadBytes(4);
        Array.Reverse(bytes);
        return BitConverter.ToUInt32(bytes, 0);
    }

    public static ulong ReadUInt64BE(this BinaryReader reader)
    {
        var bytes = reader.ReadBytes(8);
        Array.Reverse(bytes);
        return BitConverter.ToUInt64(bytes, 0);
    }

    public static void WriteUInt16BE(this BinaryWriter writer, ushort value)
    {
        var bytes = BitConverter.GetBytes(value);
        Array.Reverse(bytes);
        writer.Write(bytes);
    }

    public static void WriteUInt32BE(this BinaryWriter writer, uint value)
    {
        var bytes = BitConverter.GetBytes(value);
        Array.Reverse(bytes);
        writer.Write(bytes);
    }

    public static void WriteUInt64BE(this BinaryWriter writer, ulong value)
    {
        var bytes = BitConverter.GetBytes(value);
        Array.Reverse(bytes);
        writer.Write(bytes);
    }
}