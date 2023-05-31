using DotNetty.Transport.Channels;
using Serilog;
using System.Net;

namespace Server.Network.TCP
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

        internal Session mConnection { get; set; }

        public string Id => Channel.Id.AsLongText();

        public bool IsActive => Channel.Active;
        public bool IsWritable => Channel.IsWritable;

        public EndPoint RemoteAddress => Channel.RemoteAddress;

        public void Register(Session connection)
        {
            if (mConnection != null)
                return;

            mConnection = connection;
            connection.Register(this);
            Logger.Information($"New connection by {RemoteAddress}");
        }

        public void DeRegister()
        {
            if (mConnection == null)
                return;

            Logger.Information($"{RemoteAddress} disconnected");
            Channel.CloseAsync();
            mConnection = null;
        }
    }
}