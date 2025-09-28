# 変更履歴 (CHANGELOG)

## v2.1.0 - 2024-09-28

### 🐛 バグ修正
- Windows環境でのUnicodeEncodeError（cp932コーデック）を修正
- すべてのPythonスクリプトから絵文字を削除し、Windows互換性を向上

### 📝 変更されたファイル
- `codex_review_severity.py` - 問題分布セクションの絵文字削除
- `analyze_dangerous_files_detailed.py` - レポートヘッダーの絵文字削除
- `create_overview_report.py` - 概要レポートセクションの絵文字削除
- `merge_detailed_reports.py` - 統合レポートの絵文字削除

### 🔧 改善点
- Windows環境でのコンソール出力の安定性向上
- クロスプラットフォーム互換性の改善

## v2.0.0 - 2024-09-28

### ✨ 新機能
- `--all` オプション追加 - インデックスされたすべてのファイルを自動的に分析
- ファイル数自動検出バッチファイル (`run_detailed_analysis_auto.bat`)
- 完全な改善コード提供機能
- ソースコード全体分析（行数制限撤廃）
- 行単位の問題検出と具体的な修正案提示

### 🚀 改善点
- バッチ処理の最適化（120秒タイムアウト対策）
- レポート構成の改善
- エンコーディング自動検出機能の強化

### 📋 廃止
- 旧バージョンのスクリプト群を削除
  - `analyze_dangerous_files.py`
  - `analyze_dangerous_files_batch.py`
  - `merge_batch_reports.py`
  - その他の旧バージョンファイル

## v1.0.0 - 2024-09-27

### 🎉 初回リリース
- 基本的な危険度分析機能
- インデックス作成機能
- レポート生成機能
- バッチ処理サポート

---

詳細な技術仕様については、[README_ANALYSIS.md](README_ANALYSIS.md) を参照してください。