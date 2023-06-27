using Newtonsoft.Json;

namespace Starlight.HttpServer.Models
{
    public partial class CompareProtocolVersionBody
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("major")]
        public string Major { get; set; }

        [JsonProperty("minimum")]
        public string Minimum { get; set; }
    }
}