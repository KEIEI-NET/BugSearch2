# AI改善コード生成ツール

*バージョン: v4.1.0*
*作成日: 2025年01月05日*

## 概要

`generate_ai_improved_code.py` は、完全レポートから問題・助言を抽出し、LLM（Claude/OpenAI）で100点満点の改善コードを生成するツールです。

**重要**: このツールは実ファイルを変更しません。改善コードをレポートとして生成するのみで、実際の修正は人間が行います。

## 仕様

### 処理フロー

```
1. 完全レポートからエントリを抽出
   ↓
2. 元のソースファイルを読み込み
   ↓
3. 問題箇所にコメントを追加した元ソースを表示
   ↓
4. LLM（Claude/OpenAI）で100点満点の改善コードを生成
   ↓
5. 詳細レポート（Markdown）に追加
   ↓
6. 進捗をJSONに記録
   ↓
7. 次のエントリに進む（ループ）
```

### 入力フォーマット（完全レポート）

```markdown
### N. <ファイルパス>
- **言語**: <言語>
- **重要度**: [レベル] (スコア: XX)
- **タグ**: ...

#### 検出された問題:
- [レベル] 問題1
- [レベル] 問題2
...

#### 元のソースコード:
\`\`\`言語
<コード>
\`\`\`

#### 改善されたソースコード:
\`\`\`typescript
# 改善助言（修正コード出力なし）
<助言のテキスト>
\`\`\`
```

### 出力フォーマット（AI改善レポート）

```markdown
## N. <ファイルパス>

- **言語**: typescript
- **重要度**: [緊急] (スコア: 43)
- **生成日時**: 2025-01-05 12:30:45

### 検出された問題

- [高] UI: 入力検証が不十分
- [緊急] DB: ループ内SELECT (N+1) 疑い
...

### 改善助言

\`\`\`
<レポートからの助言>
\`\`\`

### 元のソースコード

\`\`\`typescript
<実際のファイルから読み込んだコード>
\`\`\`

### AI生成改善コード（100点満点目標）

\`\`\`typescript
<LLMが生成した改善コード>
\`\`\`
```

## 使用方法

### 基本的な使い方

```bash
# TOP20のみ処理
python generate_ai_improved_code.py reports/完全レポート.md --top 20 --out reports/ai_improved.md

# すべて処理（進捗自動保存）
python generate_ai_improved_code.py reports/完全レポート.md --all --out reports/ai_improved.md

# 進捗から再開
python generate_ai_improved_code.py reports/完全レポート.md --resume
```

### 環境変数設定

**重要**: APIキーは`.env`ファイルに記載してください（gitignore推奨）

`.env` ファイル例：

```env
# AI Provider選択（auto: Anthropic優先 → OpenAIフォールバック）
AI_PROVIDER=auto

# Anthropic API設定（推奨）
ANTHROPIC_API_KEY=sk-ant-api03-...
ANTHROPIC_MODEL=claude-sonnet-4-5

# OpenAI API設定（フォールバック）
OPENAI_API_KEY=sk-proj-...
OPENAI_MODEL=gpt-4o
```

**プロバイダー優先順位**（`AI_PROVIDER=auto`の場合）:
1. Anthropic Claude（`ANTHROPIC_API_KEY`が設定されている場合）
2. OpenAI GPT（`OPENAI_API_KEY`が設定されている場合）
3. エラー（どちらも設定されていない場合）

**手動指定**:
```env
AI_PROVIDER=anthropic  # Claudeのみ使用
# または
AI_PROVIDER=openai     # OpenAIのみ使用
```

**セキュリティ**:
- `.env`ファイルは必ず`.gitignore`に追加してください
- APIキーを直接コマンドラインや環境変数で指定しないでください
- スクリプトは自動的に`.env`を読み込みます（python-dotenv不要）

### コマンドライン引数

| 引数 | 説明 | デフォルト |
|------|------|-----------|
| `report` | 完全レポートのパス（必須） | - |
| `--top N` | 処理する件数 | 20 |
| `--all` | すべて処理 | - |
| `--out` | 出力レポートパス | `reports/ai_improved_report.md` |
| `--resume` | 進捗から再開 | - |

## 機能詳細

### 1. レポート解析

- 正規表現ベースの高速パース
- エンコーディング自動検出（BOM/chardet）
- ファイルサイズ制限（100MB）

