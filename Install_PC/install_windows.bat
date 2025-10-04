@echo off
REM ============================================
REM Claude Code Aliases インストーラー (Windows)
REM バージョン: v4.0.1
REM ============================================

echo.
echo ========================================
echo Claude Code Aliases インストーラー
echo ========================================
echo.

REM Claude Code 設定ディレクトリのパス
set "CLAUDE_CONFIG_DIR=%APPDATA%\claude-code"
set "ALIASES_FILE=%CLAUDE_CONFIG_DIR%\aliases.md"

echo [INFO] インストール先: %CLAUDE_CONFIG_DIR%
echo.

REM ディレクトリ作成
if not exist "%CLAUDE_CONFIG_DIR%" (
    echo [INFO] 設定ディレクトリを作成: %CLAUDE_CONFIG_DIR%
    mkdir "%CLAUDE_CONFIG_DIR%"
) else (
    echo [INFO] 設定ディレクトリ確認: %CLAUDE_CONFIG_DIR%
)

REM バックアップ作成（既存ファイルがある場合）
if exist "%ALIASES_FILE%" (
    echo [WARNING] 既存のaliases.mdが見つかりました
    set "BACKUP_FILE=%ALIASES_FILE%.backup_%date:~0,4%%date:~5,2%%date:~8,2%_%time:~0,2%%time:~3,2%%time:~6,2%"
    set "BACKUP_FILE=%BACKUP_FILE: =0%"
    echo [INFO] バックアップ作成: %BACKUP_FILE%
    copy "%ALIASES_FILE%" "%BACKUP_FILE%" >nul
)

REM aliases.md をコピー
echo [INFO] aliases.md をインストール中...
copy "%~dp0aliases.md" "%ALIASES_FILE%" >nul

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ========================================
    echo [OK] インストール完了！
    echo ========================================
    echo.
    echo インストール場所:
    echo   %ALIASES_FILE%
    echo.
    echo 使用方法:
    echo   @perfect ユーザー認証機能を実装して
    echo   @tdd 決済処理ロジックを実装して
    echo   @validate apply_improvements_from_report.py
    echo   @quick プロトタイプ作成して
    echo.
    echo 詳細は以下をご確認ください:
    echo   type "%ALIASES_FILE%"
    echo.
) else (
    echo.
    echo [ERROR] インストールに失敗しました
    echo エラーコード: %ERRORLEVEL%
    echo.
    pause
    exit /b 1
)

pause
