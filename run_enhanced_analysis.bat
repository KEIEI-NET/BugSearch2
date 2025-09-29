@echo off
echo ========================================
echo 改良版AI分析実行（完全コード提供）
echo ========================================
echo.

REM 環境確認
if not exist ".env" (
    echo [ERROR] .envファイルが見つかりません
    echo OPENAI_API_KEYを設定してください
    pause
    exit /b 1
)

REM 危険ファイル分析確認
if not exist "reports\danger_analysis_ALL" (
    echo [WARNING] 危険ファイル分析が未実行です
    echo 先に以下を実行してください:
    echo py codex_review_severity.py analyze . --topk 100
    pause
    exit /b 1
)

echo [INFO] 改良版分析を開始します（並列処理・完全コード提供）
echo.

REM 実行
py extract_and_batch_parallel_enhanced.py

if errorlevel 1 (
    echo.
    echo [ERROR] 処理中にエラーが発生しました
    pause
    exit /b 1
)

echo.
echo [SUCCESS] 分析が完了しました
echo 結果: reports\AI_analysis_parallel_enhanced_complete.md
echo.

REM 文字化け修正の提案
echo [INFO] レポートに文字化けがある場合:
echo py simple_fix_report.py
echo.

pause