# 複数PC環境でのセットアップガイド

*バージョン: v4.0.2*
*最終更新: 2025年09月04日*

このプロジェクトは **Dropbox で同期** されているため、複数のPCで作業を継続できます。

---

## 📋 前提条件

### すべてのPCで必要なもの

1. **Dropbox デスクトップアプリ** がインストール済み
2. **Python 3.8以上** がインストール済み
3. **Git** がインストール済み
4. **Claude Code CLI** がインストール済み
5. **Serena MCP** がインストール済み（全PC共通）

---

## 🔧 新しいPCでの初期セットアップ

### 1. Dropbox 同期確認

```bash
# Dropbox同期が完了していることを確認
cd "C:\Users\<ユーザー名>\Dropbox\<プロジェクトパス>\BugSearch"
# または Mac/Linux
cd ~/Dropbox/<プロジェクトパス>/BugSearch
```

### 2. Python パッケージのインストール

```bash
# 必須パッケージをインストール
pip install openai anthropic scikit-learn joblib chardet
```

### 3. 環境変数の設定

`.env` ファイル（Dropboxで同期済み）を確認：

```env
OPENAI_API_KEY=sk-...
OPENAI_MODEL=gpt-4o
ANTHROPIC_API_KEY=sk-ant-...
AI_PROVIDER=auto
```

**⚠️ セキュリティ注意**: `.env` は `.gitignore` に含まれており、GitHubにはアップされません。

### 4. Claude Code エイリアスのインストール

```bash
# Install_PC フォルダーから
cd Install_PC

# Windows
install_windows.bat

# Mac/Linux
chmod +x install_unix.sh
./install_unix.sh
```

### 5. サブエージェントのインストール

```bash
# Claude Code CLI に smart-review-system-v2 をインストール
# https://github.com/KEIEI-NET/smart-review-system-v2
# インストール方法は上記リポジトリのREADMEを参照
```

**注意**: Serena MCP は全PCで導入済みのため、追加インストール不要です。

---

## 📁 Dropboxで同期されるファイル

### ✅ 同期されるファイル（他のPCでも利用可能）

#### プロジェクトファイル
- `*.py` - すべてのPythonスクリプト
- `batch_config.json` - バッチ処理設定
- `.env` - 環境変数（APIキー含む）
- `requirements.txt` - パッケージリスト

#### ドキュメント
- `README.md`
- `CLAUDE.md`
- `Install_PC/` - エイリアスインストーラー
- `.claude/` - Claude Code設定

#### インデックスファイル（オプション）
- `.advice_index.jsonl` - ファイルインデックス（約400MB）
- `.advice_index.meta.json` - メタデータ（約5MB）

#### キャッシュファイル（オプション）
- `.cache/analysis/` - AI応答キャッシュ（MD5ハッシュベース）

#### Serena MCP設定
- `.serena/` - 各PC固有の設定（全PCで導入済み、同期不要）

### ❌ 同期されないファイル（`.gitignore`で除外）

- `__pycache__/` - Pythonキャッシュ
- `.venv/` - 仮想環境
- `reports/` - 生成されたレポート
- `.batch_progress*.json` - バッチ進捗状態
- `*.log` - ログファイル
- `src/` - ソースコード（分析対象）
- `.serena/` - Serena MCP設定（各PC固有）

---

## 🔄 作業の継続方法

### PC-A で作業を開始

```bash
# 1. インデックス作成（デフォルト: ./src）
py codex_review_severity.py index

# 2. 分析実行
py codex_review_severity.py advise --all --out reports/analysis_pc_a

# 3. Dropbox が自動同期するまで待機（数分）
```

### PC-B で作業を継続

```bash
# 1. Dropbox 同期完了を確認
cd ~/Dropbox/<プロジェクトパス>/BugSearch
ls -lh .advice_index.jsonl  # ファイルサイズ約400MBを確認

# 2. 既存のインデックスを使って追加分析
py codex_review_severity.py advise --topk 100 --out reports/analysis_pc_b

# 3. キャッシュも共有されているため、重複したファイルは再解析されない
```

---

## 💾 キャッシュファイルの活用

### AI応答キャッシュ (`.cache/analysis/`)

**仕組み**:
- ファイル内容のMD5ハッシュをキーとしてキャッシュ
- 同じファイル内容なら、別のPCでもキャッシュヒット
- API呼び出しを削減し、コストと時間を節約

**確認方法**:
```bash
# キャッシュファイル数を確認
ls .cache/analysis/ | wc -l

# キャッシュサイズを確認
du -sh .cache/analysis/
```

**メリット**:
- PC-Aで分析したファイルは、PC-Bでは即座に結果取得
- Dropbox経由で複数PCでキャッシュ共有
- 再解析の時間とコストを大幅削減

---

## 🚨 トラブルシューティング

### Q1: インデックスファイルが同期されない

**原因**: ファイルサイズが大きい（400MB+）ため、Dropbox同期に時間がかかる

