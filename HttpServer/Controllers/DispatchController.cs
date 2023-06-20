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
            _global.Top = "annen";

            var base64 = Convert.ToBase64String(_global.ToByteArray());
            await context.Response.WriteAsync(base64);
        }

        private static async Task HandleQueryGateway(HttpContext context)
        {
            var _dispatch = new ServerDispatch
            {
                ConnectHost = "127.0.0.1",
                ConnectPort = 22102,
                FirstBool = true,
                SecondBool = true,
                ThirdBool = true,
                WhiteErrorMsg = "ERROR",
                AsbUrl = "https://autopatchos.starrails.com/asb/V1.1Live/output_4464562_ee2b6355c5",
                LuaUrl = "https://autopatchos.starrails.com/lua/V1.1Live/output_4465720_91b3fee706",
                DesignDataUrl = "https://autopatchos.starrails.com/design_data/V1.1Live/output_4468581_a0ba6b9e03",
                ResultMessage = "OK",
                ServerName = "annen",
                OBCBJOHAOAK = true,
                EFBEPICCKNP = true,
                IHEDNHBBOFA = true,
                IOFJNPOMBFC = true,
                EOOKHNELFEH = true,
                FAAJKEEIMMD = true,
                HODGOGLIJOI = true,
                IOIFFEJFGGC = true
            };

            var base64 = Convert.ToBase64String(_dispatch.ToByteArray());
            await context.Response.WriteAsync(base64);
        }
    }
}