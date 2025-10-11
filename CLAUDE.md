# CLAUDE.md

このファイルは、Claude Code (claude.ai/code) がこのリポジトリで作業する際のガイダンスです。

*バージョン: v4.3.0 (Phase 4.0完了)*
*最終更新: 2025年10月12日 JST*
*リポジトリ: https://github.com/KEIEI-NET/BugSearch2*

## プロジェクト概要

静的コード解析とAI分析を組み合わせた高度なコードレビューシステムです。C#、PHP、Go、C++、Python、JavaScript/TypeScript、Angularコードベースに対応しています。

### 🎯 Phase 4.0完了: カスタムルールシステム (@perfect品質達成)

**Phase 4.0新機能 (v4.3.0):**
- ✅ **プロジェクト固有のカスタムルール** (`.bugsearch/rules/` ディレクトリサポート)
- ✅ **ルール優先順位システム** (カスタム > コアルール、同名ルールの上書き機能)
- ✅ **ルール管理機能** (有効/無効切り替え、カテゴリ単位の無効化)
- ✅ **カスタムルールバリデーション** (YAML構文、必須フィールド、正規表現検証)
- ✅ **全テスト100%合格** (`test/test_phase4_custom_rules.py` - 11テスト全成功)

**カスタムルールディレクトリ構造:**
```
project/
├── .bugsearch/
│   ├── config.yml                    # プロジェクト設定
│   └── rules/                        # カスタムルールディレクトリ
│       ├── custom/                   # カスタムカテゴリ
│       │   ├── my-rule-1.yml
│       │   └── my-rule-2.yml
│       ├── database/                 # コアカテゴリ拡張
│       │   └── custom-query.yml
│       └── disabled.yml              # 無効化するコアルール一覧
```

**使用例:**
```bash
# カスタムルールの作成
mkdir -p .bugsearch/rules/custom
cat > .bugsearch/rules/custom/my-rule.yml << 'EOF'
rule:
  id: "CUSTOM_FORBIDDEN_API"
  category: "custom"
  name: "Forbidden API"
  description: "禁止APIの検出"
  base_severity: 8
  patterns:
    csharp:
      - pattern: 'LegacyDatabase\\.Connect'
        context: "Legacy API usage"
EOF

# 分析実行（カスタムルール込み）
python codex_review_severity.py index
python codex_review_severity.py advise --all --out reports/custom_analysis
```

### 📊 Phase 3.3完了: 全ルール動作確認 (@perfect品質達成)

**Phase 3.3新機能 (v4.2.2):**
- ✅ **全10ルールが正常動作** (YAMLファイル構文エラー完全修正)
- ✅ **4カテゴリ完全サポート** (database×3, security×3, solid×2, performance×2)
- ✅ **全テスト100%合格** (`test/test_multiple_rules.py` - 8テスト全成功、スキップ0)
- ✅ **YAML正規表現エスケープ修正** (select-star, sql-injection, xss-vulnerability, float-money)
- ✅ **セキュリティルール動作確認** (SQL Injection, XSS, Float Money)
- ✅ **SELECT * 深刻度調整動作確認** (ORM使用時の深刻度軽減)

**Phase 3.2基盤機能 (v4.2.1):**
- ✅ **RuleCategoryクラス実装** (`core/models.py` - カテゴリ別ルール管理)
- ✅ **グローバルルール関数** (`core/rule_engine.py` - load_all_rules, group_rules_by_category, adjust_severity_by_tech_stack)
- ✅ **技術スタック考慮の深刻度調整** (Elasticsearch使用時にN+1深刻度を10→7に軽減)

