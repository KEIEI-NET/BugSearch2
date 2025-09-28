# コードレビューツール セットアップガイド

## 🎯 推奨使用バージョン

### 最終版（強く推奨）
**`codex_review_ultimate.py`** - 2段階解析システム
- ✅ ルールベース全ファイル解析 → AI詳細解析
- ✅ 2種類のレポート生成（rules/AI）
- ✅ エンコーディング自動検出
- ✅ タイムアウト対策実装済み
- ✅ 進捗表示機能
- ✅ Windows環境での権限エラー対策済み

### その他のバージョン（特定用途向け）
- `codex_review_enhanced.py` - エンコーディング自動検出特化版
- `codex_review_severity.py` - 重要度順ソート版
- `codex_review_with_solutions.py` - AI改善案生成版
- `codex_review_optimized.py` - 大量ファイル処理最適化版
- `codex_review.py` - 基本版（軽量）

## インストール

```bash
# 必要なパッケージをインストール
pip install chromadb openai scikit-learn joblib regex chardet
# または
py -m pip install chromadb openai scikit-learn joblib regex chardet
```

## 環境設定

`.env`ファイルを作成：
```
OPENAI_API_KEY=your_api_key_here
OPENAI_MODEL=gpt-4o
```

## 基本的な使い方

### 1. インデックス作成
```bash
# 全ファイルをインデックス化
py codex_review_ultimate.py index .

# Delphiファイルを除外
py codex_review_ultimate.py index . --exclude-langs delphi

# ファイルサイズ制限（デフォルト4MB）
py codex_review_ultimate.py index . --max-file-mb 5
```

### 2. ベクトル化（オプション、検索精度向上）
```bash
py codex_review_ultimate.py vectorize
```

### 3. レビュー実行
```bash
# 特定のキーワードで検索とレビュー
py codex_review_ultimate.py query "データベース N+1" --topk 50 --out reports/db_review

# 全体的な助言
py codex_review_ultimate.py advise --topk 100 --out reports/full_review
```

## 出力ファイル

実行後、以下のファイルが生成されます：
- `reports/xxx_rules.md` - ルールベース解析結果（全ファイル、改善コード例付き）
- `reports/xxx_ai.md` - AI詳細解析結果（重要ファイルのみ、Before/After形式）

## カスタマイズ

`codex_review_ultimate.py`の設定値：
```python
AI_TIMEOUT = 60         # AI解析タイムアウト（秒）
AI_MAX_RETRIES = 2      # AIリトライ回数
AI_MIN_SEVERITY = 7     # AI解析する最小重要度スコア
AI_MAX_FILES = 20       # AI解析する最大ファイル数
```

## トラブルシューティング

### エンコーディングエラー
→ `codex_review_enhanced.py`または`codex_review_ultimate.py`を使用（自動検出機能あり）

### タイムアウトエラー
→ `--topk`の値を減らすか、`AI_MAX_FILES`を調整

### メモリ不足
→ `codex_review_optimized.py`を使用するか、`--max-file-mb`でファイルサイズを制限

### Windows権限エラー（WinError 1920）
→ `codex_review_ultimate.py`は.venvディレクトリを自動的に除外します

### 大量ファイルでの処理遅延
→ 段階的に実行:
```bash
# 1. 小規模なディレクトリから開始
py codex_review_ultimate.py index src/module1 --max-file-mb 1

# 2. 問題なければ全体へ
py codex_review_ultimate.py index . --max-file-mb 2
```

## サポート

問題が発生した場合は、`reports/IMPORTANT_RESULTS.md`を参照してください。