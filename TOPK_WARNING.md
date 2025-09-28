# ⚠️ 重要: --topk パラメータについて

## 問題の概要

`codex_review_severity.py advise` コマンドは、**デフォルトで80ファイルしか分析しません**。

これは全ファイルの約0.5%に過ぎず、重要な問題を見逃す可能性があります。

## なぜこの問題が起きるのか

```python
# codex_review_severity.py の設定
ap_adv.add_argument("--topk", type=int, default=80, help="助言対象上位N件")
```

- インデックスには全ファイル（例: 15,710件）が含まれている
- しかし `--topk` のデフォルト値は80
- **インデックスのファイル数は自動的には引き継がれない**

## 解決方法

### 方法1: --all オプションを使用（推奨・新機能）
```bash
py -3 codex_review_severity.py advise --all --out reports/analysis.md
```

### 方法2: ファイル数を自動検出するバッチ
```batch
run_detailed_analysis_auto.bat
```

### 方法3: 手動でファイル数を指定
```bash
# インデックス作成時の indexed 数を確認
py -3 codex_review_severity.py index ./src
# [SUMMARY] indexed=15710 と表示

# その数を指定
py -3 codex_review_severity.py advise --topk 15710 --out reports/analysis.md
```

## 具体例

### ❌ 悪い例（デフォルト）
```bash
py -3 codex_review_severity.py advise --out reports/analysis.md
# → 80ファイルのみ分析（全体の0.5%）
```

### ✅ 良い例（全ファイル）
```bash
py -3 codex_review_severity.py advise --all --out reports/analysis.md
# → 全15,710ファイルを分析
```

### ✅ 良い例（明示的指定）
```bash
py -3 codex_review_severity.py advise --topk 15710 --out reports/analysis.md
# → 15,710ファイルを分析
```

## チェックリスト

分析実行前に確認：

- [ ] `--all` または `--topk` を指定したか？
- [ ] 指定なしの場合、80ファイルのみで良いか？
- [ ] インデックスの indexed 数を確認したか？
- [ ] 全ファイル分析が必要か、部分分析で十分か？

## 推奨される使用パターン

### 開発時（部分分析）
```bash
# 上位1000ファイルで素早く確認
py -3 codex_review_severity.py advise --topk 1000 --out reports/quick_check.md
```

### 本番分析（全ファイル）
```bash
# 全ファイルを徹底分析
py -3 codex_review_severity.py advise --all --out reports/full_analysis.md
```

### CI/CD（閾値設定）
```bash
# 危険度の高い上位500ファイルをチェック
py -3 codex_review_severity.py advise --topk 500 --out reports/ci_check.md
```

---

最終更新: 2024年9月28日
この問題は codex_review_severity.py v2.0 で --all オプションを追加して対処済み