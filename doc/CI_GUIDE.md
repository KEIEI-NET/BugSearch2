# CI 運用ガイド

*バージョン: v3.5.0*
*最終更新: 2025年01月03日 15:30 JST*

本ドキュメントは、Codex Review CLI 群を GitHub Actions などの CI 環境で安全かつ効率的に運用するための推奨設定をまとめたものです。v3.5.0では大幅なセキュリティ強化とAI自動フォールバック機能が追加されています。

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

## シークレットと環境変数 (v3.5.0強化)

### 必須GitHub Secrets
- `AI_PROVIDER` - AIプロバイダー選択 (auto/anthropic/openai/rules)
- `ANTHROPIC_API_KEY` - Anthropic Claude APIキー（オプション）
- `ANTHROPIC_MODEL` - Claudeモデル指定（デフォルト: claude-3-5-sonnet-20241022）
- `OPENAI_API_KEY` - OpenAI GPT APIキー（オプション）
- `OPENAI_MODEL` - GPTモデル指定（デフォルト: gpt-4o）

### セキュリティ強化機能
- **`.env`ファイル不使用** - GitHub Secretsのみから環境変数を取得
- **APIキー検証** - 起動時に有効性を確認、無効な場合は自動フォールバック
- **SHA-256ピン留め** - 全GitHub ActionsをSHAハッシュで固定
- **最小権限原則** - 必要最小限の権限のみ付与

### AI自動フォールバック順序
1. Anthropic Claude → 2. OpenAI GPT → 3. ルールベース解析

## アーティファクト運用
- インデックス結果（`.advice_index.jsonl`）、大容量ファイルログ、`reports/*.md` を `readonly-advice` などの名前で保存。
- プロファイル結果（CSV/JSONL）は別アーティファクトとし、ベンチマーク比較が容易になるようにする。
- 保存期限 (`retention-days`) は 7〜30 日程度を推奨。

## フェイルセーフ
- インデックスジョブが `limit_stop` や `timeout_stop` で中断された場合でも成功扱いとし、ログで通知。必要に応じて次のジョブで再実行する。
- 予期せぬ例外発生時は該当ジョブを失敗させ、PR コメントにエラー概要を添付して再実行を促す。
- `advise` ジョブは AI 呼び出しが失敗してもルールベースレポートを生成し、警告付きで完了するよう設計する。

## サンプルワークフロー (v3.5.0)

### 基本フロー
1. Checkout → Python Setup → Dependency Install
2. Index (`codex_review_severity.py index ...`)
3. Vectorize (`codex_review_severity.py vectorize`)
4. Advise (`codex_review_severity.py advise ...`)
5. Cleanup sensitive files
6. Upload artifacts
7. Post PR comment（サマリ + アーティファクト案内）

### v3.5.0 ワークフロー例
```yaml
name: Code Review v3.5.0
on:
  pull_request:
    types: [opened, synchronize]

jobs:
  code-review:
    runs-on: ubuntu-latest
    permissions:
      contents: read
      pull-requests: write

    steps:
      # セキュアなチェックアウト（SHAピン留め）
      - uses: actions/checkout@b4ffde65f46336ab88eb53be808477a3936bae11 # v4.1.1
        with:
          fetch-depth: 0

      # Python環境セットアップ（SHAピン留め）
      - uses: actions/setup-python@0b93645e9fea7318ecaed2b359559ac225c90a2b # v5.3.0
        with:
          python-version: '3.11'
          cache: 'pip'

      # 依存関係インストール
      - name: Install dependencies
        run: |
          pip install --upgrade pip
          pip install -r requirements.txt

      # コードレビュー実行（AI自動フォールバック）
      - name: Run Code Review with Auto-Fallback
        env:
          AI_PROVIDER: ${{ secrets.AI_PROVIDER || 'auto' }}
          ANTHROPIC_API_KEY: ${{ secrets.ANTHROPIC_API_KEY || '' }}
          ANTHROPIC_MODEL: ${{ secrets.ANTHROPIC_MODEL || 'claude-3-5-sonnet-20241022' }}
          OPENAI_API_KEY: ${{ secrets.OPENAI_API_KEY || '' }}
          OPENAI_MODEL: ${{ secrets.OPENAI_MODEL || 'gpt-4o' }}
        run: |
          # APIキー検証とプロバイダー選択
          if [ -n "$ANTHROPIC_API_KEY" ]; then
            echo "Using Anthropic Claude for analysis"
          elif [ -n "$OPENAI_API_KEY" ]; then
            echo "Using OpenAI GPT for analysis"
          else
            echo "Using rules-based analysis only"
          fi

          # インデックス作成
          python codex_review_severity.py index . \
            --exclude-langs delphi \
            --max-file-mb 4 \
            --worker-count 4

          # ベクトル化（セマンティック検索用）
          python codex_review_severity.py vectorize

          # 解析実行
          python codex_review_severity.py advise \
            --all \
            --out reports/review

      # セキュリティクリーンアップ（常に実行）
      - name: Security Cleanup
        if: always()
        run: |
          # 機密ファイルの削除
          rm -f .env .env.* *.key *.pem
          rm -f **/.env **/*.key **/*.pem

          # ログファイルのクリーンアップ
          find . -name "*.log" -type f -exec shred -vzu {} \; 2>/dev/null || true

          # キャッシュのクリア
          rm -rf .cache/api_keys/

      # レポートアップロード
      - uses: actions/upload-artifact@26f96dfa697d77e81fd5907df203aa23a56210a8 # v4.3.0
        if: always()
        with:
          name: code-review-reports
          path: reports/
          retention-days: 7
```

### セキュリティベストプラクティス
1. **全アクションをSHAでピン留め** - タグではなくコミットSHAを使用
2. **環境変数の最小化** - 必要な変数のみを渡す
3. **クリーンアップの徹底** - `if: always()`で確実に実行
4. **権限の最小化** - 必要最小限の権限のみ付与
5. **ログの適切な処理** - 機密情報を含む可能性のあるログは安全に削除

既存の `.github/workflows/codex-readonly-review-optimized.yml` はv3.5.0仕様に更新されています。

---

*最終更新: 2025年01月03日 15:30 JST*
*バージョン: v3.5.0*

**更新履歴:**
- v3.5.0 (2025年01月03日): GitHub Actionsセキュリティ強化、AI自動フォールバック機能追加、SHAピン留め実装
