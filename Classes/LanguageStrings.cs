using System.Collections.Generic;

namespace Scramble.Classes
{
    public class LanguageStrings
    {
        public Dictionary<string, string> English = new Dictionary<string, string>()
        {
            // Scramble Form
            { "{ScrambleShortTitle}", "Scramble" },
            { "{ScrambleLongTitle}", "Scramble — NEO TWEWY Save Editor" },
            { "{Language}", "Language" },
            { "{Notice}", "Notice" },
            { "{Warning}", "Warning" },
            { "{Hey}", "Hey!" },
            { "{OpenSaveFile}", "Open Save File..." },
            { "{SaveChanges}", "Save Changes" },
            { "{SaveSlots}", "Save Slots" },
            { "{Autosave}", "Autosave" },
            { "{BackupCheckbox}", "Make a backup" },
            { "{DumpSlotData}", "Dump Slot Data" },
            { "{ImportSlotData}", "Import Slot Data" },
            { "{Global}", "Global" },
            { "{SettingsEditor}", "Settings Editor" },
            { "{MiscEditor}", "Misc. Editor" },
            { "{ThisSelectedSlot}", "This selected slot" },
            { "{InitializedSlotCheckbox}", "Initialized slot" },
            { "{DateAndTimeOfSave}", "Date and time of save:" },
            { "{Difficulty}", "Difficulty:" },
            { "{Experience}", "Experience:" },
            { "{CurrentLevel}", "Current Level:" },
            { "{Money}", "Money:" },
            { "{FP}", "FP:" },
            { "{Lv}", "Lv." },
            { "{YourParty}", "Your party" },
            { "{CharacterEditor}", "Character Editor" },
            { "{PinsEditor}", "Pins Editor" },
            { "{ClothingEditor}", "Clothing Editor" },
            { "{SocialEditor}", "Social Editor" },
            { "{CollectionEditor}", "Collection Editor" },
            { "{NoisepediaEditor}", "Noisepedia Editor" },

            {"{NoOne}", "(no one)" },
            {"{None}", "(none)" },
            {"{YesLowercase}", "yes" },
            {"{NoLowercase}", "no" },
            {"{DeckOne}", "Deck 1" },
            {"{DeckTwo}", "Deck 2" },
            {"{DeckThree}", "Deck 3" },

            { "{Items}", "Items" },
            { "{SaveId}", "Save ID" },
            { "{ItemId}", "Item ID" },
            { "{Name}", "Name" },
            { "{Type}", "Type" },
            { "{Unlocked}", "Unlocked" },
            { "{Unseen}", "Unseen" },
            { "{UnlockAll}", "(Un)lock all" },
            { "{UnseeAll}", "(Un)see all" },
            { "{UnlockSelected}", "(Un)lock selected" },
            { "{UnseeSelected}", "(Un)see selected" },

            { "{NoSelectedPin}", "(No selected pin)" },
            { "{PinInventory}", "Pin Inventory" },
            { "{AllPins}", "All Pins" },
            { "{Id}", "ID" },
            { "{PinId}", "Pin ID" },
            { "{Level}", "Level" },
            { "{Level:}", "Level" },
            { "{EXP}", "EXP" },
            { "{EXP:}", "EXP:" },
            { "{Mastered}", "Mastered" },
            { "{Amount}", "Amount" },
            { "{Amount:}", "Amount:" },
            { "{RemoveThisPin}", "Remove this pin" },
            { "{RemoveAll}", "Remove all" },
            { "{MaxLevel}", "Max level:" },
            { "{Equipped}", "Equipped:" },
            { "{MasterThisPin}", "Master this pin" },
            { "{AddPin}", "Add pin" },
            { "{x99}", "x99" },
            { "{AddEachOfEveryPin}", "Add each of every pin" },

            // Dialog Messages
            { "DLG_FileNotFound", "The file doesn't exist." },
            { "DLG_SaveDataAlreadyOpened", "There is a save file open already. If you didn't save changes, they will be lost." },
            { "DLG_InvalidSaveFile", "This save file is invalid. Size must be exactly 3,200,512 bytes" },
            { "DLG_BackupCheckboxNotChecked", "You didn't check the \"Make a backup\" checkbox. If the save file ends up being corrupted I will laugh at you.\nDo you wish to continue?" },
            { "DLG_SaveDataSaved", "The changes have been successfully made to the save file." },
            { "DLG_SaveSlotDumped", "The save slot has been dumped." },
            { "DLG_BackupNotPossibleFileNotFound", "Note that I couldn't make a backup because the original file stopped existing for some reason (did you delete or move it?)" },
            { "DLG_InvalidSlotFile", "This slot file is invalid. Size must be exactly 319,952 bytes." },
            { "DLG_OverwriteSlotPrompt", "Are you sure you want to overwrite this save slot?" },
            { "DLG_DeleteAllPinsAreYouSure", "Are you sure you want to remove all pins from your inventory?" },
            { "DLG_AddAllPinsAreYouSure", "Are you sure you want to add every pin to your inventory?" },
            { "DLG_NoPinsToAddSelected", "You didn't select any pin to add." },
            { "DLG_YouCantAddMorePins", "You can't add more pins of this kind. Maximum value is 99." },
            { "DLG_ZeroPinsWarning", "Note that the game will crash if you have 0 pins.\nMake sure you add enough pins and equip them to your characters." }
        };

