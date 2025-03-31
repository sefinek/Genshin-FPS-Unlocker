@echo off
setlocal

set "file_path=D:\Projects\stella\Genshin-FPS-Unlocker\unlockfps_nc.sln"
set "vs_path=C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe"

echo Running unlockfps_nc.sln file as administrator... && echo.

powershell.exe -Command "Start-Process -FilePath '%vs_path%' -ArgumentList '\"%file_path%\"' -Verb RunAs"

endlocal