using Google.Protobuf;
using HttpServer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace HttpServer.Controllers
{
    internal class AccountController
    {
        internal static void AddHandlers(WebApplication app)
        {
            app.Map("/account/risky/api/check", HandleAccountRisky);
            app.Map("/hkrpg_global/mdk/shield/api/login", HandleAccountLogin);
            app.Map("/hkrpg_global/combo/granter/login/v2/login", HandleAccountLogin2);
            app.Map("/hkrpg_global/mdk/agreement/api/getAgreementInfos", (HttpContext ctx) =>
            {
                return ctx.Response.WriteAsJsonAsync(new { retcode = 0, message = "OK", data = new { marketing_agreements = Array.Empty<object>() } });
            });

            app.Map("/hkrpg_global/combo/granter/api/compareProtocolVersion", (HttpContext ctx) =>
            {
                StreamReader Reader = new(ctx.Request.Body);
                CompareProtocolVersionBody Data = JsonConvert.DeserializeObject<CompareProtocolVersionBody>(Reader.ReadToEndAsync().Result);

                return ctx.Response.WriteAsJsonAsync(new
                {
                    retcode = 0,
                    message = "OK",
                    data = new
                    {
                        modified = true,
                        protocol = new
                        {
                            id = 0,
                            app_id = "11",
                            language = "en",
                            user_proto = "",
                            priv_proto = "",
                            major = 1,
                            minimum = 2,
                            create_time = "0",
                            teenager_proto = "",
                            third_proto = ""
                        }
                    }
                });
            });

            app.Map("/hkrpg_global/combo/granter/api/getConfig", (HttpContext ctx) =>
            {
                return ctx.Response.WriteAsJsonAsync(new
                {
                    retcode = 0,
                    message = "OK",
                    data = new
                    {
                        protocol = true,
                        qr_enabled = true,
                        log_level = "INFO",
                        announce_url = "https://sdk.hoyoverse.com/hkrpg/announcement/index.html?sdk_presentation_style=fullscreen\u0026sdk_screen_transparent=true\u0026auth_appid=announcement\u0026authkey_ver=1\u0026sign_type=2#/",
                        push_alias_type = 0,
                        disable_ysdk_guard = true,
                        enable_announce_pic_popup = true
                    }
                });
            });

            app.Map("/hkrpg_global/mdk/shield/api/loadConfig", (HttpContext ctx) =>
            {
                return ctx.Response.WriteAsJsonAsync(new
                {
                    retcode = 0,
                    message = "OK",
                    data = new
                    {
                        id = 24,
                        game_key = "hkrpg_global",
                        client = "PC",
                        identity = "I_IDENTITY",
                        guest = false,
                        ignore_versions = "",
                        scene = "S_NORMAL",
                        name = "崩坏RPG",
                        disable_regist = true,
                        enable_email_captcha = false,
                        thirdparty = Array.Empty<string>(),
                        disable_mmt = false,
                        server_guest = true,
                        thirdparty_ignore = new { fb = "", tw = "" },
                        enable_ps_bind_account = false,
                        thirdparty_login_configs = new { }
                    }
                });
            });

            app.Map("/hkrpg_global/mdk/shield/api/verify", (HttpContext ctx) =>
            {
                StreamReader Reader = new(ctx.Request.Body);
                ShieldVerifyBody Data = JsonConvert.DeserializeObject<ShieldVerifyBody>(Reader.ReadToEndAsync().Result);

                ShieldLoginResponse rsp = new()
                {
                    Retcode = 0,
                    Message = "OK",
                    Data = new()
                    {
                        Account = new()
                        {
                            Uid = 1,
                            Name = "1",
                            Email = "",
                            Mobile = "",
                            IsEmailVerify = "0",
                            Realname = "",
                            IdentityCard = "",
                            Token = "1234",
                            SafeMobile = "",
                            FacebookName = "",
                            GoogleName = "",
                            TwitterName = "",
                            GameCenterName = "",
                            AppleName = "",
                            SonyName = "",
                            TapName = "",
                            Country = "TR",
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
            });

        }

        private static async Task HandleAccountRisky(HttpContext context)
        {
            var rsp = new RiskyCheck
            {
                Retcode = 0,
                Message = "OK",
                Data = new RiskyCheck.DataScheme { Id = "", Action = "ACTION_NONE", Geetest = null }
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(rsp));
        }

        private static async Task HandleAccountLogin(HttpContext context)
        {
            StreamReader Reader = new(context.Request.Body);
            ShieldLoginBody Data = JsonConvert.DeserializeObject<ShieldLoginBody>(await Reader.ReadToEndAsync())
                 ?? throw new ArgumentException("[HTTPS] Shield account login body was null!!");

            ShieldLoginResponse rsp = new ShieldLoginResponse
            {
                Retcode = 0,
                Message = "OK",
                Data = new ShieldLoginResponse.ShieldLoginResponseData { }
            };

            rsp.Data.Account = new ShieldLoginResponse.ShieldLoginResponseData.ShieldLoginResponseDataAccount
            {
                Uid = 1,
                Name = Data.Account,
                Token = "1234"
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(rsp));
        }

        private static async Task HandleAccountLogin2(HttpContext context)
        {
            StreamReader Reader = new(context.Request.Body);
            GranterLoginBody.GranterLoginBodyData GranterLoginData = JsonConvert.DeserializeObject<GranterLoginBody.GranterLoginBodyData>(await Reader.ReadToEndAsync())
                 ?? throw new ArgumentException("[HTTPS] Granter account login body was null!!");

            await context.Response.WriteAsJsonAsync(new
            {
                retcode = 0,
                message = "OK",
                data = new
                {
                    combo_id = "1",
                    open_id = GranterLoginData.Uid,
                    combo_token = GranterLoginData.Token,
                    data = JsonConvert.SerializeObject(new
                    {
                        guest = GranterLoginData.Guest
                    }),
                    heartbeat = false,
                    account_type = 1
                }
            });
        }

    }
}