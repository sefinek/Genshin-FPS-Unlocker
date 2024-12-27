@ECHO OFF
SETLOCAL EnableDelayedExpansion

SET "SOLUTION_PATH=unlockfps_nc.sln"
SET "PROJECT_PATH=unlockfps_nc\Genshin FPS Unlocker.csproj"
SET "BIN_DIR=unlockfps_nc\bin"
SET "OBJ_DIR=unlockfps_nc\obj"
SET "RELEASE_DIR=unlockfps_nc\bin\Release"
SET "UPLOAD_DIR=Upload"
SET "ORIGINAL_ZIP=%UPLOAD_DIR%\genshin-fps-unlocker.zip"
SET "CHECKSUMS_MD=%UPLOAD_DIR%\CHECKSUMS.md"
SET "HASHES=MD2 MD4 MD5 SHA1 SHA256 SHA384 SHA512"

echo =====================================
echo Cleaning up old directories...
echo =====================================
CALL :CleanDir "%BIN_DIR%"
CALL :CleanDir "%OBJ_DIR%"
CALL :CleanDir "%UPLOAD_DIR%"

echo. && echo =====================================
echo Preparing upload directory...
echo =====================================
IF NOT EXIST "%UPLOAD_DIR%" (
    echo Creating "%UPLOAD_DIR%"...
    mkdir "%UPLOAD_DIR%"
    IF %ERRORLEVEL% NEQ 0 (
        echo ERROR: Failed to create "%UPLOAD_DIR%".
        goto EndScript
    )
)

echo. && echo =====================================
echo Building the project...
echo =====================================
dotnet restore "%SOLUTION_PATH%" || GOTO EndScript
dotnet build "%PROJECT_PATH%" --configuration Release --no-restore || GOTO EndScript

echo. && echo =====================================
echo Compressing release directory...
echo =====================================
IF EXIST "%RELEASE_DIR%\net8.0-windows" (
    7z a -tzip "%ORIGINAL_ZIP%" "%RELEASE_DIR%\net8.0-windows\*" || GOTO EndScript
) ELSE (
    echo ERROR: Release directory not found!
    GOTO EndScript
)

echo. && echo =====================================
echo Generating checksums...
echo =====================================
echo ## Checksums for genshin-fps-unlocker.zip > "%CHECKSUMS_MD%"

FOR %%H IN (%HASHES%) DO (
    echo Calculating %%H hash...
    FOR /F "usebackq skip=1" %%A IN (`certutil -hashfile "%ORIGINAL_ZIP%" %%H ^| findstr /v "CertUtil"`) DO (
        echo - **%%H:** `%%A` >> "%CHECKSUMS_MD%"
    )
)

echo. && echo =====================================
echo Process completed successfully!
echo =====================================

:EndScript
    echo.
    del "temp_hash.txt" 2>NUL
    pause
    ENDLOCAL
    GOTO :EOF

:CleanDir
    IF EXIST %1 (
        echo Deleting %1...
        rmdir /s /q %1 || (
            echo ERROR: Failed to delete %1.
            exit /b 1
        )
    ) ELSE (
        echo Directory %1 not found, skipping...
    )
    GOTO :EOF