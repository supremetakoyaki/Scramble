# Scramble [![Download](https://img.shields.io/github/downloads/supremetakoyaki/Scramble/total.svg?)](https://github.com/supremetakoyaki/Scramble/releases)

![Scramble logo](https://i.imgur.com/cMt6bb6.png)
![Screenshot of the editor launcher and NEO:TWEWY mode](https://i.imgur.com/tdU8O3k.png)

Scramble is a save editor for games in the The World Ends with You series.
[Click here for the GBATemp thread.](https://gbatemp.net/threads/scramble-neo-the-world-ends-with-you-save-editor.591780/)


# Compatibility
| Title                                | Platform    | Compatible? |
|--------------------------------------|-------------|-------------|
| Neo: The World Ends with You         | PS4         | ✔           |
| Neo: The World Ends with You         | Switch      | ✔           |
| Neo: The World Ends with You         | PC          | ✔          |
| The World Ends with You: Final Remix | Switch      | ✔           |
| The World Ends with You: Solo Remix  | Android/iOS | ❌*         |
| The World Ends with You              | Nintendo DS | ❌          |

<sub>\* You can use the editor to convert Solo Remix save files to Final Remix (note that this feature is experimental.)</sub>

# How to use
You need a decrypted save file of the game. This save file weighs about 3.15MB (NEO), and 50KB (Final Remix).
After that, you can [download the latest release](https://github.com/supremetakoyaki/Scramble/releases/) and you're ready to go.

From version 0.9 onwards, Scramble targets .NET Framework 4.8. If you use an updated Windows 10 or 11, you don't need to install anything. In case you haven't updated your Windows in years, you need to install [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48).
Versions previous to 0.9 require the [.NET 5.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/5.0/runtime) in order to run the program. 

# How to get your save file
- For PC save files, check "Documents/Neo The World Ends with You/Epic Games Store". The file you're looking for is "f1fc4b9d54965358d41213ae8ff0a0f7" (fun fact, it's the MD5 hash of the word "gamesave")
- If you have a hackable Switch, you'll need to first be [running CFW](https://switch.homebrew.guide/) and then use a homebrew app to get the save file. For example, I use [JKSV](https://github.com/J-D-K/JKSV/releases/) most of the time. 
- If you have a hackable Switch but still don't want to directly hack it or run CFW, there's a [more obscure method you can use](https://gbatemp.net/threads/edit-ofw-clean-switch-save-data-from-nand-backup-restoring-via-fusee-gelee-payloads.541081/).
- In case you're running the Switch version of the game on an emulator such as Yuzu or Ryujinx, decrypted saves are in your user profile folder, typically named "user". Look for a file called "gamesave" without extension.
- If you have a PS4, use [Save Wizard](https://www.savewizard.net/)'s Advanced Mode to get your decrypted save file (this is a paid software, unfortunately.)

# Features
**NEO TWEWY Save Editing:**
- Edit your game settings, and also unlock DLC items. **(PS4/Switch only)**
- Edit any of the 10 save slots of the game.
- Edit your party members.
- Edit your game difficulty, experience, current level, calories eaten (satiety), money, FP and menu music.
- Edit your character stats.
- Edit your pin inventory.
- Edit your clothing inventory.
- Edit your social network tree and obtained rewards.
- Edit your noisepedia.
- Edit your furthest reached day.
- Edit your scramble slam scores.
- Edit your graffiti wall / trophies, and export it as an image.
- Edit your shop and brand data.
- Save data randomizer (BETA)
- Hide character names that you haven't seen or unlocked yet (they will be shown as "Spoiler").
- Change the UI and game data's text to any of these languages: English, Japanese, Spanish and French.

**TWEWY Final Remix Save Editing (BETA)**
- Edit your character and game stats.
- Edit your items.
- Edit your pins.

**Other utilities**
- **Convert between PS4/Switch and PC save files of NEO, and viceversa.**
- Decrypt and re-encrypt .unity3d assets from the PC release of NEO.
- Convert TWEWY Solo Remix save to TWEWY Final Remix.

# Upcoming features
**For NEO:**
- Continue working on the randomizer

**For Final Remix:**
- ...Everything else. Final Remix support is still in a very early state but I'll work on it as soon as I have time.

# Special thanks
- **tafice**, for the encryption keys of the PC version of NEO.

# Donations
If you want to show support, you can [donate on my ko-fi page](https://ko-fi.com/gyakutensaiban)! It is completely voluntary, and I'll appreciate it.

# Issues, reporting bugs and requests
If you found a bug or another issue, you can open an issue here on GitHub. For more questions or requests about anything else, you can leave a reply on the [GBATemp thread](https://gbatemp.net/threads/scramble-neo-the-world-ends-with-you-save-editor.591780/).

# Information for cloning/forking
New contributors who clone the repository may find that they need two class libraries, titled "[ntwewy-db](https://github.com/supremetakoyaki/ntwewy-db/releases/)" and "[finalremix-db](https://github.com/supremetakoyaki/finalremix-db/releases/)". Check for other necessary libraries in the .csproj file.
