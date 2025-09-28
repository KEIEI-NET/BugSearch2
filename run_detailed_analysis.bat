@echo off
echo ========================================
echo 詳細AI分析バッチ処理を開始します
echo 新しい analyze_dangerous_files_detailed.py を使用
echo ========================================
echo.

echo [1/7] 概要レポートを作成中...
py -3 create_overview_report.py
echo.

echo [2/7] バッチ1 (1-500) を分析中...
py -3 analyze_dangerous_files_detailed.py 1
echo.

echo [3/7] バッチ2 (501-1000) を分析中...
py -3 analyze_dangerous_files_detailed.py 2
echo.

echo [4/7] バッチ3 (1001-1500) を分析中...
py -3 analyze_dangerous_files_detailed.py 3
echo.

echo [5/7] バッチ4 (1501-2000) を分析中...
py -3 analyze_dangerous_files_detailed.py 4
echo.

echo [6/7] バッチ5 (2001-2500) を分析中...
py -3 analyze_dangerous_files_detailed.py 5
echo.

echo [7/7] バッチ6 (2501-2600) を分析中...
py -3 analyze_dangerous_files_detailed.py 6
echo.

echo ========================================
echo バッチレポートを統合中...
echo ========================================
py -3 merge_detailed_reports.py
echo.

echo ========================================
echo 完了！
echo 生成されたレポート:
echo - reports\AI分析.md (概要)
echo - reports\AI分析_詳細_改善版_完全版.md (統合版)
echo - reports\AI分析_詳細_改善版_batch1-6.md (個別)
echo ========================================
pause