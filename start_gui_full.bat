@echo off
REM ========================================================================
REM BugSearch2 GUI Control Center - Windows Startup Script
REM ========================================================================
REM
REM This script automatically performs:
REM 1. Check/Create Python virtual environment
REM 2. Install dependencies
REM 3. Launch GUI application
REM
REM Usage: Double-click start_gui.bat
REM ========================================================================

echo.
echo ========================================================================
echo BugSearch2 GUI Control Center - Starting...
echo ========================================================================
echo.

REM Set current directory to script location
cd /d "%~dp0"

REM Check Python executable
where python >nul 2>&1
if %errorlevel% neq 0 (
    echo [ERROR] Python not found.
    echo.
    echo Please install Python 3.11 or later:
    echo https://www.python.org/downloads/
    echo.
    pause
    exit /b 1
)

REM Check Python version
for /f "tokens=2" %%i in ('python --version 2^>^&1') do set PYTHON_VERSION=%%i
echo [INFO] Python version: %PYTHON_VERSION%

REM Check virtual environment
if not exist "venv\" (
    echo.
    echo [INFO] Virtual environment not found. Creating...
    python -m venv venv
    if %errorlevel% neq 0 (
        echo [ERROR] Failed to create virtual environment.
        pause
        exit /b 1
    )
    echo [OK] Virtual environment created.
) else (
    echo [OK] Virtual environment found.
)

REM Activate virtual environment
echo.
echo [INFO] Activating virtual environment...
call venv\Scripts\activate.bat
if %errorlevel% neq 0 (
    echo [ERROR] Failed to activate virtual environment.
    pause
    exit /b 1
)

REM Check dependencies
echo.
echo [INFO] Checking dependencies...

REM Install requirements.txt
if exist "requirements.txt" (
    echo [INFO] Installing packages from requirements.txt...
    pip install -q -r requirements.txt
    if %errorlevel% neq 0 (
        echo [WARN] Some packages failed to install.
    ) else (
        echo [OK] Packages from requirements.txt installed.
    )
)

REM Install requirements_gui.txt
if exist "requirements_gui.txt" (
    echo [INFO] Installing GUI dependencies from requirements_gui.txt...
    pip install -q -r requirements_gui.txt
    if %errorlevel% neq 0 (
        echo [ERROR] Failed to install GUI dependencies.
        echo.
        echo Please install manually:
        echo   pip install -r requirements_gui.txt
        pause
        exit /b 1
    ) else (
        echo [OK] GUI dependencies installed.
    )
)

REM Check CustomTkinter installation
python -c "import customtkinter" >nul 2>&1
if %errorlevel% neq 0 (
    echo.
    echo [WARN] CustomTkinter not installed.
    echo [INFO] Installing CustomTkinter...
    pip install customtkinter
    if %errorlevel% neq 0 (
        echo [ERROR] Failed to install CustomTkinter.
        pause
        exit /b 1
    )
)

REM Check psutil installation
python -c "import psutil" >nul 2>&1
if %errorlevel% neq 0 (
    echo.
    echo [WARN] psutil not installed.
    echo [INFO] Installing psutil...
    pip install psutil
    if %errorlevel% neq 0 (
        echo [ERROR] Failed to install psutil.
        pause
        exit /b 1
    )
)

REM Check GUI file existence
if not exist "gui_main.py" (
    echo.
    echo [ERROR] gui_main.py not found.
    echo.
    echo Please run from project root directory.
    pause
    exit /b 1
)

REM Launch GUI
echo.
echo ========================================================================
echo [INFO] Launching BugSearch2 GUI Control Center...
echo ========================================================================
echo.
echo [TIP] This window will close automatically when GUI is closed.
echo [TIP] Press Ctrl+C to force quit.
echo.

python gui_main.py

REM Check exit code
if %errorlevel% neq 0 (
    echo.
    echo [ERROR] GUI application exited abnormally.
    echo.
    echo If error occurred, please check:
    echo   1. Python 3.11 or later is installed
    echo   2. Required packages are installed
    echo   3. gui_main.py file is not corrupted
    echo.
    pause
    exit /b 1
)

echo.
echo [INFO] GUI application exited normally.
echo.
pause
