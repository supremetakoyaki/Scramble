namespace Scramble.Classes
{
    public static class DialogMessages
    {
        public static string FileNotFound =
            "The file doesn't exist.";

        public static string SaveDataAlreadyOpened =
            "There is a save file open already. If you didn't save changes, they will be lost.";

        public static string InvalidSaveFile =
            "This save file is invalid. Size must be exactly 3,200,512 bytes";

        public static string BackupCheckboxNotChecked =
            "You didn't check the \"Make a backup\" checkbox. If the save file ends up being corrupted I will laugh at you.\nDo you wish to continue?";

        public static string SaveDataSaved =
            "The changes have been successfully made to the save file.";

        public static string SaveSlotDumped =
            "The save slot has been dumped.";

        public static string BackupNotPossibleFileNotFound =
            "Note that I couldn't make a backup because the original file stopped existing for some reason (did you delete or move it?)";

        public static string InvalidSlotFile =
            "This slot file is invalid. Size must be exactly 319,952 bytes.";

        public static string OverwriteSlotPrompt =
            "Are you sure you want to overwrite this save slot?";

        public static string DeleteAllPinsAreYouSure =
            "Are you sure you want to remove all pins from your inventory?";

        public static string AddAllPinsAreYouSure =
            "Are you sure you want to add every pins to your inventory?";

        public static string NoPinToAddSelected =
            "You didn't select any pin to add.";

        public static string YouCantAddMorePins =
            "You can't add more pins of this kind. Maximum value is 99.";

        public static string ZeroPinsWarning =
            "Note that the game will crash if you have 0 pins.\nMake sure you add enough pins and equip them to your characters.";
    }
}
