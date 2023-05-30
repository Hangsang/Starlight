using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Server.Unsorted;
using System.Diagnostics;
using static Server.Unsorted.Constants;

namespace Server.Network.UDP;

public class UdpServerHandler : SimpleChannelInboundHandler<DatagramPacket>
{
    private const int HANDSHAKE_LEN = 0x14;
    private const int KCP_LEN = 28;

    private const uint HANDSHAKE_CONNECT = 0XFFFFFFFF;
    private const uint HANDSHAKE_DISCONNECT = 0x0; //Idk yet

    private const int OPC_EXTEND = 32;

    private static readonly byte[] HANDSHAKE_CONNECT_BYTE =
    {
        0x00, 0x00, 0x01, 0x45, 0x00, 0x00, 0x00, 0x69, 0x00, 0x00,
        0x04, 0x20, 0x00, 0x00, 0x00, 0x00, 0x14, 0x51, 0x45, 0x45
    };

    protected override void ChannelRead0(IChannelHandlerContext ctx, DatagramPacket msg)
    {
        var buf = msg.Content;
        var rdb = buf.ReadableBytes;

        /// <summary>
        /// Handshake. Is sent after Click to Start
        /// </summary>
        if (rdb == HANDSHAKE_LEN)
        {
            var hsType = buf.GetUnsignedInt(16);
            if (hsType == HANDSHAKE_CONNECT)
                HandleHandshake(ctx, msg, HandshakeType.CONNECT);
            else if (hsType == HANDSHAKE_DISCONNECT) HandleHandshake(ctx, msg, HandshakeType.DISCONNECT);
        }

        /// <summary>
        /// HSR Packet Section
        /// </summary>
        if (rdb > KCP_LEN)
        {
            buf.SkipBytes(32);
            var cmd = buf.ReadUnsignedShort();
            Console.WriteLine($"Received opcode 0x{cmd:X}");

            switch (cmd)
            {
                case (ushort)Opcode.PlayerGetTokenCsReq:
                    HandleLogin(ctx, msg);
                    break;
            }
        }
    }

    public override void ChannelReadComplete(IChannelHandlerContext context)
    {
        context.Flush();
    }

    public override void ExceptionCaught(IChannelHandlerContext ctx, Exception exception)
    {
        Console.WriteLine($"Exception on (Dotnetty UDPServerHandler): {exception}");
    }

    private static void HandleHandshake(IChannelHandlerContext ctx, DatagramPacket packet, HandshakeType handshakeType)
    {
        var buf = ctx.Allocator.Buffer(HANDSHAKE_LEN);

        switch (handshakeType)
        {
            case HandshakeType.CONNECT:
                buf.WriteBytes(HANDSHAKE_CONNECT_BYTE);
                break;

            case HandshakeType.DISCONNECT:
                //
                break;

            default:
                ctx.Channel.DisconnectAsync();
                break;
        }

        ctx.WriteAndFlushAsync(new DatagramPacket(buf, packet.Sender));
    }

    public void HandleLogin(IChannelHandlerContext ctx, DatagramPacket packet)
    {
        Stopwatch sw = new();
        sw.Start();

        if (packet.Content.GetUnsignedShort(OPC_EXTEND) == (ushort)Opcode.PlayerGetTokenCsReq)
        {
            var byteArray = new byte[packet.Content.ReadableBytes];
            packet.Content.GetBytes(40, byteArray);

            var originalLength = byteArray.Length;
            var newLength = originalLength - 10;
            Array.Resize(ref byteArray, newLength);

            var cplr = PlayerGetTokenCsReq.Parser.ParseFrom(byteArray);
            Console.WriteLine($"{cplr.PPIEAKOMAKD}");

            Console.WriteLine(BitConverter.ToString(byteArray).Replace("-", " "));
        }

        Console.WriteLine($"{sw.Elapsed.TotalMilliseconds}");
        sw.Stop();
    }
}