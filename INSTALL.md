# インストールガイド

*バージョン: v3.5.0*
*最終更新: 2025年01月03日 09:00 JST*

このガイドでは、Codex Review システムのインストール手順を詳しく説明します。

## 必要要件

- **Python**: 3.11以上（3.13対応）
- **OS**: Windows 10/11, macOS 10.14+, Linux (Ubuntu 20.04+)
- **メモリ**: 最低4GB（大規模プロジェクトの場合は8GB推奨）
- **ディスク**: 1GB空き容量（キャッシュ用に追加10GB推奨）

## インストール手順

### 1. Pythonのバージョン確認

```bash
python --version
# または
py --version
```

Python 3.11以上であることを確認してください。

### 2. 依存パッケージのインストール

#### 方法A: requirements.txtを使用（推奨）

```bash
pip install -r requirements.txt
```

Windowsで `py` コマンドを使用している場合：

```bash
py -m pip install -r requirements.txt
```

#### 方法B: 個別インストール

```bash
# AI Provider SDKs（AI分析に必須）
pip install openai>=2.0.0 anthropic>=0.69.0

# 機械学習ライブラリ
pip install scikit-learn>=1.0.0 joblib>=1.0.0

# エンコーディング検出
pip install chardet>=5.0.0
```

### 3. 環境変数の設定

`.env` ファイルをプロジェクトルートに作成：

```env
# AI Provider選択
# auto: Anthropic優先→OpenAIフォールバック（推奨）
# anthropic: Claude専用
# openai: OpenAI専用
AI_PROVIDER=auto

# OpenAI設定
OPENAI_API_KEY=your_openai_api_key_here
OPENAI_MODEL=gpt-4o

# Anthropic設定（推奨）
ANTHROPIC_API_KEY=your_anthropic_api_key_here
ANTHROPIC_MODEL=claude-sonnet-4-5
```

**重要な注意事項**:
- **v3.5以降、python-dotenvは不要です**（手動.env読み込み機能内蔵）
- AI分析機能を使用する場合、OpenAIまたはAnthropicのAPIキーが必要です
- `.env` ファイルは `.gitignore` に追加してください（APIキーの漏洩防止）

### 4. インストール確認

```bash
# Python環境確認
py -c "import openai, anthropic, sklearn, joblib, chardet; print('All packages installed successfully!')"
```

成功すると `All packages installed successfully!` と表示されます。

## トラブルシューティング

### エラー: `ModuleNotFoundError: No module named 'dotenv'`

**解決**: v3.5以降、python-dotenvは不要になりました。手動.env読み込み機能が内蔵されています。

```bash
# もしpython-dotenvがインストール済みの場合、削除してもOK
pip uninstall python-dotenv
```

### Python 3.13でのscikit-learn インストールエラー

**症状**:
```
ERROR: Failed building wheel for scikit-learn
ERROR: Could not build wheels for scikit-learn
```

**解決方法**:
```bash
# バイナリパッケージを強制インストール
pip install --only-binary :all: scikit-learn

# その後、他のパッケージをインストール
pip install openai anthropic joblib chardet
```

### エラー: `ModuleNotFoundError: No module named 'XXX'`

**原因**: パッケージがインストールされていない、または異なるPython環境にインストールされている

**解決方法**:

1. 正しいPythonコマンドを確認：
   ```bash
   # Windowsの場合
   py --version
   py -c "import sys; print(sys.executable)"

   # macOS/Linuxの場合
   python3 --version
   which python3
   ```

2. 該当するPython環境にインストール：
   ```bash
   # Windowsの場合
   py -m pip install -r requirements.txt

   # macOS/Linuxの場合
   python3 -m pip install -r requirements.txt
   ```

### エラー: `No module named 'pip'`

**原因**: pipがインストールされていない（Python 3.13の初期状態など）

**解決方法**:
```bash
py -m ensurepip --upgrade
py -m pip install -r requirements.txt
```

### エラー: `UnicodeEncodeError` (Windows)

**原因**: Windowsのコンソールエンコーディング問題

**解決方法**:
- Windows 11では通常問題ありませんが、エラーが出る場合は以下を実行：
  ```bash
  chcp 65001
  ```

### エラー: `AI改善コード生成に失敗しました`

**原因**: APIキーが設定されていない、またはSDKがインストールされていない

**確認手順**:
1. `.env` ファイルが存在し、APIキーが設定されているか確認
2. SDKがインストールされているか確認：
   ```bash
   py -c "import openai; import anthropic; print('SDKs OK')"
   ```
3. 環境変数が読み込まれているか確認：
   ```bash
   py -c "import os; print('OPENAI_API_KEY:', 'SET' if os.getenv('OPENAI_API_KEY') else 'NOT SET')"
   ```

## パッケージの詳細

### 必須パッケージ

| パッケージ | 用途 | 備考 |
|-----------|------|------|
| `openai` | OpenAI API利用 | AIモードで使用 |
| `anthropic` | Anthropic Claude API利用 | AIモードで使用（推奨） |
| `scikit-learn` | TF-IDFベクトル化、類似度計算 | インデックス生成に必須 |
| `joblib` | モデル/ベクトルの永続化 | インデックス保存に必須 |
| `chardet` | 文字エンコーディング自動検出 | 日本語ファイル対応 |

### 標準ライブラリ（追加インストール不要）

- `argparse`, `hashlib`, `json`, `os`, `pathlib`, `re`, `sys`, `time`
- `collections`, `concurrent.futures`, `dataclasses`, `fnmatch`, `typing`

## 次のステップ

インストールが完了したら、[README.md](README.md) または [SETUP_GUIDE.md](SETUP_GUIDE.md) を参照して使用方法を確認してください。

### クイックスタート

```bash
# 1. インデックス作成（デフォルトで./srcを検索）
py codex_review_severity.py index --exclude-langs delphi --max-file-mb 4 --worker-count 4

# 2. 分析実行（デフォルト80ファイル）
py codex_review_severity.py advise --out reports/quick_analysis.md

# 3. 全ファイル分析
py codex_review_severity.py advise --all --out reports/full_analysis.md

# 4. 完全レポート生成（全ファイル + AI改善コード）⭐新機能
py codex_review_severity.py advise --complete-all --out reports/complete_report.md
```

## サポート

問題が解決しない場合は、以下の情報を含めてIssueを作成してください：

1. Python バージョン (`py --version`)
2. OS とバージョン
3. エラーメッセージの全文
4. 実行したコマンド
5. `.env` ファイルの内容（APIキーは除く）

## 関連ドキュメント

- [README.md](README.md) - プロジェクト全体像とクイックスタート
- [CLAUDE.md](CLAUDE.md) - Claude CLIでの開発ガイド
- [doc/TECHNICAL.md](doc/TECHNICAL.md) - 技術仕様書
- [requirements.txt](requirements.txt) - パッケージリスト

---

*最終更新: 2025年01月03日 09:00 JST*
*バージョン: v3.5.0*

**更新履歴:**
- v3.5.0 (2025年01月03日): python-dotenv依存削除、Python 3.13対応、--complete-all機能追加
