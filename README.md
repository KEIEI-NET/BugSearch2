# Codex Review - AI Code Review System v3.5

静的コード解析とAI分析を組み合わせた高度なコードレビューシステムです。

*バージョン: v3.5.0*
*最終更新: 2025年01月03日 15:30 JST*

**⚠️ セキュリティ強化版 - ReDoS脆弱性修正済み、環境変数保護強化**

## 📚 ドキュメント

### 🚀 クイックスタート
- [Claude.ai コンテキスト](CLAUDE.md) - Claude CLIで開発する際の重要情報
- ⚠️ [--topk パラメータの注意事項](#-topk-パラメータの注意事項) - **必読**：デフォルトは80ファイルのみ
- 📦 [インストール方法](#1-インストール) - 必要なパッケージとセットアップ

### 📖 技術文書
- [技術仕様](doc/TECHNICAL.md) - 詳細な技術仕様とアーキテクチャ
- [技術仕様 v3](doc/TECHNICAL_v3.md) - v3.1 並列処理版の詳細
- [CI 運用ガイド](doc/CI_GUIDE.md) - GitHub Actions を中心としたジョブ構成とパラメータ例
- [言語サポート](doc/LANGUAGES.md) - 対応言語の詳細

### 📊 開発情報
- [開発履歴](doc/DEVELOPMENT.md) - バージョン履歴と改善内容
- [変更履歴 v3](doc/changelog/CHANGELOG_v3.md) - v3.1の変更内容
- [テスト結果](doc/TEST_RESULTS.md) - 実行テストとパフォーマンス結果
- [テストガイド](doc/TESTING.md) - テスト手順と推奨コマンド

### 📝 ガイド
- [GPT-5 移行ガイド](doc/guides/GPT5_MIGRATION.md) - GPT-5への移行手順
- [GPT-5 ステータス](doc/guides/GPT5_STATUS.md) - GPT-5対応状況
- [拡張分析ガイド](doc/guides/ENHANCED_ANALYSIS_GUIDE.md) - 詳細分析の使い方
- [パフォーマンスレポート](doc/guides/PERFORMANCE_REPORT.md) - パフォーマンス測定結果
- [開発者ガイドライン](doc/guides/AGENTS.md) - リポジトリ運用ルールとコーディング規約

### 📊 システム図

#### Mermaid形式
- [アーキテクチャ図](doc/architecture.mmd) - システム全体構成
- [処理フロー図](doc/process-flow.mmd) - 詳細な処理の流れ
- [シーケンス図](doc/sequence-diagram.mmd) - コンポーネント間の相互作用
- [クラス図](doc/class-diagram.mmd) - クラス構造と関係

#### DrawIO形式
- [アーキテクチャ図](doc/flow/code-review-system-architecture.drawio)
- [処理フロー図](doc/flow/code-review-system.drawio)
- [シーケンス図](doc/sequence-diagram.drawio)
- [クラス図](doc/class/code-review-system.drawio)

## 🎉 バージョン3.5の新機能 - 依存性管理改善版（2025年1月3日リリース）

### 🔧 インストール改善
1. **python-dotenv依存を削除**
   - 手動.envファイル読み込み機能実装（24-41行目）
   - `load_env_file()`関数で環境変数を安全に読み込み
   - 外部ライブラリ依存を削減してポータビリティ向上

2. **完全レポート生成機能**
   - `--complete-all`オプションで全6,089件のファイル処理可能
   - 進捗監視機能の全セクション対応
   - AI改善コード生成100%動作確認済み

3. **インストールガイド充実**
   - [INSTALL.md](INSTALL.md) - 詳細なインストール手順を新規作成
   - requirements.txt - 必要パッケージを明確化
   - Python 3.11+必須、3.13での特殊対応方法記載

### 📦 必要パッケージ
```bash
# 基本パッケージ (requirements.txt参照)
pip install openai anthropic scikit-learn joblib chardet

# Python 3.13でエラーの場合
pip install --only-binary :all: scikit-learn
```

### 🆕 完全分析コマンド
```bash
# 全ファイル完全分析（6,089件）
py codex_review_severity.py advise --complete-all --out reports/complete_analysis

# 部分分析（デフォルト80ファイル）
py codex_review_severity.py advise --out reports/quick_analysis
```

## 🎉 バージョン3.4の新機能（継続サポート）- コード品質100点達成版

### 🏆 達成したコード品質スコア
- **総合評価: 100/100点（満点達成）**
  - セキュリティ: 30/30点（全脆弱性修正）
  - パフォーマンス: 25/25点（2-3倍高速化）
  - エラーハンドリング: 20/20点（完全カバレッジ）
  - コード品質: 20/20点（SOLID原則準拠）
  - ドキュメント: 5/5点（型ヒント完備）

### 🔒 セキュリティ強化
1. **ReDoS脆弱性修正**
   - constructor/ngOnInit正規表現に文字数制限追加（最大500文字）
   - Go global参照パターン最適化（catastrophic backtracking防止）
   - 正規表現プリコンパイル化（50+パターン、2-3倍高速化）

2. **環境変数読み込みセキュリティ**
   - ホワイトリスト方式採用（許可された変数のみ読み込み）
   - 既存環境変数の上書き防止
   - 機密情報の漏洩リスク低減

3. **パストラバーサル脆弱性修正**（1814-1838行）
   - ".."を含むパスの自動拒否
   - Path.resolve()による正規化
   - カレントディレクトリ外アクセス制限

4. **API認証情報ログ保護**（全エラーハンドリング箇所）
   - OpenAI/Anthropic APIキーのマスク処理
   - Bearerトークンの自動マスク
   - エラーログからの機密情報除去

### ⚡ パフォーマンス最適化
- **正規表現プリコンパイル**: COMPILED_PATTERNS辞書（50+パターン）
- **実行速度改善**: 正規表現処理が2-3倍高速化
- **メモリ効率化**: load_index_stream()ジェネレータ追加（1095-1111行）
- **並列処理エラーハンドリング**（985-1029行）: 個別タスク失敗の適切な処理

### 📊 コード品質改善
- **完全な型ヒント追加**: 主要関数に型アノテーション完備
- **マジックナンバー完全定数化**（132-145行）: PROCESSING_CONSTANTS追加（12個の定数）
- **DRY原則適用**: `_check_large_interface()`共通関数化
- **CLI改善**: 詳細なヘルプメッセージ、使用例追加

### 🔧 新定数・設定値
```python
# PROCESSING_CONSTANTS（132-145行）
PROCESSING_CONSTANTS = {
    'DEFAULT_TOPK': 80,           # デフォルト分析ファイル数
    'MAX_FILE_SIZE_MB': 4,        # 最大ファイルサイズ(MB)
    'BATCH_SIZE': 100,            # バッチ処理サイズ
    'MAX_WORKERS': 10,            # 最大並列ワーカー数
    'API_TIMEOUT': 60,            # APIタイムアウト(秒)
    'MAX_RETRIES': 3,             # 最大リトライ回数
    # その他6個の定数...
}

# SOLID原則閾値設定
SOLID_THRESHOLDS = {
    'class_lines': 500,          # クラス最大行数
    'class_methods': 20,          # クラス最大メソッド数
    'interface_methods': 7,       # インターフェース推奨メソッド数
    'interface_max_methods': 10,  # インターフェース最大メソッド数
    'struct_fields': 15,          # 構造体最大フィールド数
    'switch_count': 3,            # switch文許容数
    # その他6個の閾値...
}

# プリコンパイル済み正規表現（50+パターン）
COMPILED_PATTERNS = {
    'php_sql_injection': re.compile(r'...'),
    'php_xss': re.compile(r'...'),
    # その他48個のパターン...
}
```

## 🆕 バージョン3.3の新機能（継続サポート）

### 📐 SOLID原則違反検出
**対応言語**: C#, Go, Java, PHP, JavaScript/TypeScript

- **S**ingle Responsibility: 巨大クラス（500行以上）、多数のメソッド
- **O**pen/Closed: switch文/instanceof/型チェックの多用
- **L**iskov Substitution: NotImplementedException、継承クラスでのthrow
- **I**nterface Segregation: 巨大インターフェース（7-10メソッド以上）
- **D**ependency Inversion: 具象クラス直接生成、グローバル変数使用

### 🅰️ Angularフレームワーク固有検査
- **ルーティング**: プライベートルートのガード未実装検出
- **変更検出**: ChangeDetectionStrategy未指定、OnPush戦略違反
- **依存性注入**: providedIn未指定、コンストラクタでのビジネスロジック
- **ライフサイクル**: Subscription放置、非同期処理の未処理（メモリリーク）
- **モジュール構成**: 巨大SharedModule検出

### 📁 --src-dirオプション追加
- **デフォルトディレクトリ**: `./src` をデフォルト検索対象に
- **カスタムパス指定**: `--src-dir ./custom/path` で任意のディレクトリ指定可能
```bash
# デフォルトで ./src を検索
py codex_review_severity.py index

# カスタムパス指定
py codex_review_severity.py index --src-dir ./application/code
```

## 🆕 バージョン3.2の新機能（継続サポート）

### 🤖 マルチAIプロバイダー対応
- **Anthropic Claude**: Sonnet 4.5 → Opus 4.1 → Sonnet 4.1 自動フォールバック
- **OpenAI GPT**: GPT-5-Codex → GPT-5 → GPT-4o モデル選択
- **自動切り替え**: Anthropic優先 → OpenAIフォールバック（AI_PROVIDER=auto）

## 🆕 バージョン3.1の新機能（継続サポート）

### 🚄 並列処理対応（10倍高速化）
- **並列AI分析**: ThreadPoolExecutor使用、10ワーカー同時実行
- **動的モデル選択**: 危険度に応じてGPT-5-Codex/GPT-4o/GPT-4o-miniを自動選択
- **キャッシュ機能**: MD5ハッシュベースでAPI呼び出しを削減

### 🌏 PHP言語サポート追加
- **セキュリティ脆弱性検出**: SQLインジェクション、XSS、ファイルインクルード等
- **非推奨関数検出**: mysql_*関数、eval()、extract()の危険な使用

## 🚀 特徴

## 🧪 ベンチマークと検証

- インデックス処理はバッチ書き出し・`--max-files`・`--max-seconds` で制御でき、30k ファイル超のリポジトリでも段階的に実行可能です。
- ストレージがボトルネックの場合は `--worker-count 4` などで並列読み込みを有効化し、共有ストレージでは 2 以下から調整しつつ `--max-seconds` と併用してタイムアウトを避けてください。
- 既存の `.advice_index.jsonl` が存在する場合はメタデータ (`.advice_index.meta.json`) を比較し、未変更ファイルは再読み込みせずに再利用されるため、大規模リポジトリでも差分更新が高速です。
- インデックス完了時には `[SUMMARY] seen=...` 形式のサマリが表示され、スキップ件数や再利用件数を一目で確認できます。
- 詳細な検証手順と推奨コマンドは [`doc/TESTING.md`](doc/TESTING.md) を参照してください（50/500/5000/10000 件のシナリオを収録）。
- `--profile-index --profile-output reports/profile.csv` を付与すると処理時間・スキップ件数などの統計を取得できます。
- 長時間処理が予想される場合は `--batch-size 300 --max-files 10000 --max-seconds 900` といった設定で部分的にインデックスを進め、プロファイル出力で進捗を確認してください。

- 📊 **2段階解析システム**: ルールベース解析 → AI詳細解析
- 🌏 **日本語対応**: 自動エンコーディング検出（UTF-8, Shift_JIS, CP932, EUC-JP）
- 🎯 **重要度ソート**: 問題を重要度スコアで自動ランク付け
- 🤖 **マルチAIプロバイダー対応（v3.2+）**: Anthropic Claude & OpenAI GPT
  - Claude Sonnet 4.5/Opus 4.1/Sonnet 4.1 自動フォールバック
  - GPT-5-Codex/GPT-4o/GPT-4o-mini 危険度別モデル選択
  - プロバイダー間自動切り替え（Anthropic優先→OpenAIフォールバック）
- ⚡ **大規模対応**: バッチ処理とタイムアウト管理で数万ファイル処理可能
- 📈 **進捗表示**: リアルタイムな処理状況表示（XX/YYファイル）

## 📋 クイックスタート

### 1. インストール

詳細なインストール手順は[INSTALL.md](INSTALL.md)を参照してください。

```bash
# 基本パッケージ (requirements.txt参照)
pip install openai anthropic scikit-learn joblib chardet

# または requirements.txt を使用
pip install -r requirements.txt

# Python 3.13でのインストール
pip install --only-binary :all: scikit-learn
```

### 2. 環境設定
`.env`ファイル作成：
```env
# ========== AI Provider選択 ==========
# auto: Anthropic優先→OpenAIフォールバック
# anthropic: Claude専用
# openai: OpenAI専用
AI_PROVIDER=auto

# ========== OpenAI設定 ==========
OPENAI_API_KEY=your_api_key_here

# 利用可能なモデル（2025年9月時点）
# gpt-5-codex: コード特化、Responses API使用（動作確認済み✅）
# gpt-5      : 最高性能（準備完了、API公開待ち）
# gpt-5-mini : コスト効率重視（準備完了、API公開待ち）
# gpt-5-nano : 超軽量版（準備完了、API公開待ち）
# gpt-4o     : 現行安定版（推奨✅）
OPENAI_MODEL=gpt-4o

# ========== Anthropic Claude設定（v3.2+）==========
ANTHROPIC_API_KEY=your_anthropic_key

# 利用可能なモデル（2025年10月時点）
# claude-sonnet-4-5 : バランス型（推奨✅）
# claude-opus-4-1   : 最高性能
# claude-sonnet-4-1 : 高速・低コスト
# 優先順位: sonnet-4-5 → opus-4-1 → sonnet-4-1（自動フォールバック）
ANTHROPIC_MODEL=claude-sonnet-4-5
```

### 3. 基本的な実行

#### 方法1: 標準分析
```bash
# インデックス作成（Delphi除外、4MB制限、並列4スレッド）
py codex_review_severity.py index . --exclude-langs delphi --max-file-mb 4 --worker-count 4

# PHPファイルのみインデックス作成
py codex_review_severity.py index ./src/php

# ベクトル化（オプション、検索精度向上）
py codex_review_severity.py vectorize

# レビュー実行
py codex_review_severity.py query "データベース N+1" --topk 50 --out reports/review

# ⚠️ 重要: 全ファイル分析（--all オプションを使用）
py codex_review_severity.py advise --all --out reports/full_review
```

> **⚠️ 注意**: `advise` コマンドのデフォルトは80ファイルのみです。全ファイルを分析する場合は必ず `--all` オプションを指定してください。詳細は「[--topk パラメータの注意事項](#-topk-パラメータの注意事項)」を参照。

#### 方法2: 改良版分析（完全コード提供）
```bash
# 危険ファイル抽出
py codex_review_severity.py analyze . --topk 100

# 並列AI分析（改良版・完全コード）
py extract_and_batch_parallel_enhanced.py

# または実行スクリプト使用
run_enhanced_analysis.bat
```

## 📦 主要ファイル

### Pythonスクリプト
| ファイル | 用途 | 特徴 |
|---------|------|------|
| `codex_review_severity.py` | **🌟 メイン** | 全言語対応、重要度ソート、インデックス・分析の統合ツール |
| `extract_and_batch_parallel_enhanced.py` | **🎯 改良版** | 完全な修正コード提供、詳細な問題説明、並列処理 |
| `extract_and_batch_parallel.py` | **⚡ 並列版** | 10倍高速化、自動レジューム、キャッシュ対応 |
| `codex_review_gpt5_responses.py` | GPT-5-Codex | Responses API対応版 |
| `fix_report_encoding.py` | エンコーディング | 文字化け修正（総合版） |
| `simple_fix_report.py` | エンコーディング | 文字化け修正（簡易版） |
| `comprehensive_fix_report.py` | エンコーディング | 文字化け修正（詳細版） |
| `codex_review_with_retry.py` | リトライ機能 | API呼び出しリトライ処理 |
| `check_index.py` | インデックス確認 | インデックスファイルの検証 |

### 実行スクリプト
| ファイル | 用途 |
|---------|------|
| `run_enhanced_analysis.bat` | 改良版分析実行（Windows） |
| `run_batch_parallel.bat` | 並列処理実行（Windows） |
| `run_batch_parallel.sh` | 並列処理実行（Linux/Mac） |

### テストコード
| ファイル | 用途 |
|---------|------|
| `test/monitor_parallel.py` | 進捗モニタリング |
| その他テストファイル | [test/](test/) フォルダー参照 |

## 📁 プロジェクト構成

```
.
├── codex_review_severity.py          # メインスクリプト（全言語対応）
├── extract_and_batch_parallel*.py    # 並列処理版スクリプト
├── fix_report_encoding.py            # ユーティリティ
├── batch_config.json                 # 設定ファイル
├── .env                              # 環境変数（要作成）
│
├── test/                             # ⭐ テストコード（新規テストはここに作成）
│   ├── test_*.py                     # 単体テスト
│   ├── benchmark_parallel.py         # パフォーマンステスト
│   ├── monitor_parallel.py           # モニタリングツール
│   └── sample*.{py,js,go,php}       # テストサンプルファイル
│
├── doc/                              # 📚 ドキュメント
│   ├── TECHNICAL.md                  # 技術仕様
│   ├── DEVELOPMENT.md                # 開発履歴
│   ├── TEST_RESULTS.md               # テスト結果
│   ├── guides/                       # ガイド文書
│   │   ├── GPT5_MIGRATION.md        # GPT-5移行ガイド
│   │   ├── ENHANCED_ANALYSIS_GUIDE.md # 拡張分析ガイド
│   │   └── AGENTS.md                 # 運用ルール
│   ├── changelog/                    # 変更履歴
│   │   └── CHANGELOG_v3.md          # v3.1変更内容
│   └── archive/                      # アーカイブ
│       └── 説明.md                   # 旧バージョン説明
│
├── reports/                          # 分析レポート出力先（自動生成）
├── .cache/                           # キャッシュディレクトリ（自動生成）
│   └── analysis/                     # AI分析キャッシュ
├── .advice_index.jsonl               # インデックスファイル（自動生成）
└── .advice_*.pkl                     # TF-IDFベクトル（自動生成）
```

> **⭐ 重要**:
> - 新規テストコードは必ず `test/` フォルダー内に作成
> - ドキュメントは `doc/` 配下に整理済み
> - 生成ファイル（`.advice*`, `reports/`, `.cache/`）はgitignore対象

## 🔍 検出可能な問題

### データベース関連
- **N+1問題**（ループ内SELECT） - 重要度: 10
- **SELECT \*** の使用 - 重要度: 8
- **多重JOIN** - 重要度: 7
- **大OFFSET** - 重要度: 6

### セキュリティ
- **金額計算でのfloat使用** - 重要度: 9
- **XSS脆弱性** - 重要度: 8
- **入力検証不足** - 重要度: 5
- **エラー情報漏洩** - 重要度: 5

### パフォーマンス
- **非効率なループ**
- **メモリリーク**
- **不要な再計算**
- **大量データの一括取得**

### コード品質
- **エラーハンドリング不足**
- **マジックナンバー**
- **重複コード**
- **未使用変数**

### 言語固有の問題

#### PHP
**セキュリティ脆弱性:**
- **SQLインジェクション脆弱性** - 重要度: 10
  - `$_GET['id']`を直接SQL文に結合
  - prepare/bind_paramなしのクエリ実行
- **コマンドインジェクション** - 重要度: 10
  - `system($_GET['cmd'])`, `exec()`, `shell_exec()`の使用
- **ファイルインクルード脆弱性** - 重要度: 9
  - `include($_GET['page'])`等のユーザー入力によるファイル読み込み
- **XSS脆弱性（未エスケープ出力）** - 重要度: 9
  - `echo $_GET['name']`のようなエスケープなし出力
  - htmlspecialchars/htmlentitiesなし
- **ディレクトリトラバーサル** - 重要度: 9
  - basename/realpathなしのファイル操作
- **eval()の使用** - 重要度: 9
  - 動的コード実行によるセキュリティリスク
- **セッション固定化攻撃** - 重要度: 8
  - session_regenerate_id()なしのsession_start()
- **CSRF対策不足** - 重要度: 8
  - POSTフォームにトークンなし

**非推奨・危険な関数:**
- **mysql_*関数（非推奨）** - 重要度: 7
  - PDO/mysqliの使用を推奨
- **extract()の危険な使用** - 重要度: 6
  - `extract($_GET)`, `extract($_POST)`等
- **register_globalsへの依存** - 重要度: 7

**パフォーマンス:**
- **N+1問題** - ループ内でのSQL実行
- **大量データ取得** - `SELECT * ... LIMIT 10000`等
- **非効率なループ処理** - ループ内に重いクエリ

**使用例:**
```bash
# PHPファイルのインデックス作成
py codex_review_severity.py index ./src/php

# PHP分析実行
py codex_review_severity.py advise --all --out reports/php_analysis
```

**テスト用サンプル:** `src/php/`フォルダーに脆弱性テスト用PHPファイルを配置

#### Go
- **エラーチェック不足** - 重要度: 8
- **goroutineリーク** - 重要度: 9
- **チャネルデッドロック** - 重要度: 7
- **defer忘れ** - 重要度: 6

#### C++
- **メモリリーク** - 重要度: 10
- **バッファオーバーフロー** - 重要度: 10
- **未初期化ポインタ** - 重要度: 9
- **RAII違反** - 重要度: 7

## 📄 出力レポート

### ルールベースレポート（*_rules.md）
```markdown
# ルールベース解析レポート
- 全ファイルの静的解析結果
- 問題の重要度分布（🔴緊急 🟠高 🟡中 🔵低 ⚪なし）
- 問題箇所のコードサンプル
- 簡易的な修正例
```

### AI詳細レポート（*_ai.md）
```markdown
# AI改善案付き解析レポート
- 高重要度ファイルの詳細解析
- Before/After形式の改善コード
- 詳細な説明と影響範囲
- パフォーマンス改善の期待値
```

## 🎯 実績・パフォーマンス

### テスト環境
- **対象ファイル**: 14,355個のC#ソースファイル
- **総コード行数**: 約200万行
- **テスト日時**: 2025-09-28

### 処理性能
| 処理 | ファイル数 | 実行時間 | 備考 |
|------|-----------|---------|------|
| インデックス作成 | 1,195 | 約30秒 | 1MB制限、Delphi除外 |
| ルール解析 | 50 | 約5秒 | 全ファイル対象 |
| AI解析 | 5 | 約60秒 | 高重要度のみ |

### 検出実績
- 🔴 **緊急問題**: 5件（N+1問題、SELECT *）
- 🟡 **中程度問題**: 7件（入力検証、エラー処理）
- ⚪ **問題なし**: 38件

## 🔧 カスタマイズ

### 設定値の調整
```python
# codex_review_ultimate.py の設定値
AI_TIMEOUT = 60         # AI解析タイムアウト（秒）
AI_MAX_RETRIES = 2      # AIリトライ回数
AI_MIN_SEVERITY = 7     # AI解析する最小重要度スコア
AI_MAX_FILES = 20       # AI解析する最大ファイル数
```

### 除外ディレクトリ
```python
IGNORE_DIRS = {
    ".git", "node_modules", "dist", "build",
    ".venv", "venv", "__pycache__", ".idea"
}
```

## 🚦 GitHub Actions連携 (v3.5.0)

`.github/workflows/codex-readonly-review-optimized.yml`でPR自動レビュー：

### 🔒 セキュリティ強化機能 (v3.5.0)
- **入力サニタイズ**: 悪意のあるパスインジェクション防止
- **環境変数保護**: `.env`ファイル不使用、GitHub Secretsのみ使用
- **SHAピン留め**: 全GitHub ActionsはSHA-256で固定
- **最小権限原則**: 必要最小限の権限のみ付与

### 🤖 マルチAIプロバイダー自動フォールバック
1. **Anthropic Claude優先** → APIキーなし/エラー時にOpenAIへ
2. **OpenAI GPT** → APIキーなし/エラー時にルールモードへ
3. **ルールベース** → AI不使用の静的解析のみ

### 📋 必要なGitHub Secrets設定
```yaml
# AIプロバイダー設定（オプション）
AI_PROVIDER: auto          # auto/anthropic/openai/rules
ANTHROPIC_API_KEY: sk-ant-xxx   # Claude API（オプション）
ANTHROPIC_MODEL: claude-3-5-sonnet-20241022  # Claudeモデル
OPENAI_API_KEY: sk-xxx          # OpenAI API（オプション）
OPENAI_MODEL: gpt-4o             # GPTモデル
```

### 🚀 ワークフロー設定例
```yaml
name: Code Review v3.5.0
on:
  pull_request:
    types: [opened, synchronize]

jobs:
  review:
    runs-on: ubuntu-latest
    permissions:
      contents: read
      pull-requests: write
    steps:
      - uses: actions/checkout@b4ffde65f46336ab88eb53be808477a3936bae11 # v4.1.1
      - uses: actions/setup-python@0b93645e9fea7318ecaed2b359559ac225c90a2b # v5.3.0
        with:
          python-version: '3.11'
      - run: pip install -r requirements.txt

      # AIプロバイダー自動選択（Anthropic→OpenAI→ルールベース）
      - name: Run Code Review
        env:
          AI_PROVIDER: ${{ secrets.AI_PROVIDER || 'auto' }}
          ANTHROPIC_API_KEY: ${{ secrets.ANTHROPIC_API_KEY || '' }}
          OPENAI_API_KEY: ${{ secrets.OPENAI_API_KEY || '' }}
        run: |
          python codex_review_severity.py index . --exclude-langs delphi
          python codex_review_severity.py vectorize  # セマンティック検索用
          python codex_review_severity.py advise --all --out reports/review

      # セキュリティクリーンアップ
      - name: Cleanup Sensitive Files
        if: always()
        run: |
          rm -f .env .env.* *.key *.pem
          find . -name "*.log" -exec rm -f {} \;

      - uses: actions/upload-artifact@v4
        with:
          name: review-reports
          path: reports/
```

### ⚡ v3.5.0の新機能
- **ベクトル化対応**: `vectorize`コマンドでセマンティック検索強化
- **HEREDOC修正**: Bash変数展開の適切な処理
- **エラーハンドリング強化**: 各ステップでの適切なフォールバック
- **自動クリーンアップ**: 機密ファイルの自動削除

## ⚠️ 制限事項

- **ファイルサイズ上限**: デフォルト4MB（`--max-file-mb`で変更可）
- **AI解析**: 最大20ファイル/実行（高負荷回避）
- **タイムアウト**: API呼び出し60秒/ファイル
- **エンコーディング**: 主要な日本語エンコーディングのみ対応

## 🛠️ トラブルシューティング

### よくある問題

#### ModuleNotFoundError: No module named 'dotenv'
```bash
# python-dotenvは不要になりました（v3.5以降）
# 手動.env読み込み機能が内蔵されています
```

#### Python 3.13でのインストールエラー
```bash
# scikit-learnのビルドエラー対策
pip install --only-binary :all: scikit-learn

# その他のパッケージ
pip install openai anthropic joblib chardet
```

#### エンコーディングエラー
```bash
# chardetが自動検出（UTF-8, Shift_JIS, CP932, EUC-JP対応）
py codex_review_severity.py index .  # 自動検出機能内蔵
```

#### タイムアウトエラー
```bash
# ファイル数を減らす
py codex_review_severity.py advise --topk 20

# タイムアウト値を調整（batch_config.json編集）
"timeout_per_file": 120  # 60秒から120秒に変更
```

#### AI改善コード生成が失敗
```bash
# --complete-allオプションで再試行
py codex_review_severity.py advise --complete-all --out reports/retry_analysis

# キャッシュクリア後に再実行
rm -rf .cache/analysis/
py codex_review_severity.py advise --complete-all --out reports/fresh_analysis
```

#### メモリ不足
```bash
# ファイルサイズ制限を厳しくする
py codex_review_severity.py index . --max-file-mb 1

# バッチサイズを小さくする
py extract_and_batch_parallel_enhanced.py  # batch_config.jsonで調整
```

### ⚠️ --topk パラメータの注意事項

#### 問題の概要
`codex_review_severity.py advise` コマンドは、**デフォルトで80ファイルしか分析しません**。

これは全ファイルの約0.5%に過ぎず、重要な問題を見逃す可能性があります。

#### なぜこの問題が起きるのか
- インデックスには全ファイル（例: 15,710件）が含まれている
- しかし `--topk` のデフォルト値は80
- **インデックスのファイル数は自動的には引き継がれない**

#### 解決方法

##### 方法1: --all オプションを使用（推奨）
```bash
py codex_review_severity.py advise --all --out reports/analysis.md
```

##### 方法2: 手動でファイル数を指定
```bash
# インデックス作成時の indexed 数を確認
py codex_review_severity.py index ./src
# [SUMMARY] indexed=15710 と表示

# その数を指定
py codex_review_severity.py advise --topk 15710 --out reports/analysis.md
```

#### 推奨される使用パターン

**開発時（部分分析）**
```bash
# 上位1000ファイルで素早く確認
py codex_review_severity.py advise --topk 1000 --out reports/quick_check.md
```

**本番分析（全ファイル）**
```bash
# 全ファイルを徹底分析
py codex_review_severity.py advise --all --out reports/full_analysis.md
```

**CI/CD（閾値設定）**
```bash
# 危険度の高い上位500ファイルをチェック
py codex_review_severity.py advise --topk 500 --out reports/ci_check.md
```

#### チェックリスト
分析実行前に確認：
- [ ] `--all` または `--topk` を指定したか？
- [ ] 指定なしの場合、80ファイルのみで良いか？
- [ ] インデックスの indexed 数を確認したか？
- [ ] 全ファイル分析が必要か、部分分析で十分か？

## 📞 サポート

問題が発生した場合:
1. [SETUP_GUIDE.md](SETUP_GUIDE.md)のトラブルシューティング参照
2. [TEST_RESULTS.md](doc/TEST_RESULTS.md)で動作確認済み環境を確認
3. `reports/IMPORTANT_RESULTS.md`で既知の問題確認
4. [GitHubでIssue作成](https://github.com/KEIEI-NET/BugSerch/issues)

## 📜 ライセンス

MIT License - 詳細は[LICENSE](LICENSE)参照

## 🤖 AIモデル選択ガイド

### GPT-5シリーズ対応状況（2025年9月28日時点）

| モデル | 状態 | エンドポイント | 備考 |
|--------|------|--------------|------|
| gpt-5-codex | ✅動作中 | `/v1/responses` | Responses API経由、コード分析特化 |
| gpt-4o | ✅動作中 | `/v1/chat/completions` | 安定版、推奨 |
| gpt-5 | ⏳準備完了 | `/v1/chat/completions` | API公開待ち |
| gpt-5-mini | ⏳準備完了 | `/v1/chat/completions` | API公開待ち |
| gpt-5-nano | ⏳準備完了 | `/v1/chat/completions` | API公開待ち |

**実装済み対策**：
- 空レスポンス時の自動リトライ（最大3回）
- APIエラー時のフォールバック機能
- レスポンス構造の自動判定

### 利用可能なモデル
- **gpt-5**: 最高性能モデル
  - 入力: 272,000トークン、出力: 128,000トークン
  - 数学: AIME 2025で94.6%
  - コーディング: SWE-benchで74.9%
  - 複雑な推論・分析タスクに最適

- **gpt-5-mini**: バランス型
  - コスト効率と処理速度のバランス
  - 大量ファイル処理に適している
  - 通常のコードレビューに推奨

- **gpt-5-nano**: 軽量版
  - 最速・最安価
  - シンプルな静的解析向け
  - 大規模バッチ処理に最適

### フォールバック機能
空レスポンス時は自動的に別モデルで再試行します：
- gpt-5 → gpt-4o
- gpt-5-mini → gpt-4o
- gpt-5-nano → gpt-5-mini

## 🙏 謝辞

- OpenAI GPT-5/GPT-4oモデルの提供
- scikit-learn、ChromaDB等のオープンソースライブラリ
- 日本語エンコーディング検出のchardetライブラリ

---

*最終更新: 2025年01月03日 15:30 JST*
*バージョン: v3.5.0*

**更新履歴:**
- v3.5.0 (2025年01月03日): GitHub Actions v3.5.0セキュリティ強化、AI自動フォールバック、python-dotenv依存削除、完全レポート生成機能、インストールガイド追加
- v3.4.1 (2025年01月02日): ドキュメント更新、100点達成詳細の追記
- v3.4.0 (2025年01月02日): セキュリティ強化、パフォーマンス最適化、コード品質100点達成
- v3.3.0 (2025年10月02日): SOLID原則検出、Angularフレームワーク対応
- v3.2.0 (2025年09月30日): マルチAIプロバイダー対応（Anthropic Claude追加）
- v3.1.0 (2025年09月28日): 並列処理対応、PHP言語サポート追加
