@ECHO OFF
SETLOCAL

SET "SOLUTION_PATH=.\Genshin FPS Unlocker.sln"
SET "BIN_DIR=.\unlockfps_nc\bin"
SET "OBJ_DIR=.\unlockfps_nc\obj"
SET "RELEASE_DIR=.\unlockfps_nc\bin\Release"


IF EXIST "%BIN_DIR%" (
    echo Deleting "%BIN_DIR%"...
    rmdir /s /q "%BIN_DIR%"
    IF %ERRORLEVEL% NEQ 0 (
        echo Failed to delete "%BIN_DIR%".
        goto EndScript
    )
) ELSE (
    echo Directory "%BIN_DIR%" not found, skipping...
)
IF EXIST "%OBJ_DIR%" (
    echo Deleting "%OBJ_DIR%"...
    rmdir /s /q "%OBJ_DIR%"
    IF %ERRORLEVEL% NEQ 0 (
        echo Failed to delete "%OBJ_DIR%".
        goto EndScript
    )
) ELSE (
    echo Directory "%OBJ_DIR%" not found, skipping...
)
echo.


echo Building...
dotnet restore "%SOLUTION_PATH%"
IF %ERRORLEVEL% NEQ 0 (
    echo Error occurred during dotnet restore.
    goto EndScript
)
echo Dotnet restore completed successfully! && echo.

dotnet build "%SOLUTION_PATH%" --configuration Release --no-restore
IF %ERRORLEVEL% NEQ 0 (
    echo Error occurred during dotnet build.
    goto EndScript
)
echo Dotnet build completed successfully! && echo.


echo Compressing Release directory...
.\Dependencies\7z.exe a -tzip "Release.zip" "%RELEASE_DIR%\net8.0-windows\*"
IF %ERRORLEVEL% NEQ 0 (
    echo Error occurred during compression.
    goto EndScript
)
echo Compression completed successfully!


:EndScript
echo.
pause
ENDLOCAL
