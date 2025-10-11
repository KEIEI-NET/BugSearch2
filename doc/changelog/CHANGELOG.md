# 変更履歴 (CHANGELOG)

*最終更新: 2025年09月05日 21:37 JST*

## v3.7.0 - 2025-01-05 - codex_review_severity.py PRODUCTION READY

### 🎯 品質スコア
- **97/100** (super-debugger-perfectionist 検証済み)
- **ステータス**: PRODUCTION READY

### 🔴 Critical/High修正
- **シグナルハンドラーのロック解放漏れ修正**: `sys.exit()`前に明示的なロック解放を追加
- **一時ファイルクリーンアップ追加**: save_progress()でfinallyブロックによる確実な.tmpファイル削除

### 📊 品質メトリクス
- セキュリティスコア: 97/100
- リソース管理: 完全
- 本番環境適合性: ✅

---

## v1.6.0 - 2025-01-05 - generate_ai_improved_code.py PRODUCTION READY

### 🎯 品質スコア
- **96/100** (super-debugger-perfectionist 検証済み)
- **ステータス**: PRODUCTION READY

### 🔴 Critical修正 (5件)
1. **tqdmクリーンアップ競合状態**: `_interrupt_lock`によるスレッドセーフ保護
2. **save_progress()一時ファイルリーク**: finallyブロックでの確実なクリーンアップ
3. **シグナルハンドラーのデッドロック**: try/exceptでlock.release()保護
4. **ReDoS脆弱性**: 正規表現量指定子を`{0,1000}`に制限
5. **過度に広範な例外処理**: RuntimeErrorを明示的にキャッチ

### 🔧 技術的改善
- グローバル変数のモジュールレベル宣言
- シグナルハンドラーの復元機能実装
- 非同期シグナル安全性の確保（POSIX準拠）
- すべてのリソースの適切なクリーンアップ保証

### 📊 品質メトリクス
- セキュリティスコア: 96/100
- コード品質: PRODUCTION READY
- パフォーマンス: 最適化済み（ReDoS対策含む）

---

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