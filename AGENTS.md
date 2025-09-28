# Repository Guidelines

## プロジェクト構成とモジュール配置
Root directory hosts the CLI entry points `codex_review.py`, `codex_review_optimized.py`, `codex_review_ultimate.py`, offering baseline, performance, and two-stage review flows. 生成物である `.advice_index.jsonl`, `.advice_tfidf.pkl`, `.advice_matrix.pkl`, `reports/*.md` は共有前に削除または `.gitignore` に従って管理し、長期保存は `reports/archive/` など任意の private パスへ退避してください。Documentation resides in `doc/` where `TECHNICAL.md`, `CI_GUIDE.md`, `TESTING.md`, `DEVELOPMENT.md` capture the latest architecture, workflow, and benchmark notes. Sample repositories and fixtures stay under `src/<language>/`; keep `.gitkeep` so automated tests can rely on deterministic layout. 追加の設計資料や可視化は `doc/flow/` と `doc/class/` に格納されています。

## ビルド・テスト・開発コマンド
作業開始時は仮想環境を作成し依存を導入します。
```bash
python3 -m venv .venv
. .venv/bin/activate
pip install chromadb openai scikit-learn joblib regex chardet
```
`python codex_review.py index /path/to/repo` でインデックスを構築し、`python codex_review.py vectorize --index .advice_index.jsonl` で TF-IDF を更新します。レビューは `python codex_review.py advise --mode hybrid --topk 80 --out reports/advise.md` が標準で、二段階解析や進捗監視を使いたい場合は `python codex_review_ultimate.py advise --profile-index --profile-output reports/profile.csv` を利用してください。Large scale runs should combine `--batch-size 300`, `--max-files 10000`, and `--max-seconds 900` to avoid CI timeouts.

## コーディング規約と命名
Python 3.11+, four-space indentation, UTF-8 I/O を必須とし、imports are grouped standard → third-party → local. Functions and variables adopt `snake_case`, classes use `CapWords`, shared constants remain `UPPER_CASE` (e.g. `INDEX_PATH`, `HYBRID_TOPK_AI`). CLI scripts are single-file style; helper functions stay close to their call sites and heavy utilities should receive docstrings describing parameters and side effects. ログメッセージや警告文は英日混在でも良いですが、重要な設定値は英語で明示し国際メンバーにも伝わるようにしてください。

## テスト指針
Automated suites are WIP, so rely on `src/` fixtures and manual inspection. 最低限 `index` → `vectorize` → `advise` の順で CLI を実行し、`--profile-index --profile-output reports/profile_latest.jsonl` を付与して統計を残します。`scikit-learn` 未導入時には TF-IDF をスキップする warning が出るため、フォールバック検索が継続しているかログで確認してください。CI 環境では `doc/TESTING.md` に記載の S-50 / S-500 / S-5000 / S-10000 シナリオを参考にし、結果を `reports/` 配下へコミットしないよう注意します。

## コミットと Pull Request ガイドライン
Commits follow imperative present tense such as `feat: add HasMorePages guard` or `fix: skip binary index entries`. 1 つのロジック変更につき 1 コミットを目安とし、生成物を混在させないでください。Pull Request descriptions must list updated CLI options, executed commands, required environment variables (`OPENAI_API_KEY`, `OPENAI_MODEL`), and attach previews or key findings from generated reports. Link issues via `Closes #123` when applicable and document workflow or secrets changes clearly so reviewers can update GitHub Actions and `.env.example` without猜測.

## セキュリティと設定のヒント
`.env` はリポジトリに含めず `.env.example` を配布してローカルで値を設定します。助言レポートには confidential snippets が含まれるため、外部共有時は redaction を行い、レビュー履歴は `reports/summary.md` などのサマリに落とし込みます。GitHub Actions (`codex-readonly-review*.yml`) を利用する際は必要な secrets をリポジトリ設定へ登録し、変更があれば README と PR の両方で周知してください。Two-stage pipelines should run in read-only mode and never attempt automatic code mutation; 追加権限が必要な場合は管理者に事前相談を行います。
