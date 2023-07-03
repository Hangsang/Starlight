using System;
using System.Drawing;
using System.Security.Cryptography;

namespace Starlight.Common.Utils
{
    public static class RandomProvider
    {
        public static string GenerateToken()
        {
            return Guid.NewGuid().ToString("n").Substring(0, 8);
        }
    }
}