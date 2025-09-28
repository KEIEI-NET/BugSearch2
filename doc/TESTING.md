# 大規模インデックス検証手順

本ドキュメントは Codex Review CLI 群に対して、規模別のインデックス／助言動作を確認するための手順をまとめたものです。開発者や採用チームは以下のシナリオを順に実施し、処理時間・生成物・ログの内容を記録してください。

## 前提条件
- Python 3.11 以上
- 依存パッケージ（`chromadb`, `openai`, `scikit-learn`, `joblib`, `regex`, `chardet`）をインストール済み（仮想環境推奨）
- CLI が配置されたルートディレクトリで実行する
- `.env` に必要な OpenAI 設定がある場合は適宜セットする（AI モード検証時のみ）
- 大規模ケースでは十分なディスク空き領域（インデックス＋レポート出力用）を確保する

## テスト対象 CLI
| CLI | 主用途 | 備考 |
| --- | --- | --- |
| `codex_review.py` | 基本版 | 最小構成、軽量なハイブリッドモード |
| `codex_review_optimized.py` | 全件処理 / 大規模向け | バッチ処理・AI 全件レビュー対応 |
| `codex_review_enhanced.py` | エンコーディング自動判定 | 文字コード混在リポジトリで必須 |
| `codex_review_severity.py` | 重要度ソート | 重大度順にレポート整理 |
| `codex_review_with_solutions.py` | 改善コード生成 | GPT 出力で修正案を得る |
| `codex_review_ultimate.py` | 2 段階解析 | ルール＋AI を分離、最も重厚なワークフロー |

各 CLI の `index` コマンドは以下の共通オプションを備えています:
- `--batch-size`: 書き出しバッチ件数（既定 500、0 で無効）
- `--max-files`: インデックスする最大ファイル数
- `--max-seconds`: 指定秒数を超えたら処理打ち切り
- `--include` / `--exclude`: glob パターンによる対象選別
- `--profile-index` / `--profile-output`: プロファイル計測出力

## シナリオ一覧
| シナリオ | 想定ファイル数 | 推奨設定例 | 目的 |
| --- | --- | --- | --- |
| S-50 | 約 50 ファイル | `--profile-index --profile-output reports/profile_50.csv` | 回帰テスト（高速確認） |
| S-500 | 約 500 ファイル | `--batch-size 300` | バッチ動作とメモリ消費を確認 |
| S-5000 | 約 5,000 ファイル | `--batch-size 300 --max-seconds 600` | 長時間処理・ログ粒度確認 |
| S-10000+ | 10,000〜30,000 ファイル | `--batch-size 200 --max-seconds 900 --include src/**` など | 制限動作、部分的インデックスの有効性確認 |

> **補足:** リポジトリに対してファイル数をコントロールできない場合は、サンプル生成スクリプトでダミーファイルを作成するか、`--include` / `--exclude` で範囲を調整してください。

## 検証フロー
1. **前処理**: 既存インデックス／キャッシュ／レポートを削除
   ```bash
   rm -f .advice_index.jsonl .advice_tfidf.pkl .advice_matrix.pkl
   rm -rf reports
   ```
2. **インデックス計測**: 各 CLI で対象リポジトリをインデックス化
   ```bash
   python codex_review.py index /path/to/repo \
     --profile-index --profile-output reports/profile_codex_review.csv \
     --batch-size 300 --max-files 10000 --max-seconds 900
   ```
   - コンソールに出力される `[PROFILE]` と警告メッセージを記録
   - `reports/profile_*.csv`（または `.jsonl`）を保存して比較
3. **助言コマンド確認** (`query` / `advise`)
   - ランタイムが許容範囲内か、レポートが出力されるか
   - AI モードを利用する場合はバッチ数と API 応答を確認
4. **リソース監視**
   - CPU/メモリ使用率を OS ツールで記録（`top`, `htop`, Windows リソースモニタ等）
   - `--max-seconds` や `--max-files` による停止が期待通り働くか確認
5. **ログと生成物の確認**
   - `reports/large_files_over_limit.log` が生成されているか
   - インデックス中に `limit_stop`・`timeout_stop` が発生した場合のログを残す

## 記録すべき指標
- 処理時間（`time` コマンドやプロファイル出力）
- インデックス件数とスキップ件数（プロファイル統計の `indexed_files`、`skipped_*`）
- バッチ書き出し回数と平均処理時間（`avg_read_per_file`、`write_seconds`）
- CLI 実行時のログの抜粋（特に `[INFO] Stopped due to --max-files limit` 等）
- レポートファイルサイズおよび生成件数

