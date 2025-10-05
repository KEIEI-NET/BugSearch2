@echo off
REM ============================================================
REM 完全レポート生成 - ワンライナー実行スクリプト
REM
REM 機能:
REM   1. 問題のある全ファイルを完全レポート生成
REM   2. 元コード + AI改善コード付き
REM   3. 進捗モニターを別ウィンドウで起動
REM
REM 使用方法:
REM   run_complete_full_analysis.bat
REM ============================================================

echo ============================================================
echo 完全レポート生成 - 全件処理
echo ============================================================
echo.
echo このスクリプトは以下を実行します：
echo   1. 問題のある全ファイルを完全レポート生成
echo   2. 元のソースコード + AI改善コード付き
echo   3. リアルタイム進捗モニター起動
echo.
echo 警告: 処理に数時間かかる可能性があります
echo.

REM 確認プロンプト
set /p CONFIRM="続行しますか？ (Y/N): "
if /i not "%CONFIRM%"=="Y" (
    echo 処理をキャンセルしました
    pause
    exit /b 0
)

echo.
echo [1/3] 進捗モニターを起動中...

REM 進捗モニターを別ウィンドウで起動
start "進捗モニター" cmd /c "py monitor_complete_report.py reports\.complete_progress.json reports\complete_full_analysis.md & pause"

REM モニターの起動待機（2秒）
timeout /t 2 /nobreak >nul

echo [2/3] 完全レポート生成を開始...
echo.

REM 完全レポート生成実行
py codex_review_severity.py advise --complete-all --mode ai --out reports\complete_full_analysis.md

echo.
echo [3/3] 処理完了
echo.
echo ============================================================
echo レポート生成完了
echo ============================================================
echo.
echo 生成されたファイル:
echo   - reports\complete_full_analysis.md (完全レポート)
echo   - reports\.complete_progress.json (進捗情報)
echo.
echo 進捗モニターのウィンドウを閉じてください
echo.
pause
