using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HttpServer.Controllers
{
    public class Dispatch
    {
        public static void AddHandlers(WebApplication app)
        {
            app.Map("/query_dispatch", HandleQueryDispatch);
            app.Map("/query_gateway", HandleQueryGateway);
        }

        private static async Task HandleQueryDispatch(HttpContext context)
        {
            Console.WriteLine("Received request for /query_dispatch");

            context.Response.StatusCode = 200;
            await context.Response.WriteAsync("Hello from the server!");
        }

        private static async Task HandleQueryGateway(HttpContext context)
        {
            Console.WriteLine("Received request for /query_gateway");

            context.Response.StatusCode = 200;
            await context.Response.WriteAsync("Hello from the server!");
        }
    }
}