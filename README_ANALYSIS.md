# 🔍 ソースコード危険度分析システム

## 概要

このシステムは、大規模なソースコードベースから潜在的な問題を検出し、詳細な改善提案を生成します。

## 🚀 新機能（2024年9月更新）

### ✨ 主要な改善点

1. **ソースコード全体分析**
   - ファイル全体を分析（行数制限撤廃）
   - 全ての問題箇所を検出

2. **完全な改善コード提供**
   - 実装可能な完全版コード
   - 修正前・修正後の両方を提示

3. **行単位の問題検出**
   - 各行の問題を特定
   - 具体的な修正案を行番号付きで提示

4. **レポート構成の改善**
   - 概要レポート: 問題ファイル一覧
   - 詳細レポート: 完全な改善提案

## 📁 ファイル構成

### コアスクリプト
```
codex_review_severity.py     # 危険度分析エンジン
analyze_dangerous_files_detailed.py  # 詳細分析スクリプト（新）
create_overview_report.py    # 概要レポート生成
merge_detailed_reports.py    # バッチレポート統合（新）
```

### 廃止予定スクリプト
```
analyze_dangerous_files.py   # 旧分析スクリプト（廃止）
analyze_dangerous_files_batch.py  # 旧バッチ処理（廃止）
merge_batch_reports.py       # 旧統合スクリプト（廃止）
```

### バッチファイル
```
run_detailed_analysis.bat    # 全自動実行（推奨）
```

## 🎯 使用方法

### 1. クイックスタート（推奨）

```batch
# 全自動で分析実行（ファイル数自動検出版）
run_detailed_analysis_auto.bat

# または従来版（15710ファイル固定）
run_detailed_analysis.bat
```

### 2. 手動実行

#### Step 1: インデックス作成
```bash
py -3 codex_review_severity.py index ./src --profile-index
```

#### Step 2: 危険度分析

⚠️ **重要**: `--topk` パラメータを必ず指定してください！
- **指定なし**: デフォルト80ファイルのみ分析（全体の0.5%）
- **全ファイル分析**: インデックス作成時の indexed 数を指定

```bash
# インデックス作成時に表示された indexed 数を確認
# 例: [SUMMARY] indexed=15710 と表示された場合

# その数を --topk に指定して全ファイル分析
py -3 codex_review_severity.py advise --topk 15710 --out reports/src_complete_danger_analysis.md

# または新機能: --all オプションで自動的に全ファイル分析
py -3 codex_review_severity.py advise --all --out reports/src_complete_danger_analysis.md

# 部分的に分析（例：上位1000ファイル）
py -3 codex_review_severity.py advise --topk 1000 --out reports/partial_analysis.md
```

#### Step 3: 概要レポート生成
```bash
py -3 create_overview_report.py
```

#### Step 4: 詳細分析（バッチ処理）
```bash
# 各バッチを実行（500ファイルずつ）
py -3 analyze_dangerous_files_detailed.py 1
py -3 analyze_dangerous_files_detailed.py 2
py -3 analyze_dangerous_files_detailed.py 3
py -3 analyze_dangerous_files_detailed.py 4
py -3 analyze_dangerous_files_detailed.py 5
py -3 analyze_dangerous_files_detailed.py 6
```

#### Step 5: レポート統合
```bash
py -3 merge_detailed_reports.py
```

## 📊 生成されるレポート

### 概要レポート
- `reports/AI分析.md`
  - 問題ファイル一覧（2,600件）
  - 危険度別分類
  - ファイルパスと主要問題

### 詳細レポート
- `reports/AI分析_詳細_改善版_完全版.md`
  - 全ファイルの統合レポート
  - 完全な改善コード
  - 行単位の問題分析

- `reports/AI分析_詳細_改善版_batch1-6.md`
  - バッチごとの個別レポート
  - 各500ファイル（最後は100ファイル）

## 🎨 検出される問題

### 1. 金額計算問題
- float/double型の使用
- 丸め誤差のリスク
- → decimal型への変換提案

### 2. データベース問題
- N+1クエリ問題
- SELECT * の使用
- → 最適化クエリの提案

### 3. セキュリティ問題
- 入力検証不足
- SQLインジェクション脆弱性
- XSS攻撃の可能性
- → サニタイズ処理の追加

### 4. UIパターン問題
- ダイアログの多用
- → 改善案の提示

## 📈 危険度スコア

| スコア | 危険度 | 対応優先度 | ファイル数 |
|--------|--------|------------|-----------|
| 15以上 | 緊急 | 即座に対応 | 392 |
| 10-14 | 高 | 今週中 | 423 |
| 5-9 | 中 | 今月中 | 1,785 |
| 1-4 | 低 | 計画的に | 0 |

## ⚡ パフォーマンス

- インデックス作成: 約27秒（15,710ファイル）
- 危険度分析: 約10秒（インクリメンタル更新）
- 詳細分析: 各バッチ約100秒（500ファイル）
- 総処理時間: 約15分（2,600ファイル）

## 🔧 トラブルシューティング

### Codex 120秒タイムアウト
- バッチ処理で回避済み
- 各バッチ500ファイル以下

### 文字エンコーディングエラー
- 自動検出機能実装済み
- UTF-8, CP932, Shift-JIS, Latin-1対応

### メモリ不足
- バッチ処理により解決
- 必要に応じてバッチサイズ調整可能

## 📝 改善提案の適用

1. **バックアップ作成**
   ```bash
   git add -A
   git commit -m "Before applying AI improvements"
   ```

2. **改善コード適用**
   - レポートから該当部分をコピー
   - 既存コードと置き換え

3. **テスト実行**
   ```bash
   # ユニットテスト
   dotnet test

   # 統合テスト
   npm test
   ```

4. **検証項目**
   - 金額計算の精度
   - クエリパフォーマンス
   - セキュリティ脆弱性
   - UI/UXの改善

## 🤝 サポート

問題が発生した場合は、以下を確認してください：

1. Python 3.8以上がインストールされているか
2. 必要なライブラリがインストールされているか
3. `./src`ディレクトリが存在するか
4. 十分なディスク容量があるか

---

最終更新: 2024年9月28日
バージョン: 2.1.0（Windows対応強化版）

## ⚠️ Windows環境での注意点

### v2.1.0での修正
- Windowsコンソール（cp932）でのUnicodeエンコーディングエラーを解決
- すべてのPythonスクリプトから絵文字を削除
- レポートファイル自体はUTF-8で保存（絵文字含むマークダウンは問題なし）