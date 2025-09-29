# 対応言語一覧

## サポート言語と検出可能な問題

### 📘 PHP (.php)
**バージョン3.1で新規追加**

#### セキュリティ脆弱性
| 問題 | 重要度 | 説明 |
|------|--------|------|
| SQLインジェクション | 10 | `$_GET['id']`を直接SQL文に結合 |
| コマンドインジェクション | 10 | `system($_GET['cmd'])` |
| ファイルインクルード | 9 | `include($_GET['page'])` |
| XSS（未エスケープ） | 9 | `echo $_GET['name']` |
| ディレクトリトラバーサル | 9 | パス検証なしのファイル操作 |
| eval()使用 | 9 | 動的コード実行の危険 |
| セッション固定化 | 8 | `session_regenerate_id`なし |
| CSRF対策不足 | 8 | トークン検証なし |

#### 非推奨・危険な関数
- `mysql_*`関数（PDO/mysqli推奨）
- `extract($_POST)` の危険な使用
- `display_errors = 1`（本番環境）

### 🟢 Go (.go)
| 問題 | 重要度 | 説明 |
|------|--------|------|
| goroutineリーク | 9 | 終了条件のない無限ループ |
| エラーチェック不足 | 8 | `err`を無視 |
| チャネルデッドロック | 7 | バッファなしチャネル |
| defer忘れ | 6 | リソース解放漏れ |
| panicリカバリなし | 5 | `recover()`未実装 |

### 🔵 C++ (.cpp, .hpp)
| 問題 | 重要度 | 説明 |
|------|--------|------|
| メモリリーク | 10 | `new`に対応する`delete`なし |
| バッファオーバーフロー | 10 | `strcpy`/`sprintf`使用 |
| 未初期化ポインタ | 9 | NULLチェックなし |
| RAII違反 | 7 | リソース管理不適切 |
| 例外安全性欠如 | 6 | `try-catch`なし |

### 🟡 JavaScript/TypeScript (.js, .ts)
- XSS脆弱性
- イベントリスナーリーク
- Promise未処理エラー
- 型安全性の欠如（TS）

### 🔴 C# (.cs)
- N+1問題（Entity Framework）
- 金額計算でのfloat/double使用
- 非同期処理の不適切な実装
- リソース解放忘れ（IDisposable）

### 🟣 Python (.py)
- 型ヒント不足
- グローバル変数の乱用
- 例外処理の不適切な実装
- リソース管理（with文未使用）

### 🟤 Java (.java)
- NullPointerException未対策
- リソースリーク（try-with-resources未使用）
- 同期化問題
- 非効率なコレクション操作

## 言語検出ロジック

```python
def detect_lang(path):
    ext = path.suffix.lower()

    # PHP追加
    if ext == ".php": return "php"

    # 既存の言語
    if ext in (".py",): return "python"
    if ext in (".js",".jsx"): return "javascript"
    if ext in (".ts",".tsx"): return "typescript"
    if ext in (".cs",): return "csharp"
    if ext in (".java",): return "java"
    if ext in (".go",): return "go"
    if ext in (".rs",): return "rust"
    if ext in (".cpp",".hpp",".cc",".hh"): return "cpp"
    if ext in (".c",".h"): return "c"

    return "other"
```

## 使用例

### PHPプロジェクトの分析
```bash
# PHPファイルのみインデックス化
py codex_review_severity.py index ./src/php

# 分析実行
py codex_review_severity.py advise --topk 50 --out reports/php_analysis
```

### 言語別の除外
```bash
# Delphi除外
py codex_review_severity.py index . --exclude-langs delphi

# 複数言語除外
py codex_review_severity.py index . --exclude-langs delphi java
```

## テストサンプル

各言語のテストサンプルは`src/`ディレクトリに配置：

- `src/php/` - PHPサンプル（脆弱/セキュア）
- `src/go/` - Goサンプル
- `src/cpp/` - C++サンプル
- `src/csharp/` - C#サンプル

## 今後の拡張予定

- **Ruby on Rails**固有パターン
- **Swift/Kotlin**モバイル言語
- **フレームワーク別検出**（Laravel, Django, Spring等）