# CI 運用ガイド

**最終更新**: 2025-09-28 12:56:09
**バージョン**: 1.0ライン

本ドキュメントは、Codex Review CLI 群を GitHub Actions などの CI 環境で安全かつ効率的に運用するための推奨設定をまとめたものです。リポジトリごとの要件に合わせて適宜調整してください。

## ジョブ構成
1. **依存準備ジョブ**
   - Python 3.11 をセットアップし、仮想環境で依存ライブラリをインストール。
   - 必要に応じてキャッシュ（pip cache や `.venv`）を利用。
2. **インデックスジョブ**
   - `python codex_review.py index . --batch-size 300 --max-seconds 600 --profile-index --profile-output reports/profile_ci.jsonl`
   - 大規模リポジトリでは `--include` / `--exclude` を使用して対象を絞り込み、タイムアウトを防ぐ。
   - 生成物（`.advice_index.jsonl`, `reports/large_files_over_limit.log`, プロファイル CSV/JSONL）をアーティファクトとして保存。
3. **助言ジョブ**
   - インデックス結果を再利用（アーティファクトから取得）。
   - `python codex_review.py advise --mode hybrid --topk 80 --out reports/advise.md`
   - OpenAI API を利用する場合はジョブに `OPENAI_API_KEY` を渡す。
4. **レポート／コメントジョブ**
   - `reports/*.md` を集約し、必要に応じて PR コメント投稿。
   - 長大なレポートはアーティファクトとして配布し、PR コメントにはサマリのみを記載。

## 推奨パラメータ
| フラグ | 推奨値 | 理由 |
| --- | --- | --- |
| `--batch-size` | 200〜500 | CI での書き出し頻度と I/O 負荷を調整。リポジトリ規模に応じて変更。 |
| `--max-files` | 10,000 など | 大規模リポジトリで処理量を制限。並列ジョブで分割実行する場合に有効。 |
| `--max-seconds` | 600〜900 | GitHub Actions のジョブタイムアウトを避ける。再実行時に続きから処理できるようログ参照を徹底。 |
| `--include` / `--exclude` | `src/**`, `tests/**` 等 | レビュー対象のサブディレクトリに限定しノイズを削減。 |
| `--profile-index` | 有効 | CI 上で計測統計をアーティファクト化し、処理時間のトレンドを把握。 |

## シークレットと環境変数
- `OPENAI_API_KEY` を使用するジョブは、GitHub Actions シークレットから安全に注入する。
- モデル指定（例: `OPENAI_MODEL=gpt-4o`）は環境変数または `.env` テンプレートで管理し、CI 側で上書きできるようにする。
- 追加依存や API を利用する場合は README の「セキュリティと設定」セクションを更新し、チームに周知する。

## アーティファクト運用
- インデックス結果（`.advice_index.jsonl`）、大容量ファイルログ、`reports/*.md` を `readonly-advice` などの名前で保存。
- プロファイル結果（CSV/JSONL）は別アーティファクトとし、ベンチマーク比較が容易になるようにする。
- 保存期限 (`retention-days`) は 7〜30 日程度を推奨。

## フェイルセーフ
- インデックスジョブが `limit_stop` や `timeout_stop` で中断された場合でも成功扱いとし、ログで通知。必要に応じて次のジョブで再実行する。
- 予期せぬ例外発生時は該当ジョブを失敗させ、PR コメントにエラー概要を添付して再実行を促す。
- `advise` ジョブは AI 呼び出しが失敗してもルールベースレポートを生成し、警告付きで完了するよう設計する。

## サンプルワークフローフロー
1. Checkout → Python Setup → Dependency Install
2. Index (`codex_review.py index ...`)
3. Advise (`codex_review.py advise ...`)
4. Upload artifacts
5. Post PR comment（サマリ + アーティファクト案内）

既存の `.github/workflows/codex-readonly-review-optimized.yml` を参照しつつ、必要に応じてバッチパラメータやタイムアウト値を上書きしてください。
