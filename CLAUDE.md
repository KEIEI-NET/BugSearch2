# CLAUDE.md

このファイルは、Claude Code (claude.ai/code) がこのリポジトリで作業する際のガイダンスです。

*バージョン: v4.0.2*
*最終更新: 2025年01月05日*

## プロジェクト概要

静的コード解析とAI分析を組み合わせた高度なコードレビューシステムです。C#、PHP、Go、C++、Python、JavaScript/TypeScript、Angularコードベースに対応しています。

**コアアーキテクチャ**: 2段階パイプライン
1. **Indexステージ**: 高速な静的解析 → `.advice_index.jsonl`（検索可能インデックス）
2. **Adviseステージ**: 高深刻度ファイルに対するAI詳細分析

## 必須コマンド

### インストール
```bash
# 依存パッケージのインストール（v3.5以降はpython-dotenv不要）
pip install openai anthropic scikit-learn joblib chardet

# または requirements.txt を使用
pip install -r requirements.txt

# Python 3.13でのscikit-learn対処法
pip install --only-binary :all: scikit-learn
```

### 標準ワークフロー
```bash
# 1. インデックス作成（デフォルト: ./src ディレクトリ）
py codex_review_severity.py index --exclude-langs delphi --max-file-mb 4 --worker-count 4

# カスタムソースディレクトリ指定
py codex_review_severity.py index --src-dir ./custom/path

# 2. 分析実行
# ⚠️ 重要: デフォルトでは80ファイルしか分析しません！
py codex_review_severity.py advise --all --out reports/full_analysis

# AI改善コード付き完全分析（推奨）
py codex_review_severity.py advise --complete-all --out reports/complete_analysis

# クイックプレビュー（80ファイルのみ）
py codex_review_severity.py advise --out reports/quick_analysis
```

### 並列処理（大規模コードベース向け）
```bash
# Windows
run_enhanced_analysis.bat

# 直接実行
py extract_and_batch_parallel_enhanced.py

# 進捗モニタリング
python test/monitor_parallel.py
```

### AI生成改善コードの適用（v4.0新機能）
```bash
# 変更内容のプレビュー（dry-run）
python apply_improvements_from_report.py reports/complete_analysis.md --dry-run

# 改善を適用
python apply_improvements_from_report.py reports/complete_analysis.md --apply

# ロールバック
python apply_improvements_from_report.py --rollback backups/file.py.20251004_153045.bak
```

### テスト
```bash
# コアテストの実行
python test/test_gpt5_codex.py
python test/test_solid_violations.py
python test/benchmark_parallel.py

# インデックス整合性チェック
py check_index.py
```

## アーキテクチャ詳細

### コアスクリプト
| スクリプト | 用途 | 主要機能 |
|--------|------|---------|
| `codex_review_severity.py` | メインCLI | `index`, `advise`, `query`コマンド; 深刻度スコアリング |
| `apply_improvements_from_report.py` | AI修正自動適用 | 100/100セキュリティスコア; アトミック更新; ロールバック |
| `extract_and_batch_parallel_enhanced.py` | 並列AI分析 | 10ワーカー; 10倍高速化; MD5キャッシュ |
| `extract_and_batch_parallel.py` | 代替並列実装 | 自動レジューム; バッチ処理 |

### 設定ファイル
- **`.env`**: 環境変数（手動ロード、python-dotenv依存なし）
  - `AI_PROVIDER`: `auto`（Anthropic→OpenAI）, `anthropic`, `openai`
  - `OPENAI_API_KEY`, `OPENAI_MODEL`（デフォルト: `gpt-4o`）
  - `ANTHROPIC_API_KEY`, `ANTHROPIC_MODEL`（デフォルト: `claude-sonnet-4-5`）
- **`batch_config.json`**: 並列処理設定（バッチサイズ、ワーカー数、タイムアウト、モデル選択）

### 生成ファイル（gitignore対象）
- `.advice_index.jsonl`: 静的解析によるファイルインデックス
- `.advice_*.pkl`: セマンティック検索用TF-IDFベクトル
- `reports/`: 分析出力（Markdown形式）
- `.cache/analysis/`: AI応答キャッシュ（MD5ベース）
- `.batch_progress_parallel.json`: 自動レジューム用進捗ファイル

## 深刻度スコアリングシステム

スコアは1～10の範囲、数値が高いほど重大な問題です。

