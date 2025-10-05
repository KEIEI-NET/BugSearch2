# プロジェクト依存関係情報

## プロジェクト概要
**プロジェクト名**: Codex Review - AI Code Review System v3.1
**説明**: 静的コード解析とAI分析を組み合わせた高度なコードレビューシステム
**最終更新**: 2025年9月29日
**バージョン**: 3.1.0 - 並列処理＆エンコーディング対応版

## 開発環境
- **Python**: 3.12.10
- **OS**: Windows (MINGW64_NT-10.0-26100)
- **プラットフォーム**: win32

## コア依存パッケージ

### AI/機械学習関連
- **openai** - OpenAI APIクライアント（GPT-5, GPT-4oなど）
- **anthropic** (0.45.0) - Anthropic Claude APIクライアント
- **google-generativeai** (0.8.4) - Google Gemini APIクライアント
- **google-ai-generativelanguage** (0.6.15)

### データ処理・分析
- **chardet** (5.2.0) - 文字エンコーディング自動検出（日本語対応）
- **chromadb** - ベクトルデータベース（コード検索用）
- **scikit-learn** - 機械学習（TF-IDF、類似度計算）
- **joblib** - 並列処理、モデル永続化

### ユーティリティ
- **python-dotenv** - 環境変数管理（`.env`ファイル読み込み）
- **regex** - 高度な正規表現処理
- **pathlib** - ファイルパス操作（標準ライブラリ）

### HTTP/API通信
- **httpx** (0.28.1) - 非同期HTTPクライアント
- **httpcore** (1.0.7)
- **h11** (0.14.0)
- **certifi** (2024.12.14) - SSL証明書
- **charset-normalizer** (3.4.1)

### Google Cloud関連
- **google-auth** (2.38.0)
- **google-auth-httplib2** (0.2.0)
- **google-api-python-client** (2.159.0)
- **google-api-core** (2.24.0)
- **googleapis-common-protos** (1.66.0)
- **grpcio** (1.70.0)
- **grpcio-status** (1.70.0)
- **proto-plus** (1.25.0)
- **protobuf** (5.29.3)

### その他
- **anyio** (4.8.0) - 非同期処理統一インターフェース
- **cachetools** (5.5.1) - キャッシュ実装
- **colorama** (0.4.6) - ターミナル色付け（Windows対応）
- **annotated-types** (0.7.0) - 型アノテーション拡張
- **distro** (1.9.0) - Linuxディストリビューション情報
- **jiter** (0.8.2) - JSON高速パーサー

## インストールコマンド
```bash
pip install chromadb openai scikit-learn joblib regex chardet python-dotenv
```

## 環境変数設定 (.env)
```env
# 必須
OPENAI_API_KEY=your-openai-key

# モデル選択（デフォルト: gpt-4o）
# 利用可能: gpt-5-codex, gpt-5, gpt-5-mini, gpt-5-nano, gpt-4o
OPENAI_MODEL=gpt-5-codex
```

## 主要スクリプトと依存関係

### 1. コアシステム
- **codex_review_severity.py** - メインスクリプト（重要度順ソート）
  - 依存: openai, chromadb, scikit-learn, chardet
  - 機能: インデックス作成、ベクトル化、クエリ、AI分析

### 2. 並列処理版
- **extract_and_batch_parallel_enhanced.py** - 改良版（完全コード提供）
  - 依存: openai, concurrent.futures, threading
  - 機能: 10ワーカー並列処理、キャッシュ、自動レジューム

- **extract_and_batch_parallel.py** - 並列処理版
  - 依存: concurrent.futures, hashlib
  - 機能: MD5キャッシュ、動的モデル選択

### 3. モニタリング
- **monitor_parallel.py** - 進捗監視
  - 依存: json, pathlib, datetime
  - 機能: リアルタイム監視、ETA表示、停滞検出

### 4. ユーティリティ
- **fix_report_encoding.py** - レポート文字化け修正
  - 依存: chardet, pathlib

- **codex_review_with_retry.py** - リトライ機能付きAPI呼び出し
  - 依存: openai, time, random

### 5. 言語別対応
- **codex_review_severity.py** - 全言語対応スキャナー
  - 対応言語: C#, PHP, Go, C++, Python, JavaScript/TypeScript
  - PHP検出: SQLインジェクション、XSS、ファイルインクルード等（404-461行目）

## 設定ファイル

### batch_config.json
並列処理の詳細設定：
```json
{
  "parallel_config": {
    "batch_size": 50,
    "parallel_workers": 10,
    "api_delay": 0.1,
    "timeout_per_file": 60,
    "cache_dir": ".cache/analysis",
    "rate_limit_per_minute": 100
  }
}
```

## 対応言語
- **C#** - メイン対象（14,355ファイル）
- **PHP** - v3.1で追加（セキュリティ脆弱性検出）
- **Go** - goroutineリーク、エラーチェック不足
- **C++** - メモリリーク、バッファオーバーフロー
- **Python** - 汎用分析
- **JavaScript/TypeScript** - 汎用分析

## パフォーマンス特性
- **インデックス作成**: 1,195ファイル/約30秒（1MB制限）
- **ルール解析**: 50ファイル/約5秒
- **AI解析**: 1ファイル約2-3秒（並列10ワーカー）
- **推定処理時間**: 2,753ファイル = 約3-4時間（並列版）

## キャッシュ機構
- **ファイルキャッシュ**: `.cache/analysis/` (MD5ハッシュベース)
- **進捗ファイル**: `.batch_progress_parallel.json`
- **インデックス**: `.advice_index.jsonl` + `.advice_index.meta.json`
- **ベクトル**: `.advice_tfidf.pkl` + `.advice_matrix.pkl`

## API利用状況
- **OpenAI**: GPT-5-Codex (Responses API `/v1/responses`)
- **フォールバック**: gpt-4o (Chat Completions API)
- **レート制限**: 100リクエスト/分
- **タイムアウト**: 60秒/ファイル（AI分析）

## 注意事項
1. **ファイルサイズ制限**: デフォルト4MB（`--max-file-mb`で変更可）
2. **エンコーディング**: UTF-8, Shift_JIS, CP932, EUC-JP自動検出
3. **除外ディレクトリ**: .git, node_modules, dist, build等
4. **並列処理**: 共有ストレージでは`--worker-count 2`以下推奨

## トラブルシューティング用パッケージ
- **chardet** - エンコーディングエラー対策
- **colorama** - Windows ターミナル出力
- **cachetools** - API呼び出し削減
- **filelock** (3.16.0) - 並列処理のファイルロック

## 最終更新
2025-10-01
