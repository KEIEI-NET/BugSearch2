#!/bin/bash
# ============================================
# Claude Code Aliases インストーラー (Mac/Linux)
# バージョン: v4.0.1
# ============================================

echo ""
echo "========================================"
echo "Claude Code Aliases インストーラー"
echo "========================================"
echo ""

# Claude Code 設定ディレクトリのパス
CLAUDE_CONFIG_DIR="$HOME/.config/claude-code"
ALIASES_FILE="$CLAUDE_CONFIG_DIR/aliases.md"

# macOS の場合は Application Support を使用
if [[ "$OSTYPE" == "darwin"* ]]; then
    CLAUDE_CONFIG_DIR="$HOME/Library/Application Support/claude-code"
    ALIASES_FILE="$CLAUDE_CONFIG_DIR/aliases.md"
fi

echo "[INFO] インストール先: $CLAUDE_CONFIG_DIR"
echo ""

# ディレクトリ作成
if [ ! -d "$CLAUDE_CONFIG_DIR" ]; then
    echo "[INFO] 設定ディレクトリを作成: $CLAUDE_CONFIG_DIR"
    mkdir -p "$CLAUDE_CONFIG_DIR"
else
    echo "[INFO] 設定ディレクトリ確認: $CLAUDE_CONFIG_DIR"
fi

# バックアップ作成（既存ファイルがある場合）
if [ -f "$ALIASES_FILE" ]; then
    TIMESTAMP=$(date +"%Y%m%d_%H%M%S")
    BACKUP_FILE="${ALIASES_FILE}.backup_${TIMESTAMP}"
    echo "[WARNING] 既存のaliases.mdが見つかりました"
    echo "[INFO] バックアップ作成: $BACKUP_FILE"
    cp "$ALIASES_FILE" "$BACKUP_FILE"
fi

# aliases.md をコピー
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
echo "[INFO] aliases.md をインストール中..."
cp "$SCRIPT_DIR/aliases.md" "$ALIASES_FILE"

if [ $? -eq 0 ]; then
    echo ""
    echo "========================================"
    echo "[OK] インストール完了！"
    echo "========================================"
    echo ""
    echo "インストール場所:"
    echo "  $ALIASES_FILE"
    echo ""
    echo "使用方法:"
    echo "  @perfect ユーザー認証機能を実装して"
    echo "  @tdd 決済処理ロジックを実装して"
    echo "  @validate apply_improvements_from_report.py"
    echo "  @quick プロトタイプ作成して"
    echo ""
    echo "詳細は以下をご確認ください:"
    echo "  cat \"$ALIASES_FILE\""
    echo ""

    # ファイル権限設定
    chmod 644 "$ALIASES_FILE"
else
    echo ""
    echo "[ERROR] インストールに失敗しました"
    echo "エラーコード: $?"
    echo ""
    exit 1
fi
