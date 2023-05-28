using Server.Network.TCP;
using System.Collections.Concurrent;

namespace Server.Unsorted
{
    public class OnPlrAdded
    {
        private static readonly ConcurrentDictionary<uint, Connection> Sessions = new();
        public static int SessionsCount => Sessions.Count;

        public static bool TryAdd(uint uid, Connection session)
        {
            if (Sessions.TryAdd(uid, session)) return true;
            return false;
        }

        public static bool TryRemove(uint uid)
        {
            if (Sessions.TryRemove(uid, out _)) return true;
            return false;
        }

        public static bool Contains(uint uid)
        {
            if (Sessions.ContainsKey(uid)) return true;
            return false;
        }
    }
}
