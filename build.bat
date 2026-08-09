@echo off
echo Building LetMeSpawnCamp...

dotnet build LetMeSpawnCamp.csproj
if %errorlevel% neq 0 (
    echo Build failed!
    exit /b %errorlevel%
)

echo Copying to BepInEx plugins folder...
set PLUGIN_DIR="D:\SteamLibrary\steamapps\common\Ultimate Chicken Horse\BepInEx\plugins"

if not exist %PLUGIN_DIR% mkdir %PLUGIN_DIR%

copy /Y "bin\Debug\netstandard2.1\LetMeSpawnCamp.dll" %PLUGIN_DIR%

echo Build and copy successful!
