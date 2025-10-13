# 技術仕様書

*バージョン: v4.11.7 (タグベース深刻度調整システム)*
*最終更新: 2025年10月14日 12:00 JST*

## システムアーキテクチャ

### 概要
BugSearch2 v4.11.7は、タグベース深刻度調整システムを実装し、56個のタグ情報とYAMLルールシステムを完全統合しました。従来8技術スタックのみ対応していた深刻度調整が、タグ情報の活用により22技術スタック（+14追加）に拡大し、.bugsearch.yml設定ファイルなしでも自動的に技術スタックを検出して適切な深刻度調整を適用します。v4.11.6のチェックボックスデフォルト設定、v4.11.5の64個の事前生成データベース最適化ルールと組み合わせることで、より高精度な静的解析とAI分析を実現します。**@perfect品質（全テスト100%合格）**を維持しています。

### v4.11.7 タグベース深刻度調整システムの新機能（2025年10月14日実装）

- ✅ **タグ統合ルールエンジン** (`core/models.py` - Rule._matches_condition()拡張)
  - YAMLルールシステムが56個のタグ情報を活用
  - .bugsearch.yml設定なしでも技術スタック自動検出
  - OR論理: 設定ファイル OR タグのいずれかで検出
  - 22技術スタック完全対応（従来8 → 新方式22）

- ✅ **深刻度調整API拡張** (`core/rule_engine.py`)
  - `adjust_severity_by_tech_stack(rule, tech_stack, severity, tags=[])`
  - `Rule.evaluate_severity(tech_stack, code_context, tags=[])`
  - `Rule._matches_condition(condition, tech_stack, code_context, tags=[])`
  - 全APIにタグパラメータ追加（オプショナル、後方互換性100%）

- ✅ **技術スタック名正規化**
  ```python
  # 例: "Entity Framework Core" → "tech-entity-framework-core"
  tech_normalized = tech_condition.lower().replace(' ', '-').replace('_', '-')
  tech_tag = f"tech-{tech_normalized}"
  has_in_tags = tech_tag in tags  # ["tech-entity-framework-core", "lang-csharp"]
  ```

- ✅ **実例: Elasticsearch N+1問題の深刻度調整**
  ```python
  # YAML定義 (rules/core/database/n-plus-one.yml)
  context_modifiers:
    - condition:
        tech_stack_has: "Elasticsearch"
        code_context: "search|index|elastic"
      action:
        severity_adjustment: -3
        note: "検索クエリはElasticsearchで処理されるため、N+1の影響は限定的"
  
  # タグベース検出（新機能）
  tags = ["tech-elasticsearch", "lang-typescript"]
  code = "await elastic.search({ index: 'users' })"
  
  severity, notes = adjust_severity_by_tech_stack(
      rule, TechStack(), base_severity=10, 
      code_context=code, tags=tags
  )
  # → severity = 7 (10 - 3)
  # → notes = ["検索クエリはElasticsearchで処理されるため..."]
  ```

- ✅ **カバレッジ拡大**
  - **従来方式 (v4.11.6以前)**: 
    - 8技術スタック対応（Cassandra, Django, Elasticsearch, Entity Framework Core, Laravel, Sequelize, Spring, Spring Boot）
    - .bugsearch.yml手動設定必須
  - **新方式 (v4.11.7)**:
    - 22技術スタック対応（+14技術スタック追加）
    - タグから自動検出（Angular, React, Vue, Express, Flask等）
    - 設定ファイル不要（ファイル単位の動的検出）

- ✅ **全テスト100%合格** (`test/test_tag_based_severity.py` - 5/5成功)
  ```python
  # テスト内訳:
  # 1. Elasticsearch検出（タグのみ） - 10→7深刻度調整 ✅
  # 2. React検出（タグのみ） - 9→7深刻度調整 ✅
  # 3. Django検出（設定+タグ併用） - 8→6深刻度調整 ✅
  # 4. Cassandra検出（設定のみ、後方互換） - 10深刻度維持 ✅
  # 5. n-plus-one.yml統合テスト - 実際のYAMLルールと正常連携 ✅
  ```

**技術的アーキテクチャ**:
```python
# core/models.py - Rule._matches_condition()
def _matches_condition(
    self,
    condition: Dict[str, Any],
    tech_stack: TechStack,
    code_context: str,
    tags: Optional[List[str]] = None
) -> bool:
    if 'tech_stack_has' in condition:
        tech_condition = condition['tech_stack_has']
        
        # 方法1: .bugsearch.yml設定から判定（既存）
        has_in_config = tech_stack.has_technology(tech_condition)
        
        # 方法2: タグから動的判定（新機能 v4.11.7）
        has_in_tags = False
        if tags:
            tech_normalized = tech_condition.lower().replace(' ', '-').replace('_', '-')
            tech_tag = f"tech-{tech_normalized}"
            has_in_tags = tech_tag in tags
        
        # OR論理: どちらかの方法で検出されればOK
        if not (has_in_config or has_in_tags):
            return False
    
    if 'code_context' in condition:
        pattern = condition['code_context']
        if not re.search(pattern, code_context, re.IGNORECASE):
            return False
    
    return True
```

**対応技術スタック（22種類）**:
```
フロントエンド (5種):
  - Angular, React, Vue, Svelte, Next.js

バックエンド (8種):
  - Django, Flask, Express, NestJS, Spring, Spring Boot, Laravel, ASP.NET Core

データベース (9種):
  - PostgreSQL, MySQL, SQL Server, MongoDB, Redis, 
    Elasticsearch, Cassandra, Oracle, Memcached
```

### v4.11.6 チェックボックスデフォルト設定システム（Phase 8.4）の新機能（2025年10月14日実装）

