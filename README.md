# Genshin Impact FPS Unlocker [modified by Sefinek]
> [Custom release for Genshin Stella Mod. Read more...](https://sefinek.net/genshin-impact-reshade)

## Information
- This tool helps you to unlock the 60 FPS limit in the game.
- This is an external program which uses **WriteProcessMemory** to write the desired fps to the game.
- Handle protection bypass is already included.
- Does not require a driver for R/W access.
- Supports OS and CN version.
- Should work for future updates.
- If the source needs to be updated, I'll try to do it as soon as possible.
- You can download the compiled binary over at [Release](https://github.com/sefinek24/genshin-fps-unlock/releases) if you don't want to compile it yourself.

## Usage
- Make sure you have the [Visual C++ 2015-2022 Redistributable (x64)](https://aka.ms/vs/17/release/vc_redist.x64.exe) and [.NET Framework 4.8.1](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net481) installed
- If it is your first time running, unlocker will attempt to find your game through the registry. If it fails, then it will ask you to either browse or run the game.
- Place the compiled exe anywhere you want.
- Make sure your game is closed—the unlocker will automatically start the game for you.
- Run the exe as administrator, and leave the exe running.
> It requires administrator because the game needs to be started by the unlocker and the game requires such permission.
- To inject other third-party plugins (e.g. ReShade), go to `Options->Settings->DLLs` and click add.

## Notes
- My test account is currently AR55, can't guarantee it will be safe forever, but honestly though, I doubt they would ban you for this.
- Modifying game memory with an unauthorized third party application is a violation of the ToS, so use it at your own risk. Same thing applies for injecting ReShade.

## Compiling
Use Visual Studio 2022 Community Edition to compile.

## Version 2.0.0 Changes
[Click here](https://github.com/34736384/genshin-fps-unlock#version-200-changes)

# Chinese translation
[Click here](https://github.com/34736384/genshin-fps-unlock#%E5%8E%9F%E7%A5%9E%E8%A7%A3%E9%94%81fps%E9%99%90%E5%88%B6)