# Codex Review - AI Code Review System

静的コード解析とAI分析を組み合わせた高度なコードレビューシステムです。

## 📚 ドキュメント

- [セットアップガイド](SETUP_GUIDE.md) - インストールと基本的な使い方
- [技術文書](doc/TECHNICAL.md) - 詳細な技術仕様とアーキテクチャ
- [開発履歴](doc/DEVELOPMENT.md) - バージョン履歴と改善内容

### 📊 システム図

- [アーキテクチャ図](doc/architecture.mmd) - システム全体構成
- [処理フロー図](doc/process-flow.mmd) - 詳細な処理の流れ
- [シーケンス図](doc/sequence-diagram.mmd) - コンポーネント間の相互作用
- [クラス図](doc/class-diagram.mmd) - クラス構造と関係

## 特徴

- 📊 **2段階解析システム**: ルールベース解析 → AI詳細解析
- 🌏 **日本語対応**: 自動エンコーディング検出（UTF-8, Shift_JIS, CP932, EUC-JP）
- 🎯 **重要度ソート**: 問題を重要度スコアで自動ランク付け
- 🤖 **AI改善提案**: OpenAI GPT-4oによる具体的な修正コード生成
- ⚡ **大規模対応**: バッチ処理とタイムアウト管理で数万ファイル処理可能

## クイックスタート

### 1. インストール
```bash
pip install chromadb openai scikit-learn joblib regex chardet
```

### 2. 環境設定
`.env`ファイル作成：
```
OPENAI_API_KEY=your_api_key_here
OPENAI_MODEL=gpt-4o
```

### 3. 実行
```bash
# インデックス作成（Delphi除外、4MB制限）
py codex_review_ultimate.py index . --exclude-langs delphi --max-file-mb 4

# レビュー実行
py codex_review_ultimate.py query "データベース" --topk 50 --out reports/review
```

## 利用可能なバージョン

| ファイル | 用途 | 特徴 |
|---------|------|------|
| `codex_review_ultimate.py` | **推奨** | 2段階解析、エンコード自動検出、タイムアウト対策 |
| `codex_review_enhanced.py` | エンコード特化 | 日本語ファイルの文字化け対策 |
| `codex_review_severity.py` | 重要度ソート | 問題の優先順位付け |
| `codex_review_with_solutions.py` | AI改善案 | 具体的な修正コード提案 |
| `codex_review_optimized.py` | 大規模処理 | 数万ファイル対応 |
| `codex_review.py` | 基本版 | 軽量・シンプル |

## 検出可能な問題

### データベース関連
- N+1問題（ループ内SELECT）
- SELECT * の使用
- インデックス未使用
- トランザクション未使用

### セキュリティ
- XSS脆弱性
- SQLインジェクション
- 入力検証不足
- エラー情報漏洩

### パフォーマンス
- 非効率なループ
- メモリリーク
- 不要な再計算
- 大量データの一括取得

### コード品質
- 金額計算でのfloat使用
- エラーハンドリング不足
- マジックナンバー
- 重複コード

## 出力レポート

### ルールベースレポート（*_rules.md）
- 全ファイルの静的解析結果
- 問題箇所のコードサンプル
- 簡易的な修正例

### AI詳細レポート（*_ai.md）
- 高重要度ファイルの詳細解析
- Before/After形式の改善コード
- 詳細な説明と影響範囲

## GitHub Actions連携

`.github/workflows/codex-readonly-review.yml`でPR自動レビュー：
1. ソースチェックアウト
2. 依存ライブラリセットアップ
3. インデックス作成・解析実行
4. レポートをアーティファクト化
5. PRにコメント投稿

## 前提条件

- Python 3.11以上
- OpenAI APIキー
- 十分なディスク容量（インデックス用）

## 制限事項

- ファイルサイズ上限: デフォルト4MB（変更可）
- AI解析: 最大20ファイル/実行（高負荷回避）
- タイムアウト: API呼び出し60秒/ファイル

## サポート

問題が発生した場合:
1. [SETUP_GUIDE.md](SETUP_GUIDE.md)のトラブルシューティング参照
2. `reports/IMPORTANT_RESULTS.md`で既知の問題確認
3. GitHubでIssue作成

## ライセンス

MIT License - 詳細は[LICENSE](LICENSE)参照