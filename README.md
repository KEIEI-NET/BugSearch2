# Readonly Review ツール

このリポジトリは、Pull Request 向けの読取専用コードレビュー支援ツールです。codex_review.py でルールベースと GPT-5 を組み合わせたアドバイスを生成し、GitHub Actions から自動でレポートを出力・コメント投稿できます。

## 特徴
- 金額・印刷・UI/UX・DB負荷に焦点を当てた静的チェック
- OpenAI GPT-5 を使った要約アドバイス（ハイブリッド/AIモード）
- リポジトリ全体をインデックス化し、自然言語で関連コードを探索
- GitHub Actions (codex-readonly-review.yml) による PR 自動レビュー

## 前提条件
- Python 3.11 以上
- pip install chromadb openai scikit-learn joblib regex
  - scikit-learn が無い場合、TF-IDF ベクトル化はスキップされます（素朴検索で継続）
- GPT-5 を利用する場合は OPENAI_API_KEY を環境変数に設定してください

## 使い方
### 1. リポジトリのインデックス構築
    python codex_review.py index /path/to/repo
- .advice_index.jsonl を生成し、可能であれば TF-IDF ベクトル (.advice_tfidf.pkl, .advice_matrix.pkl) を作成します。

### 2. オプション: ベクトル再構築
    python codex_review.py vectorize --index .advice_index.jsonl
- インデックスの内容から再度 TF-IDF モデルを構築します。

### 3. 自然言語で検索・アドバイス取得
    python codex_review.py query "印刷が途中で止まる" --mode hybrid --topk 30 --out reports/print.md
- 指定クエリに関連するコード片を検索し、ルール検知と GPT-5 のコメントをレポート化します。
- --mode は rules, ai, hybrid から選択できます。

### 4. 横断チェックの自動助言
    python codex_review.py advise --mode hybrid --topk 80 --out reports/advise.md
- 金額/印刷/UI/DB に関連する兆候が強いファイルを横断的に抽出し、重点指摘をまとめます。

## GitHub Actions 連携
.github/workflows/codex-readonly-review.yml に本リポジトリの codex-readonly-review.yml を配置すると、PR オープン・同期時に以下を実行します。
1. ソースをチェックアウト
2. Python 3.11 と依存ライブラリをセットアップ
3. python codex_review.py index . でリポジトリを読取専用でスキャン
4. python codex_review.py advise --mode hybrid --topk 80 --out reports/advise.md で助言レポート生成
5. レポートをアーティファクト化 (readonly-advice)
6. PR に結果サマリをコメント投稿

GitHub Actions から GPT-5 を利用する場合、リポジトリシークレットに OPENAI_API_KEY を設定してください。モデルを変更したい場合は OPENAI_MODEL シークレットを追加します。

## 生成物
- .advice_index.jsonl: インデックス化されたソース情報
- .advice_tfidf.pkl, .advice_matrix.pkl: TF-IDF モデル（scikit-learn 利用時）
- reports/*.md: ルール/GPT の助言レポート

## 注意事項
- ツールはソースを読み取り、指摘のみを出力します。自動修正は行いません。
- 大きすぎるファイル（既定で 3MB 超）はインデックス対象外で、`reports/large_files_over_limit.log` に一覧を出力します。
- OPENAI_API_KEY が未設定の場合、AI モードは “AI未有効” のメッセージを返します。

## ライセンス
- ライセンスは未指定です。必要に応じて追記してください。
