namespace Scramble.Util
{
    public static class ByteUtil
    {
        public static bool GetBit(byte b, byte Index)
        {
            return (b & (1 << Index)) != 0;
        }

        public static byte SetBit(byte b, byte Index, bool Value)
        {
            return Value ? (byte)(b | (1 << Index)) : (byte)(b & ~(1 << Index));
        }
    }
}
