#!/bin/bash
# ========================================================================
# BugSearch2 GUI Control Center - macOS/Linux起動スクリプト
# ========================================================================
#
# このスクリプトは以下を自動実行します：
# 1. Python仮想環境のチェック・作成
# 2. 依存パッケージのインストール
# 3. GUIアプリケーションの起動
#
# 使用方法:
#   chmod +x start_gui.sh  # 初回のみ（実行権限付与）
#   ./start_gui.sh
# ========================================================================

# エラー時に即座に終了
set -e

# 色定義
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

# ログ関数
log_info() {
    echo -e "${BLUE}[INFO]${NC} $1"
}

log_success() {
    echo -e "${GREEN}[OK]${NC} $1"
}

log_warn() {
    echo -e "${YELLOW}[WARN]${NC} $1"
}

log_error() {
    echo -e "${RED}[ERROR]${NC} $1"
}

echo ""
echo "========================================================================"
echo "BugSearch2 GUI Control Center - 起動中..."
echo "========================================================================"
echo ""

# スクリプトのディレクトリに移動
cd "$(dirname "$0")"

# Pythonコマンドの検出（python3を優先）
if command -v python3 &> /dev/null; then
    PYTHON_CMD="python3"
    PIP_CMD="pip3"
elif command -v python &> /dev/null; then
    PYTHON_CMD="python"
    PIP_CMD="pip"
else
    log_error "Python が見つかりません。"
    echo ""
    echo "Python 3.11以上をインストールしてください:"
    echo "  macOS: brew install python3"
    echo "  Ubuntu/Debian: sudo apt-get install python3 python3-pip python3-venv"
    echo "  Fedora/RHEL: sudo dnf install python3 python3-pip"
    echo ""
    exit 1
fi

# Pythonバージョン確認
PYTHON_VERSION=$($PYTHON_CMD --version 2>&1 | awk '{print $2}')
log_info "Python バージョン: $PYTHON_VERSION"

# Python 3.11以上かチェック
PYTHON_MAJOR=$($PYTHON_CMD -c "import sys; print(sys.version_info.major)")
PYTHON_MINOR=$($PYTHON_CMD -c "import sys; print(sys.version_info.minor)")

if [ "$PYTHON_MAJOR" -lt 3 ] || ([ "$PYTHON_MAJOR" -eq 3 ] && [ "$PYTHON_MINOR" -lt 11 ]); then
    log_error "Python 3.11以上が必要です（現在: $PYTHON_VERSION）"
    exit 1
fi

# 仮想環境のチェック
if [ ! -d "venv" ]; then
    echo ""
    log_info "仮想環境が見つかりません。新規作成します..."
    $PYTHON_CMD -m venv venv
    if [ $? -ne 0 ]; then
        log_error "仮想環境の作成に失敗しました。"
        echo ""
        echo "python3-venv がインストールされているか確認してください:"
        echo "  Ubuntu/Debian: sudo apt-get install python3-venv"
        echo "  Fedora/RHEL: sudo dnf install python3-venv"
        exit 1
    fi
    log_success "仮想環境を作成しました。"
else
    log_success "仮想環境が見つかりました。"
fi

# 仮想環境をアクティベート
echo ""
log_info "仮想環境をアクティベート中..."
source venv/bin/activate

if [ $? -ne 0 ]; then
    log_error "仮想環境のアクティベートに失敗しました。"
    exit 1
fi

# pipのアップグレード（推奨）
log_info "pip をアップグレード中..."
$PIP_CMD install --upgrade pip -q

# 依存パッケージのチェック
echo ""
log_info "依存パッケージを確認中..."

# requirements.txtのインストール
if [ -f "requirements.txt" ]; then
    log_info "requirements.txt からパッケージをインストール中..."
    $PIP_CMD install -q -r requirements.txt
    if [ $? -ne 0 ]; then
        log_warn "一部のパッケージのインストールに失敗しました。"
    else
        log_success "requirements.txt のパッケージをインストールしました。"
    fi
fi

# requirements_gui.txtのインストール
if [ -f "requirements_gui.txt" ]; then
    log_info "requirements_gui.txt からGUI依存パッケージをインストール中..."
    $PIP_CMD install -q -r requirements_gui.txt
    if [ $? -ne 0 ]; then
        log_error "GUI依存パッケージのインストールに失敗しました。"
        echo ""
        echo "手動でインストールしてください:"
        echo "  $PIP_CMD install -r requirements_gui.txt"
        exit 1
    else
        log_success "GUI依存パッケージをインストールしました。"
    fi
fi

# CustomTkinterのインストール確認
$PYTHON_CMD -c "import customtkinter" &> /dev/null
if [ $? -ne 0 ]; then
    echo ""
    log_warn "CustomTkinter がインストールされていません。"
    log_info "CustomTkinter をインストール中..."
    $PIP_CMD install customtkinter
    if [ $? -ne 0 ]; then
        log_error "CustomTkinter のインストールに失敗しました。"
        exit 1
    fi
fi

# psutilのインストール確認
$PYTHON_CMD -c "import psutil" &> /dev/null
if [ $? -ne 0 ]; then
    echo ""
    log_warn "psutil がインストールされていません。"
    log_info "psutil をインストール中..."
    $PIP_CMD install psutil
    if [ $? -ne 0 ]; then
        log_error "psutil のインストールに失敗しました。"
        exit 1
    fi
fi

# GUIファイルの存在確認
if [ ! -f "gui_main.py" ]; then
    echo ""
    log_error "gui_main.py が見つかりません。"
    echo ""
    echo "プロジェクトルートディレクトリから実行してください。"
    exit 1
fi

# macOS用の追加チェック
if [[ "$OSTYPE" == "darwin"* ]]; then
    # macOSでTkinterが正しく動作するか確認
    $PYTHON_CMD -c "import tkinter" &> /dev/null
    if [ $? -ne 0 ]; then
        log_error "Tkinter が正しくインストールされていません。"
        echo ""
        echo "macOSでTkinterを使用するには、以下のいずれかが必要です:"
        echo "  1. Homebrewでインストールしたpython3を使用"
        echo "     brew install python-tk@3.11"
        echo "  2. 公式のPythonインストーラーを使用"
        echo "     https://www.python.org/downloads/macos/"
        exit 1
    fi
fi

# GUI起動
echo ""
echo "========================================================================"
log_info "BugSearch2 GUI Control Center を起動しています..."
echo "========================================================================"
echo ""
echo "[TIP] GUIウィンドウを閉じるとこのウィンドウも自動的に閉じます。"
echo "[TIP] 強制終了する場合は Ctrl+C を押してください。"
echo ""

$PYTHON_CMD gui_main.py

# 終了コードをチェック
if [ $? -ne 0 ]; then
    echo ""
    log_error "GUIアプリケーションが異常終了しました。"
    echo ""
    echo "エラーが発生した場合は、以下を確認してください:"
    echo "  1. Python 3.11以上がインストールされているか"
    echo "  2. 必要なパッケージがインストールされているか"
    echo "  3. gui_main.py ファイルが破損していないか"
    echo "  4. (macOS) Tkinter が正しくインストールされているか"
    echo ""
    exit 1
fi

echo ""
log_success "GUIアプリケーションが正常に終了しました。"
echo ""
