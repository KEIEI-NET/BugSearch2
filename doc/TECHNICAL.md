# 技術仕様書

*バージョン: v5.0.0 (GUI Production v1.0.0 対応)*  
*最終更新: 2025年10月21日*  
*作成者: KEIEI.NET INC.*

## システムアーキテクチャ

### 概要
BugSearch2 v5.0.0は、GUI Production v1.0.0の正式リリースにより、本番環境で動作保証されたGUIとCLIの両方を提供する統合コードレビューシステムです。34,125ファイルの処理成功実績を持ち、リアルタイム進捗トラッキング、unbuffered output対応により、大規模プロジェクトでも安定稼働します。

### アーキテクチャ構成

#### 1. GUI Production v1.0.0 アーキテクチャ

**コンポーネント構成**:
```
gui_production.py (v1.0.0)
├── BugSearchProduction (メインクラス)
│   ├── UI Components
│   │   ├── IndexTab (インデックス作成)
│   │   ├── AdviseTab (AI分析)
│   │   └── QueryTab (検索機能)
│   ├── Process Management
│   │   ├── subprocess.Popen (プロセス起動)
│   │   ├── unbuffered output (リアルタイムログ)
│   │   └── threading.Thread (非同期処理)
│   └── Progress Tracking
│       ├── File Counter (12,500 / 34,125 files)
│       ├── Speed Calculator (97 files/sec)
│       └── ETA Calculator (残り時間表示)
└── Queue System
    └── queue.Queue (スレッド間通信)
```

**技術スペック**:
- **UI Framework**: CustomTkinter 5.2.2
- **Python Version**: 3.11.9+
- **Process Control**: subprocess (unbuffered mode)
- **Threading**: threading + queue.Queue
- **Real-time Log**: line-buffered stdout/stderr

**パフォーマンス実績**:
```yaml
処理ファイル数: 34,125
平均処理速度: 97 files/sec
所要時間: 5分52秒
ログ更新頻度: 500ファイルごと
メモリ使用量: 最大512MB
CPU使用率: 平均25%
```

#### 2. CLI アーキテクチャ

**3段階パイプライン**:
```
1. Index Stage
   └── codex_review_severity.py index
       ├── ソースファイル解析
       ├── タグ生成（56種類）
       └── .advice_index.jsonl 生成

2. Advise Stage
   └── codex_review_severity.py advise
       ├── YAMLルール適用（64個）
       ├── AI分析（Claude/GPT）
       └── レポート生成

3. Apply Stage
   └── apply_improvements_from_report.py
       ├── AI改善コード解析
       ├── アトミック更新
       └── ロールバック機能
```

### GUI Production v1.0.0 詳細仕様

#### 1. リアルタイム進捗トラッキング

**実装方式**:
```python
# unbuffered output設定
process = subprocess.Popen(
    cmd,
    stdout=subprocess.PIPE,
    stderr=subprocess.STDOUT,
    text=True,
    bufsize=1,  # line-buffered
    universal_newlines=True,
    env={**os.environ, 'PYTHONUNBUFFERED': '1'}
)

# 進捗パース正規表現
patterns = {
    'file_count': r'処理中: (\d+)/(\d+) files',
    'percentage': r'進捗: (\d+)%',
    'speed': r'速度: (\d+) files/sec',
    'eta': r'残り時間: (.+)'
}
```

#### 2. インテリジェント進捗計算

**アルゴリズム**:
```python
def calculate_progress(self):
    # ファイル数ベース進捗
    if self.total_files > 0:
        file_progress = self.processed_files / self.total_files
    
    # 処理速度計算（移動平均）
    if len(self.speed_history) > 0:
        avg_speed = sum(self.speed_history[-10:]) / len(self.speed_history[-10:])
    
    # ETA計算
    if avg_speed > 0:
        remaining_files = self.total_files - self.processed_files
        eta_seconds = remaining_files / avg_speed
        return self.format_time(eta_seconds)
```

#### 3. 準備中メッセージシステム

**段階的メッセージ表示**:
```python
preparation_messages = [
    "プロジェクトを解析中...",
    "ファイルをスキャン中...",
    "インデックスを準備中...",
    "分析エンジンを初期化中...",
    "まもなく開始します..."
]
```

### YAMLルールシステム v4.11.8

#### ルール構成（64個）

**データベース別ルール**:
- **Cassandra**: 9ルール (529行)
- **Elasticsearch**: 8ルール (477行)
- **Redis**: 8ルール (570行)
- **MySQL**: 7ルール (420行)
- **PostgreSQL**: 9ルール (650行)
- **SQL Server**: 8ルール (720行)
- **Oracle**: 8ルール (730行)
- **Memcached**: 7ルール (680行)

#### C++/Angular誤検出修正