**解決策**:
```bash
# Dropbox同期状態を確認
# Windows: タスクバーのDropboxアイコン
# Mac: メニューバーのDropboxアイコン

# または、PC-Bで再インデックス作成（デフォルト: ./src）
py codex_review_severity.py index
```

### Q2: 環境変数（APIキー）が読み込めない

**原因**: `.env` ファイルが存在しない、または同期されていない

**解決策**:
```bash
# .env ファイルの存在確認
ls -la .env

# なければ手動作成
cp .env.example .env  # サンプルがある場合
nano .env  # APIキーを入力
```

### Q3: キャッシュが有効にならない

**原因**: `.cache/` が `.gitignore` されている場合、Dropbox設定で除外されている可能性

**解決策**:
```bash
# .cache/ ディレクトリの存在確認
ls -la .cache/

# なければ作成
mkdir -p .cache/analysis

# Dropbox で選択的同期の設定を確認
# 設定 > 同期 > 選択的同期
```

### Q4: バッチ処理の進捗が別PCに引き継がれない

**原因**: `.batch_progress*.json` は `.gitignore` されており、Dropboxで同期されない

**理由**: 進捗ファイルはPC固有のため、同期すると競合が発生する

**解決策**: 各PCで個別にバッチ処理を実行し、レポートだけを共有

---

## 📊 推奨ワークフロー

### パターン1: インデックス共有型

```bash
# PC-A (高性能PC): インデックス作成（デフォルト: ./src）
py codex_review_severity.py index
# → .advice_index.jsonl がDropboxに同期

# PC-B (ノートPC): インデックスを使って分析
py codex_review_severity.py advise --topk 50 --out reports/analysis_b
# → キャッシュ活用で高速分析
```

### パターン2: 分散分析型

```bash
# PC-A: 前半50ファイル分析
py codex_review_severity.py advise --topk 50 --out reports/analysis_a

# PC-B: 後半50ファイル分析（--skip オプション使用）
py codex_review_severity.py advise --topk 100 --skip 50 --out reports/analysis_b

# いずれかのPCでレポート統合
cat reports/analysis_a/*.md reports/analysis_b/*.md > reports/combined_analysis.md
```

### パターン3: キャッシュ優先型

```bash
# PC-A: 初回分析（キャッシュ蓄積）
py codex_review_severity.py advise --all --out reports/full_analysis_a

# Dropbox同期待機（.cache/ 同期）

# PC-B: 同じ分析を実行（すべてキャッシュヒット）
py codex_review_severity.py advise --all --out reports/full_analysis_b
# → API呼び出しゼロ、数秒で完了
```

---

## 🔐 セキュリティのベストプラクティス

### 1. APIキーの管理

- ✅ `.env` は `.gitignore` に含める（GitHubにアップしない）
- ✅ Dropboxで同期（信頼できるPC間のみ）
- ❌ パブリックリポジトリにコミットしない

### 2. 分析対象コードの管理

- `src/` ディレクトリは `.gitignore` に含まれる
- 機密コードはDropbox内のみで管理
- GitHubにはツールのみをアップ

### 3. レポートの管理

- `reports/` も `.gitignore` に含まれる
- 機密情報を含むレポートはGitHubにアップされない
- Dropbox内で他のPCと共有可能

---

## 📝 チェックリスト（新しいPC追加時）

- [ ] Dropbox デスクトップアプリインストール
- [ ] プロジェクトフォルダの同期完了確認
- [ ] Python 3.8+ インストール
- [ ] `pip install openai anthropic scikit-learn joblib chardet`
- [ ] `.env` ファイルの存在確認
- [ ] Claude Code CLI インストール
- [ ] Serena MCP インストール確認（全PCで導入済み）
- [ ] `Install_PC/install_*.bat` または `install_*.sh` 実行
- [ ] smart-review-system-v2 サブエージェントインストール
- [ ] テスト実行: `py codex_review_severity.py --help`
- [ ] インデックス読み込み確認: `ls -lh .advice_index.jsonl`
- [ ] キャッシュ確認: `ls .cache/analysis/`

---

## 🎯 よくある質問

### Q: レポートも他のPCで見られますか？

A: はい。`reports/` は `.gitignore` されていますが、Dropboxでは同期されます。ただし、GitHubにはアップされません。

### Q: インデックス作成は各PCで必要ですか？

A: 不要です。1台のPCで作成した `.advice_index.jsonl` がDropboxで同期されれば、他のPCでもそのまま使えます。

### Q: 仮想環境（.venv）も共有できますか？

A: 推奨しません。`.venv/` は `.gitignore` に含まれており、OS・Python版が異なるとエラーが発生します。各PCで個別に `pip install` してください。

### Q: Git の履歴も同期されますか？

A: はい。`.git/` ディレクトリもDropboxで同期されるため、Git履歴・ブランチ・コミットすべて共有されます。

---

*このドキュメントは Dropbox 同期環境を前提としています*
*GitHub へのアップロードは行いません*
