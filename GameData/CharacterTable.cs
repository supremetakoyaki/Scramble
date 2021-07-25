using System.Collections.Generic;

namespace Scramble.GameData
{
    public static class CharacterTable
    {
        private static Dictionary<int, string> CharacterNames = new Dictionary<int, string>()
        {
            { 1, "Rindo" },
            { 2, "Shoka" },
            { 3, "Fret" },
            { 4, "Nagi" },
            { 5, "Beat" },
            { 6, "Neku" },
            { 7, "Minamimoto" }
        };

        public static string GetCharacterName(int Id)
        {
            if (CharacterNames.ContainsKey(Id))
            {
                return CharacterNames[Id];
            }

            return string.Empty;
        }
    }
}
