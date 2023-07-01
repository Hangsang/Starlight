using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Starlight.HttpServer.Models
{
    internal class ShieldLoginBody
    {
        [DataMember(Name = "account")]
        public string Account { get; set; }

        [DataMember(Name = "is_crypto")]
        public bool IsCrypto { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }
    }

    internal class ShieldVerifyBody
    {
        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "uid")]
        public string Uid { get; set; }
    }

    internal class ShieldLoginResponse
    {
        [DataMember(Name = "data")]
        public ShieldLoginResponseData Data { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "retcode")]
        public long Retcode { get; set; }

        internal class ShieldLoginResponseData
        {
            [DataMember(Name = "account")]
            public ShieldLoginResponseDataAccount? Account { get; set; }

            [DataMember(Name = "device_grant_required")]
            public bool DeviceGrantRequired { get; set; }

            [DataMember(Name = "reactivate_required")]
            public bool ReactivateRequired { get; set; }

            [DataMember(Name = "realname_operation")]
            public string RealnameOperation { get; set; }

            [DataMember(Name = "realperson_required")]
            public bool RealpersonRequired { get; set; }

            [DataMember(Name = "safe_moblie_required")]
            public bool SafeMoblieRequired { get; set; }

            internal class ShieldLoginResponseDataAccount
            {
                [DataMember(Name = "apple_name")]
                public string AppleName { get; set; }

                [DataMember(Name = "area_code")]
                public string AreaCode { get; set; }

                [DataMember(Name = "country")]
                public string Country { get; set; }

                [DataMember(Name = "device_grant_ticket")]
                public string DeviceGrantTicket { get; set; }

                [DataMember(Name = "email")]
                public string Email { get; set; }

                [DataMember(Name = "facebook_name")]
                public string FacebookName { get; set; }

                [DataMember(Name = "game_center_name")]
                public string GameCenterName { get; set; }

                [DataMember(Name = "google_name")]
                public string GoogleName { get; set; }

                [DataMember(Name = "identity_card")]
                public string IdentityCard { get; set; }

                [DataMember(Name = "is_email_verify")]
                public string IsEmailVerify { get; set; }

                [DataMember(Name = "mobile")]
                public string Mobile { get; set; }

                [DataMember(Name = "name")]
                public string Name { get; set; }

                [DataMember(Name = "reactivate_ticket")]
                public string ReactivateTicket { get; set; }

                [DataMember(Name = "realname")]
                public string Realname { get; set; }

                [DataMember(Name = "safe_mobile")]
                public string SafeMobile { get; set; }

                [DataMember(Name = "sony_name")]
                public string SonyName { get; set; }

                [DataMember(Name = "steam_name")]
                public string SteamName { get; set; }

                [DataMember(Name = "tap_name")]
                public string TapName { get; set; }

                [DataMember(Name = "token")]
                public string Token { get; set; }

                [DataMember(Name = "twitter_name")]
                public string TwitterName { get; set; }

                [DataMember(Name = "uid")]
                public long Uid { get; set; }

                [DataMember(Name = "unmasked_email")]
                public string UnmaskedEmail { get; set; }

                [DataMember(Name = "unmasked_email_type")]
                public long UnmaskedEmailType { get; set; }
            }
        }
    }
}