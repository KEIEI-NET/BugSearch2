#!/bin/bash

# =======================================================
# GPT-5-Codex 並列処理バッチ実行スクリプト (Mac/Linux)
# =======================================================

# カラー定義
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

echo ""
echo -e "${BLUE}============================================================${NC}"
echo -e "${BLUE} GPT-5-Codex コード分析 - 並列処理版${NC}"
echo -e "${BLUE} 高速化実装 (10並列ワーカー / キャッシュ有効)${NC}"
echo -e "${BLUE}============================================================${NC}"
echo ""

# 実行開始時刻
echo -e "実行開始: $(date '+%Y-%m-%d %H:%M:%S')"
echo ""

# .envファイルの存在確認
if [ ! -f ".env" ]; then
    echo -e "${RED}[ERROR] .envファイルが見つかりません${NC}"
    echo "OPENAI_API_KEYとOPENAI_MODELを設定してください"
    exit 1
fi

# Pythonの存在確認
if ! command -v python3 &> /dev/null; then
    echo -e "${RED}[ERROR] Python 3が見つかりません${NC}"
    echo "Python 3をインストールしてください"
    exit 1
fi

# レポートディレクトリの作成
if [ ! -d "reports" ]; then
    echo -e "${YELLOW}[INFO] reportsディレクトリを作成します${NC}"
    mkdir -p reports
fi

# キャッシュディレクトリの作成
if [ ! -d ".cache/analysis" ]; then
    echo -e "${YELLOW}[INFO] キャッシュディレクトリを作成します${NC}"
    mkdir -p .cache/analysis
fi

# 既存の進捗ファイルの確認
if [ -f ".batch_progress_parallel.json" ]; then
    echo -e "${GREEN}[INFO] 前回の処理を継続します（キャッシュ使用）${NC}"
    echo ""
fi

# 処理モードの選択
echo "処理モードを選択してください:"
echo ""
echo "[1] 高速モード（並列10ワーカー - 推奨）"
echo "[2] 標準モード（並列5ワーカー - 安定）"
echo "[3] 低速モード（並列3ワーカー - API制限厳しい場合）"
echo ""
read -p "選択 (1-3) [デフォルト: 1]: " mode

# デフォルト値の設定
if [ -z "$mode" ]; then
    mode=1
fi

# ワーカー数を設定
case $mode in
    2)
        export PARALLEL_WORKERS=5
        echo -e "${YELLOW}[INFO] 標準モード: 5並列ワーカーで実行${NC}"
        ;;
    3)
        export PARALLEL_WORKERS=3
        echo -e "${YELLOW}[INFO] 低速モード: 3並列ワーカーで実行${NC}"
        ;;
    *)
        export PARALLEL_WORKERS=10
        echo -e "${GREEN}[INFO] 高速モード: 10並列ワーカーで実行${NC}"
        ;;
esac

echo ""
echo -e "${BLUE}============================================================${NC}"
echo "処理設定:"
echo "  - 並列ワーカー数: $PARALLEL_WORKERS"
echo "  - バッチサイズ: 50ファイル"
echo "  - キャッシュ: 有効"
echo "  - モデル選択: 重要度に応じて自動選択"
echo "    * 緊急(15+): GPT-5-Codex (高精度)"
echo "    * 高(10-14): GPT-4o"
echo "    * 中(5-9): GPT-4o-mini (高速)"
echo -e "${BLUE}============================================================${NC}"
echo ""

# メイン処理の実行
echo -e "${GREEN}[INFO] 並列バッチ処理を開始します...${NC}"
echo "--------------------------------------------------------"

# Pythonスクリプトの実行
python3 extract_and_batch_parallel.py
exit_code=$?

# エラーチェック
if [ $exit_code -ne 0 ]; then
    echo ""
    echo -e "${RED}============================================================${NC}"
    echo -e "${RED}[ERROR] 処理中にエラーが発生しました${NC}"
    echo -e "${RED}エラーコード: $exit_code${NC}"
    echo -e "${RED}============================================================${NC}"
    echo ""
    echo "トラブルシューティング:"
    echo "1. .envファイルにOPENAI_API_KEYが正しく設定されているか確認"
    echo "2. インターネット接続を確認"
    echo "3. OpenAI APIの利用制限を確認"
    echo "4. 並列数を減らして再試行（モード3を選択）"
    echo ""
    exit $exit_code
fi

echo ""
echo -e "${GREEN}============================================================${NC}"
echo -e "${GREEN}[SUCCESS] 並列バッチ処理が正常に完了しました！${NC}"
echo -e "${GREEN}============================================================${NC}"
echo ""
echo "生成されたレポート:"
echo "  - 個別バッチ: reports/AI_batch*_parallel.md"
echo "  - 統合レポート: reports/AI_analysis_parallel_complete.md"
echo ""
echo -e "実行終了: $(date '+%Y-%m-%d %H:%M:%S')"
echo ""

# レポートファイル情報
if [ -f "reports/AI_analysis_parallel_complete.md" ]; then
    echo "レポート情報:"
    ls -lh "reports/AI_analysis_parallel_complete.md" | awk '{print "  サイズ: " $5 "  更新: " $6 " " $7 " " $8}'
    echo ""
fi

# キャッシュ情報を表示
echo "キャッシュ情報:"
if [ -d ".cache/analysis" ]; then
    cache_count=$(find .cache/analysis -name "*.json" 2>/dev/null | wc -l)
    cache_size=$(du -sh .cache/analysis 2>/dev/null | cut -f1)
    echo "  キャッシュファイル数: $cache_count"
    echo "  キャッシュサイズ: ${cache_size:-0}"
else
    echo "  キャッシュファイル数: 0"
fi
echo ""

echo "処理完了。"