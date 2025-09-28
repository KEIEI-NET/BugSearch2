# Codex Review - AI Code Review System v2.1

静的コード解析とAI分析を組み合わせた高度なコードレビューシステムです。

**最終更新: 2025年9月28日**
**バージョン: 3.0.0** - GPT-5/GPT-5-Codex完全対応版

## 📚 ドキュメント

- [セットアップガイド](SETUP_GUIDE.md) - インストールと基本的な使い方
- [技術文書](doc/TECHNICAL.md) - 詳細な技術仕様とアーキテクチャ
- [CI 運用ガイド](doc/CI_GUIDE.md) - GitHub Actions を中心としたジョブ構成とパラメータ例
- [開発履歴](doc/DEVELOPMENT.md) - バージョン履歴と改善内容
- [テスト結果](doc/TEST_RESULTS.md) - 実行テストとパフォーマンス結果

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

## 🆕 バージョン3.0の新機能

### GPT-5シリーズ完全対応
- **GPT-5-Codex**: Responses API (`/v1/responses`) 経由でコード特化分析
- **GPT-5/GPT-5-mini/GPT-5-nano**: Chat Completions API対応準備完了
- **自動フォールバック**: API障害時のgpt-4oへの自動切り替え
- **空レスポンス対策**: 3段階リトライとパラメータ自動調整

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
- 🤖 **AI改善提案**: OpenAI GPT-4oによる具体的な修正コード生成
- ⚡ **大規模対応**: バッチ処理とタイムアウト管理で数万ファイル処理可能
- 📈 **進捗表示**: リアルタイムな処理状況表示（XX/YYファイル）

## 📋 クイックスタート

### 1. インストール
```bash
pip install chromadb openai scikit-learn joblib regex chardet
```

### 2. 環境設定
`.env`ファイル作成：
```env
OPENAI_API_KEY=your_api_key_here

# 利用可能なモデル（2025年9月時点）
# gpt-5-codex: コード特化、Responses API使用（動作確認済み✅）
# gpt-5      : 最高性能（準備完了、API公開待ち）
# gpt-5-mini : コスト効率重視（準備完了、API公開待ち）
# gpt-5-nano : 超軽量版（準備完了、API公開待ち）
# gpt-4o     : 現行安定版（推奨✅）
OPENAI_MODEL=gpt-4o
```

### 3. 基本的な実行
```bash
# インデックス作成（Delphi除外、4MB制限、並列4スレッド）
py codex_review_ultimate.py index . --exclude-langs delphi --max-file-mb 4 --worker-count 4

# ベクトル化（オプション、検索精度向上）
py codex_review_ultimate.py vectorize

# レビュー実行
py codex_review_ultimate.py query "データベース N+1" --topk 50 --out reports/review

# 全体的な助言
py codex_review_ultimate.py advise --topk 100 --out reports/full_review
```

## 📦 利用可能なバージョン

| ファイル | 用途 | 特徴 |
|---------|------|------|
| `codex_review_ultimate.py` | **🌟 推奨** | 2段階解析、エンコード自動検出、タイムアウト対策、進捗表示 |
| `codex_review_enhanced.py` | エンコード特化 | 日本語ファイルの文字化け対策 |
| `codex_review_severity.py` | 重要度ソート | 問題の優先順位付け |
| `codex_review_with_solutions.py` | AI改善案 | 具体的な修正コード提案 |
| `codex_review_optimized.py` | 大規模処理 | 数万ファイル対応 |
| `codex_review.py` | 基本版 | 軽量・シンプル |

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

## 🚦 GitHub Actions連携

`.github/workflows/codex-readonly-review.yml`でPR自動レビュー：

```yaml
name: Code Review
on:
  pull_request:
    types: [opened, synchronize]

jobs:
  review:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      - uses: actions/setup-python@v4
      - run: pip install -r requirements.txt
      - run: python codex_review_ultimate.py index .
      - run: python codex_review_ultimate.py advise --topk 50
      - uses: actions/upload-artifact@v3
```

## ⚠️ 制限事項

- **ファイルサイズ上限**: デフォルト4MB（`--max-file-mb`で変更可）
- **AI解析**: 最大20ファイル/実行（高負荷回避）
- **タイムアウト**: API呼び出し60秒/ファイル
- **エンコーディング**: 主要な日本語エンコーディングのみ対応

## 🛠️ トラブルシューティング

### よくある問題

#### エンコーディングエラー
```bash
# UTF-8以外のファイルがある場合
py codex_review_enhanced.py  # または ultimate.py（自動検出機能あり）
```

#### タイムアウトエラー
```bash
# ファイル数を減らす
py codex_review_ultimate.py query "keyword" --topk 20

# タイムアウト値を調整（ソースコード編集必要）
AI_TIMEOUT = 120  # 60秒から120秒に変更
```

#### メモリ不足
```bash
# ファイルサイズ制限を厳しくする
py codex_review_ultimate.py index . --max-file-mb 1
```

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
最終更新: 2025-09-28 18:35:00 | バージョン: 3.0.0 (GPT-5 Complete Edition)
