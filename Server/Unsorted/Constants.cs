namespace Server.Unsorted
{
    public class Constants
    {
        public enum SessionState
        {
            Authorized,
            Ignored
        }

        public enum HandshakeType
        {
            CONNECT = 1,
            DISCONNECT = 2,
            SEND_BACK_CONV = 3,
            UNKNOWN = 4
        }
    }
}