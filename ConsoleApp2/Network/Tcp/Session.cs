using DotNetty.Buffers;
using DotNetty.Common.Utilities;
using Google.Protobuf;
using Server.Unsorted;
using System.Net;

namespace Server.Network.TCP
{
    public class Session
    {
        public Connection mConnection;

        public string Address => mConnection.RemoteAddress;
        public bool mKicked = false;
        public uint mUID { get; set; }

        internal void Register(Connection channel)
        {
            mConnection = channel;
        }

        public async Task DisconnectAsync()
        {
            this.mKicked = true;
            await mConnection.Channel.DisconnectAsync();
        }

        public async Task SendAsync(Opcode opcode, IMessage message, bool sendBytes = false)
        {
            if (!mConnection.IsWritable || !mConnection.IsActive || mKicked)
                return;

            try
            {
                var mPooledBuffer = mConnection.Channel.Allocator.Buffer();
                var size = message.CalculateSize();

                mPooledBuffer.WriteBytes(new byte[] { 0x9D, 0x74, 0xC7, 0x14 });
                mPooledBuffer.WriteShort((ushort)opcode);
                mPooledBuffer.WriteShort(0);
                mPooledBuffer.WriteInt(size);
                mPooledBuffer.WriteBytes(message.ToByteArray());

                mPooledBuffer.WriteBytes(new byte[] { 0xD7, 0xA1, 0x52, 0xC8 });

                await mConnection.Channel.WriteAndFlushAsync(mPooledBuffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await DisconnectAsync();
            }
        }

        public async Task SendBytesAsync(byte[] buffer)
        {
            if (!mConnection.IsWritable || !mConnection.IsActive || mKicked)
                return;

            try
            {
                var mPooledBuffer = mConnection.Channel.Allocator.Buffer();
                mPooledBuffer.WriteBytes(buffer);
                await mConnection.Channel.WriteAndFlushAsync(mPooledBuffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await DisconnectAsync();
            }
        }
    }
}