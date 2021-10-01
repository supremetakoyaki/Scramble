using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scramble.Util
{
    // this isn't done yet.

    public static class NeoTwewySaveConverter
    {
        public const int NEOTWEWYPC_SAVE_LENGTH = 3201072;
        public const int NEOTWEWYPC_GLOBAL_LENGTH = 1083;
        public const int NEOTWEWYSWITCH_SAVE_LENGTH = 3200512;
        public const int NEOTWEWYSWITCH_GLOBAL_LENGTH = 555;
        public const int NEOTWEWY_SLOT_LENGTH = 311989;

        public static byte[] NEOTWEWYPC_ENCRYPTED_MAGIC = new byte[] { 0xCE, 0x37, 0xEC, 0xF1, 0xEC, 0x66, 0xA3, 0xA7, 0x1F, 0x16, 0xAB, 0xF7, 0x68, 0x2A, 0xA7, 0xA5, 0x2D, 0x13, 0x1F, 0x5E, 0x2C, 0x3D, 0xA2, 0x56, 0x0D, 0x29, 0x18, 0x7A, 0x8C, 0x12, 0xB0, 0x83 };

        public static byte[] NEOTWEWYPC_UNKNOWN_END = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 };

        public static byte[] NEOTWEWYSWITCH_MAGIC = new byte[] { 0x6D, 0x74, 0x29, 0x7E, 0x23, 0x45, 0x61, 0x67, 0x21, 0x48, 0x47, 0x5D, 0x7E, 0x64, 0x3E, 0x29, 0x79, 0x6A, 0x7A, 0x54, 0x4A, 0x73, 0x53, 0x2E, 0x20, 0x00, 0x01, 0x00, 0xE0, 0xD5, 0x30, 0x00 };

        public static byte[] NEOTWEWYSWITCH_UNKNOWN_END = new byte[] { 0x00, 0x00, 0x00 };

        public static bool IsValidSaveFile(byte[] RawSaveFile)
        {
            if (RawSaveFile.Length == NEOTWEWYPC_SAVE_LENGTH || RawSaveFile.Length == NEOTWEWYSWITCH_SAVE_LENGTH)
            {
                return true;
            }

            return false;
        }

        public static byte[] ProcessFile(byte[] RawSaveFile, out bool FromPcVer)
        {
            if (RawSaveFile.Length == NEOTWEWYSWITCH_SAVE_LENGTH)
            {
                FromPcVer = false;
                return FromSwitchSaveFile(RawSaveFile);
            }
            else if (RawSaveFile.Length == NEOTWEWYPC_SAVE_LENGTH)
            {
                FromPcVer = true;
                return FromPCSaveFile(RawSaveFile);
            }

            throw new ArgumentException("I attempted to convert a save file that wasn't valid.");
        }

        private static byte[] FromSwitchSaveFile(byte[] RawSaveFile)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                mStream.Write(NEOTWEWYPC_ENCRYPTED_MAGIC, 0, NEOTWEWYPC_ENCRYPTED_MAGIC.Length);

                byte[] SwitchSettings = new byte[555];
                Array.Copy(RawSaveFile, 64, SwitchSettings, 0, 555);

                return mStream.ToArray();
            }
        }

        private static byte[] FromPCSaveFile(byte[] RawSaveFile)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                return mStream.ToArray();
            }
        }
    }
}
