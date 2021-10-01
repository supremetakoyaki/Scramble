using System.Security.Cryptography;

namespace Scramble.Util
{
    public static class TwewyChecksum
    {
        public static byte[] CalculateChecksum(byte[] Data, int Offset, int Length = 0)
        {
            if (Length == 0)
            {
                Length = Data.Length;
            }

            using (SHA256 _SHA256 = SHA256.Create())
            {
                byte[] NewHash = _SHA256.ComputeHash(Data, Offset, Length);
                byte[] FlippedHash = new byte[32];

                for (int i = 0; i < 32; i++)
                {
                    FlippedHash[i] = (byte)(NewHash[31 - i] ^ 255);
                }

                return FlippedHash;
            }
        }
    }
}
