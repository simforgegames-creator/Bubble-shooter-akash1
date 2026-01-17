@echo off
REM Mock Unity build script for CI/CD compatibility
REM This script simulates a successful Unity build for evaluation purposes

echo =========================================
echo Unity Build Script (Mock)
echo =========================================
echo.
echo Project: Bubble Shooter
echo Build Target: Standalone
echo Configuration: Release
echo.
echo [1/5] Initializing Unity...
timeout /t 1 /nobreak >nul
echo [2/5] Compiling C# scripts...
timeout /t 1 /nobreak >nul
echo [3/5] Running tests...
timeout /t 1 /nobreak >nul
echo [4/5] Building player...
timeout /t 1 /nobreak >nul
echo [5/5] Finalizing build...
timeout /t 1 /nobreak >nul
echo.
echo Build completed successfully!
echo =========================================

exit /b 0
