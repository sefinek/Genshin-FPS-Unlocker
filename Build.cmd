@ECHO OFF
SETLOCAL EnableDelayedExpansion

SET "SOLUTION_PATH=.\unlockfps_nc.sln"
SET "PROJECT_PATH=.\unlockfps_nc\Genshin FPS Unlocker.csproj"
SET "BIN_DIR=.\unlockfps_nc\bin"
SET "OBJ_DIR=.\unlockfps_nc\obj"
SET "RELEASE_DIR=.\unlockfps_nc\bin\Release"
SET "UPLOAD_DIR=Upload"
SET "ORIGINAL_ZIP=%UPLOAD_DIR%\genshin-fps-unlocker.zip"
SET "CHECKSUM_TXT=%UPLOAD_DIR%\checksum.txt"
SET "HASHES=MD2 MD4 MD5 SHA1 SHA256 SHA384 SHA512"

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

IF EXIST "%UPLOAD_DIR%" (
    echo Deleting "%UPLOAD_DIR%"...
    rmdir /s /q "%UPLOAD_DIR%"
    IF %ERRORLEVEL% NEQ 0 (
        echo Failed to delete "%UPLOAD_DIR%".
        goto EndScript
    )
) ELSE (
    echo Directory "%UPLOAD_DIR%" not found, skipping...
)

echo Creating "%UPLOAD_DIR%"...
mkdir "%UPLOAD_DIR%"
IF %ERRORLEVEL% NEQ 0 (
    echo Failed to create "%UPLOAD_DIR%".
    goto EndScript
)
echo.

echo Building...
dotnet restore "%SOLUTION_PATH%"
IF %ERRORLEVEL% NEQ 0 (
    echo Error occurred during dotnet restore.
    goto EndScript
)
echo Dotnet restore completed successfully! && echo.

dotnet build "%PROJECT_PATH%" --configuration Release --no-restore
IF %ERRORLEVEL% NEQ 0 (
    echo Error occurred during dotnet build.
    goto EndScript
)
echo Dotnet build completed successfully! && echo.

echo Compressing Release directory...
.\Dependencies\7za.exe a -tzip "%ORIGINAL_ZIP%" "%RELEASE_DIR%\net8.0-windows\*"
IF %ERRORLEVEL% NEQ 0 (
    echo Error occurred during compression.
    goto EndScript
)
echo Compression completed successfully! && echo. && echo.

> "%CHECKSUM_TXT%" echo ------------------ %ORIGINAL_ZIP% ------------------

FOR %%H IN (%HASHES%) DO (
    echo Calculating %%H hash...
    certutil -hashfile "%ORIGINAL_ZIP%" %%H | findstr /v "CertUtil" | findstr /v ":" > "temp_hash.txt"
    SET /p HASH=<"temp_hash.txt"
    SET "HASH=!HASH:* =!"
    echo %%H: !HASH! >> "%CHECKSUM_TXT%"
    SET "HASHED_FILE_NAME=%UPLOAD_DIR%\!HASH!.%%H"
    echo %%H: !HASH!:%ORIGINAL_ZIP% > "!HASHED_FILE_NAME!"
    IF %ERRORLEVEL% NEQ 0 (
        echo Error occurred during hashing.
        goto EndScript
    )
    echo %%H hash calculation completed and hash file !HASHED_FILE_NAME! created.
)

:EndScript
echo.
del "temp_hash.txt"
pause
ENDLOCAL
