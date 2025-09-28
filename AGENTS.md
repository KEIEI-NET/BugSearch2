# Repository Guidelines

## プロジェクト構成とモジュール配置
- ルート直下に各 CLI 版 (`codex_review.py`、`codex_review_optimized.py` など) があり、バージョンごとに機能追加を切り分けています。
- インデックスやベクトルキャッシュ (`.advice_index.jsonl`, `.advice_tfidf.pkl`, `.advice_matrix.pkl`) とレポート (`reports/*.md`) はすべて生成物です。共有時は削除または `.gitignore` に従って無視してください。
- ドキュメントは `doc/` 配下（`TECHNICAL.md`、Mermaid 図、開発履歴など）。サンプルコードは `src/<language>/` に整理し、空ディレクトリ維持用の `.gitkeep` を残します。

## ビルド・テスト・開発コマンド
- 依存導入（仮想環境推奨）:
  ```bash
  python3 -m venv .venv
  . .venv/bin/activate
  pip install chromadb openai scikit-learn joblib regex chardet
  ```
- インデックス作成（読取専用）:
  ```bash
  python codex_review.py index /path/to/repo
  ```
- TF-IDF ベクトル再構築:
  ```bash
  python codex_review.py vectorize --index .advice_index.jsonl
  ```
- 助言レポート生成（ハイブリッド）:
  ```bash
  python codex_review.py advise --mode hybrid --topk 80 --out reports/advise.md
  ```
- 最適化版 / 究極版でも同じサブコマンドが利用可能。2段階解析が必要な場合は `codex_review_ultimate.py` を優先してください。

## コーディング規約と命名
- Python 3.11 以上、4 スペースインデント、UTF-8 I/O。import は標準→サードパーティ→ローカルの順にグルーピング。
- 関数・変数は `snake_case`、クラスは `CapWords`、定数は `UPPER_CASE`。CLI 全体で共有する定数（例: `INDEX_PATH`, `HYBRID_TOPK_AI`）を流用し、魔法値を避けてください。
- CLI は単一ファイルで完結するスタイルを維持し、関連ヘルパーは使用箇所の近くにまとめる方針です。

## テスト指針
- 公式テストスイートは未整備。`src/` 配下のサンプルリポジトリを使い、`index`・`query`・`advise` コマンドを実行して出力内容を確認します。
- scikit-learn 未導入時は、TF-IDF スキップメッセージが出ること、およびフォールバック検索で異常終了しないことを確認してください。
- レポート生成結果（Markdown）を PR に添付、または主要な指摘をサマリして共有するのが推奨です。

## コミットと Pull Request ガイドライン
- コミットメッセージは命令形・現在形（例: `feat: add HasMorePages guard`, `fix: skip binary index entries`）。論理単位で粒度を保ちます。
- PR では追加/変更された CLI オプションや影響範囲、実行したコマンド、必要な環境変数（`OPENAI_API_KEY`, `OPENAI_MODEL` など）を記載してください。
- Issue との関連は `Closes #123` 形式で明記し、ワークフローやシークレットに変更がある場合はレビュアーへ必ず共有します。

## セキュリティと設定のポイント
- `.env` はコミットから除外し、`.env.example` を写して使用者がローカルで値を設定する運用としてください。
- レポートにはコード断片が含まれるため、第三者共有時は機密情報が含まれていないか確認します。
- GitHub Actions ( `codex-readonly-review*.yml` ) を使用する場合、`OPENAI_API_KEY` など必要なシークレットを事前にリポジトリ設定へ追加し、追加項目があれば README/PR で告知します。