- ✅ **統一されたデフォルト設定管理** (`config/integration_test_defaults.yml` - マスター設定ファイル)
  - Context7統合分析のデフォルト（技術スタック、トピック）
  - 統合テストのデフォルト（プロジェクトタイプ、トピック、最大ファイルサイズ、ワーカー数）
  - インデックス作成のデフォルト（最大ファイルサイズ、ワーカー数、除外言語）
  - AI分析のデフォルト（完全レポート、最大完了項目数）
  - データベース統合テストのデフォルト（データベースタイプ、トピック）

- ✅ **IntegrationTestConfigManager** (`core/integration_test_config.py` - 375行)
  - シングルトンパターン実装（`get_config_manager()`グローバル関数）
  - YAML設定の読み込み・検証・保存
  - 5セクション×13メソッドのGetter/Setter API
  - 設定リセット機能（工場出荷時デフォルトに復元）
  - 設定リロード機能（ファイル変更の動的反映）
  - バリデーション機能（必須フィールド・セクション構造検証）

- ✅ **GUI統合** (`gui_main.py` - 設定タブ拡張)
  - **起動タブ**: チェックボックス初期化（行391-401, 455-462, 515-525, 570-580）
    - デフォルト設定に含まれる項目を自動チェック
    - Context7技術スタック×2、トピック×16
    - 統合テストプロジェクトタイプ×16、トピック×16
  - **設定タブ**: デフォルト設定管理UI（行769-834, 1264-1388）
    - サマリー表示（読み取り専用テキストボックス）
    - [設定ファイルを開く]ボタン（システムエディタで編集）
    - [表示を更新]ボタン（設定再読み込み+UI更新）
    - [デフォルトに戻す]ボタン（確認ダイアログ+リセット）

- ✅ **CUI統合** (`core/integration_test_engine.py` - main関数拡張)
  - オプション引数のデフォルト値対応（行678-778）
  - `--project-type`、`--topics`、`--max-file-mb`、`--worker-count`を省略可能に
  - 引数省略時にconfig_managerから自動取得
  - フォールバック機能（config_manager未インストール時はハードコード値）
  - INFOログでデフォルト使用を明示

- ✅ **全テスト100%合格** (`test/test_integration_test_config.py` - 15/15成功)
  ```python
  # テスト内訳:
  # - デフォルト設定ファイル自動生成
  # - Context7デフォルト設定取得
  # - 統合テストデフォルト設定取得
  # - インデックスデフォルト設定取得
  # - AI分析デフォルト設定取得
  # - Context7デフォルト設定保存
  # - 統合テストデフォルト設定保存
  # - 設定バリデーション（正常/異常）
  # - デフォルト設定へのリセット
  # - 設定ファイル再読み込み
  # - 利用可能技術スタック/トピック取得
  # - シングルトンパターン検証
  # - データベース統合テストデフォルト設定取得
  ```

**YAMLマスター設定構造**:
```yaml
version: "1.0.0"

# Context7統合分析のデフォルト設定
context7:
  default_tech_stacks:
    - react
    - angular
  default_topics:
    - security
    - performance
    - best-practices

# 統合テストのデフォルト設定
integration_test:
  default_project_types:
    - react
    - angular
    - vue
  default_topics:
    - security
    - performance
    - best-practices
    - error-handling
    - testing
  default_max_file_mb: 4
  default_worker_count: 4

# インデックス作成のデフォルト設定
index:
  default_max_file_mb: 4
  default_worker_count: 4
  default_exclude_langs: []

# AI分析のデフォルト設定
advise:
  default_complete_report: false
  default_max_complete_items: 100

# データベース統合テストのデフォルト設定
database_integration_test:
  default_database_types:
    - cassandra
    - elasticsearch
    - redis
  default_topics:
    - performance
    - security
    - best-practices
```

**GUI/CUI統合の動作フロー**:
```python
# GUI起動タブ - チェックボックス初期化
config_manager = get_config_manager()
default_tech_stacks = config_manager.get_context7_default_tech_stacks()

for tech, desc in TECH_STACKS:
    is_default = tech in default_tech_stacks  # デフォルト設定でチェック状態を決定
    var = ctk.BooleanVar(value=is_default)
    checkbox = ctk.CTkCheckBox(parent, text=desc, variable=var)

# CUI integration_test_engine - デフォルト値適用
if not args.project_type and config_manager:
    args.project_type = config_manager.get_integration_test_default_project_types()[0]
    print(f"[INFO] デフォルト設定からproject-type取得: {args.project_type}")
```

### v4.11.5 事前生成データベースルールの新機能（2025年10月14日実装）

- ✅ **8データベース×64ルール事前生成** (`rules/core/database/*.yml` - 計4,776行)
  - **Cassandra** (529行、9ルール): ALLOW FILTERING、巨大パーティション、トゥームストーン蓄積
  - **Elasticsearch** (477行、8ルール): 深いページング、ワイルドカード検索、マッピング爆発
  - **Redis** (570行、8ルール): KEYS *コマンド、大きなキー、Luaスクリプトブロッキング
  - **MySQL** (420行、7ルール): Prepared Statement未使用、インデックス欠損
  - **PostgreSQL** (650行、9ルール): VACUUM未実行、JSONB未インデックス
  - **SQL Server** (720行、8ルール): デッドロック、TEMPDB競合、パラメータスニッフィング
  - **Oracle** (730行、8ルール): 行ごとPL/SQL処理、ループ内Commit
  - **Memcached** (680行、7ルール): 長すぎるキー、キャッシュスタンピード

- ✅ **多言語パターン検出** - 各ルールで6+言語対応
  - Java, Python, JavaScript, C#, Go, PHP, SQL

