@echo off
SETLOCAL EnableDelayedExpansion

SET "SOLUTION_PATH=unlockfps_nc.sln"
SET "PROJECT_PATH=unlockfps_nc\Genshin FPS Unlocker.csproj"
SET "RELEASE_DIR=unlockfps_nc\bin\Release"
SET "UPLOAD_DIR=Upload"
SET "ZIP_SELF=%UPLOAD_DIR%\genshin-fps-unlocker.selfcontained.zip"
SET "ZIP_NORMAL=%UPLOAD_DIR%\genshin-fps-unlocker.zip"
SET "CHECKSUMS_MD=%UPLOAD_DIR%\CHECKSUMS.md"
SET "HASHES=SHA256 SHA384 SHA512"


echo ============================================
echo Cleaning up old files and directories...
echo ============================================
CALL :RemoveDirs "UnlockerStub\x64"
CALL :RemoveDirs "unlockfps_nc\bin"
CALL :RemoveDirs "unlockfps_nc\obj"
CALL :RemoveDirs "%UPLOAD_DIR%"
CALL :RemoveFiles "unlockfps_nc\Resources\UnlockerStub.exp" "unlockfps_nc\Resources\UnlockerStub.lib" "unlockfps_nc\Resources\UnlockerStub.pdb"


echo. && echo ============================================
echo Preparing upload directory...
echo ============================================
IF NOT EXIST "%UPLOAD_DIR%" (
    echo Creating "%UPLOAD_DIR%"...
    mkdir "%UPLOAD_DIR%"
    IF %ERRORLEVEL% NEQ 0 (
        echo ERROR: Failed to create "%UPLOAD_DIR%".
        goto EndScript
    )
)


REM ====================================================================================================================
REM BUILD SELF-CONTAINED
echo. && echo ============================================
echo Building self-contained...
echo ============================================
dotnet publish "%PROJECT_PATH%" -c Release -r win-x64 --self-contained true -o "%RELEASE_DIR%\self" || GOTO EndScript

echo. && echo ============================================
echo Compressing self-contained build...
echo ============================================
pushd "%RELEASE_DIR%\self" && (
    7z a -tzip "%~dp0%ZIP_SELF%" * || (
        echo ERROR: Failed to create self-contained ZIP archive!
        popd & GOTO EndScript
    )
    popd
)


REM ====================================================================================================================
REM BUILD NORMAL
echo. && echo ============================================
echo Building framework-dependent...
echo ============================================
dotnet publish "%PROJECT_PATH%" -c Release -r win-x64 --self-contained false -o "%RELEASE_DIR%\normal" || GOTO EndScript

echo. && echo ============================================
echo Compressing framework-dependent build...
echo ============================================
pushd "%RELEASE_DIR%\normal" && (
    7z a -tzip "%~dp0%ZIP_NORMAL%" * || (
        echo ERROR: Failed to create framework-dependent ZIP archive!
        popd & GOTO EndScript
    )
    popd
)


REM ====================================================================================================================
REM GENERATE CHECKSUMS
echo. && echo ============================================
echo Generating checksums...
echo ============================================
(
    echo ## Information
    echo This fork is dedicated to the Stella Mod application. If you want to use this tool, consider installing ^[Genshin Stella Mod^]^(https://stella.sefinek.net^).
    echo.
    echo ## Checksums
    echo.
    echo ### genshin-fps-unlocker.selfcontained.zip
    echo *If you don't have ^[.NET 9^]^(https://dotnet.microsoft.com/en-us/download/dotnet/9.0^) installed, recommended for Linux, larger size due to the built-in .NET Runtime.*
    FOR %%H IN (%HASHES%) DO (
        echo.
        echo ^<details^>
        echo     ^<summary^>%%H^</summary^>
        FOR /F "usebackq skip=1" %%A IN (`certutil -hashfile "%ZIP_SELF%" %%H ^| findstr /v "CertUtil"`) DO (
            echo     ^<code^>%%A^</code^>
        )
        echo ^</details^>
    )
    echo.
    echo ### genshin-fps-unlocker.zip
    echo *If you have ^[.NET 9^]^(https://dotnet.microsoft.com/en-us/download/dotnet/9.0^) installed, smaller size.*
    FOR %%H IN (%HASHES%) DO (
        echo.
        echo ^<details^>
        echo     ^<summary^>%%H^</summary^>
        FOR /F "usebackq skip=1" %%A IN (`certutil -hashfile "%ZIP_NORMAL%" %%H ^| findstr /v "CertUtil"`) DO (
            echo     ^<code^>%%A^</code^>
        )
        echo ^</details^>
    )
) > "%CHECKSUMS_MD%"

echo. && echo ============================================
echo Process completed successfully!
echo ============================================


REM ====================================================================================================================
:EndScript
    echo.
    del "temp_hash.txt" 2>NUL
    pause
    ENDLOCAL
    GOTO :EOF

:RemoveDirs
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


:RemoveFiles
    IF "%~1"=="" (
        echo ERROR: No files specified for deletion.
        exit /b 1
    )

    FOR %%F IN (%*) DO (
        IF EXIST "%%F" (
            del /q "%%F" && echo Deleted file: %%F || (
                echo ERROR: Failed to delete %%F.
                exit /b 1
            )
        ) ELSE (
            echo File %%F not found, skipping...
        )
    )
    GOTO :EOF