        public Dictionary<string, string> Japanese = new Dictionary<string, string>()
        {
            // Scramble Form
            { "{ScrambleShortTitle}", "Scramble" },
            { "{ScrambleLongTitle}", "Scramble — 新すばせかにセーブデータエディタ" },
            { "{Language}", "言語：" },
            { "{Notice}", "Notice" },
            { "{Warning}", "Warning" },
            { "{Hey}", "Hey!" },
            { "{OpenSaveFile}", "ファイルを開く" },
            { "{SaveChanges}", "変更内容を保存" },
            { "{SaveSlots}", "セーブスロット" },
            { "{Autosave}", "オートセーブ" },
            { "{BackupCheckbox}", "バックアップコピー" },
            { "{DumpSlotData}", "スロットをダンプ" },
            { "{ImportSlotData}", "スロットをインポート" },
            { "{Global}", "設定" },
            { "{SettingsEditor}", "設定のエディタ." },
            { "{MiscEditor}", "その他のエディタ" },
            { "{ThisSelectedSlot}", "この選択されたスロット" },
            { "{InitializedSlotCheckbox}", "ゲームが始まり" },
            { "{DateAndTimeOfSave}", "保存された日時：" },
            { "{Difficulty}", "難易度：" },
            { "{Experience}", "EXP：" },
            { "{CurrentLevel}", "現在のLVL：" },
            { "{Money}", "お金：" },
            { "{FP}", "CP：" },
            { "{Lv}", "LVL" },
            { "{YourParty}", "パーティー" },
            { "{CharacterEditor}", "主人公のエディタ" },
            { "{PinsEditor}", "バッジのエディタ" },
            { "{ClothingEditor}", "ファッションのエディタ" },
            { "{SocialEditor}", "ソーシャルのエディタ" },
            { "{CollectionEditor}", "コレクショのエディタ" },
            { "{NoisepediaEditor}", "エネミーのエディタ" },

            {"{NoOne}", "（誰も）" },
            {"{None}", "（なし）" },
            {"{YesLowercase}", "yes" },
            {"{NoLowercase}", "no" },
            {"{DeckOne}", "デッキ１" },
            {"{DeckTwo}", "デッキ２" },
            {"{DeckThree}", "デッキ３" },

            { "{Items}", "アイテム" },
            { "{SaveId}", "セーブID" },
            { "{ItemId}", "アイテムID" },
            { "{Name}", "項目名" },
            { "{Type}", "タイプ" },
            { "{Unlocked}", "ロック解除" },
            { "{Unseen}", "見えない" },
            { "{UnlockAll}", "すべてロック/を解除" },
            { "{UnseeAll}", "すべて見る/見えない" },
            { "{UnlockSelected}", "選択したアイテムをロック/を解除" },
            { "{UnseeSelected}", "選択したアイテムを見る/見えない" },

            { "{NoSelectedPin}", "（バッジ選択されていません）" },
            { "{PinInventory}", "バッジの在庫" },
            { "{AllPins}", "すべてのバッジ" },
            { "{Id}", "ID" },
            { "{PinId}", "バッジID" },
            { "{Level}", "レベル" },
            { "{Level:}", "レベル：" },
            { "{EXP}", "EXP" },
            { "{EXP:}", "EXP：" },
            { "{Mastered}", "MASTER" },
            { "{Amount}", "量" },
            { "{Amount:}", "量：" },
            { "{RemoveThisPin}", "このバッジの削除" },
            { "{RemoveAll}", "すべて削除" },
            { "{MaxLevel}", "最大レベル：" },
            { "{Equipped}", "装備した：" },
            { "{MasterThisPin}", "マスターする" },
            { "{AddPin}", "バッジの追加" },
            { "{x99}", "x99" },
            { "{AddEachOfEveryPin}", "バッジの各を追加" },

            // Dialog Messages
            { "DLG_FileNotFound", "ファイルが見つかりません。" },
            { "DLG_SaveDataAlreadyOpened", "There is a save file open already. If you didn't save changes, they will be lost." },
            { "DLG_InvalidSaveFile", "セーブファイルは無効です。\nサイズは　３２００５１２バイトである必要があります。" },
            { "DLG_BackupCheckboxNotChecked", "You didn't check the \"Make a backup\" checkbox. If the save file ends up being corrupted I will laugh at you.\nDo you wish to continue?" },
            { "DLG_SaveDataSaved", "変更は保存されました。" },
            { "DLG_SaveSlotDumped", "セーブスロットはだんぽされました。" },
            { "DLG_BackupNotPossibleFileNotFound", "セーブファイルが削除されたため、\nバックアップが不可能です。" },
            { "DLG_InvalidSlotFile", "このスロットファイルは無効です。\nサイズは　３１９９５２バイトである必要があります。" },
            { "DLG_OverwriteSlotPrompt", "このセーブスロットを上書きしますか？" },
            { "DLG_DeleteAllPinsAreYouSure", "すべての在庫のバッジを削除しますか？" },
            { "DLG_AddAllPinsAreYouSure", "すべてのバッジを追加しますか？" },
            { "DLG_NoPinsToAddSelected", "バッジが選択されていないか。" },
            { "DLG_YouCantAddMorePins", "これ以上同じ特性を持つバッジを追加できません。\n最大値は９９。" },
            { "DLG_ZeroPinsWarning", "注：０バッジを持っている場合の結果はゲームのクラッシュ。\n必ずバッジ化も装備してください。" }
        };

