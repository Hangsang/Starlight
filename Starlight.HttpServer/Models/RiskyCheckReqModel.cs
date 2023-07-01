using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Starlight.HttpServer.Models
{
    internal sealed record RiskyCheckReqModel
    {
        [DataMember(Name = "retcode")]
        public int? Retcode { get; init; }

        [DataMember(Name = "message")]
        public string? Message { get; init; }

        [DataMember(Name = "data")]
        public RiskyData? Data { get; init; }

        internal record struct RiskyData
        {
            [DataMember(Name = "id")]
            public string? Id { get; init; }

            [DataMember(Name = "action")]
            public string? Action { get; init; }

            [DataMember(Name = "geetest")]
            public object? Geetest { get; init; }
        }
    }
}