**問題と解決**:
```yaml
# 修正前（誤検出あり）
cpp:
  - pattern: 'new\s+\w+(?!\s*\([^)]*\))(?!.*delete)'
    # Angular: new HttpClient() を誤検出

# 修正後（C++のみ検出）
cpp:
  - pattern: '\w+\s*\*\s*\w+\s*=\s*new\s+\w+'
    # C++: Type* ptr = new Type のみ検出
```

### タグシステム（56種類）

#### タグ分類

**1. 言語タグ（9種類）**:
```
lang-python, lang-javascript, lang-typescript,
lang-php, lang-csharp, lang-java, lang-go,
lang-cpp, lang-delphi
```

**2. 技術スタックタグ（22種類）**:
```
Frontend: tech-react, tech-angular, tech-vue, tech-svelte
Backend: tech-express, tech-nestjs, tech-fastapi, tech-django
Database: tech-elasticsearch, tech-cassandra, tech-mongodb
```

**3. トピックタグ（18種類）**:
```
topic-security, topic-performance, topic-database,
topic-solid, topic-best-practices, topic-error-handling
```

### 並列処理システム

#### 設定（batch_config.json）

```json
{
  "parallel_config": {
    "parallel_workers": 10,
    "batch_size": 50,
    "timeout_per_file": 360,
    "max_retries": 3
  }
}
```

#### パフォーマンス最適化

**Phase 7.0 大規模処理**:
- 30,000+ファイル対応
- 15,889 files/sec達成
- メモリ増加: +3.79MB
- チェックポイント/再開機能

### セキュリティ機能

#### v4.0.0 セキュリティ強化

**100/100セキュリティスコア達成**:
1. **パストラバーサル防止**: ホワイトリスト + シンボリックリンクチェック
2. **TOCTOU保護**: stat → open間の競合状態防止
3. **アトミック更新**: tempfile + fsync + atomic rename
4. **ファイルロック**: Windows(msvcrt) / Unix(fcntl)
5. **Unicode攻撃防止**: C0/C1/BIDI制御文字検出
6. **ReDoS軽減**: ファイルサイズ制限 + コンパイル済み正規表現

### AIプロバイダー統合

#### マルチプロバイダー対応

**優先順位**:
```python
providers = [
    ('anthropic', 'claude-3-5-sonnet-20241022'),
    ('openai', 'gpt-4o'),
    ('openai', 'gpt-4o-mini')
]
```

**深刻度別モデル選択**:
- **重大（15+）**: Opus 4.1 / GPT-4o
- **高（10-14）**: Sonnet 4.5 / GPT-4o
- **中（5-9）**: Sonnet 4.1 / GPT-4o-mini

### エンコーディング処理

#### 自動検出チェーン

```python
encoding_chain = [
    'utf-8-sig',  # BOM付きUTF-8
    'utf-8',      # 標準UTF-8
    'cp932',      # Windows日本語
    'shift_jis',  # Shift_JIS
    'euc-jp',     # EUC-JP
    'latin1'      # フォールバック
]
```

### テスト品質指標

#### Phase別テスト結果

| Phase | テスト数 | 成功率 | 品質レベル |
|-------|---------|--------|-----------|
| Phase 8.5 | 8/8 | 100% | @perfect |
| Phase 8.4 | 15/15 | 100% | @perfect |
| Phase 8.2 | 9/9 | 100% | @perfect |
| Phase 7.0 | 17/17 | 100% | @tdd |
| Phase 6.1 | 14/14 | 100% | @perfect |
| Phase 5.0 | 9/9 | 100% | @perfect |
| Phase 4.4 | 6/6 | 100% | @perfect |

### システム要件

#### 最小要件
- Python 3.11+
- RAM: 4GB
- Storage: 1GB
- CPU: 2コア

#### 推奨要件
- Python 3.11.9+
- RAM: 8GB+
- Storage: 5GB+
- CPU: 4コア+
- OS: Windows 11 / macOS 13+ / Ubuntu 22.04+

### デプロイメント

#### Docker対応

```dockerfile
# CLI版
docker-compose up -d bugsearch-cli

# GUI版（X11設定必要）
docker-compose up -d bugsearch-gui
```

#### 起動スクリプト

```bash
# Production GUI（推奨）
start_gui.bat        # Windows
./start_gui.sh       # macOS/Linux

# Full Feature GUI
start_gui_full.bat   # Windows
./start_gui_full.sh  # macOS/Linux
```

---

*作成者: KEIEI.NET INC.*  
*最終更新: 2025年10月21日*  
*バージョン: v5.0.0*

**更新履歴:**
- v5.0.0 (2025年10月21日): GUI Production v1.0.0対応、34,125ファイル処理実績追加
- v4.11.8 (2025年10月17日): YAMLルール構文エラー修正、C++/Angular誤検出修正
- v4.11.7 (2025年10月14日): Phase 8.5完了、レポート生成バグ修正
- v4.11.6 (2025年10月14日): Phase 8.4完了、デフォルト設定システム実装