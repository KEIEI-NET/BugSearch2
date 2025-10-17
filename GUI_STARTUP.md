# BugSearch2 GUI Control Center - Startup Guide

This guide explains how to easily launch BugSearch2 GUI.

## 📋 Prerequisites

- **Python 3.11 or later** must be installed
- Internet connection (required for installing dependencies on first launch)

## 🚀 Quick Start

### Windows

1. **Double-click start_gui.bat**
2. On first launch, virtual environment creation and package installation will be performed automatically (may take a few minutes)
3. GUI window will appear (optimized for 1920x1024 screens)

```batch
# If running from command prompt:
start_gui.bat
```

### macOS

1. ターミナルを開く
2. プロジェクトディレクトリに移動
3. 以下のコマンドを実行:

```bash
# 初回のみ: 実行権限を付与
chmod +x start_gui.sh

# GUI起動
./start_gui.sh
```

### Linux

1. ターミナルを開く
2. プロジェクトディレクトリに移動
3. 以下のコマンドを実行:

```bash
# 初回のみ: 実行権限を付与
chmod +x start_gui.sh

# GUI起動
./start_gui.sh
```

## 🔧 Startup Script Features

The startup script automatically performs the following:

1. ✅ **Check/Create Python Virtual Environment**
   - Automatically creates `venv/` directory if it doesn't exist
   - Uses existing virtual environment if available

2. ✅ **Install Dependencies**
   - Installs core packages from `requirements.txt`
   - Installs GUI-specific packages from `requirements_gui.txt`
   - Automatically detects and installs missing packages

3. ✅ **Launch GUI Application**
   - Executes `gui_main.py`
   - Displays detailed error messages if issues occur
   - Window size optimized for 1920x1024 screens (1600x900 default)

## 🐛 トラブルシューティング

### 問題: "Python が見つかりません"

**解決策:**
- Python 3.11以上をインストールしてください
- Pythonのインストール先がPATH環境変数に追加されているか確認

**Pythonダウンロード:**
- 公式サイト: https://www.python.org/downloads/
- Windows: 「Add Python to PATH」にチェックを入れてインストール

### 問題: "CustomTkinter のインストールに失敗しました"

**解決策 (Windows):**
```batch
# 仮想環境をアクティベート
venv\Scripts\activate.bat

# 手動でインストール
pip install customtkinter psutil
```

**解決策 (macOS/Linux):**
```bash
# 仮想環境をアクティベート
source venv/bin/activate

# 手動でインストール
pip install customtkinter psutil
```

### 問題: (macOS) "Tkinter が正しくインストールされていません"

**解決策:**

macOSでは、Tkinterが正しく動作するために、以下のいずれかが必要です:

**オプション1: Homebrewでインストール（推奨）**
```bash
# Homebrewをインストール（未インストールの場合）
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"

# Python 3.11とTkinterをインストール
brew install python@3.11 python-tk@3.11
```

**オプション2: 公式インストーラー**
- https://www.python.org/downloads/macos/ から最新版をダウンロード
- インストーラーを実行（Tkinterがデフォルトでインストールされます）

### 問題: (Linux) "python3-venv がインストールされていません"

**解決策:**

**Ubuntu/Debian:**
```bash
sudo apt-get update
sudo apt-get install python3 python3-pip python3-venv python3-tk
```

**Fedora/RHEL:**
```bash
sudo dnf install python3 python3-pip python3-tkinter
```

**Arch Linux:**
```bash
sudo pacman -S python python-pip tk
```

### 問題: 権限エラー (macOS/Linux)

**解決策:**
```bash
# start_gui.sh に実行権限を付与
chmod +x start_gui.sh

# ファイルの所有者を確認
ls -l start_gui.sh

# 必要に応じて所有者を変更
sudo chown $USER:$USER start_gui.sh
```

## 📝 手動起動方法

起動スクリプトを使用せずに手動で起動する場合:

### 1. 仮想環境を作成（初回のみ）
```bash
# Windows
python -m venv venv

# macOS/Linux
python3 -m venv venv
```

### 2. 仮想環境をアクティベート
```bash
# Windows
venv\Scripts\activate.bat

# macOS/Linux
source venv/bin/activate
```

### 3. 依存パッケージをインストール
```bash
pip install -r requirements.txt
pip install -r requirements_gui.txt
```

### 4. GUIを起動
```bash
# Windows
python gui_main.py

# macOS/Linux
python3 gui_main.py
```

## 🎯 次のステップ

GUIが正常に起動したら、以下のドキュメントを参照してください:

- **使用方法**: `doc/guides/GUI_USER_GUIDE.md`
- **技術仕様**: `doc/TECHNICAL.md`
- **アーキテクチャ**: `doc/ARCHITECTURE.md`

## 📞 サポート

問題が解決しない場合:

1. **ログを確認**: 起動時のエラーメッセージをコピー
2. **Issue報告**: https://github.com/KEIEI-NET/BugSearch2/issues
3. **ドキュメント参照**: `CLAUDE.md` - プロジェクト詳細情報

---

**バージョン**: v1.0.0
**最終更新**: 2025年10月13日
