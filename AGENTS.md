# Repository Guidelines

## プロジェクト構成とモジュール配置
- `codex_review.py` はインデックス作成、検索、ルール評価、GPT 出力を統合した単一 CLI です。ヘルパーは呼び出し元近くにまとめ、既存のフラットな構造とセクション見出しを踏襲してください。
- `codex-readonly-review.yml` は配布用テンプレートであり、変更は必ずここから適用して利用者がコピーペーストできる状態を保ちます。ワークフローのバージョンピンは定期的に見直します。
- 生成物（`.advice_index.jsonl`、`.advice_tfidf.pkl`、`.advice_matrix.pkl`、`reports/*.md`）はローカル専用です。配布物を作る際は `.gitignore` の指針に従い、クリーンな状態で共有してください。
- `README.md` には高レベルの使い方と前提条件がまとまっています。CLI にフラグやモードを追加した場合は、ここに追記して採用者に最新情報を届けます。
- ドキュメントを拡充する場合は `docs/` ディレクトリを新設し、日本語・英語双方の利用者に配慮した構成を検討してください。
- インデックス対象は 3MB 以下のテキストのみです。閾値を超えたファイルはスキップされ、`reports/large_files_over_limit.log` に手動解析用の一覧が出力されます。
- 秘密情報は `.env` に定義します。`.env.example` をコピーして利用し、`.env` はコミット対象外に保ってください。
- サンプルコードは `src/<language>/` に配置します。既定の `csharp`、`java`、`typescript`、`javascript`、`delphi`、`python` ディレクトリを活用し、不要なものは `.gitignore` で除外してください。

## ビルド・テスト・開発コマンド
- `python -m pip install --upgrade pip && pip install chromadb openai scikit-learn joblib regex` で主要依存を導入します。scikit-learn が無い場合でも動作しますが、TF-IDF が無効になる点をチームと共有してください。
- `python codex_review.py index <repo>` でターゲットリポジトリを読み取り専用でスキャンし、存在すれば TF-IDF キャッシュも自動再生成します。
- `python codex_review.py query "印刷が途中で止まる" --mode hybrid --out reports/query.md` は個別課題の深掘りに利用します。`--mode` や `--topk` を調整し、ルール追加時の挙動を素早く確認します。
- `python codex_review.py advise --mode hybrid --topk 80 --out reports/advise.md` で CI 同等のレポートをローカル再現します。マージ前に少なくとも 1 回実行し、出力のサマリが期待通りか確認してください。
- `python codex_review.py vectorize --index .advice_index.jsonl` は大規模なインデックス更新や依存アップデート後に行い、旧モデルとの不整合を防ぎます。
- 開発中の軽量テスト用に `python codex_review.py query "UI 入力検証" --mode rules` のような短命コマンドを活用し、応答の差異をログに残してください。

## コーディング規約と命名
- Python 3.11、4 スペースインデント、グループ化された import、UTF-8 IO を標準とし、既存の shebang とモジュールドキュメント形式を維持します。外部依存へのフォールバック処理は現在の書き方を踏襲してください。
- 関数は snake_case、データクラスは CapWords、定数は UPPER_CASE を使用し、コメントは目的や注意点に限定します。冗長な説明は README へ移してください。
- 型ヒントは主要な引数と戻り値に付与し、`from __future__ import annotations` を活かして循環参照を避けます。
- 新しい CLI フラグは `argparse` で定義し、対応する定数（例: `HYBRID_TOPK_AI`）と README の使用例を必ず更新します。引数の既定値はハードコードせず定数経由に統一します。

## テスト指針
- 自動テストは未整備です。`index`、`query`、`advise` をルールの対象領域（金額・印刷・UI/UX・DB 負荷など）を含むサンプルリポジトリで実行し、助言内容を手動で検証します。
- 新しい検出ロジックを追加する際は最小限のサンプルコードを用意し、`reports/*.md` に期待する助言文が出力されることを確認し、PR に抜粋や差分を添付します。
- オプション依存（例: scikit-learn）は導入時と未導入時の双方でエラーハンドリングをテストし、想定外の ImportError を防ぎます。
- テスト実行ログは PR テンプレートまたは説明欄に貼り付け、再現手順をチーム全体で共有してください。

## コミットと Pull Request 方針
- コミットメッセージは命令形・現在形で簡潔に書きます（例: `feat: add HasMorePages guard`、`fix: skip binary index entries`）。まとめたい変更は論理単位で分割し、差分レビューを容易にします。
- PR ではユーザー向けの影響、実行した検証コマンド、必要なシークレットや環境変数（`OPENAI_API_KEY`、`OPENAI_MODEL` など）を明記し、レビューアが再現できる情報を提供します。
- ワークフローやシークレット利用に変更がある場合はレビュアーへ必ず通知し、レポートが GitHub の 60k 文字制限に収まることを確認します。必要に応じてサマリのトリミング戦略を共有してください。
- Issue と関連づけられる変更は PR 説明に `Closes #123` の形式で明記し、トラッキングを容易にします。

## セキュリティと設定のポイント
- API キーやシークレットはコミットしないでください。ローカルでは一時的なシェル export、CI ではリポジトリシークレットを利用し、ログ出力に残らないよう注意します。
- 新しい環境変数を導入する際は README に追記し、安全な既定値を定数経由で提供して、利用者の自動化やスクリプトが破綻しないようにします。また、秘密情報を扱うコードには最小権限の原則を適用してください。
- 設定例を共有する場合は `.env.example` や `docs/config.md` のようなテンプレートを用意し、実値の流出を防ぎます。
