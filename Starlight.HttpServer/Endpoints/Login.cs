using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Starlight.Database.Repositories;
using Starlight.HttpServer.Models;

namespace Starlight.HttpServer.Endpoints
{
    internal class Login
    {
        internal static void MapLoginEndpoints(WebApplication app)
        {
            app.MapPost("/hkrpg_global/mdk/shield/api/login", OnShieldLogin);
            app.MapPost("/hkrpg_global/mdk/shield/api/verify", OnShieldVerify);
            app.MapPost("/hkrpg_global/combo/granter/login/v2/login", OnGranterLogin);
        }

        private static async Task OnShieldLogin(HttpContext ctx)
        {
            var reader = new StreamReader(ctx.Request.Body);
            var data = JsonConvert.DeserializeObject<ShieldLoginBody>(await reader.ReadToEndAsync()) ?? throw new ArgumentException();

            var rsp = new ShieldLoginResponse
            {
                Retcode = 0,
                Message = "OK",
                Data = new ShieldLoginResponse.ShieldLoginResponseData { }
            };

            var plr = await PlayerRepository.FirstOrDefault(x => x.Username == data.Account);
            if (plr == null)
            {
                rsp.Retcode = -202;
                rsp.Message = "Account not found";
            }
            else
            {
                rsp.Data.Account = new ShieldLoginResponse.ShieldLoginResponseData.ShieldLoginResponseDataAccount
                {
                    Uid = plr.UID,
                    Name = data.Account,
                    Token = "1234567890"
                };
            }

            await ctx.Response.WriteAsJsonAsync(rsp);
        }

        private static async Task OnGranterLogin(HttpContext ctx)
        {
            var reader = new StreamReader(ctx.Request.Body);
            var data = JsonConvert.DeserializeObject<GranterLoginBody.GranterLoginBodyData>(await reader.ReadToEndAsync()) ?? throw new ArgumentException();

            await ctx.Response.WriteAsJsonAsync(new
            {
                retcode = 0,
                message = "OK",
                data = new
                {
                    combo_id = "1",
                    open_id = data.Uid,
                    combo_token = data.Token,
                    data = new
                    {
                        guest = data.Guest
                    },
                    heartbeat = false,
                    account_type = 1,
                    fatigue_remind = new { }
                }
            });
        }

        private static async Task OnShieldVerify(HttpContext ctx)
        {
            StreamReader reader = new(ctx.Request.Body);
            var data = JsonConvert.DeserializeObject<ShieldVerifyBody>(await reader.ReadToEndAsync()) ?? throw new ArgumentException();

            var plr = await PlayerRepository.FirstOrDefault(x => x.UID == int.Parse(data.Uid));
            if (plr == null)
                return;

            ShieldLoginResponse rsp = new()
            {
                Retcode = 0,
                Message = "OK",
                Data = new()
                {
                    Account = new()
                    {
                        Uid = plr.UID,
                        Name = plr.Username,
                        Email = "",
                        Mobile = "",
                        IsEmailVerify = "0",
                        Realname = "",
                        IdentityCard = "",
                        Token = "1234567890",
                        SafeMobile = "",
                        FacebookName = "",
                        GoogleName = "",
                        TwitterName = "",
                        GameCenterName = "",
                        AppleName = "",
                        SonyName = "",
                        TapName = "",
                        Country = "US",
                        ReactivateTicket = "",
                        AreaCode = "**",
                        DeviceGrantTicket = "",
                        SteamName = "",
                        UnmaskedEmail = "",
                        UnmaskedEmailType = 0
                    },
                    DeviceGrantRequired = false,
                    SafeMoblieRequired = false,
                    RealpersonRequired = false,
                    ReactivateRequired = false,
                    RealnameOperation = "None"
                }
            };

            await ctx.Response.WriteAsJsonAsync(rsp);
        }
    }
}