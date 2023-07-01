using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Starlight.HttpServer.Models;

namespace Starlight.HttpServer.Endpoints
{
    internal class Miscellaneous
    {
        internal static void MapSdkApiEndpoints(WebApplication app)
        {
            app.MapPost("/account/risky/api/check", OnRiskyCheck);
            app.Map("/hkrpg_global/mdk/agreement/api/getAgreementInfos", OnGetAgreementInfos);
        }

        private static async Task OnRiskyCheck(HttpContext ctx)
        {
            var rsp = new RiskyCheckReqModel
            {
                Retcode = 0,
                Message = "OK",
                Data = new RiskyCheckReqModel.RiskyData { Id = "", Action = "ACTION_NONE", Geetest = null }
            };

            await ctx.Response.WriteAsJsonAsync(rsp);
        }

        private static async Task OnGetAgreementInfos(HttpContext ctx)
        {
            await ctx.Response.WriteAsJsonAsync(new { retcode = 0, message = "OK", data = new { marketing_agreements = Array.Empty<object>() } });
        }

        private static async Task OnCompareProtocolVersion(HttpContext ctx)
        {
            await ctx.Response.WriteAsJsonAsync(new
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
        }
    }
}