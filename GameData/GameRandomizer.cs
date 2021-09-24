using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;
using NTwewyDb;

namespace Scramble.GameData
{
    public class GameRandomizer
    {
        public ScrambleForm Sukuranburu => Program.Sukuranburu;

        private RNGCryptoServiceProvider RngProvider;
        private byte[] RngBuffer;

        public GameRandomizer()
        {
            RngProvider = new RNGCryptoServiceProvider();
            RngBuffer = new byte[4];
        }

        public int GenerateRandomNumber(int MinValue, int MaxValue)
        {
            if (MinValue > MaxValue)
                throw new ArgumentOutOfRangeException("MinValue");

            if (MinValue == MaxValue) return MinValue;

            long Difference = MaxValue - MinValue;
            while (true)
            {
                RngProvider.GetBytes(RngBuffer);
                uint Rand = BitConverter.ToUInt32(RngBuffer, 0);

                long Max = (1 + (long)uint.MaxValue);
                long Remainder = Max % Difference;
                if (Rand < Max - Remainder)
                {
                    return (int)(MinValue + (Rand % Difference));
                }
            }
        }

    }
}
