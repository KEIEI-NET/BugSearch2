@echo off
REM =======================================================
REM GPT-5-Codex バッチ処理自動実行スクリプト (Windows)
REM =======================================================
echo.
echo ============================================================
echo  GPT-5-Codex コード分析バッチ処理システム
echo  最適化版 (200ファイル/バッチ)
echo ============================================================
echo.

REM 現在の日時を表示
echo 実行開始: %date% %time%
echo.

REM .envファイルの存在確認
if not exist ".env" (
    echo [ERROR] .envファイルが見つかりません
    echo OPENAI_API_KEYとOPENAI_MODELを設定してください
    pause
    exit /b 1
)

REM Pythonの存在確認
py -3 --version >nul 2>&1
if %ERRORLEVEL% NEQ 0 (
    echo [ERROR] Python 3が見つかりません
    echo Python 3をインストールしてください
    pause
    exit /b 1
)

REM レポートディレクトリの作成
if not exist "reports" (
    echo [INFO] reportsディレクトリを作成します
    mkdir reports
)

REM 既存の進捗ファイルの確認
if exist ".batch_progress.json" (
    echo [INFO] 前回の処理を継続します
    echo.
)

REM メイン処理の実行
echo [INFO] バッチ処理を開始します...
echo --------------------------------------------------------
py -3 extract_and_batch_optimized.py

REM エラーチェック
if %ERRORLEVEL% NEQ 0 (
    echo.
    echo ============================================================
    echo [ERROR] 処理中にエラーが発生しました
    echo エラーコード: %ERRORLEVEL%
    echo ============================================================
    echo.
    echo トラブルシューティング:
    echo 1. .envファイルにOPENAI_API_KEYが正しく設定されているか確認
    echo 2. インターネット接続を確認
    echo 3. OpenAI APIの利用制限を確認
    echo 4. batch_processing.logファイルでエラー詳細を確認
    echo.
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo ============================================================
echo [SUCCESS] バッチ処理が正常に完了しました！
echo ============================================================
echo.
echo 生成されたレポート:
echo   - 個別バッチ: reports\AI_batch*_optimized.md
echo   - 統合レポート: reports\COMPLETE_ANALYSIS_OPTIMIZED_GPT5.md
echo.
echo 実行終了: %date% %time%
echo.

REM レポートファイルのサイズを表示
if exist "reports\COMPLETE_ANALYSIS_OPTIMIZED_GPT5.md" (
    echo レポートファイル情報:
    dir "reports\COMPLETE_ANALYSIS_OPTIMIZED_GPT5.md" | findstr /i "COMPLETE"
    echo.
)

echo 処理完了。任意のキーを押して終了してください。
pause >nul