- ✅ **深刻度スコアリング拡張**
  - **Critical (10)**: ALLOW FILTERING、深いページング (from+size>10000)、KEYS *コマンド
  - **High (9)**: 巨大パーティション、ワイルドカード検索、大きなキー
  - **Medium (7-8)**: セカンダリインデックス濫用、_allフィールド使用

- ✅ **パフォーマンス革命**
  - **旧版 (v4.11.4以前)**: Context7 API呼び出し (20-60秒) → YAML生成 → 検証
  - **新版 (v4.11.5)**: ルール読み込み (即座) → 分析開始
  - **結果**: 4-6倍の高速化達成

- ✅ **GUI統合拡張**
  - Context7タブに8データベース追加 (行372-374)
  - 統合テストタブに8データベース追加 (行485-487)
  - 合計16技術スタック対応 (8フレームワーク + 8データベース)

- ✅ **詳細な修正提案**
  - Bad/Good/Better/Bestの段階的コード例
  - 公式ドキュメントリファレンス
  - パフォーマンス影響の定量的説明 (例: 50倍高速化、1000倍高速化)

### 統合テストシステム仕様 (v4.11.5拡張)

#### IntegrationTestEngine アーキテクチャ
**場所**: `core/integration_test_engine.py`

**6ステップ自動ワークフロー**:
```python
@dataclass
class IntegrationTestConfig:
    """統合テスト設定"""
    project_type: str          # react, cassandra, elasticsearch等 (16種類)
    topics: List[str]          # 分析トピック（複数可、16種類）
    include_examples: bool = True
    test_dir: Path = Path("test_integration")
    timeout_seconds: int = 1800  # 30分
    max_file_mb: int = 4
    worker_count: int = 4

class IntegrationTestEngine:
    """6ステップ統合テストフロー"""

    def run_full_test(self) -> IntegrationTestResult:
        # Step 1: テストプロジェクト作成（意図的バグ埋め込み）
        self._setup_test_project()

        # Step 2: Context7分析実行（YAMLルール生成）
        self._run_context7_analysis()

        # Step 3: インデックス作成
        self._run_index_creation()

        # Step 4: AI分析実行 (--all --complete-report)
        self._run_ai_analysis()

        # Step 5: 改善コード適用 (--dry-run)
        self._run_code_improvement()

        # Step 6: 結果検証
        return self._verify_results()
```

**対応プロジェクトタイプ (16種類)**:
```python
PROJECT_TYPES = [
    # フレームワーク (8種類)
    'react', 'angular', 'vue', 'svelte',
    'express', 'nestjs', 'django', 'flask',

    # データベース (8種類)
    'cassandra', 'elasticsearch', 'redis',
    'mysql', 'postgresql', 'sqlserver',
    'oracle', 'memcached'
]
```

**分析トピック (16種類、複数選択可)**:
```python
TOPICS = [
    'security',           # セキュリティ脆弱性
    'performance',        # パフォーマンス最適化
    'best-practices',     # ベストプラクティス
    'error-handling',     # エラーハンドリング
    'testing',            # テスト品質
    'accessibility',      # アクセシビリティ
    'optimization',       # コード最適化
    'architecture',       # アーキテクチャ設計
    'patterns',           # デザインパターン
    'styling',            # スタイリング規約
    'state-management',   # 状態管理
    'routing',            # ルーティング
    'deployment',         # デプロイメント
    'monitoring',         # モニタリング
    'api-integration',    # API統合
    'data-validation'     # データ検証
]
```

**サンプルコードテンプレート（意図的バグ）**:
```typescript
// React サンプル - 4種類の意図的バグ
export const VulnerableComponent = ({ userInput }) => {
    // Bug 1: XSS脆弱性
    return <div dangerouslySetInnerHTML={{ __html: userInput }} />;
};

export const LeakyComponent = () => {
    // Bug 2: メモリリーク（cleanup不足）
    useEffect(() => {
        const interval = setInterval(() => {
            console.log('tick');
        }, 1000);
        // 🐛 clearInterval忘れ
    }, []);

    // Bug 3: 型安全性問題
    const data: any = fetchData();

    // Bug 4: パフォーマンス問題（useCallback不足）
    const handleClick = () => { /* ... */ };

    return <button onClick={handleClick}>Click</button>;
};
```

**GUI統合テスト起動**:
```python
# gui_main.py: 行360-424
def launch_integration_test(self):
    """統合テストをGUIから起動"""
    # プロジェクトタイプ選択
    selected_projects = [
        proj for proj, var in options_frame.project_checkboxes.items()
        if var.get()
    ]

    # トピック選択（複数可）
    selected_topics = [
        topic for topic, var in options_frame.topic_checkboxes.items()
        if var.get()
    ]

    # コマンド構築
    command = [
        'python', '-m', 'core.integration_test_engine',
        '--project-type', selected_projects[0],
        '--topics'
    ] + selected_topics

    # オプションパラメータ追加
    if hasattr(options_frame, 'max_file_mb_var'):
        command.extend(['--max-file-mb', options_frame.max_file_mb_var.get()])
    if hasattr(options_frame, 'worker_count_var'):
        command.extend(['--worker-count', options_frame.worker_count_var.get()])

    # ジョブ実行
    self.start_job(
        f"統合テスト ({selected_projects[0]})",
        command,
        JobPriority.HIGH
    )
```

**検証項目**:
1. ✅ YAMLルールファイルが正常に生成されたか
2. ✅ インデックスファイル (.advice_index.jsonl) が作成されたか
3. ✅ AIレポートに意図的バグが検出されたか
4. ✅ テストプロジェクトディレクトリが正常に作成されたか
5. ✅ 改善コード適用がdry-runで正常に実行されたか

### v4.11.0 GUI Control Center v1.0.0の新機能（2025年10月13日実装）

