# PHP対応ガイド

## 概要
codex_review_severity.pyにPHP言語のサポートを追加しました。

## 追加機能

### 1. PHP固有の問題検出
- **セキュリティ脆弱性**
  - SQLインジェクション（スコア: 10）
  - XSS脆弱性（スコア: 9）
  - ファイルインクルード脆弱性（スコア: 9）
  - コマンドインジェクション（スコア: 10）
  - セッション固定化攻撃（スコア: 8）
  - CSRF対策不足（スコア: 8）
  - ディレクトリトラバーサル（スコア: 9）

- **非推奨・危険な関数**
  - mysql_*関数の使用（スコア: 7）
  - extract()の危険な使用（スコア: 6）
  - eval()の使用（スコア: 9）

- **エラー処理**
  - エラー表示有効（スコア: 5）
  - 例外処理不足（スコア: 4）

## 使用方法

```bash
# PHPファイルのインデックス作成
py codex_review_severity.py index ./src/php

# 分析実行
py codex_review_severity.py advise --topk 10 --out reports/php_analysis
```

## サンプルファイル

`src/php/`フォルダに以下のテスト用PHPファイルを配置：

1. **vulnerable_login.php** - 脆弱なログイン実装（多数の問題を含む）
2. **secure_login.php** - セキュアなログイン実装（ベストプラクティス）
3. **ecommerce_cart.php** - ECサイトのカート実装（金額計算とDB問題）

## 検出可能な問題

### セキュリティ
- SQLインジェクション: `$_GET['id']`を直接SQL文に結合
- XSS: `echo $_GET['name']`のようなエスケープなし出力
- ファイルインクルード: `include($_GET['page'])`
- コマンドインジェクション: `system($_GET['cmd'])`

### パフォーマンス
- N+1問題: ループ内でのSQL実行
- 大量データ取得: `SELECT * ... LIMIT 10000`
- 多重JOIN: 5つ以上のテーブル結合

### 金額処理
- float/double型での金額計算
- 税計算での端数処理問題

## テスト結果

実行例：
```
[OK] Indexed 3 files -> .advice_index.jsonl
検出された問題:
- vulnerable_login.php: 危険度52（緊急）
- ecommerce_cart.php: 危険度50（緊急）
- secure_login.php: 危険度13（正常）
```

## 今後の拡張

- Laravel/Symfonyフレームワーク固有の問題検出
- Composerパッケージの脆弱性チェック
- PSR標準準拠チェック