using Starlight.Common.Attributes;
using Starlight.Common.Network;
using Starlight.Common.Packet;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Reflection;

namespace Starlight.Common.Unsorted
{
    public sealed class MessageFactory : Singleton<MessageFactory>
    {
        private ImmutableDictionary<Opcode, (HandlerAttribute, HandlerDelegate)> clientMessageHandlers;

        public void Initialize()
        {
            InitializePacketHandlers();
        }

        private void InitializePacketHandlers()
        {
            var messageHandlers = ImmutableDictionary
                .CreateBuilder<Opcode, (HandlerAttribute, HandlerDelegate)>();

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
                                         .Concat(Assembly.GetEntryAssembly()?.GetTypes() ??
                                                 throw new InvalidOperationException()))
                foreach (var method in type.GetMethods())
                {
                    var attribute = method.GetCustomAttribute<HandlerAttribute>();
                    if (attribute == null)
                        continue;

                    var parameterInfo = method.GetParameters();

                    var connectionParameter = Expression.Parameter(typeof(Session));
                    var bufferParameter = Expression.Parameter(typeof(Memory<byte>));

                    var call = Expression.Call(method,
                                               Expression.Convert(connectionParameter, parameterInfo[0].ParameterType),
                                               Expression.Convert(bufferParameter, parameterInfo[1].ParameterType));

                    var lambda = Expression.Lambda<HandlerDelegate>(call, connectionParameter, bufferParameter);

                    if (!messageHandlers.TryGetKey(attribute.Opcode, out var _))
                        messageHandlers.Add(attribute.Opcode, (attribute, lambda.Compile()));
                }

            clientMessageHandlers = messageHandlers.ToImmutable();
        }

        public (HandlerAttribute attribute, HandlerDelegate @delegate) GetMessageInformation(Opcode opcode)
        {
            clientMessageHandlers.TryGetValue(opcode,
                                              out (HandlerAttribute attribute, HandlerDelegate @delegate)
                                                  handler);
            return handler;
        }

        public delegate void HandlerDelegate(Session session, Memory<byte> payload);
    }
}