# 📁 現在のファイル構成

## 🎯 実行に必要なファイル

### コアスクリプト（4ファイル）
```
codex_review_severity.py              # 危険度分析エンジン（メイン）
analyze_dangerous_files_detailed.py   # 詳細分析スクリプト
create_overview_report.py             # 概要レポート生成
merge_detailed_reports.py             # バッチレポート統合
```

### 実行用バッチファイル（2ファイル）
```
run_detailed_analysis_auto.bat        # 全自動実行（ファイル数自動検出）
run_detailed_analysis.bat             # 全自動実行（15710固定）
```

### ドキュメント（4ファイル）
```
README.md                              # プロジェクト全体の説明
README_ANALYSIS.md                     # 分析システムの説明
MIGRATION_GUIDE.md                     # 移行ガイド
CURRENT_FILES.md                       # このファイル
```

### その他のドキュメント（3ファイル）
```
AGENTS.md                              # エージェントの説明
Todo.md                                # タスクリスト
説明.md                                # 日本語での説明
```

## 📊 生成されるファイル

### インデックスファイル
```
.advice_index.pickle                   # ベクトルインデックス
.advice_index.meta.json               # メタデータ
```

### レポートファイル
```
reports/
  ├── AI分析.md                        # 概要レポート（問題ファイル一覧）
  ├── src_complete_danger_analysis.md # 危険度分析結果
  ├── AI分析_詳細_改善版_batch1.md    # バッチ1詳細（作成時）
  ├── AI分析_詳細_改善版_batch2.md    # バッチ2詳細（作成時）
  ├── AI分析_詳細_改善版_batch3.md    # バッチ3詳細（作成時）
  ├── AI分析_詳細_改善版_batch4.md    # バッチ4詳細（作成時）
  ├── AI分析_詳細_改善版_batch5.md    # バッチ5詳細（作成時）
  ├── AI分析_詳細_改善版_batch6.md    # バッチ6詳細（作成時）
  └── AI分析_詳細_改善版_完全版.md    # 統合レポート（作成時）
```

### プロファイルファイル
```
src_scan_profile.csv                   # スキャンプロファイル（作成時）
```

## 🗑️ 削除されたファイル

### 旧バージョンのスクリプト
- analyze_dangerous_files.py （旧分析スクリプト）
- analyze_dangerous_files_batch.py （旧バッチ処理）
- merge_batch_reports.py （旧統合スクリプト）
- codex_review.py （旧バージョン）
- codex_review_enhanced.py
- codex_review_optimized.py
- codex_review_performance.py
- codex_review_ultimate.py
- codex_review_with_solutions.py

### テストスクリプト
- run_full_test.py
- test_index_small.py
- test_small_incremental.py
- test_summary_log.py

### 旧ドキュメント
- CLI_COMPARISON.md
- INSPECTION_RESULTS.md
- PERFORMANCE_REPORT.md
- README_optimized.md
- SETUP_GUIDE.md

### 旧レポート
- 各種テストレポート
- 旧形式のバッチレポート

## 📝 合計ファイル数

- **必須ファイル**: 5個（スクリプト4個 + バッチ1個）
- **ドキュメント**: 7個
- **総ファイル数**: 12個（クリーンアップ後）

---

最終更新: 2024年9月28日
バージョン: 2.1.0

## 🔄 最新の変更

### v2.1.0 (2024-09-28)
- **Windows環境対応強化**: cp932エンコーディングエラーの修正
- **絵文字削除**: すべてのPythonスクリプトからUnicode絵文字を削除
  - `codex_review_severity.py`: 問題分布セクションの絵文字削除
  - `analyze_dangerous_files_detailed.py`: レポートヘッダーの絵文字削除
  - `create_overview_report.py`: 概要レポートの絵文字削除
  - `merge_detailed_reports.py`: 統合レポートの絵文字削除

### v2.0.0 (2024-09-28)
- **--allオプション追加**: 全ファイル自動分析機能
- **バッチ処理改善**: 120秒タイムアウト対策強化
- **完全な改善コード提供**: 実装可能な完全版コード生成