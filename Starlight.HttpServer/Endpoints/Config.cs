using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Starlight.HttpServer.Endpoints
{
    internal class Config
    {
        internal static void MapConfigEndpoints(WebApplication app)
        {
            app.Map("/hkrpg_global/combo/granter/api/getConfig", OnGetConfig);
            app.Map("/hkrpg_global/mdk/shield/api/loadConfig", OnLoadConfig);
        }

        private static async Task OnGetConfig(HttpContext ctx)
        {
            await ctx.Response.WriteAsJsonAsync(new
            {
                retcode = 0,
                message = "OK",
                data = new
                {
                    protocol = true,
                    qr_enabled = true,
                    log_level = "INFO",
                    announce_url = "https://google.com",
                    push_alias_type = 0,
                    disable_ysdk_guard = true,
                    enable_announce_pic_popup = true
                }
            });
        }

        private static async Task OnLoadConfig(HttpContext ctx)
        {
            await ctx.Response.WriteAsJsonAsync(new
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
                    thirdparty_ignore = new { },
                    enable_ps_bind_account = false,
                    thirdparty_login_configs = new { }
                }
            });
        }
    }
}