## トラブルシューティング
| 症状 | 対処 |
| --- | --- |
| タイムアウトで処理が終わらない | `--batch-size` を減らす、`--max-seconds` を延長、`--include` で対象絞り込み |
| メモリ不足 | 小さめのバッチサイズ（200以下）に設定、`--max-files` で段階的に処理 |
| AI レビュー中のレート制限 | `advise` 実行前にインデックスのみを行い、AI コールを `query` に限定 |
| エンコーディングエラー | `codex_review_enhanced.py` または `codex_review_ultimate.py` を使用し、ログに出力されたファイルを重点的に確認 |

## レポート提出テンプレート（例）
```
### インデックス検証結果
- CLI: codex_review_ultimate.py
- リポジトリ: /data/projects/huge-repo (約 12,300 ファイル)
- 実行コマンド: python codex_review_ultimate.py index . --batch-size 250 --max-seconds 900 --profile-index --profile-output reports/profile_ultimate.jsonl
- 所要時間: 742 秒
- 結果: indexed=11,845 / seen=12,300, skipped_filter=320, skipped_large=45, timeout_stop=1
- 備考: timeout_stop により一部ファイル未処理。`--max-seconds` を 1200 に設定して再実行予定。
```

## 今後の改善候補
- ベンチマーク結果を継続的に追記し、各 CLI の推奨設定値を更新する
- 実行ログを集約するスクリプト（CSV→Markdown サマリ）を追加検討
- 並列処理導入後は本ドキュメントの指標項目（CPU 使用率など）を再評価

---

## 実測結果（2025-09-28 Claude Code実行）

### テスト環境
- **実行環境**: Claude Code (Windows 10)
- **対象リポジトリ**: 約27,940ファイル（内15,751がテキストファイル）
- **実行ツール**: codex_review_ultimate.py

### 実測データ

| シナリオ | ファイル数 | 実行時間 | 読込時間 | 平均読込/ファイル | stat時間 | 書込時間 | スキップ(大) | スキップ(エラー) |
|---------|-----------|---------|---------|------------------|---------|---------|------------|---------------|
| S-50    | 50        | 5.52秒  | 0.18秒  | 3.7ms           | 1.13秒  | 0.001秒 | 7          | 27            |
| S-500   | 500       | 7.30秒  | 2.56秒  | 5.1ms           | 0.74秒  | 0.011秒 | 6          | 27            |
| S-5000  | 5,000     | 43.19秒 | 32.12秒 | 6.4ms           | 0.77秒  | 0.241秒 | 7          | 27            |
| S-10000 | 10,000    | 88.50秒 | 70.75秒 | 7.1ms           | 0.77秒  | 0.473秒 | 7          | 27            |

### 実行コマンド例
```bash
# 50ファイルテスト
py codex_review_ultimate.py index . --max-files 50 --profile-index --profile-output reports/test_50.csv

# 500ファイルテスト（バッチサイズ100）
py codex_review_ultimate.py index . --max-files 500 --batch-size 100 --profile-index --profile-output reports/test_500.csv

# 5000ファイルテスト（バッチサイズ500、タイムアウト5分）
py codex_review_ultimate.py index . --max-files 5000 --batch-size 500 --max-seconds 300 --profile-index --profile-output reports/test_5000.csv

# 10000ファイルテスト（バッチサイズ500、タイムアウト10分）
py codex_review_ultimate.py index . --max-files 10000 --batch-size 500 --max-seconds 600 --profile-index --profile-output reports/test_10000.csv
```

### パフォーマンス分析
- **処理速度**: 約113ファイル/秒（10,000ファイルベース）
- **ボトルネック**: ファイル読込が処理時間の約80%を占める
- **スケーラビリティ**: ほぼリニアな性能（ファイル数に比例）
- **メモリ使用**: バッチ処理により安定（10,000ファイルで.advice_index.jsonlが約181MB）

### 観測された挙動
- stat操作時間はキャッシュ効果により一定（約0.77秒）
- 書込時間はファイル数に比例して増加
- --max-filesによる制限が正常に機能（limit_stop=1）
- 大容量ファイルスキップが適切に動作

### 推奨設定（実測ベース）
- **〜1,000ファイル**: `--batch-size 100`
- **1,000〜5,000ファイル**: `--batch-size 250`
- **5,000〜10,000ファイル**: `--batch-size 500 --max-seconds 300`
- **10,000ファイル以上**: 段階的実行を推奨（`--max-files 10000`ずつ）

### 今後の改善点
- 並列読込実装によるI/Oボトルネック改善（予想効果: 2-3倍高速化）
- インクリメンタル更新による差分処理（予想効果: 90%以上の処理時間削減）

