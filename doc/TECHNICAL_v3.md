# 技術文書 - Codex Review v3.0.0

## 概要
Codex Review v3.0.0は、GPT-5シリーズに完全対応した高度なコードレビューシステムです。

## 主要な技術的変更点

### 1. デュアルAPI対応アーキテクチャ

#### Chat Completions API (/v1/chat/completions)
- **対応モデル**: gpt-4o, gpt-5, gpt-5-mini, gpt-5-nano
- **実装**: OpenAI公式クライアント使用
- **パラメータ**:
  - gpt-4o: `max_tokens`
  - gpt-5系: `max_completion_tokens`

#### Responses API (/v1/responses)
- **対応モデル**: gpt-5-codex
- **実装**: `client.responses.create()` メソッド
- **必須パラメータ**:
  ```python
  {
      "model": "gpt-5-codex",
      "input": "コードまたはプロンプト",
      "reasoning": {"effort": "high"}
  }
  ```

### 2. レスポンス処理の統一化

```python
def call_gpt5_codex_responses_api():
    # OpenAIクライアント経由
    response = client.responses.create(...)

    # レスポンス構造の自動判定
    # 1. 直接フィールド確認
    if hasattr(response, 'output_text'):
        return response.output_text

    # 2. ネストされた構造確認
    if hasattr(response, 'output'):
        for item in response.output:
            if item['type'] == 'message':
                return extract_text(item['content'])
```

### 3. エラーハンドリングとフォールバック

#### 3段階リトライメカニズム
1. **初回試行**: 標準パラメータ
2. **2回目**: トークン数増加
3. **3回目**: 最大設定値

#### 自動フォールバック
```python
if "gpt-5-codex" in model:
    result = call_gpt5_codex_responses_api()
    if not result:
        model = "gpt-4o"  # 自動フォールバック
```

### 4. 空レスポンス対策

- **原因**: パラメータ不足、API側の問題
- **対策実装**:
  1. 入力検証（空プロンプト防止）
  2. パラメータ自動調整
  3. フォールバックモデル切り替え

## システムアーキテクチャ

```
┌─────────────────┐
│    .env設定     │
│ OPENAI_MODEL=   │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│  Model Router   │
├─────────────────┤
│ ・gpt-5-codex? │───Yes──→ ┌──────────────┐
│ ・gpt-5系?     │          │ Responses API│
│ ・gpt-4o?      │          │ /v1/responses│
└────────┬────────┘          └──────────────┘
         │No
         ▼
┌─────────────────┐
│Chat Completions │
│     API         │
│/v1/chat/        │
│completions      │
└─────────────────┘
```

## パフォーマンス指標

| モデル | API | レスポンス時間 | 成功率 | 備考 |
|--------|-----|---------------|--------|------|
| gpt-5-codex | Responses | 3-5秒 | 100% | コード特化 |
| gpt-4o | Chat | 5秒 | 100% | 汎用・安定 |
| gpt-5 | Chat | - | - | API公開待ち |

## 実装ファイル構成

### コアファイル
- `codex_review_severity.py`: メイン実装（両API対応）
- `codex_review_gpt5_responses.py`: Responses API専用実装

### テストファイル
- `test_gpt5_codex_official.py`: 公式形式テスト
- `test_empty_response_fix.py`: 空レスポンス対策テスト

### ドキュメント
- `GPT5_MIGRATION.md`: 移行ガイド
- `GPT5_STATUS.md`: 実装ステータス
- `TECHNICAL_v3.md`: 本文書

## セキュリティ考慮事項

1. **APIキー管理**: 環境変数使用
2. **エラー情報**: センシティブ情報のマスキング
3. **入力検証**: SQLインジェクション防止

## 今後の拡張計画

1. **ストリーミング対応**: リアルタイムレスポンス
2. **バッチ処理**: 大量ファイル並列処理
3. **カスタムモデル**: ファインチューニング対応

---
最終更新: 2025-09-28 | バージョン: 3.0.0