**Phase 3.1機能 (v4.2.0):**
- ✅ **YAMLルール定義** (Database×3, Security×3, SOLID×2, Performance×2の計10ルール作成)
- ✅ **7言語サポート** (C#, Java, PHP, JavaScript, TypeScript, Python, Go)
- ✅ **詳細な修正提案** (技術スタック別の推奨修正方法)

**Phase 2の基盤機能 (v4.1.0):**
- ✅ **技術スタック自動検出エンジン** (`core/tech_stack_detector.py`)
- ✅ **YAMLベースルールシステム** (Phase 3で8ルール追加)
- ✅ **対話型設定ジェネレータ** (`stack_generator.py auto` - 自動検出+手動修正)
- ✅ **全テスト合格** (`test/test_tech_stack_detector.py` - 5/5)

**対応技術スタック:**
- フロントエンド: Angular, React, Vue.js, Svelte
- バックエンド: C#/.NET, Java/Spring Boot, Python, PHP, Go, Node.js
- データベース: PostgreSQL, MySQL, SQL Server, MongoDB, Cassandra, Elasticsearch
- インフラ: Redis, RabbitMQ, Kafka
- 設定ファイル: package.json, pom.xml, *.csproj, docker-compose.yml, go.mod, composer.json

### 🎯 PERFECT PRODUCTION QUALITY ステータス

| コンポーネント | バージョン | スコア | ステータス |
|------------|---------|--------|----------|
| **codex_review_severity.py** | v3.7.0 | **100/100** 🏆 | ✅ PERFECT QUALITY |
| **generate_ai_improved_code.py** | v1.6.0 | **100/100** 🏆 | ✅ PERFECT QUALITY |
| **apply_improvements_from_report.py** | v4.0.0 | **100/100** 🏆 | ✅ PERFECT QUALITY |
| **core/tech_stack_detector.py** | v1.0.0 (Phase 2) | **100/100** 🏆 | ✅ 全テスト合格 |
| **stack_generator.py** | v2.0.0 (Phase 2) | **100/100** 🏆 | ✅ 自動検出対応 |

**全コンポーネントが完璧な100/100スコアを達成！** super-debugger-perfectionist による5パス多層検証を完了し、完璧な品質で本番環境にデプロイ可能です。

**コアアーキテクチャ**: 3段階パイプライン
1. **設定ステージ**: 技術スタック自動検出 → `.bugsearch.yml`生成
2. **Indexステージ**: 高速な静的解析 → `.advice_index.jsonl`（検索可能インデックス）
3. **Adviseステージ**: 技術スタック考慮のAI詳細分析

## 必須コマンド

### インストール
```bash
# 依存パッケージのインストール（v3.5以降はpython-dotenv不要）
pip install openai anthropic scikit-learn joblib chardet pyyaml

# または requirements.txt を使用
pip install -r requirements.txt

# Python 3.13でのscikit-learn対処法
pip install --only-binary :all: scikit-learn
```

### Phase 2: 技術スタック設定 (新機能)
```bash
# 1. 技術スタック自動検出+設定生成
py stack_generator.py auto

# 2. フルマニュアル設定
py stack_generator.py init

# 3. 特定ディレクトリから自動検出
py stack_generator.py auto --dir ./my-project

# 生成された .bugsearch.yml を確認・編集
notepad .bugsearch.yml
```

### 標準ワークフロー
```bash
# 1. インデックス作成（デフォルト: ./src ディレクトリ、4MB制限、4ワーカー）
py codex_review_severity.py index

# オプション指定の例
py codex_review_severity.py index --max-file-mb 4 --worker-count 4

# 特定言語を除外する場合
py codex_review_severity.py index --exclude-langs delphi java

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
# Phase 1 MVPテスト
python test/test_mvp.py

# Phase 2 技術スタック自動検出テスト
python test/test_tech_stack_detector.py

# Phase 3.3 複数ルール管理テスト (@perfect品質: 8/8成功)
python test/test_multiple_rules.py

# Phase 4.0 カスタムルールシステムテスト (@perfect品質: 11/11成功)
python test/test_phase4_custom_rules.py

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
├── stack_generator.py                # 技術スタック設定生成（Phase 2新機能）
├── batch_config.json                 # 設定ファイル
├── .env                              # 環境変数（要作成）
├── .bugsearch.yml                    # プロジェクト技術スタック設定（自動生成）
│
├── .bugsearch/                       # ⭐ プロジェクト固有設定（Phase 4）
│   ├── config.yml                    # プロジェクト設定
│   └── rules/                        # カスタムルール
│       ├── custom/                   # カスタムカテゴリルール
│       │   └── *.yml
│       ├── database/                 # データベースルール拡張
│       ├── security/                 # セキュリティルール拡張
│       └── disabled.yml              # 無効化ルール一覧
│
├── core/                             # ⭐ コアモジュール（Phase 1-2）
│   ├── __init__.py                   # モジュール初期化
│   ├── models.py                     # データモデル（TechStack, ProjectConfig, Rule）
│   ├── project_config.py             # YAML設定読み込み
│   ├── rule_engine.py                # ルールベース解析エンジン
│   ├── tech_stack_detector.py        # 技術スタック自動検出（Phase 2）
│   └── encoding_handler.py           # マルチエンコーディング対応
│
├── rules/                            # ⭐ YAMLルール定義（Phase 3完了）
│   └── core/
│       ├── database/
│       │   ├── n-plus-one.yml        # N+1問題検出（Phase 1）
│       │   ├── select-star.yml       # SELECT * 検出（Phase 3）
│       │   └── multiple-join.yml     # 多重JOIN検出（Phase 3）
│       ├── security/
│       │   ├── sql-injection.yml     # SQLインジェクション（Phase 3）
│       │   ├── xss-vulnerability.yml # XSS脆弱性（Phase 3）
│       │   └── float-money.yml       # 金額計算float検出（Phase 3）
│       ├── solid/
│       │   ├── large-class.yml       # 巨大クラス検出（Phase 3）
│       │   └── large-interface.yml   # 巨大IF検出（Phase 3）
│       └── performance/
│           ├── memory-leak.yml       # メモリリーク検出（Phase 3）
│           └── goroutine-leak.yml    # Goroutineリーク検出（Phase 3）
│
├── config/                           # 設定ファイルサンプル
│   └── default.bugsearch.yml         # デフォルト設定テンプレート
│
├── test/                             # ⭐ テストコード（新規テストはここに配置）
│   ├── test_mvp.py                   # Phase 1 MVPテスト
│   ├── test_tech_stack_detector.py   # Phase 2 自動検出テスト
│   ├── test_*.py                     # その他ユニットテスト
│   ├── benchmark_parallel.py         # パフォーマンステスト
│   ├── monitor_parallel.py           # モニタリングツール
│   └── samples/                      # テストサンプルファイル
│       ├── n-plus-one-csharp.cs     # C# N+1サンプル
│       └── test-bugsearch.yml        # テスト用設定
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

---

*最終更新: 2025年10月12日 JST*
*バージョン: v4.3.0 (Phase 4.0完了)*
*リポジトリ: https://github.com/KEIEI-NET/BugSearch2*

**更新履歴:**
- v4.3.0 (2025年10月12日): **Phase 4.0完了 (@perfect品質達成)** - カスタムルールシステム実装、RuleLoader/RuleValidator追加(core/rule_engine.py +290行)、ルール優先順位(カスタム>コア)、ルール有効/無効管理、カスタムルールバリデーション、全テスト100%合格(11/11成功)
- v4.2.2 (2025年10月12日): **Phase 3.3完了 (@perfect品質達成)** - 全10YAMLルール正常動作、4カテゴリ完全サポート、全テスト100%合格(8/8成功、スキップ0)、YAML正規表現エスケープ修正(select-star, sql-injection, xss-vulnerability, float-money)、セキュリティルール動作確認
- v4.2.1 (2025年10月12日): **Phase 3.2完了** - RuleCategoryクラス、グローバルルール関数(load_all_rules, group_rules_by_category, adjust_severity_by_tech_stack)実装、複数ルール管理テスト(8テスト、6成功+2スキップ)、技術スタック考慮の深刻度調整(Elasticsearch使用時N+1深刻度10→7)
- v4.2.0 (2025年10月12日): **Phase 3.1完了** - 10個のYAMLルール定義作成(Database×3, Security×3, SOLID×2, Performance×2)、7言語サポート、詳細な修正提案、技術スタック別推奨方法
- v4.1.0 (2025年10月12日): **Phase 2完了** - 技術スタック自動検出エンジン、YAMLルールシステム、対話型設定ジェネレータ実装、全テスト合格(5/5)
- v4.0.5 (2025年10月11日): **Phase 1完了** - BugSearch2リポジトリ新規作成、coreモジュール実装、MVPテスト合格(3/3)