- ✅ **GUI Control Center** (`gui_main.py` - 348行)
  - CustomTkinter 5.2.0+によるモダンUI
  - 4タブ構成（起動/監視/設定/履歴）
  - ダーク/ライトテーマ対応
  - Windows/Mac/Linux完全対応

- ✅ **プロセス管理モジュール** (`gui/process_manager.py` - 459行)
  - psutil統合によるクロスプラットフォーム対応
  - プロセス起動/停止/一時停止/再開
  - 環境変数の動的設定
  - リアルタイムステータス監視

- ✅ **ログ収集システム** (`gui/log_collector.py` - 431行)
  - リアルタイムログストリーミング
  - ログレベル自動検出（INFO/WARNING/ERROR）
  - 進捗バーのパース（tqdm対応）
  - バッファリングとスレッドセーフ実装

- ✅ **キュー管理システム** (`gui/queue_manager.py` - 462行)
  - 優先度管理（URGENT/HIGH/NORMAL/LOW）
  - 依存関係グラフ管理
  - 最大並列度制御（デフォルト10）
  - ジョブ自動スケジューリング

- ✅ **状態管理モジュール** (`gui/state_manager.py` - 373行)
  - ウィンドウ状態の永続化
  - 設定ファイル管理（JSON形式）
  - ジョブ履歴の保存（最大1000件）
  - クラッシュリカバリー機能

- ✅ **テスト実装** (`test/test_gui_basic.py` - 244行)
  - 14テスト実装、13成功（93%合格率）
  - UnicodeEncodeError対策（Windows cp932対応）
  - モック使用による単体テスト

### GUI システムアーキテクチャ詳細

#### プロセス管理フロー
```mermaid
sequenceDiagram
    participant User
    participant GUI
    participant ProcessMgr
    participant QueueMgr
    participant Process
    participant LogCollector

    User->>GUI: ジョブ起動ボタンクリック
    GUI->>QueueMgr: add_job(job_config)
    QueueMgr->>QueueMgr: 優先度順ソート
    QueueMgr->>QueueMgr: 依存関係チェック
    QueueMgr->>ProcessMgr: start_process(command, env)
    ProcessMgr->>Process: subprocess.Popen()
    Process-->>ProcessMgr: PID返却
    ProcessMgr->>LogCollector: start_collecting(process)

    loop リアルタイム監視
        Process-->>LogCollector: stdout/stderr
        LogCollector->>LogCollector: ログレベル検出
        LogCollector->>LogCollector: 進捗パース
        LogCollector-->>GUI: ログエントリ送信
        GUI-->>User: UI更新
    end

    Process-->>ProcessMgr: 終了コード
    ProcessMgr->>QueueMgr: job_completed(job_id)
    QueueMgr->>GUI: 完了通知
    GUI-->>User: 完了表示
```

#### キュー管理アルゴリズム
```python
# 優先度順ソート + 依存関係考慮
def get_next_job(self):
    ready_jobs = []
    for job in self.queue:
        if self._dependencies_satisfied(job):
            ready_jobs.append(job)

    # 優先度でソート
    ready_jobs.sort(key=lambda x: (
        PRIORITY_ORDER[x['priority']],
        x['created_at']
    ))

    if ready_jobs and self.running_count < self.max_concurrent:
        return ready_jobs[0]
    return None
```

### v4.10.0 Phase 8.2の主な新機能（Context7統合 & AI自動修正）
- ✅ **Context7 MCP統合** (`core/config_generator.py` - 687行)
  - ライブラリID解決機能（resolve-library-id）
  - 技術ドキュメント取得API（get-library-docs）
  - 最新仕様に基づくYAML生成
- ✅ **AI自動YAML修正エンジン** (`fix_yaml_with_ai()` メソッド)
  - 検証エラーの自動修正（最大5回試行）
  - Anthropic Claude / OpenAI GPTマルチプロバイダー対応
  - プロンプトエンジニアリングによる正確な修正
- ✅ **完全自動実行フロー** (`run_full_analysis()` 関数)
  - YAML生成→検証→修正→index→adviseの一括実行
  - `--auto-run`フラグによるCLI統合
  - CI/CD対応のバッチ実行
- ✅ **5段階厳格検証システム**
  - YAMLスキーマ検証
  - 必須フィールドチェック
  - パターン妥当性検証
  - RuleValidator/RuleLoader統合
  - 詳細エラーメッセージ出力
- ✅ **対話型設定ウィザード** (`generate_tech_config.py` - 277行)
  - 技術スタック選択UI
  - カスタマイズオプション
  - ステップバイステップガイド
- ✅ **全テスト100%合格** (9/9成功)
  - Context7統合テスト: 7/7
  - YAML検証テスト: 1/1
  - AI自動修正テスト: 1/1

### v4.7.0 Phase 6の主な新機能（チーム協業）
- ✅ **レポート比較エンジン** (`core/report_comparator.py` - 305行)
  - レポート差分比較（新規・修正・悪化・未修正の自動分類）
  - 改善率計算（固定件数÷(新規+固定)）
  - Markdown形式の比較レポート生成
- ✅ **進捗トラッキングシステム** (`core/progress_tracker.py` - 372行)
  - スナップショット記録（問題数、深刻度、カテゴリ別統計）
  - トレンド分析（improving/worsening/stable）
  - 時系列での進捗レポート生成（30日/90日対応）
- ✅ **チームダッシュボード** (`dashboard/team_dashboard.py` - 380行)
  - Flask WebUI（統計表示、進捗グラフ）
  - 6つのREST APIエンドポイント（/api/stats, /api/progress, /api/compare, /api/reports, /health）
  - CORS対応、日本語対応（JSON_AS_ASCII=False）
- ✅ **全テスト100%合格** (14/14成功、2スキップ - Flask未インストール時)

