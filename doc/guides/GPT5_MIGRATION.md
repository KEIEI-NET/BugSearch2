# AI Provider移行ガイド

*バージョン: v4.0.0*
*最終更新: 2025年01月04日*

## 概要
本プログラムは複数のAI Providerに対応しており、環境変数でプロバイダーとモデルを指定できます。
- v3.2+: Anthropic Claude対応
- v3.5+: python-dotenv依存削除
- v4.0: 自動適用ツール搭載

## 対応AIプロバイダーとモデル

### Anthropic Claude（v3.2+）
| モデル | 説明 | 推奨用途 |
|--------|------|----------|
| `claude-sonnet-4-5` | デフォルト（最新） | 通常のコードレビュー |
| `claude-opus-4-1` | 最高精度 | 複雑な解析・推論タスク |
| `claude-sonnet-4-1` | バランス型 | コスト効率重視 |

### OpenAI
| モデル | 説明 | 推奨用途 |
|--------|------|----------|
| `gpt-5` | 最高性能モデル | 複雑な解析・推論タスク |
| `gpt-5-codex` | コード特化 | コードレビュー専用 |
| `gpt-5-mini` | バランス型 | 通常のコードレビュー |
| `gpt-5-nano` | 軽量版 | 大量ファイル処理 |
| `gpt-4o` | 前世代（安定版） | フォールバック用 |

## 設定方法

### Anthropic Claude使用（推奨）
```.env
# プロバイダー選択
AI_PROVIDER=anthropic  # または auto（Anthropic優先 → OpenAI fallback）

# Anthropic API設定
ANTHROPIC_API_KEY=sk-ant-...
ANTHROPIC_MODEL=claude-sonnet-4-5  # オプション（デフォルト: claude-sonnet-4-5）
```

### OpenAI使用
```.env
# プロバイダー選択
AI_PROVIDER=openai

# OpenAI API設定
OPENAI_API_KEY=sk-...
OPENAI_MODEL=gpt-4o  # または gpt-5, gpt-5-mini, gpt-5-nano
```

### 自動フォールバック設定（推奨）
```.env
# 自動モード: Anthropic優先、失敗時OpenAIにフォールバック
AI_PROVIDER=auto

# 両方のAPIキーを設定
ANTHROPIC_API_KEY=sk-ant-...
OPENAI_API_KEY=sk-...
```

### 実行時の動作確認
```bash
py codex_review_severity.py advise --topk 10
# [INFO] 使用プロバイダー: Anthropic (claude-sonnet-4-5)
# または
# [INFO] 使用プロバイダー: OpenAI (gpt-4o)
```

## 技術的な変更点

### APIパラメータの違い

#### GPT-5シリーズ
- `max_completion_tokens`を使用（`max_tokens`は非対応）
- `temperature`は1のみサポート
- 入力: 272,000トークン、出力: 128,000トークン

#### GPT-4o
- 従来の`max_tokens`を使用
- `temperature`は自由に設定可能

### 実装の詳細
```python
# codex_review_severity.py での実装
params = {
    "model": model,
    "messages": [{"role":"user","content":prompt}],
    "temperature": 1,
    "timeout": AI_TIMEOUT
}

# GPT-5系はmax_completion_tokensを使用
if "gpt-5" in model:
    params["max_completion_tokens"] = 2000
else:
    params["max_tokens"] = 2000
```

## フォールバック機能

空レスポンスを受信した場合、自動的に別モデルで再試行します：

1. `gpt-5` → `gpt-4o`
2. `gpt-5-mini` → `gpt-4o`
3. `gpt-5-nano` → `gpt-5-mini`

## 既知の問題と対策

### 問題1: GPT-5が空レスポンスを返す
**症状**: GPT-5モデルで実行すると空の応答（APIの既知の問題）
**原因**:
- `max_output_tokens`が不足
- `verbosity`が"low"すぎる
- `response_format`の未指定
- ストリーミング設定の不整合

**実装済み対策**:
1. **自動リトライ機能（3回まで）**
   - 1回目: 標準パラメータ
   - 2回目: `max_output_tokens`を2倍、`verbosity="high"`
   - 3回目: さらにトークン数増加、プロンプト強化

2. **パラメータ最適化**
   ```python
   # GPT-5系の推奨設定
   - max_output_tokens: 4000（十分な出力領域）
   - verbosity: "medium"（lowは空レスポンスリスク）
   - reasoning_effort: "medium"
   - response_format: {"type": "text"}（明示的指定）
   ```

3. **フォールバック**
   - 3回失敗後は`gpt-4o`または`gpt-3.5-turbo`で最終試行

### 問題2: パラメータエラー
**症状**: `max_tokens is not supported`エラー
**対策**: すでに対応済み（自動的に`max_completion_tokens`を使用）

### 問題3: temperatureエラー
**症状**: `temperature does not support 0.5`エラー
**対策**: GPT-5では`temperature=1`固定（実装済み）

## テスト方法

提供されている`test_gpt5.py`でモデルの動作確認が可能：

```bash
py test_gpt5.py
```

成功時の出力例：
```
[INFO] 使用モデル: gpt-4o
[SUCCESS] レスポンス受信: プログラミング言語
[SUCCESS] GPT-5モデル対応テスト成功！
```

## 推奨設定

### 開発・テスト環境
```env
OPENAI_MODEL=gpt-4o  # 安定動作確認済み
```

### 本番環境（GPT-5利用可能な場合）
```env
OPENAI_MODEL=gpt-5-mini  # コスト効率とパフォーマンスのバランス
```

### 大規模処理
```env
OPENAI_MODEL=gpt-5-nano  # 最速・最安価
```

## 更新履歴

- 2025-09-28: GPT-5対応実装
  - `max_completion_tokens`パラメータ対応
  - 空レスポンス時のフォールバック機能追加
  - モデル別パラメータ自動調整機能

---
最終更新: 2025-09-28