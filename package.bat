@echo off
echo Building LetMeSpawnCamp (Release)...

dotnet build LetMeSpawnCamp.csproj -c Release
if %errorlevel% neq 0 (
    echo Build failed!
    pause
    exit /b %errorlevel%
)

echo Creating package folder...
set RELEASE_DIR=ReleasePackage
if exist %RELEASE_DIR% rmdir /S /Q %RELEASE_DIR%
mkdir %RELEASE_DIR%
mkdir "%RELEASE_DIR%\BepInEx\plugins"

echo Copying files...
copy /Y "bin\Release\netstandard2.1\LetMeSpawnCamp.dll" "%RELEASE_DIR%\BepInEx\plugins\"
if exist "README.md" copy /Y "README.md" %RELEASE_DIR%\
if exist "manifest.json" copy /Y "manifest.json" %RELEASE_DIR%\
if exist "icon.png" copy /Y "icon.png" %RELEASE_DIR%\

echo Zipping package...
powershell Compress-Archive -Path "%RELEASE_DIR%\*" -DestinationPath "LetMeSpawnCamp_Release.zip" -Force

echo.
echo Packaging complete! LetMeSpawnCamp_Release.zip is ready.
echo Cleaning up temp folder...
rmdir /S /Q %RELEASE_DIR%
pause