### v4.6.0 Phase 5の主な新機能（リアルタイム解析）
- ✅ **ファイルウォッチャー機能** (`core/file_watcher.py` - 281行)
  - watchdogライブラリ統合（クロスプラットフォーム対応）
  - 12言語対応（C#, Java, PHP, JS/TS, Python, Go, C++, Ruby, Swift, Kotlin, Rust, Dart）
  - デバウンス処理（連続変更時の不要解析防止、デフォルト1.0秒）
  - イベントフィルタリング（modified/created/deleted）
- ✅ **差分解析エンジン** (`core/incremental_analyzer.py` - 298行)
  - Git diff統合（変更ファイル自動検出）
  - インクリメンタル解析（変更ファイルのみ再解析）
  - 10倍高速化（全体解析 vs 差分解析）
- ✅ **リアルタイム解析CLI** (`watch_mode.py` - 220行)
  - ファイル監視モード（保存時に自動解析実行）
  - 複数ディレクトリ監視対応
  - デバウンス設定（--debounce オプション）
- ✅ **全テスト100%合格** (9/9成功)

### v4.5.0 Phase 4.2の主な新機能（ルール共有・AI生成）
- ✅ **ルール共有システム** (`core/rule_sharing.py` - 289行)
  - YAML/JSONエクスポート機能
  - ルールインポート（バリデーション付き）
  - バッチエクスポート（カテゴリ別）
- ✅ **ルールメトリクス収集** (`core/rule_metrics.py` - 313行)
  - 統計収集（検出回数、誤検知追跡、カテゴリ別集計）
  - メトリクスレポート生成（Markdown形式）
  - トレンド分析
- ✅ **AI支援ルール生成** (`core/ai_rule_generator.py` - 354行)
  - マルチAIプロバイダー対応（Anthropic/OpenAI）
  - 自然言語からYAMLルール生成
  - パターン推奨・代替API提案
- ✅ **全テスト100%合格** (16/16成功)

### v4.4.0 Phase 4.1の主な新機能（ルールテンプレート）
- ✅ **ルールテンプレート機能** (`core/rule_template.py` - 240行)
  - 5種類のテンプレートカタログ（forbidden-api, naming-convention, security-check, performance, custom-pattern）
  - 変数置換システム（RULE_ID, API_NAME, SEVERITY等）
  - テンプレートバリデーション
- ✅ **対話型ルール生成ウィザード** (`rule_wizard.py` - 343行)
  - ステップバイステップでルール作成
  - 自動バリデーション
  - `.bugsearch/rules/custom/` への自動保存
- ✅ **全テスト100%合格** (7/7成功)

### v4.3.0 Phase 4.0の主な新機能（カスタムルール）
- ✅ **プロジェクト固有カスタムルール** (`.bugsearch/rules/` ディレクトリサポート)
- ✅ **ルール優先順位システム** (カスタム > コアルール)
- ✅ **ルール管理機能** (有効/無効切り替え、カテゴリ単位の無効化)
- ✅ **カスタムルールバリデーション** (YAML構文、必須フィールド、正規表現検証)
- ✅ **全テスト100%合格** (11/11成功)

### v4.2.2 Phase 3.3の主な新機能
- ✅ **全10YAMLルール動作確認** (database×3, security×3, solid×2, performance×2)
- ✅ **4カテゴリ完全サポート** (database, security, solid, performance)
- ✅ **YAML正規表現エスケープ修正** (4ファイル修正完了)
- ✅ **全テスト100%合格** (8/8成功、スキップ0)
- ✅ **技術スタック依存の深刻度調整動作確認**

### v4.0.0の主な機能
- 🤖 **AI改善コード自動適用ツール** (`apply_improvements_from_report.py`, 1,101行)
  - 100点満点セキュリティ（デバッガー、セキュリティ、コードレビュー全て100/100）
  - パストラバーサル防止（ホワイトリスト方式）
  - TOCTOU攻撃対策（lstat()シンボリックリンク検証）
  - アトミックファイル更新（tempfile + fsync + atomic rename）
  - クロスプラットフォームファイルロック（msvcrt/fcntl）
- 🌐 **文字エンコーディング自動検出**
  - BOM自動認識（UTF-8/UTF-16 LE/BE）
  - chardet統合（confidence > 0.7）
  - 多段階フォールバック（UTF-8→CP932→Shift_JIS→latin1）
- 💾 **安全機能**
  - タイムスタンプバックアップ + メタデータJSON
  - ロールバック機能（メタデータベース復元）
  - Unicode制御文字検出（C0/C1/BIDI攻撃防止）

### v3.5.0の改善点（継続サポート）
- **python-dotenv依存削除**: 手動.env読み込み機能`load_env_file()`実装
- **完全レポート生成**: `--complete-all`オプションで全ファイルのAI分析可能
- **インストールガイド追加**: [INSTALL.md](../INSTALL.md)と requirements.txt 作成

### v3.2.0の改善点（継続サポート）
- **マルチAIプロバイダー対応**: Anthropic Claude + OpenAI自動フォールバック
- **AI_PROVIDER環境変数**: auto/anthropic/openai選択可能

### コンポーネント構成

#### 1. インデックスマネージャー
- **役割**: ソースファイルのスキャンとインデックス化
- **主要機能**:
  - ファイルサイズチェック（デフォルト4MB制限）
  - 言語フィルタリング（--exclude-langs オプション）
  - エンコーディング自動検出
  - JSONLフォーマットでの保存

#### 2. 環境変数ローダー（v3.5新規）
- **load_env_file()関数**（24-41行目）:
  - python-dotenv不要の独立実装
  - .envファイルの手動パース
  - 既存環境変数の保護（上書き防止）
  - ホワイトリスト方式でセキュリティ向上
