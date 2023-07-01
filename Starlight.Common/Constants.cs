namespace Starlight.Common
{
    public class Constants
    {
        public const uint HEAD_MAGIC = 0x9D74C714;

        public const int MAGIC_BEGIN_LENGTH = 0;
        public const int CMD_BEGIN_LENGTH = 4;
        public const int METALEN_BEGIN_LENGTH = 6;
        public const int BODYLEN_BEGIN_LENGTH = 8;
        public const int DATA_BEGIN_LENGTH = 12;

        public enum SessionState
        {
            Authorized,
            Ignored
        }
    }
}