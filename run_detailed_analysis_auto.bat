@echo off
setlocal enabledelayedexpansion

echo ========================================
echo 詳細AI分析バッチ処理を開始します（自動版）
echo analyze_dangerous_files_detailed.py を使用
echo ========================================
echo.

echo [1/8] インデックスを作成中...
py -3 codex_review_severity.py index ./src --profile-index > temp_index_output.txt 2>&1
type temp_index_output.txt

rem インデックス数を抽出
for /f "tokens=2 delims==" %%a in ('findstr /C:"indexed=" temp_index_output.txt') do (
    for /f "tokens=1" %%b in ("%%a") do (
        set INDEXED_COUNT=%%b
    )
)

if not defined INDEXED_COUNT (
    echo エラー: インデックス数を取得できませんでした
    echo デフォルト値 15710 を使用します
    set INDEXED_COUNT=15710
)

echo.
echo 検出されたファイル数: !INDEXED_COUNT!
echo.

echo [2/8] 危険度分析を実行中（!INDEXED_COUNT!ファイル）...
py -3 codex_review_severity.py advise --topk !INDEXED_COUNT! --out reports/src_complete_danger_analysis.md
echo.

echo [3/8] 概要レポートを作成中...
py -3 create_overview_report.py
echo.

echo [4/8] バッチ1 (1-500) を分析中...
py -3 analyze_dangerous_files_detailed.py 1
echo.

echo [5/8] バッチ2 (501-1000) を分析中...
py -3 analyze_dangerous_files_detailed.py 2
echo.

echo [6/8] バッチ3 (1001-1500) を分析中...
py -3 analyze_dangerous_files_detailed.py 3
echo.

echo [7/8] バッチ4 (1501-2000) を分析中...
py -3 analyze_dangerous_files_detailed.py 4
echo.

echo [8/8] バッチ5 (2001-2500) を分析中...
py -3 analyze_dangerous_files_detailed.py 5
echo.

echo [8/8] バッチ6 (2501-2600) を分析中...
py -3 analyze_dangerous_files_detailed.py 6
echo.

echo ========================================
echo バッチレポートを統合中...
echo ========================================
py -3 merge_detailed_reports.py
echo.

rem 一時ファイルを削除
del temp_index_output.txt 2>nul

echo ========================================
echo 完了！
echo インデックスファイル数: !INDEXED_COUNT!
echo 生成されたレポート:
echo - reports\AI分析.md (概要)
echo - reports\AI分析_詳細_改善版_完全版.md (統合版)
echo - reports\AI分析_詳細_改善版_batch1-6.md (個別)
echo ========================================
pause

endlocal