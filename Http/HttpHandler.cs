using System.Text;
using DotNetty.Codecs.Http;
using DotNetty.Transport.Channels;

namespace HttpHandler
{
    public class HttpServerHandler : SimpleChannelInboundHandler<IHttpObject>
    {
        protected override void ChannelRead0(IChannelHandlerContext ctx, IHttpObject msg)
        {
            if (msg is IHttpRequest request) {
                //if (!request.Uri.Contains("starrail"))
                 //   return;

                var body = "";
                if (request is IFullHttpRequest fullHttpRequest) {
                    body = fullHttpRequest.Content.ToString(Encoding.UTF8);
                }

                Console.WriteLine($"Received {request.Method} request for {request.Uri} with body {body}");

                var response = new DefaultFullHttpResponse(HttpVersion.Http11, HttpResponseStatus.OK);
                response.Headers.Add(HttpHeaderNames.ContentType, "text/plain; charset=UTF-8");
                response.Content.WriteString("IjUKB0NyZXBlU1IaHmh0dHA6Ly9sb2NhbGhvc3QvcXVlcnlfZ2F0ZXdheSIBMioHQ3JlcGVTUioHQ3JlcGVTUg==", Encoding.UTF8);

                ctx.WriteAndFlushAsync(response);
                //.ContinueWith(_ => ctx.CloseAsync());
            }
        }

        public override void ExceptionCaught(IChannelHandlerContext ctx, Exception e)
        {
            Console.WriteLine($"Exception caught: {e}");
            ctx.CloseAsync();
        }
    }
}