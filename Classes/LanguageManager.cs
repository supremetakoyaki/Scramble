using Scramble.Properties;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Scramble.Classes
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public Dictionary<string, string> LanguageStrings { get; set; }

        public Language(int languageId, string languageName)
        {
            LanguageId = languageId;
            LanguageName = languageName;
            LanguageStrings = new Dictionary<string, string>();
        }
    }

    public class LanguageManager
    {
        public SortedDictionary<int, Language> Languages;

        public LanguageManager(ComboBox LanguageComboBox)
        {
            Languages = new SortedDictionary<int, Language>();

            // Load the embedded English.
            string EnglishJson = Resources.ResourceManager.GetObject("lang_en") as string;
            dynamic DeserializedEnglish = JsonSerializer.Deserialize<ExpandoObject>(EnglishJson);
            dynamic DeserializeEnglishStrings = JsonSerializer.Deserialize<ExpandoObject>(DeserializedEnglish.languageStrings.ToString());

            Languages.Add(0, new Language(0, DeserializedEnglish.languageName.ToString()));
            foreach (dynamic Entry in DeserializeEnglishStrings)
            {
                Languages[0].LanguageStrings.Add(Entry.Key.ToString(), Entry.Value.ToString());
            }

            int MaxLang = 0;

            // Load the rest of the languages
            foreach (string FileName in Directory.GetFiles(Environment.CurrentDirectory, "*.json", SearchOption.TopDirectoryOnly))
            {
                if (Path.GetFileName(FileName).StartsWith("lang_"))
                {
                    string LanguageJson = File.ReadAllText(FileName);
                    dynamic DeserializedLanguage = JsonSerializer.Deserialize<ExpandoObject>(LanguageJson);
                    dynamic DeserializeLanguageStrings = JsonSerializer.Deserialize<ExpandoObject>(DeserializedLanguage.languageStrings.ToString());

                    int LangId = LanguageComboBox.Items.Count;
                    int.TryParse(DeserializedLanguage.languageId.ToString(), out LangId);

                    if (LangId > MaxLang)
                    {
                        MaxLang = LangId;
                    }

                    Languages.Add(LangId, new Language(LangId, DeserializedLanguage.languageName.ToString()));
                    foreach (dynamic Entry in DeserializeLanguageStrings)
                    {
                        Languages[LangId].LanguageStrings.Add(Entry.Key.ToString(), Entry.Value.ToString());
                    }
                }
            }

            for (int i = 0; i <= MaxLang; i++)
            {
                if (!Languages.ContainsKey(i) || Languages[i].LanguageId != i)
                {
                    MessageBox.Show(string.Format("Language ID {0} could not be found.", i), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LanguageComboBox.Items.Insert(i, "Invalid language");
                }
                else
                {
                    LanguageComboBox.Items.Insert(i, Languages[i].LanguageName);
                }
            }
        }

        public string GetLanguageString(int Language, string Key)
        {
            if (Languages == null || !Languages.ContainsKey(0))
            {
                return Key;
            }

            string ReturnValue;
            if (Languages.ContainsKey(Language))
            {
                Languages[Language].LanguageStrings.TryGetValue(Key, out ReturnValue);
            }
            else
            {
                Languages[0].LanguageStrings.TryGetValue(Key, out ReturnValue);
            }

            if (ReturnValue == null)
            {
                Languages[0].LanguageStrings.TryGetValue(Key, out ReturnValue);

                if (ReturnValue == null)
                {
                    ReturnValue = "{Error}";
                }
            }

            return ReturnValue;
        }
    }
}
