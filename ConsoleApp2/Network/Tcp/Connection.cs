using DotNetty.Transport.Channels;
using Serilog;
using System.Collections.Concurrent;
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

        internal Session mConnection { get; private set; }

        public string Id => Channel.Id.AsLongText();

        public bool IsActive => Channel.Active;
        public bool IsWritable => Channel.IsWritable;

        //public EndPoint RemoteAddress => Channel.RemoteAddress;
        public string RemoteAddress => ((IPEndPoint) Channel.RemoteAddress).Address.MapToIPv4().ToString();
        public string LocalAddress => ((IPEndPoint)Channel.LocalAddress).Address.MapToIPv4().ToString();

        public void Register(Session connection)
        {
            if (mConnection != null)
                return;

            mConnection = connection;
            connection.Register(this);
            Logger.Information($"New connection by {RemoteAddress}");
        }
    }
}