### 2. ソースファイル読み込み

- エンコーディング自動検出
  - BOM検出: UTF-8, UTF-16 LE/BE
  - chardet統合（confidence > 0.7）
  - フォールバック: UTF-8 → CP932 → Shift_JIS → latin1
- ファイルサイズ制限（10MB）
- 存在チェック・権限チェック

### 3. LLM連携

#### プロンプト構成

```
あなたはコードレビューとリファクタリングの専門家です。

## ファイル情報
- ファイルパス: ...
- 言語: ...

## 検出された問題
- ...

## 改善助言
...

## 元のソースコード
```
...
```

## 指示
1. 上記の問題をすべて解決してください
2. 助言に従って実装してください
3. デバッグ、セキュリティ、コードレビューで100点満点を目指してください
4. コメントは日本語で記載してください
5. 改善されたコードのみを出力してください
```

#### AI Provider選択

- **auto**: Anthropic優先、OpenAIフォールバック
- **anthropic**: Claude専用
- **openai**: OpenAI専用

### 4. 進捗管理

- `.ai_improved_progress.json` に自動保存
- 中断しても再開可能（`--resume`）
- エントリごとに成功/失敗を記録

進捗JSON例：

```json
{
  "processed": [
    {
      "number": 1,
      "file_path": "src/...",
      "success": true,
      "timestamp": "2025-01-05T12:30:45"
    }
  ],
  "last_index": 0,
  "timestamp": "2025-01-05T12:30:45"
}
```

## エラーハンドリング

### ファイル読み込みエラー

- ファイルが存在しない → スキップ
- ファイルサイズ超過 → スキップ
- エンコーディングエラー → フォールバック

### LLMエラー

- APIキー未設定 → スキップ
- レート制限 → 1秒待機後に次へ
- Quota超過 → エラー表示してスキップ

## パフォーマンス

- **レート制限対策**: 各エントリ間に1秒待機
- **並列処理**: なし（LLM APIレート制限のため逐次処理）
- **処理時間目安**: 1エントリあたり5-30秒（LLM応答時間に依存）

## セキュリティ

- **実ファイル変更なし**: 読み込みのみ、書き込みは出力レポートのみ
- **APIキー保護**: `.env` ファイルで管理（gitignore推奨）
- **ファイルサイズ制限**: DoS攻撃対策
- **エンコーディング安全**: 複数フォールバックで堅牢性確保

## トラブルシューティング

### Q: OpenAI Quota超過エラー

**症状**:
```
[ERROR] LLM呼び出しエラー: Error code: 429 - insufficient_quota
```

**解決策**:
```bash
# .env でAnthropicに切り替え
AI_PROVIDER=anthropic
ANTHROPIC_API_KEY=sk-ant-...
```

### Q: 絵文字でUnicodeEncodeError (Windows)

**症状**:
```
UnicodeEncodeError: 'cp932' codec can't encode character
```

**解決策**: v4.1.0で修正済み（絵文字を `[OK]` などに置換）

### Q: ファイルが見つからない

**症状**:
```
[WARNING] ファイルが存在しません: src/...
```

**原因**: レポート内のパスと実際のファイルパスが一致しない

**解決策**: レポート生成時のプロジェクトルートと実行時のカレントディレクトリを確認

## 制限事項

- **LLMトークン制限**: 8192トークン（約6000行）までの改善コード生成
- **ファイルサイズ**: 元のソースコードは10MBまで
- **レポートサイズ**: 完全レポートは100MBまで
- **並列処理なし**: レート制限対策のため逐次処理のみ

## 今後の拡張予定

- [ ] 並列処理対応（複数APIキーでレート制限回避）
- [ ] 差分生成（元コードと改善コードのdiff表示）
- [ ] 自動適用モード（TouchDesigner等での利用）
- [ ] キャッシュ機能（同じファイルの再生成を回避）
- [ ] バッチ処理（複数レポート一括処理）

## 関連ドキュメント

- [codex_review_severity.py](../codex_review_severity.py) - 完全レポート生成ツール
- [CLAUDE.md](../CLAUDE.md) - プロジェクト全体ガイド
- [TECHNICAL.md](TECHNICAL.md) - 技術仕様

---

*最終更新: 2025年01月05日*
*バージョン: v4.1.0*
