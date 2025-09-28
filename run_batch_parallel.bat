@echo off
REM =======================================================
REM GPT-5-Codex 並列処理バッチ実行スクリプト (Windows)
REM =======================================================
echo.
echo ============================================================
echo  GPT-5-Codex コード分析 - 並列処理版
echo  高速化実装 (10並列ワーカー / キャッシュ有効)
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

REM キャッシュディレクトリの作成
if not exist ".cache\analysis" (
    echo [INFO] キャッシュディレクトリを作成します
    mkdir .cache\analysis 2>nul
)

REM 既存の進捗ファイルの確認
if exist ".batch_progress_parallel.json" (
    echo [INFO] 前回の処理を継続します（キャッシュ使用）
    echo.
)

REM 処理モードの選択
echo 処理モードを選択してください:
echo.
echo [1] 高速モード（並列10ワーカー - 推奨）
echo [2] 標準モード（並列5ワーカー - 安定）
echo [3] 低速モード（並列3ワーカー - API制限厳しい場合）
echo.
set /p mode=選択 (1-3) [デフォルト: 1]:

if "%mode%"=="" set mode=1

REM ワーカー数を設定
if "%mode%"=="2" (
    set PARALLEL_WORKERS=5
    echo [INFO] 標準モード: 5並列ワーカーで実行
) else if "%mode%"=="3" (
    set PARALLEL_WORKERS=3
    echo [INFO] 低速モード: 3並列ワーカーで実行
) else (
    set PARALLEL_WORKERS=10
    echo [INFO] 高速モード: 10並列ワーカーで実行
)

echo.
echo ============================================================
echo 処理設定:
echo   - 並列ワーカー数: %PARALLEL_WORKERS%
echo   - バッチサイズ: 50ファイル
echo   - キャッシュ: 有効
echo   - モデル選択: 重要度に応じて自動選択
echo     * 緊急(15+): GPT-5-Codex (高精度)
echo     * 高(10-14): GPT-4o
echo     * 中(5-9): GPT-4o-mini (高速)
echo ============================================================
echo.

REM 環境変数をエクスポート
set PARALLEL_WORKERS=%PARALLEL_WORKERS%

REM メイン処理の実行
echo [INFO] 並列バッチ処理を開始します...
echo --------------------------------------------------------
py -3 extract_and_batch_parallel.py

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
    echo 4. 並列数を減らして再試行（モード3を選択）
    echo.
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo ============================================================
echo [SUCCESS] 並列バッチ処理が正常に完了しました！
echo ============================================================
echo.
echo 生成されたレポート:
echo   - 個別バッチ: reports\AI_batch*_parallel.md
echo   - 統合レポート: reports\AI_analysis_parallel_complete.md
echo.
echo 実行終了: %date% %time%
echo.

REM レポートファイルのサイズを表示
if exist "reports\AI_analysis_parallel_complete.md" (
    echo レポート情報:
    dir "reports\AI_analysis_parallel_complete.md" | findstr /i "AI_analysis"
    echo.
)

REM キャッシュ情報を表示
echo キャッシュ情報:
for /f %%i in ('dir /b /s ".cache\analysis\*.json" 2^>nul ^| find /c /v ""') do set cache_count=%%i
if "%cache_count%"=="" set cache_count=0
echo   キャッシュファイル数: %cache_count%
echo.

echo 処理完了。任意のキーを押して終了してください。
pause >nul