### 重大な問題（8-10）
- **データベース**: N+1クエリ（10）、SELECT *（8）、多重JOIN（7）
- **PHPセキュリティ**: SQLi/コマンドインジェクション（10）、XSS/ファイルインクルード（9）、eval()（9）
- **C++メモリ**: バッファオーバーフロー/メモリリーク（10）、未初期化ポインタ（9）
- **Go並行性**: Goroutineリーク（9）、エラーチェック不足（8）
- **Angular**: プライベートルートのガード未実装（8）、Subscriptionリーク（7）

### 中程度の問題（4-7）
- SOLID原則違反: 巨大クラス（5）、switch/instanceof濫用（4）
- Angular: ChangeDetectionStrategy問題（4-6）
- リソースリーク: Goのdefer不足（6）

### 軽微な問題（1-3）
- UI: マルチクリック防止なし（3）
- SOLID: DIなしの直接インスタンス化（3）

## 重要な落とし穴

### ⚠️ --topkデフォルトの罠
`advise`コマンドは**デフォルトで80ファイルしか分析しません**。これが最も混乱を招く原因です。

```bash
# ❌ 悪い例: 80ファイルしか分析されない
py codex_review_severity.py advise --out reports/analysis

# ✅ 良い例: インデックス化された全ファイルを分析
py codex_review_severity.py advise --all --out reports/analysis

# ✅ より良い例: AI改善コード付き完全分析
py codex_review_severity.py advise --complete-all --out reports/analysis
```

本番環境の分析では常に `--all` または `--complete-all` を使用してください。

### 環境変数ロード
v3.5以降は `load_env_file()` による組み込み`.env`ロード機能があります（`codex_review_severity.py` 24-41行目）。python-dotenv不要です。

### エンコーディング自動検出
`chardet`が日本語ファイルのUTF-8/Shift_JIS/CP932/EUC-JPを自動処理します。`apply_improvements_from_report.py`ツールでこの機能を広く使用（66-112行目）。

## ファイル構成ルール

### テストファイル
**新規テストファイルは必ず`test/`ディレクトリに配置:**
- `test_*.py`: ユニットテスト
- `benchmark_*.py`: パフォーマンステスト
- `monitor_*.py`: モニタリングユーティリティ

### ドキュメント
**ルートディレクトリ**: 最大3-5個のコアドキュメント（README.md、CLAUDE.md、INSTALL.md等）
**その他のドキュメント**: `doc/`サブディレクトリに配置:
- `doc/guides/`: 使用ガイド
- `doc/changelog/`: バージョン履歴
- `doc/archive/`: 古いドキュメント

### 生成ファイル
コミット禁止: `.advice_index.jsonl`, `.advice_*.pkl`, `reports/`, `.cache/`, `.batch_progress_parallel.json`

## 実装ノート

### 言語サポートの追加
1. `SEVERITY_SCORES`辞書に深刻度パターンを追加（`codex_review_severity.py` 54-130行目）
2. 正規表現パターンに言語の拡張子を追加（プリコンパイル済みパターンを使用する場合は`COMPILED_PATTERNS`をチェック）
3. `test/sample_*.{ext}`でサンプルファイルをテスト

### マルチAIプロバイダーサポート
- **Autoモード**（デフォルト）: Anthropic Claude → OpenAI GPT → ルールのみの順で試行
- **深刻度別モデル選択**:
  - 重大（15以上）: Opus 4.1 / GPT-4o
  - 高（10-14）: Sonnet 4.5 / GPT-4o
  - 中（5-9）: Sonnet 4.1 / GPT-4o-mini

### 並列処理詳細
- **設定**: `batch_config.json` → `parallel_config`セクション
- **ワーカー数**: デフォルト10並列スレッド
- **バッチサイズ**: 50ファイル/バッチ
- **タイムアウト**: 60秒/ファイル
- **自動レジューム**: `.batch_progress_parallel.json`に進捗保存
- **MD5キャッシュ**: `.cache/analysis/`にファイル内容ハッシュでAI応答をキャッシュ

## よくある問題

### 80ファイルしか分析されない
**解決策**: 常に`--all`フラグを使用するか、インデックスサイズに合わせた明示的な`--topk`指定

### エンコーディングエラー（日本語ファイル）
**自動処理**: `chardet`がUTF-8/Shift_JIS/CP932/EUC-JPを検出

### 大きなファイルでのタイムアウト
```bash
# ファイルサイズ制限を下げる
py codex_review_severity.py index . --max-file-mb 1

# batch_config.jsonでタイムアウトを調整
"timeout_per_file": 120
```

### Python 3.13インストールエラー
```bash
pip install --only-binary :all: scikit-learn
```

## v4.0.0ハイライト - apply_improvements_from_report.py

