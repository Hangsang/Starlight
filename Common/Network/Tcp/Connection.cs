using DotNetty.Transport.Channels;
using Serilog;
using System.Net;

namespace Common.Network.Tcp
{
    public class Connection
    {
        private static readonly ILogger Logger = Log.ForContext(
            Serilog.Core.Constants.SourceContextPropertyName,
            nameof(Connection));

        public Connection(IChannel channel)
        {
            Channel = channel;
        }

        internal IChannel Channel { get; }
        public string Id => Channel.Id.AsLongText();
        public bool IsActive => Channel.Active;
        public bool IsWritable => Channel.IsWritable;

        internal Session mConnection { get; set; }
        public EndPoint RemoteAddress => Channel.RemoteAddress;

        public void Register(Session connection)
        {
            if (mConnection != null)
                return;

            mConnection = connection;
            connection.Register(this);
            Logger.Information($"New connection by {RemoteAddress}");
        }

        public void DeRegister(bool sendPacket = false)
        {
            if (mConnection == null)
                return;

            if (sendPacket)
            {
                mConnection?.KickAsync();
            }

            Logger.Information($"{RemoteAddress} disconnected");
            Channel.CloseAsync();
            mConnection = null;
        }
    }
}