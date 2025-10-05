#!/bin/bash
# ============================================================
# 完全レポート生成 - ワンライナー実行スクリプト (Linux/Mac)
#
# 機能:
#   1. 問題のある全ファイルを完全レポート生成
#   2. 元コード + AI改善コード付き
#   3. 進捗モニターを別ターミナルで起動
#
# 使用方法:
#   chmod +x run_complete_full_analysis.sh
#   ./run_complete_full_analysis.sh
# ============================================================

echo "============================================================"
echo "完全レポート生成 - 全件処理"
echo "============================================================"
echo ""
echo "このスクリプトは以下を実行します："
echo "  1. 問題のある全ファイルを完全レポート生成"
echo "  2. 元のソースコード + AI改善コード付き"
echo "  3. リアルタイム進捗モニター起動"
echo ""
echo "警告: 処理に数時間かかる可能性があります"
echo ""

# 確認プロンプト
read -p "続行しますか？ (Y/N): " CONFIRM
if [[ ! "$CONFIRM" =~ ^[Yy]$ ]]; then
    echo "処理をキャンセルしました"
    exit 0
fi

echo ""
echo "[1/3] 進捗モニターを起動中..."

# 進捗モニターを別ターミナルで起動（バックグラウンド）
python3 monitor_complete_report.py reports/.complete_progress.json reports/complete_full_analysis.md &
MONITOR_PID=$!

# モニターの起動待機（2秒）
sleep 2

echo "[2/3] 完全レポート生成を開始..."
echo ""

# 完全レポート生成実行
python3 codex_review_severity.py advise --complete-all --mode ai --out reports/complete_full_analysis.md

echo ""
echo "[3/3] 処理完了"
echo ""
echo "============================================================"
echo "レポート生成完了"
echo "============================================================"
echo ""
echo "生成されたファイル:"
echo "  - reports/complete_full_analysis.md (完全レポート)"
echo "  - reports/.complete_progress.json (進捗情報)"
echo ""

# 進捗モニターを終了
if ps -p $MONITOR_PID > /dev/null 2>&1; then
    echo "進捗モニターを終了中..."
    kill $MONITOR_PID 2>/dev/null
fi

echo "完了"
