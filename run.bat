@echo off
taskkill /IM UltimateChickenHorse.exe /F >nul 2>&1
echo Running build script...
call build.bat

if %errorlevel% neq 0 (
    echo Build failed, game will not start.
    exit /b %errorlevel%
)

echo Starting Ultimate Chicken Horse via Steam...

start "" "steam://rungameid/386940"