- **サポート形式**:
  ```env
  KEY=value
  KEY="quoted value"
  KEY='single quoted'
  # コメント行
  ```

#### 3. エンコーディング検出器（改善版）
- **対応エンコーディング**:
  - UTF-8（優先）
  - CP932（Windows日本語環境）
  - Shift-JIS（日本語Windows）
  - EUC-JP（Unix/Linux日本語）
  - Latin-1（フォールバック）
- **検出アルゴリズム**:
  1. chardetライブラリによる推定
  2. 順次デコード試行によるフォールバック
  3. 読み取り不能時はスキップ

#### 4. AI改善コード自動適用ツール（v4.0新規）
**`apply_improvements_from_report.py`** (1,101行)

- **セキュリティバリデーター**:
  - `validate_safe_path()`: ホワイトリスト方式パス検証
  - `validate_improved_code()`: Unicode制御文字/NULL/サイズ検証
  - lstat()によるTOCTOU対策（シンボリックリンク検出）

- **エンコーディングハンドラー**:
  - `detect_encoding()`: BOM検出（UTF-8/UTF-16 LE/BE）
  - `read_file_with_fallback()`: 多段階フォールバック
  - chardet統合（confidence > 0.7で採用）

- **アトミックファイルライター**:
  - `atomic_write()`: tempfile.mkstemp() + os.fsync() + atomic rename
  - クロスプラットフォームロック（Windows: msvcrt、UNIX: fcntl）
  - 失敗時の自動クリーンアップ

- **バックアップマネージャー**:
  - タイムスタンプ付きバックアップ（`YYYYMMDD_HHMMSS.bak`）
  - メタデータJSON（original_path、timestamp、backup_type）
  - `rollback_from_backup()`: メタデータベース復元

#### 5. ルール解析エンジン
- **検出パターン**:
  ```python
  SEVERITY_SCORES = {
      "DB: ループ内SELECT (N+1) 疑い": 10,
      "DB: SELECT * →負荷増。列限定": 8,
      "金額: 浮動小数で金額→誤差。Decimal/通貨型へ": 9,
      "UI: XSS脆弱性の疑い（未サニタイズHTML）": 8,
      "UI: 入力検証不足（文字数/型チェックなし）": 7,
      "印刷: プレビューなしで直接印刷": 6,
      "エラー: catch内で握りつぶし": 5,
      "UI: ユーザーフィードバック未提供": 4
  }
  ```

#### 6. AI詳細分析エンジン（v3.5強化）
- **完全レポート生成**: `--complete-all`オプション対応
- **並列処理対応**: extract_and_batch_parallel_enhanced.py (10 workers)
- **MD5キャッシュ**: `.cache/analysis/` でAPI呼び出し削減
- **マルチAIプロバイダー**: Anthropic Claude + OpenAI自動フォールバック
- **設定パラメータ**:
  ```python
  AI_TIMEOUT = 60        # 秒
  AI_MAX_RETRIES = 2     # リトライ回数
  AI_MIN_SEVERITY = 7    # 最小重要度スコア
  AI_MAX_FILES = 20      # 最大解析ファイル数
  ```
- **プロンプトテンプレート**:
  ```
  あなたは経験豊富なソフトウェアエンジニアです。
  以下のコードと検出された問題を分析し、具体的な改善案を提示してください。

  【必須フォーマット】
  問題種別: [問題のタイプ]

  ## 現在のコード（Before）:
  ```language
  [問題のあるコード]
  ```

  ## 改善後のコード（After）:
  ```language
  [修正されたコード]
  ```

  ## 説明:
  [なぜこの変更が必要か、どのような効果があるか]
  ```

#### 6. ベクトル化エンジン
- **アルゴリズム**: TF-IDF（Term Frequency-Inverse Document Frequency）
- **ライブラリ**: scikit-learn
- **保存形式**: pickle（.pkl）
- **用途**: コード類似検索、関連ファイル抽出

## データフロー

### 2段階パイプライン全体像

```mermaid
graph TB
    subgraph "Phase 1: インデックス作成"
        A[ソースファイル] --> B[ファイルスキャン]
        B --> C{サイズ/言語チェック}
        C -->|OK| D[エンコーディング検出]
        C -->|NG| E[スキップ]
        D --> F[ファイル読み込み]
        F --> G[.advice_index.jsonl]
    end

    subgraph "Phase 2: 解析実行"
        G --> H[インデックス読み込み]
        H --> I[類似検索<br/>TF-IDF]
        I --> J[Phase 1:<br/>ルールベース解析]
        J --> K[重要度スコア計算]
        K --> L{AI解析対象?}
        L -->|高重要度| M[Phase 2:<br/>AI詳細解析]
        L -->|低重要度| N[*_rules.mdレポート]
        M --> O[*_ai.mdレポート]
    end

    style A fill:#e1f5ff
    style G fill:#fff4e6
    style N fill:#e8f5e9
    style O fill:#e8f5e9
```

## ベンチマークとプロファイル

