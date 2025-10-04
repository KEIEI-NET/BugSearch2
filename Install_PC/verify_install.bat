@echo off
REM ============================================
REM Claude Code Aliases インストール確認スクリプト
REM バージョン: v4.0.1
REM ============================================

echo.
echo ========================================
echo Claude Code Aliases インストール確認
echo ========================================
echo.

set "CLAUDE_CONFIG_DIR=%APPDATA%\claude-code"
set "ALIASES_FILE=%CLAUDE_CONFIG_DIR%\aliases.md"

echo [INFO] 確認先: %ALIASES_FILE%
echo.

if exist "%ALIASES_FILE%" (
    echo [OK] aliases.md が見つかりました！
    echo.
    echo ファイル情報:
    dir "%ALIASES_FILE%"
    echo.
    echo 最初の30行を表示:
    echo ----------------------------------------
    powershell -Command "Get-Content '%ALIASES_FILE%' | Select-Object -First 30"
    echo ----------------------------------------
    echo.
    echo [OK] インストール確認完了
) else (
    echo [ERROR] aliases.md が見つかりません
    echo.
    echo インストールされていないか、別の場所にある可能性があります。
    echo install_windows.bat を実行してインストールしてください。
    echo.
)

pause
