using Common.Packet;
using static Common.Unsorted.Constants;

namespace Common.Attributes;

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