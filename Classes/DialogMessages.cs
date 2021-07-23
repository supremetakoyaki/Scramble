namespace Scramble.Classes
{
    public static class DialogMessages
    {
        public static string FileNotFound =
            "The file doesn't exist.";

        public static string SaveDataAlreadyOpened =
            "There is a save file open already. This will overwrite it, are you sure?";

        public static string InvalidSaveFile =
            "This save file is invalid. Size must be exactly 3,200,512 bytes";

        public static string HashInvalidOnOpen =
            "This save file has an invalid checksum. It is either corrupted or not a save file at all.\n" +
            "You could try re-calculating the checksum but there's no guarantee it'll work.";
    }
}