        public Dictionary<string, string> Spanish = new Dictionary<string, string>()
        {
            // Scramble Form
            { "{ScrambleShortTitle}", "Scramble" },
            { "{ScrambleLongTitle}", "Scramble — NEO TWEWY Save Editor" },
            { "{Language}", "Idioma:" },
            { "{Notice}", "Aviso" },
            { "{Warning}", "Advertencia" },
            { "{Hey}", "Atención" },
            { "{OpenSaveFile}", "Abrir archivo..." },
            { "{SaveChanges}", "Guardar cambios" },
            { "{SaveSlots}", "Ranuras de guardado" },
            { "{Autosave}", "Autoguardado" },
            { "{BackupCheckbox}", "Hacer un respaldo" },
            { "{DumpSlotData}", "Exportar ranura" },
            { "{ImportSlotData}", "Importar ranura" },
            { "{Global}", "Global" },
            { "{SettingsEditor}", "Editar config." },
            { "{MiscEditor}", "Editar misceláneos" },
            { "{ThisSelectedSlot}", "Ranura seleccionada" },
            { "{InitializedSlotCheckbox}", "Ranura iniciada" },
            { "{DateAndTimeOfSave}", "Fecha y hora de guardado:" },
            { "{Difficulty}", "Dificultad:" },
            { "{Experience}", "Experiencia:" },
            { "{CurrentLevel}", "Nivel actual:" },
            { "{Money}", "Dinero:" },
            { "{FP}", "PA:" },
            { "{Lv}", "Nv." },
            { "{YourParty}", "Tu equipo" },
            { "{CharacterEditor}", "Editar personajes" },
            { "{PinsEditor}", "Editar pins" },
            { "{ClothingEditor}", "Editar ropa" },
            { "{SocialEditor}", "Editar social" },
            { "{CollectionEditor}", "Editar colecciones" },
            { "{NoisepediaEditor}", "Editar ruidopedia" },

            {"{NoOne}", "(nadie)" },
            {"{None}", "(ninguno)" },
            {"{YesLowercase}", "sí" },
            {"{NoLowercase}", "no" },
            {"{DeckOne}", "Set 1" },
            {"{DeckTwo}", "Set 2" },
            {"{DeckThree}", "Set 3" },

            { "{Items}", "Ítems" },
            { "{SaveId}", "ID del save" },
            { "{ItemId}", "ID del ítem" },
            { "{Name}", "Nombre" },
            { "{Type}", "Tipo" },
            { "{Unlocked}", "Desbloqueado" },
            { "{Unseen}", "No visto" },
            { "{UnlockAll}", "(Des)bloquear todos" },
            { "{UnseeAll}", "Olvidar/ver todos" },
            { "{UnlockSelected}", "(Des)bloquear seleccionados" },
            { "{UnseeSelected}", "Olvidar/ver seleccionados" },

            { "{NoSelectedPin}", "(Ningún pin seleccionado)" },
            { "{PinInventory}", "Mi inventario de pines" },
            { "{AllPins}", "Todos los pines" },
            { "{Id}", "ID" },
            { "{PinId}", "ID del pin" },
            { "{Level}", "Nivel" },
            { "{Level:}", "Nivel:" },
            { "{EXP}", "EXP" },
            { "{EXP:}", "EXP:" },
            { "{Mastered}", "Dominado" },
            { "{Amount}", "Cantidad" },
            { "{Amount:}", "Cantidad:" },
            { "{RemoveThisPin}", "Quitar este pin" },
            { "{RemoveAll}", "Quitar todos" },
            { "{MaxLevel}", "Nivel máx:" },
            { "{Equipped}", "Equipado:" },
            { "{MasterThisPin}", "Dominar pin" },
            { "{AddPin}", "Añadir pin" },
            { "{x99}", "x99" },
            { "{AddEachOfEveryPin}", "Añadir uno de cada pin" },

            // Dialog Messages
            { "DLG_FileNotFound", "El archivo no existe." },
            { "DLG_SaveDataAlreadyOpened", "Ya hay un archivo abierto. Si no guardaste los cambios, se perderán." },
            { "DLG_InvalidSaveFile", "Este archivo no es válido. El tamaño debe ser exactamente 3.200.512 bytes" },
            { "DLG_BackupCheckboxNotChecked", "No marcaste la casilla de \"hacer un respaldo\". Es posible que el archivo guardado termine siendo corrompido.\n¿Deseas proceder?" },
            { "DLG_SaveDataSaved", "Los cambios fueron guardados con éxito." },
            { "DLG_SaveSlotDumped", "La ranura de guardado fue exportada." },
            { "DLG_BackupNotPossibleFileNotFound", "No pude hacer un respaldo porque el archivo original dejó de existir por alguna razón." },
            { "DLG_InvalidSlotFile", "Este archivo de ranura no es válido. El tamaño debe ser exactamente 319.952 bytes." },
            { "DLG_OverwriteSlotPrompt", "¿Estás segur@ de que quieres sobreescribir esta ranura?" },
            { "DLG_DeleteAllPinsAreYouSure", "¿Estás segur@ de que quieres borrar todos los pines de tu inventario?" },
            { "DLG_AddAllPinsAreYouSure", "¿Estás segur@ de que quieres agregar cada pin a tu inventario?" },
            { "DLG_NoPinsToAddSelected", "No seleccionaste ningún pin para añadir." },
            { "DLG_YouCantAddMorePins", "No puedes añadir más pines con la misma característica. El valor máximo es 99." },
            { "DLG_ZeroPinsWarning", "Toma nota que el juego crasheará si tienes 0 pines.\nAsegúrate de agregar pines suficientes y equiparlos a los personajes." }
        };

