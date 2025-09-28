# Readonly Review ツール（最適化版）

このリポジトリは、Pull Request 向けの読取専用コードレビュー支援ツールです。`codex_review_optimized.py` でルールベースと GPT-5 を組み合わせたアドバイスを生成し、GitHub Actions から自動でレポートを出力・コメント投稿できます。

## 🚀 最適化版の新機能
- **全件処理対応**: 検索結果のすべてのファイルをAIレビュー
- **バッチ処理**: 10ファイルずつのバッチでGPT-5を効率的に利用
- **タイムアウト延長**: 240秒のタイムアウトで大規模プロジェクトに対応
- **詳細レポート**: 全検出ファイルの詳細な指摘事項を出力

## 特徴
- 金額・印刷・UI/UX・DB負荷に焦点を当てた静的チェック
- OpenAI GPT-5 を使った要約アドバイス（ハイブリッド/AIモード）
- リポジトリ全体をインデックス化し、自然言語で関連コードを探索
- GitHub Actions (codex-readonly-review.yml) による PR 自動レビュー

## アーキテクチャ

### フロー図
`doc/flow/codex_review_optimized_flow.drawio` - プログラム全体の処理フローを可視化
- 4つの主要コマンド（index, vectorize, query, advise）の処理フロー
- ルールエンジンとGPT-5バッチ処理の統合
- ファイルサイズ制限とエラーハンドリング

### シーケンス図
`doc/flow/codex_review_query_sequence.drawio` - QUERYコマンドの詳細な処理シーケンス
- ユーザー、CLI、インデックス、検索、ルールエンジン、GPT-5 API間の相互作用
- バッチ処理による全ファイル処理の流れ
- 240秒タイムアウトの適用箇所

## サンプルソース配置
- ルール検証用のサンプルコードは `src/<language>/` 配下に置いてください。
- 既定で `csharp`、`java`、`typescript`、`javascript`、`delphi`、`python` のディレクトリを用意しています。
- サンプルはローカル検証用途に留め、公開不要なファイルは `.gitignore` で除外するか手動で管理から外してください。

## 前提条件
- Python 3.11 以上
- pip install chromadb openai scikit-learn joblib regex
  - scikit-learn が無い場合、TF-IDF ベクトル化はスキップされます（素朴検索で継続）
- ルート直下に配置した `.env` から環境変数を読み込みます。`OPENAI_API_KEY`, `OPENAI_MODEL` などを `.env.example` を参考に設定してください。

## 使い方

### 1. リポジトリのインデックス構築
```bash
python codex_review_optimized.py index /path/to/repo
```
- `.advice_index.jsonl` を生成し、可能であれば TF-IDF ベクトル (`.advice_tfidf.pkl`, `.advice_matrix.pkl`) を作成します。

### 2. オプション: ベクトル再構築
```bash
python codex_review_optimized.py vectorize --index .advice_index.jsonl
```
- インデックスの内容から再度 TF-IDF モデルを構築します。

### 3. 自然言語で検索・アドバイス取得（全件処理）
```bash
python codex_review_optimized.py query "印刷が途中で止まる" --mode hybrid --topk 30 --out reports/print.md
```
- 指定クエリに関連するコード片を検索し、ルール検知と GPT-5 のコメントをレポート化します。
- **--mode** は rules, ai, hybrid から選択できます。
- **全30ファイル**を3バッチに分けてGPT-5でレビュー（最適化版の新機能）

### 4. 横断チェックの自動助言（全件処理）
```bash
python codex_review_optimized.py advise --mode hybrid --topk 80 --out reports/advise.md
```
- 金額/印刷/UI/DB に関連する兆候が強いファイルを横断的に抽出し、重点指摘をまとめます。
- **全80ファイル**を8バッチに分けてGPT-5でレビュー（最適化版の新機能）

## パフォーマンス最適化

### バッチ処理設定
- **BATCH_SIZE**: 10ファイル/バッチ（調整可能）
- **MAX_PROMPT_SIZE**: 10,000文字/プロンプト
- **AI_TIMEOUT**: 240秒/APIコール

### 処理時間の目安
- 30ファイル: 約1-2分（3バッチ）
- 80ファイル: 約2-4分（8バッチ）
- 200ファイル: 約5-10分（20バッチ）

## GitHub Actions 連携
`.github/workflows/codex-readonly-review.yml` に本リポジトリの codex-readonly-review.yml を配置すると、PR オープン・同期時に以下を実行します。

1. ソースをチェックアウト
2. Python 3.11 と依存ライブラリをセットアップ
3. `python codex_review_optimized.py index .` でリポジトリを読取専用でスキャン
4. `python codex_review_optimized.py advise --mode hybrid --topk 80 --out reports/advise.md` で助言レポート生成
5. レポートをアーティファクト化 (readonly-advice)
6. PR に結果サマリをコメント投稿

GitHub Actions から GPT-5 を利用する場合、リポジトリシークレットに **OPENAI_API_KEY** を設定してください。

## 生成物
- `.advice_index.jsonl`: インデックス化されたソース情報
- `.advice_tfidf.pkl`, `.advice_matrix.pkl`: TF-IDF モデル（scikit-learn 利用時）
- `reports/*.md`: ルール/GPT の助言レポート
- `reports/large_files_over_limit.log`: 3MB超のファイル一覧
- `doc/flow/*.drawio`: フロー図・シーケンス図

## 注意事項
- ツールはソースを読み取り、指摘のみを出力します。自動修正は行いません。
- 大きすぎるファイル（既定で 3MB 超）はインデックス対象外で、`reports/large_files_over_limit.log` に一覧を出力します。
- OPENAI_API_KEY が未設定の場合、AI モードは "AI未有効" のメッセージを返します。
- GPT-5 APIのレート制限に注意してください（大規模プロジェクトの場合）

## トラブルシューティング

### タイムアウトエラーが発生する場合
- `AI_TIMEOUT`を増やす（例: 300秒）
- `BATCH_SIZE`を減らす（例: 5ファイル）
- `--topk`の値を減らして処理ファイル数を削減

### メモリ不足エラーが発生する場合
- `MAX_PROMPT_SIZE`を減らす（例: 5000文字）
- インデックスを分割して処理

### APIレート制限エラーが発生する場合
- バッチ間にsleep処理を追加（コード修正必要）
- OpenAIの有料プランにアップグレード

## ライセンス
- ライセンスは未指定です。必要に応じて追記してください。

## 更新履歴
- 2025-09-28: 最適化版リリース - 全件処理、バッチ処理、240秒タイムアウト対応
- 2025-09-27: 初版リリース