using Server.Packet;
using static Server.Unsorted.Constants;

namespace Server.Attributes;

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