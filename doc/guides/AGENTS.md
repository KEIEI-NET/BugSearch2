# Repository Guidelines

*バージョン: v4.0.0*
*最終更新: 2025年09月04日*

## プロジェクト構成とモジュール配置

### メインスクリプト（ルートディレクトリ）
- **`codex_review_severity.py`**: メインCLIエントリーポイント（index/advise/query）
- **`extract_and_batch_parallel_enhanced.py`**: 並列AI分析処理（10 workers）
- **`apply_improvements_from_report.py`**: v4.0新機能 - AI改善コードの自動適用ツール

### 生成ファイル（.gitignoreで管理）
- `.advice_index.jsonl`: ファイルインデックス（JSONL形式）
- `.advice_index.pickle`, `.advice_tfidf.pkl`, `.advice_matrix.pkl`: ベクトルデータ
- `reports/*.md`: 分析レポート（共有前に削除またはアーカイブ）
- `.cache/analysis/*.json`: MD5ハッシュベースのAI応答キャッシュ
- `backups/*.bak`: 自動適用時のバックアップファイル
- `.apply_log.jsonl`: 自動適用ログ

### ドキュメント構成
- `doc/`: 技術文書（TECHNICAL.md, CI_GUIDE.md, TESTING.md等）
- `doc/guides/`: 利用ガイド（AUTO_APPLY_GUIDE.md等）
- `doc/changelog/`: バージョン履歴（v4.0.0.md等）
- `doc/*.mmd`: Mermaid図（architecture.mmd, process-flow.mmd等）
- `src/<language>/`: サンプルリポジトリとフィクスチャ

## ビルド・テスト・開発コマンド

### 依存パッケージのインストール
```bash
# 仮想環境作成（推奨）
python3 -m venv .venv
source .venv/bin/activate  # Windows: .venv\Scripts\activate

# 必須パッケージ（requirements.txt参照）
pip install openai anthropic scikit-learn joblib chardet
```

### 基本ワークフロー
```bash
# 1. インデックス作成
python codex_review_severity.py index ./src --exclude-langs delphi --max-file-mb 4

# 2. AI分析実行（デフォルト: 80ファイルのみ）
python codex_review_severity.py advise --out reports/analysis.md

# 3. 全ファイル分析（重要！）
python codex_review_severity.py advise --all --out reports/full_analysis.md

# 4. 完全レポート生成（v3.5+）
python codex_review_severity.py advise --complete-all --out reports/complete.md

# 5. AI改善コードの自動適用（v4.0新機能）
python apply_improvements_from_report.py reports/complete.md --dry-run  # プレビュー
python apply_improvements_from_report.py reports/complete.md --apply     # 実際に適用
```

### 並列処理（大規模コードベース向け）
```bash
# 並列AI分析（10 workers、MD5キャッシュ対応）
python extract_and_batch_parallel_enhanced.py

# 進捗モニタリング（別ターミナル）
python test/monitor_parallel.py
```

## コーディング規約と命名
Python 3.11+, four-space indentation, UTF-8 I/O を必須とし、imports are grouped standard → third-party → local. Functions and variables adopt `snake_case`, classes use `CapWords`, shared constants remain `UPPER_CASE` (e.g. `INDEX_PATH`, `HYBRID_TOPK_AI`). CLI scripts are single-file style; helper functions stay close to their call sites and heavy utilities should receive docstrings describing parameters and side effects. ログメッセージや警告文は英日混在でも良いですが、重要な設定値は英語で明示し国際メンバーにも伝わるようにしてください。

## テスト指針
Automated suites are WIP, so rely on `src/` fixtures and manual inspection. 最低限 `index` → `vectorize` → `advise` の順で CLI を実行し、`--profile-index --profile-output reports/profile_latest.jsonl` を付与して統計を残します。`scikit-learn` 未導入時には TF-IDF をスキップする warning が出るため、フォールバック検索が継続しているかログで確認してください。CI 環境では `doc/TESTING.md` に記載の S-50 / S-500 / S-5000 / S-10000 シナリオを参考にし、結果を `reports/` 配下へコミットしないよう注意します。

## コミットと Pull Request ガイドライン
Commits follow imperative present tense such as `feat: add HasMorePages guard` or `fix: skip binary index entries`. 1 つのロジック変更につき 1 コミットを目安とし、生成物を混在させないでください。Pull Request descriptions must list updated CLI options, executed commands, required environment variables (`OPENAI_API_KEY`, `OPENAI_MODEL`), and attach previews or key findings from generated reports. Link issues via `Closes #123` when applicable and document workflow or secrets changes clearly so reviewers can update GitHub Actions and `.env.example` without猜測.

## セキュリティと設定のヒント
`.env` はリポジトリに含めず `.env.example` を配布してローカルで値を設定します。助言レポートには confidential snippets が含まれるため、外部共有時は redaction を行い、レビュー履歴は `reports/summary.md` などのサマリに落とし込みます。GitHub Actions (`codex-readonly-review*.yml`) を利用する際は必要な secrets をリポジトリ設定へ登録し、変更があれば README と PR の両方で周知してください。Two-stage pipelines should run in read-only mode and never attempt automatic code mutation; 追加権限が必要な場合は管理者に事前相談を行います。
