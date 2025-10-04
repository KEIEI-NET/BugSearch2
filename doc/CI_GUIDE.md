# CI 運用ガイド

*バージョン: v4.0.0*
*最終更新: 2025年01月04日*

本ドキュメントは、Codex Review CLI 群を GitHub Actions などの CI 環境で安全かつ効率的に運用するための推奨設定をまとめたものです。

**v4.0.0の新機能**:
- AI改善コードの自動適用ツール（100点満点セキュリティ）
- 文字エンコーディング自動検出（BOM + chardet）
- 完全レポート生成機能（--complete-all）
- マルチAIプロバイダー対応（Anthropic + OpenAI）

## ジョブ構成
1. **依存準備ジョブ**
   - Python 3.11 をセットアップし、仮想環境で依存ライブラリをインストール。
   - 必要に応じてキャッシュ（pip cache や `.venv`）を利用。
2. **インデックスジョブ**
   - `python codex_review_severity.py index ./src --exclude-langs delphi --max-file-mb 4 --worker-count 4`
   - 大規模リポジトリでは `--src-dir` で対象を絞り込み、タイムアウトを防ぐ。
   - 生成物（`.advice_index.jsonl`, `reports/large_files_over_limit.log`）をアーティファクトとして保存。
3. **助言ジョブ**
   - インデックス結果を再利用（アーティファクトから取得）。
   - `python codex_review_severity.py advise --all --out reports/analysis.md`（⚠️ --allを忘れずに！）
   - または完全レポート生成: `python codex_review_severity.py advise --complete-all --out reports/complete.md`
   - AI API を利用する場合はジョブに `ANTHROPIC_API_KEY` または `OPENAI_API_KEY` を渡す。
4. **自動適用ジョブ（v4.0新機能、オプション）**
   - `python apply_improvements_from_report.py reports/complete.md --dry-run`（プレビューのみ）
   - セキュリティ上の理由から、CI環境での自動適用は推奨しません（ローカル環境で実行）。
5. **レポート／コメントジョブ**
   - `reports/*.md` を集約し、必要に応じて PR コメント投稿。
   - 長大なレポートはアーティファクトとして配布し、PR コメントにはサマリのみを記載。

## 推奨パラメータ（v4.0更新）
| フラグ | 推奨値 | 理由 |
| --- | --- | --- |
| `--src-dir` | `./src` | インデックス対象ディレクトリ指定（デフォルト: ./src） |
| `--exclude-langs` | `delphi` | 除外する言語（Delphiは処理が重いため推奨） |
| `--max-file-mb` | 4 | ファイルサイズ制限（4MB推奨） |
| `--worker-count` | 4 | インデックス並列ワーカー数 |
| `--all` | 必須 | 全ファイル分析（デフォルトは80件のみ！） |
| `--complete-all` | オプション | 完全レポート生成（AI改善コード含む） |
| `--out` | `reports/*.md` | 出力ファイル指定（自動的に.md拡張子追加） |

## シークレットと環境変数 (v4.0更新)

### 必須GitHub Secrets
- `AI_PROVIDER` - AIプロバイダー選択 (auto/anthropic/openai) ※デフォルト: auto
- `ANTHROPIC_API_KEY` - Anthropic Claude APIキー（auto/anthropic選択時）
- `ANTHROPIC_MODEL` - Claudeモデル指定（デフォルト: claude-sonnet-4-5）
- `OPENAI_API_KEY` - OpenAI GPT APIキー（auto/openai選択時）
- `OPENAI_MODEL` - GPTモデル指定（デフォルト: gpt-4o）

### セキュリティ強化機能（v4.0）
- **`.env`ファイル不使用** - GitHub Secretsのみから環境変数を取得（手動.env読み込み機能）
- **APIキー検証** - 起動時に有効性を確認、無効な場合は自動フォールバック
- **SHA-256ピン留め** - 全GitHub ActionsをSHAハッシュで固定
- **最小権限原則** - 必要最小限の権限のみ付与
- **自動適用の制限** - CI環境ではdry-runのみ推奨（セキュリティリスク回避）

### AI自動フォールバック順序
1. Anthropic Claude (Sonnet 4.5 → Opus 4.1 → Sonnet 4.1)
2. OpenAI GPT (GPT-4o → GPT-5)
3. ルールベース解析（AI不要の場合）

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
