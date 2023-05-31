using Google.Protobuf;
using Server.Unsorted;
using System.Net;

namespace Server.Network.TCP
{
    public class Session
    {
        public Connection mConnection;

        public EndPoint Address => mConnection.RemoteAddress;
        public bool mKicked = false;

        internal void Register(Connection channel)
        {
            mConnection = channel;
        }

        public async Task DisconnectAsync()
        {
            this.mKicked = true;
            await mConnection.Channel.DisconnectAsync();
        }

        public async Task SendAsync(Opcode opcode, IMessage message)
        {
            if (!mConnection.IsWritable || !mConnection.IsActive || mKicked)
                return;

            try
            {
                var mPooledBuffer = mConnection.Channel.Allocator.Buffer();
                var size = message.CalculateSize();

                mPooledBuffer.WriteShort(0x9D74);
                mPooledBuffer.WriteShort(0xC714);
                mPooledBuffer.WriteShort((ushort)opcode);
                mPooledBuffer.WriteShort(0);
                mPooledBuffer.WriteInt(size);
                mPooledBuffer.WriteBytes(message.ToByteArray());
                mPooledBuffer.WriteShort(0xD7A1);
                mPooledBuffer.WriteShort(0x52C8);

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