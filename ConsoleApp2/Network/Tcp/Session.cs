using DotNetty.Common.Utilities;
using Google.Protobuf;
using Serilog;
using Server.Database.MongoDb.Entities;
using Server.Packet;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;

namespace Server.Network.TCP
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
            Stopwatch sw = new();
            sw.Start();

            if (!mConnection.IsWritable || !mConnection.IsActive || mKicked)
                return;

            mSendQueue.Enqueue((opcode, message));

            if (await mSemaphore.WaitAsync(0))
            {
                try
                {
                    while (mSendQueue.TryDequeue(out var item))
                    {
                        var mPooledBuffer = mConnection.Channel.Allocator.Buffer();
                        var size = message.CalculateSize();

                        mPooledBuffer.WriteShort(0x9D74);
                        mPooledBuffer.WriteShort(0xC714);
                        mPooledBuffer.WriteShort((ushort)item.opcode);
                        mPooledBuffer.WriteShort(0);
                        mPooledBuffer.WriteInt(size);
                        mPooledBuffer.WriteBytes(item.message.ToByteArray());
                        mPooledBuffer.WriteShort(0xD7A1);
                        mPooledBuffer.WriteShort(0x52C8);

                        await mConnection.Channel.WriteAndFlushAsync(mPooledBuffer);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
                finally
                {
                    mSemaphore.Release();
                }
            }

            Logger.Information(sw.Elapsed.TotalMilliseconds.ToString());
            sw.Stop();
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

        public async Task KickAsync()
        {
            var kick = new PlayerKickoutScNotify
            {
                JIOKMHDOPJP = new EGHHJDHHBKM
                {
                    FCONOFEKJMH = DateTimeOffset.Now.ToUnixTimeMilliseconds() * 2,
                    KJHDCEDJACN = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    AMKAMCCPGHH = 2,
                    FGNMJDDGHNA = 2
                }
            };
            await SendAsync(Opcode.PlayerKickOutScNotify, kick);
            mKicked = true;
            mConnection.DeRegister();
        }

        public Task DisconnectAsync()
        {
            mKicked = true;
            return mConnection.Channel.DisconnectAsync();
        }
    }
}