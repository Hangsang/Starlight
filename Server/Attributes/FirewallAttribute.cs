using Server.Packet;
using static Server.Unsorted.Constants;

namespace Server.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class FirewallAttribute : Attribute
{
    public FirewallAttribute(uint delay)
    {
        Delay = delay;
    }

    public uint Delay { get; }
}