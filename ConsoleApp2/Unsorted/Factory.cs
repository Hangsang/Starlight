using Server.Attributes;
using Server.Network.TCP;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Reflection;

namespace Server.Unsorted
{
    public sealed class MessageManager : Singleton<MessageManager>
    {
        private ImmutableDictionary<Opcode, (HandlerAttribute, HandlerDelegate)> clientMessageHandlers;

        public void Initialize()
        {
            InitializePacketHandlers();
        }

        /*
        private void InitializeMessages()
        {
            var messageFactories = ImmutableDictionary.CreateBuilder<Opcode, MessageFactoryDelegate>();
            var messageOpcodes = ImmutableDictionary.CreateBuilder<Type, Opcode>();

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes().Concat(Assembly.GetEntryAssembly()?.GetTypes() ?? throw new InvalidOperationException()))
            {
                var attribute = type.GetCustomAttribute<MessageAttribute>();
                if (attribute == null)
                    continue;

                if (typeof(IReadable).IsAssignableFrom(type))
                    messageOpcodes.Add(type, attribute.Opcode);
            }

            clientMessageFactories = messageFactories.ToImmutable();
            serverMessageOpcodes = messageOpcodes.ToImmutable();
        }
        */

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

                    var connectionParameter = Expression.Parameter(typeof(TcpSession));
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

        /*
        public IMessage GetMessage(Opcode opcode)
        {
            return clientMessageFactories.TryGetValue(opcode, out var factory) ? factory.Invoke() : null;
        }
        */

        public (HandlerAttribute attribute, HandlerDelegate @delegate) GetMessageInformation(Opcode opcode)
        {
            clientMessageHandlers.TryGetValue(opcode,
                                              out (HandlerAttribute attribute, HandlerDelegate @delegate)
                                                  handler);
            return handler;
        }

        /*
        public Opcode? GetMessageOpcode(IWritable message)
        {
            if (!serverMessageOpcodes.TryGetValue(message.GetType(), out var opcode)) return null;
            return opcode;
        }
        */

        public delegate void HandlerDelegate(TcpSession session, Memory<byte> payload);
    }

    public abstract class Singleton<T> where T : class
    {
        private static readonly Lazy<T> instance = new(() => Activator.CreateInstance(typeof(T), true) as T);
        public static T Instance => instance.Value;
    }
}