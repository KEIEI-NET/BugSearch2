#!/bin/bash
# ============================================
# Claude Code Aliases インストール確認スクリプト
# バージョン: v4.0.1
# ============================================

echo ""
echo "========================================"
echo "Claude Code Aliases インストール確認"
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

echo "[INFO] 確認先: $ALIASES_FILE"
echo ""

if [ -f "$ALIASES_FILE" ]; then
    echo "[OK] aliases.md が見つかりました！"
    echo ""
    echo "ファイル情報:"
    ls -lh "$ALIASES_FILE"
    echo ""
    echo "最初の30行を表示:"
    echo "----------------------------------------"
    head -n 30 "$ALIASES_FILE"
    echo "----------------------------------------"
    echo ""
    echo "[OK] インストール確認完了"
else
    echo "[ERROR] aliases.md が見つかりません"
    echo ""
    echo "インストールされていないか、別の場所にある可能性があります。"
    echo "install_unix.sh を実行してインストールしてください。"
    echo ""
fi