**100/100セキュリティスコア**を以下により達成:
- パストラバーサル防止（ホワイトリスト + `os.lstat()`シンボリックリンクチェック）
- TOCTOU保護（stat → open間の競合状態防止）
- アトミックファイル更新（`tempfile` + `fsync` + `atomic rename`）
- クロスプラットフォームファイルロック（Windows: msvcrt、Unix: fcntl）
- Unicode制御文字検出（C0/C1/BIDI攻撃防止）
- ReDoS軽減（ファイルサイズ制限 + コンパイル済み正規表現）

**自動エンコーディング検出**（66-112行目）:
- BOM検出: UTF-8、UTF-16 LE/BE
- chardet統合: confidence > 0.7
- フォールバックチェーン: UTF-8 → CP932 → Shift_JIS → latin1

**バックアップ/ロールバック**: メタデータJSON付きタイムスタンプバックアップによる安全な復元。

## プロジェクト構成

```
.
├── codex_review_severity.py          # メインスクリプト（全言語対応）
├── apply_improvements_from_report.py # AI改善自動適用（v4.0新機能）
├── extract_and_batch_parallel*.py    # 並列処理版スクリプト
├── batch_config.json                 # 設定ファイル
├── .env                              # 環境変数（要作成）
│
├── test/                             # ⭐ テストコード（新規テストはここに配置）
│   ├── test_*.py                     # ユニットテスト
│   ├── benchmark_parallel.py         # パフォーマンステスト
│   ├── monitor_parallel.py           # モニタリングツール
│   └── sample*.{py,js,go,php}       # テストサンプルファイル
│
├── doc/                              # 📚 ドキュメント
│   ├── TECHNICAL.md                  # 技術仕様
│   ├── ARCHITECTURE.md               # アーキテクチャ詳細
│   ├── DEVELOPMENT.md                # 開発履歴
│   ├── TEST_RESULTS.md               # テスト結果
│   ├── guides/                       # ガイド文書
│   │   ├── AUTO_APPLY_GUIDE.md      # 自動適用ガイド
│   │   ├── GPT5_MIGRATION.md        # GPT-5移行ガイド
│   │   ├── ENHANCED_ANALYSIS_GUIDE.md # 拡張分析ガイド
│   │   └── AGENTS.md                 # 運用ルール
│   ├── changelog/                    # 変更履歴
│   │   ├── CHANGELOG_v3.md          # v3.1変更内容
│   │   └── v4.0.0.md                # v4.0.0変更内容
│   └── archive/                      # アーカイブ
│
├── reports/                          # 分析レポート出力先（自動生成）
├── backups/                          # バックアップディレクトリ（自動生成）
├── .cache/                           # キャッシュディレクトリ（自動生成）
│   └── analysis/                     # AI分析キャッシュ
├── .advice_index.jsonl               # インデックスファイル（自動生成）
└── .advice_*.pkl                     # TF-IDFベクトル（自動生成）
```

> **⭐ 重要**:
> - 新規テストコードは必ず`test/`フォルダー内に配置
> - ドキュメントは`doc/`配下に整理済み
> - 生成ファイル（`.advice*`、`reports/`、`.cache/`、`backups/`）はgitignore対象

## コーディング規約

- **Python 3.11+必須**、4スペースインデント、UTF-8 I/O
- インポートのグループ化: 標準ライブラリ → サードパーティ → ローカル
- 命名規則:
  - 関数と変数: `snake_case`
  - クラス: `CapWords`
  - 定数: `UPPER_CASE`（例: `INDEX_PATH`, `HYBRID_TOPK_AI`）
- CLIスクリプトはシングルファイルスタイル
- ヘルパー関数は呼び出し位置の近くに配置
- 重要なユーティリティにはdocstring（パラメータと副作用を説明）を記述
- ログメッセージは英日混在可、重要な設定値は英語で明示

## コミットとPull Requestガイドライン

- コミットメッセージは命令形現在時制（例: `feat: add HasMorePages guard`、`fix: skip binary index entries`）
- 1つの論理変更につき1コミット
- Pull Request説明に含めるべき内容:
  - 更新されたCLIオプション
  - 実行したコマンド
  - 必要な環境変数（`OPENAI_API_KEY`、`OPENAI_MODEL`）
  - 生成レポートのプレビューまたは主要な発見事項
- 該当する場合は`Closes #123`でissueをリンク
- ワークフローやシークレットの変更を明確に文書化（レビュアーがGitHub Actionsと`.env.example`を推測なしで更新できるように）

---

*詳細な技術仕様については`doc/TECHNICAL.md`を参照*
*CI/CD統合については`doc/CI_GUIDE.md`を参照*
*テスト手順については`doc/TESTING.md`を参照*
