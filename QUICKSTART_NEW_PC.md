# 🚀 クイックスタートガイド - 新PC版

*最終更新: 2025年10月14日 19:45 JST*

このガイドは、他のPCでBugSearch2を最速でセットアップするための手順です。

---

## ⚡ 3ステップセットアップ

### ステップ1: リポジトリのクローン

```bash
# GitHubからクローン
git clone https://github.com/KEIEI-NET/BugSearch2.git
cd BugSearch2

# または既存リポジトリの更新
cd BugSearch2
git fetch KEIEI-NET
git pull KEIEI-NET main
```

### ステップ2: 自動セットアップスクリプトの実行

**Windows:**
```bash
setup_new_pc.bat
```

**Linux/macOS:**
```bash
chmod +x setup_new_pc.sh
./setup_new_pc.sh
```

スクリプトが自動で以下を実行します：
- ✅ Git状態の確認
- ✅ 最新状態への更新
- ✅ Python バージョン確認
- ✅ 仮想環境の作成
- ✅ 依存パッケージのインストール
- ✅ .envファイルの作成

### ステップ3: APIキーの設定

`.env`ファイルを編集して、APIキーを設定します：

```env
OPENAI_API_KEY=sk-...
ANTHROPIC_API_KEY=sk-ant-...
AI_PROVIDER=auto
OPENAI_MODEL=gpt-4o
ANTHROPIC_MODEL=claude-sonnet-4-5
```

---

## ✅ 動作確認

### クイックテスト（推奨）

```bash
# インデックス作成テスト（10ファイル）
python codex_review_severity.py index --max-files 10

# 分析テスト（3ファイル）
python codex_review_severity.py advise --topk 3 --out reports/test
```

### Phase 8.5 検証テスト

```bash
# 完全レポート生成テスト（ソースコード読み込みエラー0件を確認）
python codex_review_severity.py advise --all --complete-report --max-complete-items 10 --out reports/phase8_5_verify
```

成功すれば：
- `reports/phase8_5_verify.md` が生成される
- ソースコード読み込みエラーが0件
- レポートフォーマットが仕様通り（`doc/AI_IMPROVED_CODE_GENERATOR.md`準拠）

### GUI起動テスト（オプション）

```bash
# Windows
python gui_main.py
# または
start_gui.bat

# Linux/macOS
python gui_main.py
# または
./start_gui.sh
```

---

## 📋 チェックリスト

セットアップ完了後、以下を確認：

- [ ] Git最新コミットが `afae3bbf` である
- [ ] Python 3.11+ がインストールされている
- [ ] 仮想環境が作成されている（`venv/`ディレクトリ）
- [ ] 依存パッケージがインストールされている
- [ ] `.env`ファイルにAPIキーが設定されている
- [ ] クイックテストが成功した
- [ ] `HANDOFF.md`を読んだ

---

## 🎯 次にやること

### 最優先タスク

1. **Phase 8.5の動作検証**
   - 完全レポート生成テスト実行
   - ソースコード読み込みエラー0件を確認

2. **Windows cp932対応の確認**（Windowsの場合）
   - integration_test_engineの動作確認

3. **レポートフォーマット確認**
   - 生成されたレポートが仕様通りか確認

### 開発再開の手順

1. **最新状態の確認**
   ```bash
   git log --oneline -n 5
   git status
   ```

2. **ブランチ作成**（新機能開発の場合）
   ```bash
   git checkout -b feature/your-feature-name
   ```

3. **開発開始**
   - コード編集
   - テスト実行
   - コミット

---

## 📚 重要ドキュメント

必読ドキュメント（優先順）:

1. **HANDOFF.md** - 引き継ぎドキュメント（最重要）
2. **CLAUDE.md** - プロジェクト概要とガイドライン
3. **doc/TECHNICAL.md** - 技術仕様詳細
4. **INSTALL.md** - インストールガイド
5. **README.md** - プロジェクトREADME

---

## 🆘 トラブルシューティング

### エラー: Python が見つからない
```bash
# Python 3.11以上をインストール
# Windows: https://www.python.org/downloads/
# Linux: sudo apt install python3.11
# macOS: brew install python@3.11
```

### エラー: pip install が失敗する
```bash
# pipをアップグレード
python -m pip install --upgrade pip

# 再試行
pip install -r requirements.txt
```

### エラー: API キーが無効
- `.env`ファイルを確認
- APIキーが正しく設定されているか確認
- 引用符で囲まない（例: `OPENAI_API_KEY=sk-...`）

### エラー: モジュールが見つからない
```bash
# 仮想環境がアクティブか確認
# Windows: venv\Scripts\activate
# Linux/macOS: source venv/bin/activate

# パッケージを再インストール
pip install -r requirements.txt
```

---

## 💡 ヒント

### 高速セットアップ（上級者向け）

全コマンドを一度に実行:

**Windows (PowerShell):**
```powershell
git pull KEIEI-NET main; python -m venv venv; .\venv\Scripts\activate; pip install -r requirements.txt; pip install -r requirements_gui.txt; copy .env.example .env
```

**Linux/macOS (Bash):**
```bash
git pull KEIEI-NET main && python3 -m venv venv && source venv/bin/activate && pip install -r requirements.txt && pip install -r requirements_gui.txt && cp .env.example .env
```

その後、`.env`を編集してAPIキーを設定。

---

## 🔗 リンク

- **リポジトリ**: https://github.com/KEIEI-NET/BugSearch2
- **Issues**: https://github.com/KEIEI-NET/BugSearch2/issues
- **最新リリース**: https://github.com/KEIEI-NET/BugSearch2/releases

---

**これで新PCでの開発準備が完了です！Happy Coding! 🚀**
