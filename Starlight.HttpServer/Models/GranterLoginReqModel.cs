using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Starlight.HttpServer.Models
{
    internal partial class GranterLoginBody
    {
        [DataMember(Name = "app_id")]
        public int? AppId { get; init; }

        [DataMember(Name = "channel_id")]
        public int? ChannelId { get; init; }

        [DataMember(Name = "data")]
        public string? Data { get; init; }

        [DataMember(Name = "device")]
        public string? Device { get; init; }

        [DataMember(Name = "sign")]
        public string? Sign { get; init; }

        internal record GranterLoginBodyData
        {
            [DataMember(Name = "uid")]
            public string? Uid { get; init; }

            [DataMember(Name = "guest")]
            public bool? Guest { get; init; }

            [DataMember(Name = "token")]
            public string? Token { get; init; }
        }
    }
}