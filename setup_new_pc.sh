#!/bin/bash
# ========================================
# BugSearch2 - 新PC セットアップスクリプト
# Linux/macOS用
# ========================================

echo ""
echo "========================================"
echo "BugSearch2 新PC セットアップ"
echo "バージョン: v4.11.7"
echo "========================================"
echo ""

# 色定義
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

# 1. Git リポジトリの確認
echo "[1/7] Git リポジトリの状態確認..."
if ! git status &> /dev/null; then
    echo -e "${RED}エラー: Gitリポジトリが見つかりません${NC}"
    echo "このスクリプトをBugSearch2ディレクトリで実行してください"
    exit 1
fi

# 最新状態に更新
echo "[2/7] 最新状態に更新中..."
git fetch KEIEI-NET
git checkout main
git pull KEIEI-NET main

# コミットハッシュの確認
echo ""
echo "現在のコミット:"
git log --oneline -n 3
echo ""

# 2. Python バージョン確認
echo "[3/7] Python バージョン確認..."
if ! command -v python3 &> /dev/null; then
    echo -e "${RED}エラー: Python3が見つかりません${NC}"
    echo "Python 3.11以上をインストールしてください"
    exit 1
fi
python3 --version

# 3. 仮想環境の作成
echo "[4/7] 仮想環境の作成..."
if [ -d "venv" ]; then
    echo -e "${YELLOW}仮想環境が既に存在します${NC}"
else
    python3 -m venv venv
    echo -e "${GREEN}仮想環境を作成しました${NC}"
fi

# 4. 仮想環境のアクティベート
echo "[5/7] 仮想環境のアクティベート..."
source venv/bin/activate

# 5. 依存パッケージのインストール
echo "[6/7] 依存パッケージのインストール..."
echo "コアパッケージをインストール中..."
pip install -r requirements.txt

echo ""
echo "GUIパッケージをインストール中..."
pip install -r requirements_gui.txt

# 6. .envファイルの確認
echo "[7/7] .envファイルの確認..."
if [ -f ".env" ]; then
    echo -e "${GREEN}.envファイルが存在します${NC}"
else
    echo -e "${YELLOW}.envファイルが見つかりません${NC}"
    echo ".env.exampleから.envを作成します..."
    cp .env.example .env
    echo ""
    echo "========================================"
    echo -e "${YELLOW}重要: .envファイルを編集してAPIキーを設定してください${NC}"
    echo "========================================"
    echo ""
    echo "必須設定:"
    echo "  OPENAI_API_KEY=sk-..."
    echo "  ANTHROPIC_API_KEY=sk-ant-..."
    echo "  AI_PROVIDER=auto"
    echo ""

    # エディタで開く
    if command -v nano &> /dev/null; then
        nano .env
    elif command -v vim &> /dev/null; then
        vim .env
    else
        echo "テキストエディタで .env を編集してください"
    fi
fi

# 7. スクリプトに実行権限を付与
echo ""
echo "スクリプトファイルに実行権限を付与..."
chmod +x start_gui.sh
chmod +x setup_new_pc.sh

# 完了
echo ""
echo "========================================"
echo -e "${GREEN}セットアップ完了！${NC}"
echo "========================================"
echo ""
echo "次のステップ:"
echo "  1. .envファイルを編集してAPIキーを設定（まだの場合）"
echo "  2. 動作確認テストを実行"
echo ""
echo "動作確認コマンド:"
echo "  python codex_review_severity.py index --max-files 10"
echo "  python codex_review_severity.py advise --topk 3 --out reports/test"
echo ""
echo "GUI起動:"
echo "  python gui_main.py"
echo "  または"
echo "  ./start_gui.sh"
echo ""
echo "Phase 8.5 検証:"
echo "  python codex_review_severity.py advise --all --complete-report --max-complete-items 10 --out reports/phase8_5_verify"
echo ""
echo "詳細は HANDOFF.md を参照してください。"
echo ""
