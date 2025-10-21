# BugSearch2 - AI Code Review System v5.0.0

静的コード解析とAI分析を組み合わせた高度なコードレビューシステムです。
**🎉 v5.0.0 メジャーリリース**: GUI Production v1.0.0が本番環境対応！34,125ファイル処理成功、リアルタイム進捗表示、平均速度97 files/secを実証。初心者向けGUI版と上級者向けCLI版の両方をサポート。

*バージョン: v5.0.0 (GUI Production v1.0.0 リリース)*  
*最終更新: 2025年10月21日*  
*作成者: KEIEI.NET INC.*  
*リポジトリ: https://github.com/KEIEI-NET/BugSearch2*

**✅ GUI Production v1.0.0 - 本番環境で動作保証あり**  
**⚠️ セキュリティ強化版 - ReDoS脆弱性修正済み、環境変数保護強化**

## 🚀 クイックスタート

### GUI版（推奨）- 初心者向け
```bash
# Windows: ダブルクリック
start_gui.bat

# macOS/Linux
chmod +x start_gui.sh  # 初回のみ
./start_gui.sh
```
**動作保証**: 34,125ファイルを5分52秒で処理成功（平均97 files/sec）

### CLI版 - 上級者向け
```bash
# 1. インデックス作成
python codex_review_severity.py index

# 2. AI分析実行（全ファイル対象）
python codex_review_severity.py advise --all --out reports/analysis
```

## 📊 実績とパフォーマンス

### GUI Production v1.0.0 実績
- ✅ **34,125ファイル処理成功** (2025年10月21日検証)
- ✅ **平均速度: 97 files/sec**
- ✅ **所要時間: 5分52秒**
- ✅ **リアルタイム進捗表示** (ファイル数、処理速度、残り時間)
- ✅ **本番環境動作保証**

### 対応規模
- **小規模プロジェクト**: 1,000ファイル以下 → 10秒以内で完了
- **中規模プロジェクト**: 10,000ファイル → 2分以内で完了
- **大規模プロジェクト**: 30,000ファイル以上 → 6分以内で完了

## 📚 ドキュメント

