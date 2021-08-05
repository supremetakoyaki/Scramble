# Scramble
Scramble is a NEO: The World Ends with You save editor.

It works for save files for versions 1.00 and 1.01 of the game.

# How to use
You need a decrypted save file of the game. This save file weighs about 3.15MB.
After that, you can [download the latest release](https://github.com/supremetakoyaki/Scramble/releases/) and you're ready to go.

Note that you need the [.NET 5.0 Runtime](https://dotnet.microsoft.com/download/dotnet/5.0/runtime) to run the editor! 
I recommend running it on Windows 10 or 11. But Mac works fine too.

# How to get your save file
- If you have a hackable Switch, you'll need to first be [running CFW](https://switch.homebrew.guide/) and then use a homebrew app to get the save file. For example, I use [JKSV](https://github.com/J-D-K/JKSV/releases/) most of the time. 
- If you have a hackable Switch but still don't want to directly hack it or run CFW, there's a [more obscure method you can use](https://gbatemp.net/threads/edit-ofw-clean-switch-save-data-from-nand-backup-restoring-via-fusee-gelee-payloads.541081/).
- In case you're running the Switch version of the game on an emulator such as Yuzu or Ryujinx, decrypted saves are in your user profile folder, typically named "user". Look for a 3.15MB file called "gamesave" without extension.
- If you have a PS4, I'm afraid I can't help you... yet. You could request the Save Wizard folks to enable Advanced Mode for NEO:TWEWY. That way you could get access to the decrypted PS4 save.

# Features
Right now, Scramble can do the following:
- Edit any of the 10 save slots of the game.
- Edit your game difficulty, experience, current level, money and FP.
- Edit your character stats.
- Edit your pin inventory.
- Edit your clothing inventory.
- Hide character names that you haven't seen or unlocked yet (they will be shown as "Spoiler").
- Change the UI and game data's text to any of these languages: English, Japanese, Spanish and French.

There will be more features coming in the future, so stay tuned!

# Issues, reporting bugs and requests
If you found a bug or another issue, you can open an issue here on GitHub. For more questions or requests about anything else, you can leave a reply on the [GBATemp thread](https://gbatemp.net/threads/scramble-neo-the-world-ends-with-you-save-editor.591780/). I'm actively working on this so I'll try to resolve it ASAP.

# Information for cloning/forking

New contributors who clone the repository may find that they need a class library titled "ntwewy-db". Please download the latest release [here](https://github.com/supremetakoyaki/ntwewy-db/releases/).
They may also find that nearly all the game images are not there. This is mainly to avoid the repository being DMCA'd even though these images are fair uses. There are two options:
- Ignore the fact that the images are gone.
- Wait until I merge the images to the ntwewy-db database (I have this planned.)

# More

I love TWEWY so much and I'm really happy with the sequel. I datamined absolutely everything from the game and I'm determined to make this save editor user-friendly and pleasing to the eye.
Thank you for reading up to here!