        public Dictionary<string, string> French = new Dictionary<string, string>()
        {
            // Scramble Form
            { "{ScrambleShortTitle}", "Scramble" },
            { "{ScrambleLongTitle}", "Scramble — NEO TWEWY Save Editor" },
            { "{Language}", "Langue:" },
            { "{Notice}", "Avis" },
            { "{Warning}", "Attention" },
            { "{Hey}", "Choisissez" },
            { "{OpenSaveFile}", "Ouvrir fichier..." },
            { "{SaveChanges}", "Enregistrer" },
            { "{SaveSlots}", "Slots de sauvegarde" },
            { "{Autosave}", "sauve automatique" },
            { "{BackupCheckbox}", "Faire une copie" },
            { "{DumpSlotData}", "Exporter slot" },
            { "{ImportSlotData}", "Importer slot" },
            { "{Global}", "Global" },
            { "{SettingsEditor}", "Éditer paramètres" },
            { "{MiscEditor}", "Éditer misc." },
            { "{ThisSelectedSlot}", "Ce slot sélectionné" },
            { "{InitializedSlotCheckbox}", "Slot commencé" },
            { "{DateAndTimeOfSave}", "Date et heure de sauvegarde:" },
            { "{Difficulty}", "Difficulté:" },
            { "{Experience}", "Experience:" },
            { "{CurrentLevel}", "Niveau actuel:" },
            { "{Money}", "Argent:" },
            { "{FP}", "PA:" },
            { "{Lv}", "LVL " },
            { "{YourParty}", "Ton équipe" },
            { "{CharacterEditor}", "Éditer personnages" },
            { "{PinsEditor}", "Éditer badges" },
            { "{ClothingEditor}", "Éditer vêtements" },
            { "{SocialEditor}", "Éditer social" },
            { "{CollectionEditor}", "Éditer collection" },
            { "{NoisepediaEditor}", "Éditer échopédie" },

            {"{NoOne}", "(personne)" },
            {"{None}", "(aucun)" },
            {"{YesLowercase}", "oui" },
            {"{NoLowercase}", "non" },
            {"{DeckOne}", "Deck 1" },
            {"{DeckTwo}", "Deck 2" },
            {"{DeckThree}", "Deck 3" },

            { "{Items}", "Objets" },
            { "{SaveId}", "ID de la save" },
            { "{ItemId}", "ID de le objet" },
            { "{Name}", "Nom" },
            { "{Type}", "Type" },
            { "{Unlocked}", "Débloqué" },
            { "{Unseen}", "Pas vu" },
            { "{UnlockAll}", "(Dé)bloquer tous" },
            { "{UnseeAll}", "Oublier/voir tous" },
            { "{UnlockSelected}", "(Dé)bloquer sélectionné" },
            { "{UnseeSelected}", "Oublier/voir sélectionné" },

            { "{NoSelectedPin}", "(Aucun badge sélectionné)" },
            { "{PinInventory}", "Mon inventaire de badges" },
            { "{AllPins}", "Tous les badges" },
            { "{Id}", "ID" },
            { "{PinId}", "ID de la badge" },
            { "{Level}", "Niveau" },
            { "{Level:}", "Niveau:" },
            { "{EXP}", "EXP" },
            { "{EXP:}", "EXP:" },
            { "{Mastered}", "Maîtrisé" },
            { "{Amount}", "Quantité" },
            { "{Amount:}", "Quantité:" },
            { "{RemoveThisPin}", "Supprimer ce badge" },
            { "{RemoveAll}", "Supprimer tous" },
            { "{MaxLevel}", "Niveau máx:" },
            { "{Equipped}", "Équipé par:" },
            { "{MasterThisPin}", "Maîtriser ce badge" },
            { "{AddPin}", "Ajouter ce badge" },
            { "{x99}", "x99" },
            { "{AddEachOfEveryPin}", "Ajouter un de chaque badge" },


            // Dialog messages
            { "DLG_FileNotFound", "Le fichier de sauvegarde n'existe pas." },
            { "DLG_SaveDataAlreadyOpened", "Il y a déjà un fichier ouvert. Si vous n'avez pas enregistré vos modifications, elles seront perdues." },
            { "DLG_InvalidSaveFile", "Ce fichier n'est pas valide. La taille doit être exactement de 3 200 512 octets." },
            { "DLG_BackupCheckboxNotChecked", "Vous n'avez pas coché la case \"faire une sauvegarde\". Le fichier enregistré peut finir par être corrompu.\nVoulez-vous toujours continuer ?" },
            { "DLG_SaveDataSaved", "Les modifications ont été enregistrées avec succès." },
            { "DLG_SaveSlotDumped", "La slot de sauvegarde a été exporté" },
            { "DLG_BackupNotPossibleFileNotFound", "Je n'ai pas pu faire de sauvegarde car le fichier d'origine a cessé d'exister pour une raison quelconque." },
            { "DLG_InvalidSlotFile", "Ce fichier de slot n'est pas valide. La taille doit être exactement de 319 952 octets" },
            { "DLG_OverwriteSlotPrompt", "Voulez-vous vraiment écraser cet slot ?" },
            { "DLG_DeleteAllPinsAreYouSure", "Êtes-vous sûr de vouloir supprimer toutes les badges de votre inventaire ?" },
            { "DLG_AddAllPinsAreYouSure", "Êtes-vous sûr de vouloir supprimer toutes les badges de votre inventaire ?" },
            { "DLG_NoPinsToAddSelected", "Vous n'avez sélectionné aucune badge à ajouter." },
            { "DLG_YouCantAddMorePins", "Vous ne pouvez pas ajouter plus de badges avec la même caractéristique. La valeur maximale est 99." },
            { "DLG_ZeroPinsWarning", "Prenez note que le jeu plantera si vous avez 0 badges.\nAssurez-vous d'ajouter suffisamment de badges et de les équiper des personnages." }
        };

        public Dictionary<string, string> Italian = new Dictionary<string, string>();

        public Dictionary<string, string> German = new Dictionary<string, string>();

        public string GetLanguageString(byte Language, string Key)
        {
            switch (Language)
            {
                case 0:
                default:
                    if (English.ContainsKey(Key))
                    {
                        return English[Key];
                    }
                    return Key;

                case 1:
                    if (Japanese.ContainsKey(Key))
                    {
                        return Japanese[Key];
                    }
                    return GetLanguageString(0, Key);

                case 2:
                    if (Spanish.ContainsKey(Key))
                    {
                        return Spanish[Key];
                    }
                    return GetLanguageString(0, Key);

                case 3:
                    if (French.ContainsKey(Key))
                    {
                        return French[Key];
                    }
                    return GetLanguageString(0, Key);

                case 4:
                    if (Italian.ContainsKey(Key))
                    {
                        return Italian[Key];
                    }
                    return GetLanguageString(0, Key);

                case 5:
                    if (German.ContainsKey(Key))
                    {
                        return German[Key];
                    }
                    return GetLanguageString(0, Key);
            }
        }
    }
}
