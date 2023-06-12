using Common.Database.MongoDb.Entities;
using Common.Packet;
using Google.Protobuf;
using Serilog;
using System.Collections.Concurrent;
using System.Net;

namespace Common.Network.Tcp
{
    public class Session
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(Session));

        private readonly ConcurrentQueue<(Opcode opcode, IMessage message)> mSendQueue = new();
        private readonly SemaphoreSlim mSemaphore = new(1);

        public Connection mConnection { get; set; }
        public PlayerEntity Player { get; set; }
        public EndPoint Address => mConnection.RemoteAddress;
        public bool mKicked { get; set; }

        internal void Register(Connection channel)
        {
            mConnection = channel;
        }

        public async Task SendAsync(Opcode opcode, IMessage message)
        {
            if (!mConnection.IsWritable || !mConnection.IsActive || mKicked)
                return;

            try
            {
                var mPooledBuffer = mConnection.Channel.Allocator.Buffer();
                //var size = message.CalculateSize();
                var mData = message.ToByteArray();

                mPooledBuffer.WriteShort(0x9D74);
                mPooledBuffer.WriteShort(0xC714);
                mPooledBuffer.WriteShort((ushort)opcode);
                mPooledBuffer.WriteShort(0);
                mPooledBuffer.WriteInt(mData.Length);
                mPooledBuffer.WriteBytes(mData);
                mPooledBuffer.WriteShort(0xD7A1);
                mPooledBuffer.WriteShort(0x52C8);

                await mConnection.Channel.WriteAndFlushAsync(mPooledBuffer);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
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
                Logger.Error(ex.Message);
            }
        }

        public async Task SendCmdId(Opcode opcode)
        {
            if (!mConnection.IsWritable || !mConnection.IsActive || mKicked)
                return;

            try
            {
                var mPooledBuffer = mConnection.Channel.Allocator.Buffer();

                mPooledBuffer.WriteShort(0x9D74);
                mPooledBuffer.WriteShort(0xC714);
                mPooledBuffer.WriteShort((ushort)opcode);
                mPooledBuffer.WriteShort(0);
                mPooledBuffer.WriteInt(0);
                mPooledBuffer.WriteShort(0xD7A1);
                mPooledBuffer.WriteShort(0x52C8);

                await mConnection.Channel.WriteAndFlushAsync(mPooledBuffer);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        public async Task KickAsync(bool _deReg = false)
        {
            /*
            var kick = new PlayerKickoutScNotify
            {
                JIOKMHDOPJP = new EGHHJDHHBKM
                {
                    FCONOFEKJMH = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() * 2,
                    KJHDCEDJACN = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    AMKAMCCPGHH = 2,
                    FGNMJDDGHNA = 2
                }
            };
            */
            //await SendAsync(Opcode.PlayerKickOutScNotify, kick);
            mKicked = true;
            if (_deReg) mConnection.DeRegister();
        }

        public Task DisconnectAsync()
        {
            mKicked = true;
            return mConnection.Channel.DisconnectAsync();
        }
    }
}