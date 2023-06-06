using Google.Protobuf;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HttpServer.Controllers
{
    internal class DispatchController
    {
        internal static void AddHandlers(WebApplication app)
        {
            app.Map("/query_dispatch", HandleQueryDispatch);
            app.Map("/query_gateway", HandleQueryGateway);
        }

        private static async Task HandleQueryDispatch(HttpContext context)
        {
            var _global = new GlobalDispatchData();
            _global.EIIAPMEBGFK.Add(new ServerData
            {
                Name = "annen",
                DispatchUrl = "http://localhost/query_gateway",
                SdkEnv = "2",
                DisplayName = "annen"
            });

            var base64 = Convert.ToBase64String(_global.ToByteArray());
            await context.Response.WriteAsync(base64);
        }

        private static async Task HandleQueryGateway(HttpContext context)
        {
            var _dispatch = new ServerDispatchData
            {
                AssetBundleVersionUpdateUrl = "https://autopatchos.starrails.com/asb/V1.0Live/output_4186973_52d0b74c56",
                LuaBundleVersionUpdateUrl = "https://autopatchos.starrails.com/lua/V1.0Live/output_4135247_48f4e37838",
                DesignDataBundleVersionUpdateUrl = "https://autopatchos.starrails.com/design_data/V1.0Live/output_4333050_e99822159b",
                RedeemCodeUrl = "http://localhost/common/apicdkey/api",
                OfficialCommunityUrl = "https://google.com",
                TemporaryMaintenanceUrl = "https://google.com",
                CustomServiceUrl = "https://google.com",
                EnableDesignDataBundleVersionUpdate = true,
                EventTrackingOpen = true,
                LoginWhiteMsg = "The Astral Express will depart at 2069/02/30 13:37 (UTC+420). Trailblazers, please be patient~",
                Name = "annen",
                KMJAFDLEPOH = "", //ec2b,
                UseTcp = true,
                Host = "127.0.0.1",
                Port = 22102
            };

            var base64 = Convert.ToBase64String(_dispatch.ToByteArray());
            await context.Response.WriteAsync(base64);
        }
    }
}