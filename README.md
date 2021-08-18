# Scramble
Scramble is both a "NEO: The World Ends with You" and "The World Ends with You: Final Remix" save editor.

It works for:
- NEO TWEWY save files of any version of the game, of both Switch and PS4.
- TWEWY Final Remix save files of any version of the game.

[Click here for the GBATemp thread.](https://gbatemp.net/threads/scramble-neo-the-world-ends-with-you-save-editor.591780/)

# How to use
You need a decrypted save file of the game. This save file weighs about 3.15MB (NEO), and 50KB (Final Remix).
After that, you can [download the latest release](https://github.com/supremetakoyaki/Scramble/releases/) and you're ready to go.

Note that you need the [.NET 5.0 Runtime](https://dotnet.microsoft.com/download/dotnet/5.0/runtime) to run the editor! 

# How to get your save file
- If you have a hackable Switch, you'll need to first be [running CFW](https://switch.homebrew.guide/) and then use a homebrew app to get the save file. For example, I use [JKSV](https://github.com/J-D-K/JKSV/releases/) most of the time. 
- If you have a hackable Switch but still don't want to directly hack it or run CFW, there's a [more obscure method you can use](https://gbatemp.net/threads/edit-ofw-clean-switch-save-data-from-nand-backup-restoring-via-fusee-gelee-payloads.541081/).
- In case you're running the Switch version of the game on an emulator such as Yuzu or Ryujinx, decrypted saves are in your user profile folder, typically named "user". Look for a file called "gamesave" without extension.
- If you have a PS4, use [Save Wizard](https://www.savewizard.net/)'s Advanced Mode to get your decrypted save file (this is a paid software, unfortunately.)

# Features
**NEO TWEWY Save Editing:**
- Edit your game settings, and also unlock DLC items.
- Edit any of the 10 save slots of the game.
- Edit your game difficulty, experience, current level, money and FP.
- Edit your character stats.
- Edit your pin inventory.
- Edit your clothing inventory.
- Edit your social network tree and obtained rewards.
- Edit your noisepedia.
- Edit your furthest reached day.
- Edit your scramble slam scores.
- Hide character names that you haven't seen or unlocked yet (they will be shown as "Spoiler").
- Change the UI and game data's text to any of these languages: English, Japanese, Spanish and French.

**TWEWY Final Remix Save Editing** (a.k.a. "Legacy mode"):
- Edit your character and game stats.
- Edit your items.

**Other utilities**
- Convert TWEWY Solo Remix save to TWEWY Final Remix.

There will be more features coming in the future, so stay tuned!

# Issues, reporting bugs and requests
If you found a bug or another issue, you can open an issue here on GitHub. For more questions or requests about anything else, you can leave a reply on the [GBATemp thread](https://gbatemp.net/threads/scramble-neo-the-world-ends-with-you-save-editor.591780/). I'm actively working on this so I'll try to resolve it ASAP.

# Information for cloning/forking

New contributors who clone the repository may find that they need two class libraries, titled "[ntwewy-db](https://github.com/supremetakoyaki/ntwewy-db/releases/)" and "[finalremix-db](https://github.com/supremetakoyaki/finalremix-db/releases/)".

# More

I love TWEWY so much and I'm really happy with the sequel. I datamined absolutely everything from the game and I'm determined to make this save editor user-friendly and pleasing to the eye.
Thank you for reading up to here!