### 🎯 必読ドキュメント
- [GUI Production v1.0.0 ユーザーガイド](doc/guides/GUI_USER_GUIDE.md) - 本番環境推奨GUI
- [Claude.ai コンテキスト](CLAUDE.md) - Claude CLIで開発する際の重要情報
- ⚠️ [--topk パラメータの注意事項](#-topk-パラメータの注意事項) - **必読**：デフォルトは80ファイルのみ

### 📖 技術文書
- [技術仕様 v5.0.0](doc/TECHNICAL.md) - GUI/CLI両対応の詳細仕様
- [アーキテクチャ](doc/ARCHITECTURE.md) - システム全体構成
- [開発履歴](doc/DEVELOPMENT.md) - Phase 0-3 GUI開発履歴含む
- [変更履歴 v5.0.0](doc/changelog/CHANGELOG_v5.md) - v5.0.0の変更内容

### 📊 システム図
- [CLI アーキテクチャ図 v5.0.0](doc/diagrams/ARCHITECTURE_CLI_v5.0.0.mmd) - CLIシステム構成
- [GUI アーキテクチャ図 v1.0.0](doc/diagrams/ARCHITECTURE_GUI_v1.0.0.mmd) - GUIシステム構成

## 🎉 v5.0.0 新機能 - GUI Production v1.0.0 リリース

### 🖥️ GUI Production v1.0.0（2025年10月21日）- 本番環境動作保証

1. **シンプルで信頼性の高いUI**
   - 3タブ構成: Index/Advise/Query
   - リアルタイム進捗表示
   - インテリジェント進捗トラッキング

2. **実証されたパフォーマンス**
   ```
   処理ファイル数: 34,125
   処理速度: 97 files/sec
   所要時間: 5分52秒
   ログ更新: 500ファイルごと
   ```

3. **簡単起動**
   ```bash
   # Production版（推奨）
   start_gui.bat          # Windows
   ./start_gui.sh         # macOS/Linux

   # フル機能版（開発者向け）
   start_gui_full.bat     # Windows  
   ./start_gui_full.sh    # macOS/Linux
   ```

4. **技術スペック**
   - Python 3.11.9 + CustomTkinter 5.2.2
   - unbuffered output対応
   - subprocess + threading統合
   - queue.Queue によるスレッド間通信

### 📈 Phase 0-3 開発完了

**開発フェーズ実績**:
- **Phase 0**: 基盤準備（0.5時間）- 開発環境構築
- **Phase 1**: MVP GUI（1時間）- `gui_mvp.py` 基本機能実装
- **Phase 2**: リアルタイムログ（2時間）- `gui_phase2.py` ストリーミング対応
- **Phase 3**: 複数コマンド対応（3時間）- `gui_phase3.py` 3コマンド統合
- **Phase 3改良版**: インテリジェント進捗トラッキング - `gui_production.py` v1.0.0

## 🔧 主要機能

### コア機能
- **9言語サポート**: Python, JavaScript, TypeScript, PHP, C#, Java, Go, C++, Delphi
- **22技術スタック対応**: React, Angular, Express, Django, PostgreSQL, MySQL等
- **AIプロバイダー**: Anthropic Claude, OpenAI GPT（自動フォールバック）
- **並列処理**: 最大10ワーカーで10倍高速化

### YAMLルールシステム
- **64個のデータベースルール**: 8データベース×8ルール事前生成
- **カスタムルール対応**: プロジェクト固有ルール定義可能
- **技術スタック最適化**: 環境に応じた深刻度調整

### レポート機能
- **AI改善コード生成**: 100点満点目標の改善コード自動生成
- **完全レポート**: 詳細分析とAI改善提案
- **差分解析**: Git diff統合による変更箇所のみの高速解析

## 📦 インストール

### 必要要件
- Python 3.11以上
- Git
- 8GB以上のRAM（推奨）

### GUI版インストール（推奨）
```bash
# リポジトリクローン
git clone https://github.com/KEIEI-NET/BugSearch2.git
cd BugSearch2

# 起動スクリプト実行（自動セットアップ）
# Windows
start_gui.bat

# macOS/Linux
chmod +x start_gui.sh
./start_gui.sh
```

### CLI版インストール
```bash
# 依存パッケージインストール
pip install -r requirements.txt

# 環境変数設定
cp .env.example .env
# .envファイルを編集してAPIキーを設定
```

## 🎯 使用方法

### GUI版の使い方

1. **起動**
   - `start_gui.bat` (Windows) または `./start_gui.sh` (macOS/Linux) を実行

2. **Indexタブ**
   - ソースディレクトリを選択
   - 「Index作成」ボタンをクリック
   - リアルタイムで進捗を確認

3. **Adviseタブ**
   - 分析オプションを設定
   - 「分析開始」ボタンをクリック
   - レポートが自動生成

4. **Queryタブ**
   - 検索クエリを入力
   - 特定ファイルを高速検索

### CLI版の使い方

```bash
# 基本的なワークフロー
# 1. インデックス作成
python codex_review_severity.py index

# 2. 全ファイル分析（推奨）
python codex_review_severity.py advise --all --out reports/analysis

# 3. AI改善コード付き完全分析
python codex_review_severity.py advise --complete-all --out reports/complete

# 4. 改善コード適用
python apply_improvements_from_report.py reports/complete.md --apply
```

## ⚠️ 重要な注意事項

### --topk パラメータの注意事項

**デフォルトでは80ファイルしか分析されません！** 全ファイルを分析するには必ず `--all` フラグを使用してください。

```bash
# ❌ 悪い例: 80ファイルのみ分析
python codex_review_severity.py advise --out reports/analysis

# ✅ 良い例: 全ファイル分析
python codex_review_severity.py advise --all --out reports/analysis
```

### エンコーディング対応

日本語ファイル（UTF-8/Shift_JIS/CP932/EUC-JP）は自動検出されます。chardetによる自動エンコーディング検出機能搭載。

## 🤝 コントリビューション

1. Forkしてください
2. Feature branchを作成 (`git checkout -b feature/AmazingFeature`)
3. 変更をコミット (`git commit -m 'feat: add AmazingFeature'`)
4. Branchにプッシュ (`git push origin feature/AmazingFeature`)
5. Pull Requestを作成

## 📝 ライセンス

本プロジェクトはMITライセンスの下で公開されています。詳細は[LICENSE](LICENSE)ファイルを参照してください。

## 🙏 謝辞

- Anthropic Claude API
- OpenAI GPT API
- CustomTkinter
- scikit-learn
- そして全てのコントリビューターの皆様

---

*作成者: KEIEI.NET INC.*  
*最終更新: 2025年10月21日*  
*バージョン: v5.0.0*

**更新履歴:**
- v5.0.0 (2025年10月21日): **GUI Production v1.0.0 正式リリース** - 本番環境動作保証、34,125ファイル処理成功、リアルタイム進捗表示、平均97 files/sec達成、Phase 0-3開発完了
- v4.11.8 (2025年10月17日): YAMLルール構文エラー修正 + Angular/C++誤検出修正
- v4.11.7 (2025年10月14日): Phase 8.5完了 - レポート生成重大バグ修正
- v4.11.6 (2025年10月14日): Phase 8.4完了 - チェックボックスデフォルト設定システム