- 全 CLI の `index` コマンドは `--batch-size`（既定 500）、`--max-files`、`--max-seconds`、`--include` / `--exclude`、`--worker-count` をサポートします。大規模リポジトリではこれらを組み合わせて段階的にインデックス処理を進めてください。
- `--worker-count` を設定するとファイル読み込みが並列化されます。NVMe SSD では 4〜8、HDD や NAS では 1〜2 から調整し、I/O が飽和してタイムアウトしそうな場合は `--batch-size` と `--max-seconds` を併用して短時間ジョブに分割します。
- `.advice_index.meta.json` にファイルサイズと更新時刻、ハッシュを保存し、再インデックス時は未変更ファイルをスキップして前回のエントリを差し戻すインクリメンタル更新を採用しています。
- インデックス完了時には `[SUMMARY]` 行で処理件数・再利用件数・各種スキップ数を出力し、`[DETAIL]` 行で大容量スキップの上位例を提示します。
- `--profile-index` と `--profile-output`（.csv または .jsonl）を併用すると、処理時間、スキップ件数（`skipped_large` / `skipped_binary` / `skipped_filter` / `skipped_errors`）、および停止理由（`limit_stop` / `timeout_stop`）を数値で取得できます。
- 代表的な計測例: `python codex_review_ultimate.py index . --batch-size 250 --max-files 15000 --max-seconds 900 --profile-index --profile-output reports/profile_ultimate.csv`. このコマンドの出力は計測ログと CSV に保存し、`doc/TESTING.md` の記録テンプレートに追加します。
- ベンチマーク結果（処理時間、バッチ数、スキップ件数）は README および `doc/TESTING.md` に追記し、既定値を定期的に見直します。

### インデックス作成フェーズ
```
ソースファイル
    ↓
ファイルスキャン
    ↓
サイズ/言語チェック
    ↓
エンコーディング検出
    ↓
ファイル読み込み
    ↓
.advice_index.jsonl
```

### 解析フェーズ
```
インデックス読み込み
    ↓
類似検索（TF-IDF）
    ↓
Phase 1: ルールベース解析（全ファイル）
    ├─→ ルール適用
    ├─→ 重要度スコア計算
    └─→ *_rules.md レポート
    ↓
Phase 2: AI解析（高重要度のみ）
    ├─→ OpenAI API呼び出し
    ├─→ Before/After抽出
    └─→ *_ai.md レポート
```

## パフォーマンス最適化

### バッチ処理
- **目的**: 大量ファイルの効率的処理
- **実装**: joblibによる並列処理
- **バッチサイズ**: 100ファイル/バッチ

### タイムアウト管理
```python
def call_api_with_timeout(prompt, timeout=60):
    try:
        response = client.chat.completions.create(
            model=OPENAI_MODEL,
            messages=[{"role": "user", "content": prompt}],
            timeout=timeout
        )
        return response
    except Timeout:
        return None
```

### メモリ管理
- インデックスファイルの増分読み込み
- 大容量ファイルの自動スキップ
- ベクトル行列の効率的な保存（sparse matrix）

## エラーハンドリング

### API エラー
```python
try:
    response = analyze_with_ai(content)
except OpenAIError as e:
    log_error(f"API Error: {e}")
    continue  # 次のファイルへ
```

### エンコーディングエラー（v2.1改善）
```python
for encoding in ['utf-8', 'cp932', 'shift-jis', 'latin-1']:
    try:
        with open(file_path, 'r', encoding=encoding) as f:
            return f.read(), encoding
    except UnicodeDecodeError:
        continue
# v2.1: EUC-JPを削除しLatin-1を追加（フォールバック）
```

## CI/CD統合 (v3.5.0)

### GitHub Actions セキュリティ強化
#### 入力サニタイゼーション
- **パスインジェクション防止**: 全ファイルパスを正規化・検証
- **コマンドインジェクション防止**: シェルコマンドの適切なエスケープ
- **環境変数制御**: ホワイトリスト方式での環境変数読み込み

#### GitHub Actions SHA ピン留め
```yaml
# セキュリティ強化: SHA-256でアクションを固定
- uses: actions/checkout@b4ffde65f46336ab88eb53be808477a3936bae11 # v4.1.1
- uses: actions/setup-python@0b93645e9fea7318ecaed2b359559ac225c90a2b # v5.3.0
```

#### 機密情報の保護
- **`.env`ファイル不使用**: GitHub Secretsのみから環境変数を取得
- **APIキー検証**: 起動時にAPIキーの有効性を確認
- **自動クリーンアップ**: ワークフロー終了時に機密ファイルを削除

### マルチAIプロバイダー自動フォールバック
#### 優先順位とフォールバック
1. **Anthropic Claude** (AI_PROVIDER=anthropic or auto)
   - Primary: claude-3-5-sonnet-20241022
   - Fallback: OpenAI GPTへ移行

2. **OpenAI GPT** (AI_PROVIDER=openai or auto fallback)
   - Primary: gpt-4o / gpt-5-codex
   - Fallback: ルールベース解析へ移行

3. **ルールベース** (AI_PROVIDER=rules or final fallback)
   - 静的解析のみ実行
   - AI APIを一切使用しない

#### APIキー検証ロジック
```python
def validate_api_keys():
    if AI_PROVIDER in ['anthropic', 'auto']:
        if ANTHROPIC_API_KEY and validate_anthropic_key():
            return 'anthropic'

    if AI_PROVIDER in ['openai', 'auto']:
        if OPENAI_API_KEY and validate_openai_key():
            return 'openai'

    return 'rules'  # フォールバック
```

### ベクトル化とセマンティック検索
- **TF-IDFベクトル化**: `vectorize`コマンドでコード類似性分析
- **セマンティック検索**: 関連コードの自動抽出
- **キャッシュ最適化**: ベクトル化結果の永続化

### HEREDOC変数展開修正
```bash
# v3.5.0: 正しい変数展開
cat <<EOF
API_KEY=${OPENAI_API_KEY}
MODEL=${OPENAI_MODEL:-gpt-4o}
EOF

# 変数展開を防ぐ場合
cat <<'EOF'
${LITERAL_TEXT}
EOF
```

## セキュリティ考慮事項

### APIキー管理
- `.env`ファイルでの管理（ローカル開発のみ）
- GitHub Secretsでの管理（CI/CD環境）
- 環境変数からの読み込み
- Gitignoreによる除外

