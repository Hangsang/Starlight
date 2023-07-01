using Google.Protobuf;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Starlight.HttpServer.Endpoints
{
    internal sealed class Dispatch
    {
        internal static void MapRegionalDispatchEndpoints(WebApplication endpoints)
        {
            endpoints.MapGet("/query_dispatch", OnHttpQueryDispatch);
            endpoints.MapGet("/query_gateway", OnHttpQueryGateway);
        }

        private static async Task OnHttpQueryDispatch(HttpContext context)
        {
            var rsp = new QueryDispatch();
            rsp.RegionList.Add(new RegionSimpleInfo
            {
                Name = "Starlight",
                DispatchUrl = "http://localhost/query_gateway",
                EnvType = "2",
                Title = "Starlight"
            });

            var base64 = Convert.ToBase64String(rsp.ToByteArray());
            await context.Response.WriteAsync(base64);
        }

        private static async Task OnHttpQueryGateway(HttpContext ctx)
        {
            var rsp = new QueryGateway
            {
                ConnectHost = "127.0.0.1",
                ConnectPort = 22102,
                FirstBool = true,
                SecondBool = true,
                ThirdBool = true,
                WhiteErrorMsg = "ERROR",
                AsbUrl = "https://autopatchos.starrails.com/asb/V1.1Live/output_4614962_fe9960d784",
                LuaUrl = "https://autopatchos.starrails.com/lua/V1.1Live/output_4614962_fe9960d784",
                DesignDataUrl = "https://autopatchos.starrails.com/design_data/V1.1Live/output_4621062_d7a74831c4",
                ResultMessage = "OK",
                ServerName = "Starlight",
                EOOKHNELFEH = true //useTcp
            };

            var base64 = Convert.ToBase64String(rsp.ToByteArray());
            await ctx.Response.WriteAsync(base64);
        }
    }
}