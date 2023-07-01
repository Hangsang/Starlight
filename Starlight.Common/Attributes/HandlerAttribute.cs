using Starlight.Common.Packet;
using static Starlight.Common.Constants;

namespace Starlight.Common.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class HandlerAttribute : Attribute
{
    public HandlerAttribute(Opcode opcode, SessionState state = SessionState.Authorized)
    {
        Opcode = opcode;
        State = state;
    }

    public Opcode Opcode { get; }
    public SessionState State { get; }
}