### ファイルアクセス
- 読み取り専用モード
- パス検証とサニタイゼーション
- シンボリックリンクの追跡制限
- パストラバーサル攻撃の防止

## 拡張性

### カスタムルール追加
```python
# 新しいルールの追加例
def detect_custom_issue(text):
    pattern = r'your_pattern_here'
    if re.search(pattern, text, re.IGNORECASE):
        return {
            'type': 'Custom Issue',
            'severity': 8,
            'message': 'Description',
            'fix': 'Suggested fix'
        }
```

### 新言語サポート
```python
LANGUAGE_EXTENSIONS = {
    'rust': ['.rs'],
    'go': ['.go'],
    'kotlin': ['.kt', '.kts'],
    # 追加...
}
```

## システム要件

### 最小要件
- CPU: 2コア以上
- メモリ: 4GB RAM
- ディスク: 1GB空き容量
- Python: 3.11以上

### 推奨要件
- CPU: 4コア以上
- メモリ: 8GB RAM
- ディスク: 10GB空き容量
- Python: 3.11以上

## 制限事項

### ファイルサイズ
- デフォルト上限: 4MB/ファイル
- 変更可能: `--max-file-mb` オプション

### API制限
- レート制限: OpenAI APIの制限に準拠
- タイムアウト: 60秒/リクエスト
- リトライ: 最大2回

### 処理能力
- 危険度分析: 15,710ファイルを約10秒で処理
- 詳細分析: 500ファイル/バッチ（120秒タイムアウト対策）
- インデックス: 27,884ファイルを約28秒で処理
- 完全分析: 6,089ファイルのAI改善コード生成対応（v3.5）

---

*最終更新: 2025年10月14日 10:00 JST*
*バージョン: v4.11.6 (Phase 8.4 チェックボックスデフォルト設定)*
*リポジトリ: https://github.com/KEIEI-NET/BugSearch2*

**更新履歴:**
- v4.11.7 (2025年10月14日): **タグベース深刻度調整システム完了 (@perfect品質達成)** - YAMLルールシステムとタグシステム統合、Rule._matches_condition()拡張（タグ参照機能）、adjust_severity_by_tech_stack()拡張（tagsパラメータ）、22技術スタック完全対応（従来8→22、+14追加）、OR論理（設定ファイル OR タグ）、後方互換性100%維持、全5テスト合格（5/5成功、test/test_tag_based_severity.py +261行）、ドキュメント更新（CLAUDE.md/TECHNICAL.md Phase 4.11.7セクション追加）
- v4.11.6 (2025年10月14日): **Phase 8.4完了 (@perfect品質達成)** - チェックボックスデフォルト設定システム実装、IntegrationTestConfigManager(+375行)、config/integration_test_defaults.ymlマスター設定、GUI設定タブ拡張（デフォルト設定UI）、CUIオプション引数デフォルト対応、全15テスト合格（15/15成功）、シングルトンパターン、YAML一元管理
- v4.11.5 (2025年10月14日): **Phase 8.3 事前生成データベースルール完成 (@perfect品質達成)** - 8データベース×64ルール事前生成（計4,776行）、Context7依存排除、4-6倍高速化、GUI統合拡張（16技術スタック）、統合テストシステム詳細仕様追加
- v4.11.0 (2025年10月13日): **Phase 4.1 GUI Control Center v1.0.0実装** - CustomTkinter GUI（9ファイル、2,889行）、プロセス管理、ログストリーミング、キュー管理、状態管理、4タブUI、13/14テスト成功(93%)
- v4.10.0 (2025年10月12日): **Phase 8.2完了** - Context7統合、AI自動YAML修正、完全自動実行フロー、5段階検証システム、全テスト100%合格(9/9成功)
- v4.7.0 (2025年10月12日): **Phase 6完了** - チーム機能実装（レポート比較、進捗トラッキング、チームダッシュボード）、Flask WebUI + 6 REST API、全テスト100%合格
- v4.6.0 (2025年10月12日): **Phase 5完了** - リアルタイム解析システム（ファイルウォッチャー、差分解析、Git diff統合）、watchdog統合、10倍高速化、全テスト100%合格
- v4.5.0 (2025年10月12日): **Phase 4.2完了** - ルール共有システム（YAML/JSONエクスポート・インポート）、ルールメトリクス、AI支援ルール生成、全テスト100%合格
- v4.4.0 (2025年10月12日): **Phase 4.1完了** - ルールテンプレート機能、対話型ルール生成ウィザード、5種類のテンプレートカタログ、全テスト100%合格
- v4.3.0 (2025年10月12日): **Phase 4.0完了** - カスタムルールシステム、ルール優先順位、ルール管理、全テスト100%合格
- v4.2.2 (2025年10月12日): **Phase 3.3完了** - 全10YAMLルール動作確認、4カテゴリ完全サポート、全テスト100%合格、YAML正規表現エスケープ修正
- v4.2.1 (2025年10月12日): **Phase 3.2完了** - RuleCategoryクラス実装、グローバルルール関数追加、技術スタック考慮の深刻度調整
- v4.2.0 (2025年10月12日): **Phase 3.1完了** - 10個のYAMLルール作成、7言語サポート、技術スタック別推奨方法
- v4.1.0 (2025年10月12日): **Phase 2完了** - 技術スタック自動検出エンジン、対話型設定ジェネレータ、全テスト合格
- v4.0.5 (2025年10月11日): **Phase 1完了** - coreモジュール実装、MVPテスト合格
- v4.0.0 (2025年10月11日): BugSearch2リポジトリ新規作成、ドキュメント更新
- v3.5.0 (2025年09月03日): CI/CD統合強化、GitHub Actionsセキュリティ改善、AI自動フォールバック、環境変数ローダー実装、完全レポート生成機能追加
