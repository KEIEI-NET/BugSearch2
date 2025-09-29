#!/bin/bash
# =======================================================
# GPT-5-Codex バッチ処理自動実行スクリプト (Mac/Linux)
# =======================================================

# カラー定義
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

# バナー表示
echo ""
echo "============================================================"
echo " GPT-5-Codex コード分析バッチ処理システム"
echo " 最適化版 (200ファイル/バッチ)"
echo "============================================================"
echo ""

# 現在の日時を表示
echo "実行開始: $(date '+%Y-%m-%d %H:%M:%S')"
echo ""

# .envファイルの存在確認
if [ ! -f ".env" ]; then
    echo -e "${RED}[ERROR]${NC} .envファイルが見つかりません"
    echo "OPENAI_API_KEYとOPENAI_MODELを設定してください"
    read -p "Press any key to continue..."
    exit 1
fi

# Pythonの存在確認
if ! command -v python3 &> /dev/null; then
    echo -e "${RED}[ERROR]${NC} Python 3が見つかりません"
    echo "Python 3をインストールしてください"

    # OS別インストール案内
    if [[ "$OSTYPE" == "darwin"* ]]; then
        echo "Mac: brew install python3"
    elif [[ "$OSTYPE" == "linux-gnu"* ]]; then
        echo "Ubuntu/Debian: sudo apt-get install python3"
        echo "CentOS/RHEL: sudo yum install python3"
    fi

    read -p "Press any key to continue..."
    exit 1
fi

# Python版確認
echo -e "${BLUE}[INFO]${NC} Python version: $(python3 --version)"
echo ""

# OpenAIライブラリの確認
if ! python3 -c "import openai" 2>/dev/null; then
    echo -e "${YELLOW}[WARNING]${NC} OpenAIライブラリが見つかりません"
    echo "インストールしますか？ (y/n)"
    read -r response
    if [[ "$response" == "y" ]]; then
        pip3 install openai
    else
        echo -e "${RED}[ERROR]${NC} OpenAIライブラリが必要です"
        exit 1
    fi
fi

# レポートディレクトリの作成
if [ ! -d "reports" ]; then
    echo -e "${BLUE}[INFO]${NC} reportsディレクトリを作成します"
    mkdir -p reports
fi

# 既存の進捗ファイルの確認
if [ -f ".batch_progress.json" ]; then
    echo -e "${BLUE}[INFO]${NC} 前回の処理を継続します"
    echo ""
fi

# メイン処理の実行
echo -e "${BLUE}[INFO]${NC} バッチ処理を開始します..."
echo "--------------------------------------------------------"

# ログファイルに出力しながら実行
LOG_FILE="batch_processing_$(date +%Y%m%d_%H%M%S).log"
python3 extract_and_batch_optimized.py 2>&1 | tee "$LOG_FILE"

# 実行結果を取得
EXIT_CODE=${PIPESTATUS[0]}

# エラーチェック
if [ $EXIT_CODE -ne 0 ]; then
    echo ""
    echo "============================================================"
    echo -e "${RED}[ERROR]${NC} 処理中にエラーが発生しました"
    echo "エラーコード: $EXIT_CODE"
    echo "============================================================"
    echo ""
    echo "トラブルシューティング:"
    echo "1. .envファイルにOPENAI_API_KEYが正しく設定されているか確認"
    echo "2. インターネット接続を確認"
    echo "3. OpenAI APIの利用制限を確認"
    echo "4. $LOG_FILE でエラー詳細を確認"
    echo ""
    read -p "Press any key to continue..."
    exit $EXIT_CODE
fi

echo ""
echo "============================================================"
echo -e "${GREEN}[SUCCESS]${NC} バッチ処理が正常に完了しました！"
echo "============================================================"
echo ""
echo "生成されたレポート:"
echo "  - 個別バッチ: reports/AI_batch*_optimized.md"
echo "  - 統合レポート: reports/COMPLETE_ANALYSIS_OPTIMIZED_GPT5.md"
echo ""
echo "実行終了: $(date '+%Y-%m-%d %H:%M:%S')"
echo ""

# レポートファイルのサイズを表示
if [ -f "reports/COMPLETE_ANALYSIS_OPTIMIZED_GPT5.md" ]; then
    echo "レポートファイル情報:"
    ls -lh "reports/COMPLETE_ANALYSIS_OPTIMIZED_GPT5.md"
    echo ""

    # ファイルサイズが大きい場合の警告
    FILE_SIZE=$(stat -f%z "reports/COMPLETE_ANALYSIS_OPTIMIZED_GPT5.md" 2>/dev/null || stat -c%s "reports/COMPLETE_ANALYSIS_OPTIMIZED_GPT5.md" 2>/dev/null)
    if [ "$FILE_SIZE" -gt 26214400 ]; then  # 25MB以上
        echo -e "${YELLOW}[WARNING]${NC} レポートファイルが25MBを超えています"
        echo "閲覧時に時間がかかる可能性があります"
    fi
fi

echo ""
echo -e "${GREEN}処理完了${NC}"
echo "ログファイル: $LOG_FILE"
echo ""
read -p "Press any key to exit..."