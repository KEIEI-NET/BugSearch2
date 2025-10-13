# BugSearch2 全体処理フロー図

## 完全な処理フローチャート

```mermaid
flowchart TD
    Start([BugSearch2起動]) --> Choice{使用シナリオ選択}

    Choice -->|パターンA: 既存ルールで分析| PatternA[パターンA: 高速分析]
    Choice -->|パターンB: 技術スタック特化| PatternB[パターンB: Context7統合]

    %% パターンA: 既存ルールで分析
    PatternA --> IndexA[1. インデックス作成<br/>codex_review_severity.py index]
    IndexA --> LoadRulesA[ルール読み込み]
    LoadRulesA --> CoreRules[コアルール 64個<br/>rules/core/database/*.yml]
    LoadRulesA --> CustomRules[カスタムルール<br/>.bugsearch/rules/*.yml]
    LoadRulesA --> ConfigRules[Context7ルール<br/>config/*.yml]

    CoreRules --> ScanA[ソースコードスキャン]
    CustomRules --> ScanA
    ConfigRules --> ScanA

    ScanA --> IndexFileA[.advice_index.jsonl生成<br/>静的解析結果]
    IndexFileA --> VectorA[TF-IDFベクトル化<br/>.advice_*.pkl]
    VectorA --> AdviseA[2. AI詳細分析<br/>codex_review_severity.py advise --all]
    AdviseA --> AIAnalysisA[AI改善コード生成]
    AIAnalysisA --> ReportA[Markdownレポート<br/>reports/*.md]
    ReportA --> ApplyA{3. 改善コード適用<br/>apply_improvements_from_report.py}
    ApplyA --> EndA([完了])

    %% パターンB: Context7統合分析
    PatternB --> Context7[1. Context7統合分析<br/>generate_tech_config.py --auto-run]
    Context7 --> FetchDocs[最新ドキュメント取得<br/>Context7 API]
    FetchDocs --> GenerateYAML[YAMLルール生成<br/>config/tech-rules.yml]
    GenerateYAML --> ValidateYAML{YAML検証}

    ValidateYAML -->|検証エラー| AIFix[AI自動修正<br/>最大5回試行]
    AIFix --> ValidateYAML

    ValidateYAML -->|検証成功| IndexB[2. インデックス作成<br/>自動実行]
    IndexB --> LoadRulesB[ルール読み込み]
    LoadRulesB --> CoreRulesB[コアルール 64個]
    LoadRulesB --> CustomRulesB[カスタムルール]
    LoadRulesB --> NewRulesB[新規生成ルール<br/>config/tech-rules.yml]

    CoreRulesB --> ScanB[ソースコードスキャン]
    CustomRulesB --> ScanB
    NewRulesB --> ScanB

    ScanB --> IndexFileB[.advice_index.jsonl生成]
    IndexFileB --> VectorB[TF-IDFベクトル化]
    VectorB --> AdviseB[3. AI詳細分析<br/>自動実行]
    AdviseB --> AIAnalysisB[AI改善コード生成]
    AIAnalysisB --> ReportB[Markdownレポート]
    ReportB --> ApplyB{4. 改善コード適用}
    ApplyB --> EndB([完了])

    %% スタイル定義
    classDef processClass fill:#4CAF50,stroke:#2E7D32,stroke-width:2px,color:#fff
    classDef decisionClass fill:#FF9800,stroke:#F57C00,stroke-width:2px,color:#fff
    classDef dataClass fill:#2196F3,stroke:#1565C0,stroke-width:2px,color:#fff
    classDef ruleClass fill:#9C27B0,stroke:#6A1B9A,stroke-width:2px,color:#fff

    class IndexA,IndexB,AdviseA,AdviseB,Context7,AIFix processClass
    class Choice,ValidateYAML,ApplyA,ApplyB decisionClass
    class IndexFileA,IndexFileB,VectorA,VectorB,ReportA,ReportB dataClass
    class CoreRules,CustomRules,ConfigRules,CoreRulesB,CustomRulesB,NewRulesB ruleClass
```

## ルール優先順位システム

```mermaid
flowchart LR
    A[ルール読み込み開始] --> B[1. カスタムルール<br/>.bugsearch/rules/]
    B --> C[2. Context7生成ルール<br/>config/*.yml]
    C --> D[3. コアルール<br/>rules/core/]
    D --> E[ルールマージ]
    E --> F{同名ルール衝突?}
    F -->|Yes| G[優先度順で上書き<br/>カスタム > Config > コア]
    F -->|No| H[全ルール統合]
    G --> H
    H --> I[最終ルールセット]

    classDef customClass fill:#E91E63,stroke:#C2185B,stroke-width:2px,color:#fff
    classDef configClass fill:#FF9800,stroke:#F57C00,stroke-width:2px,color:#fff
    classDef coreClass fill:#2196F3,stroke:#1565C0,stroke-width:2px,color:#fff

    class B customClass
    class C configClass
    class D coreClass
```

## Context7統合分析の詳細フロー（Phase 8.2完全自動）

```mermaid
flowchart TD
    Start([generate_tech_config.py --auto-run]) --> Input[技術スタック指定<br/>例: --tech react]
    Input --> Resolve[1. ライブラリID解決<br/>resolve_library]
    Resolve --> Fetch[2. ドキュメント取得<br/>fetch_documentation]
    Fetch --> Analyze[3. ベストプラクティス解析<br/>analyze_best_practices]
    Analyze --> Generate[4. YAMLルール生成<br/>generate_yaml_rules]
    Generate --> Validate{5. YAML検証<br/>validate_generated_config}

    Validate -->|検証エラー| ErrorLog[エラー詳細表示<br/>- 構文エラー<br/>- 必須フィールド欠損<br/>- 正規表現エラー]
    ErrorLog --> AIFix[6. AI自動修正<br/>fix_yaml_with_ai]
    AIFix --> Attempt{修正試行回数<br/>< 5回?}
    Attempt -->|Yes| Validate
    Attempt -->|No| Failed([修正失敗 - 終了])

    Validate -->|検証成功| Save[7. ファイル保存<br/>config/tech-rules.yml]
    Save --> Index[8. インデックス作成<br/>subprocess: py codex_review_severity.py index]
    Index --> Advise[9. AI分析実行<br/>subprocess: py codex_review_severity.py advise --all]
    Advise --> Success([完全自動実行完了])

    classDef processClass fill:#4CAF50,stroke:#2E7D32,stroke-width:2px,color:#fff
    classDef errorClass fill:#F44336,stroke:#C62828,stroke-width:2px,color:#fff
    classDef successClass fill:#4CAF50,stroke:#2E7D32,stroke-width:3px,color:#fff

    class Resolve,Fetch,Analyze,Generate,AIFix,Index,Advise processClass
    class ErrorLog,Failed errorClass
    class Success successClass
```

## GUI Control Centerとの統合フロー

```mermaid
flowchart TD
    GUI([GUI Control Center<br/>gui_main.py]) --> Tab1[🚀 起動タブ]
    GUI --> Tab2[📊 監視タブ]
    GUI --> Tab3[⚙ 設定タブ]
    GUI --> Tab4[📜 履歴タブ]

    Tab1 --> Job1[Context7統合分析<br/>ボタン]
    Tab1 --> Job2[インデックス作成<br/>ボタン]
    Tab1 --> Job3[AI分析実行<br/>ボタン]
    Tab1 --> Job4[改善コード適用<br/>ボタン]
    Tab1 --> Job5[統合テスト<br/>ボタン]

    Job1 --> Options1[詳細設定<br/>- 技術スタック選択 16種類<br/>- トピック選択 16種類]
    Options1 --> Launch1[generate_tech_config.py --auto-run起動]

    Job2 --> Options2[詳細設定<br/>- 最大ファイルサイズ<br/>- ワーカー数]
    Options2 --> Launch2[codex_review_severity.py index起動]

    Job3 --> Options3[詳細設定<br/>- 完全レポート生成<br/>- 最大件数]
    Options3 --> Launch3[codex_review_severity.py advise起動]

    Job4 --> FileDialog[レポートファイル選択<br/>reports/*.md]
    FileDialog --> Launch4[apply_improvements_from_report.py起動]

    Launch1 --> Process[プロセス管理<br/>ProcessManager]
    Launch2 --> Process
    Launch3 --> Process
    Launch4 --> Process

    Process --> Log[ログ収集<br/>LogCollector]
    Log --> Tab2Monitor[監視タブ<br/>リアルタイム表示]

    Process --> Complete{完了?}
    Complete -->|Yes| History[履歴記録<br/>StateManager]
    History --> Tab4History[履歴タブ<br/>統計サマリー]

    classDef guiClass fill:#673AB7,stroke:#512DA8,stroke-width:2px,color:#fff
    classDef jobClass fill:#4CAF50,stroke:#2E7D32,stroke-width:2px,color:#fff
    classDef tabClass fill:#2196F3,stroke:#1565C0,stroke-width:2px,color:#fff

    class GUI guiClass
    class Job1,Job2,Job3,Job4,Job5 jobClass
    class Tab1,Tab2,Tab3,Tab4 tabClass
```

## 技術スタック別ルール適用例（React分析）

```mermaid
flowchart LR
    Start([Reactプロジェクト分析]) --> Index[インデックス作成]
    Index --> Rules[ルール読み込み]

    Rules --> Core[コアルール 64個<br/>- SQL Injection<br/>- XSS<br/>- N+1クエリ<br/>- メモリリーク]
    Rules --> React[Reactルール<br/>react-rules.yml<br/>- dangerouslySetInnerHTML<br/>- useEffect依存配列<br/>- key prop<br/>- メモ化不足]
    Rules --> DB[DBルール<br/>- Cassandra<br/>- Elasticsearch<br/>- Redis<br/>- MySQL/PostgreSQL]

    Core --> Scan[ソースコードスキャン]
    React --> Scan
    DB --> Scan

    Scan --> Detect[問題検出]
    Detect --> React1[React問題: 15件<br/>深刻度9-10]
    Detect --> DB1[DB問題: 8件<br/>深刻度8-10]
    Detect --> Core1[その他問題: 23件<br/>深刻度5-9]

    React1 --> Report[Markdownレポート<br/>合計46件]
    DB1 --> Report
    Core1 --> Report

    classDef reactClass fill:#61DAFB,stroke:#149ECA,stroke-width:2px,color:#000
    classDef dbClass fill:#4CAF50,stroke:#2E7D32,stroke-width:2px,color:#fff
    classDef coreClass fill:#2196F3,stroke:#1565C0,stroke-width:2px,color:#fff

    class React,React1 reactClass
    class DB,DB1 dbClass
    class Core,Core1 coreClass
```

## v4.11.5の事前生成ルールによる高速化

```mermaid
flowchart LR
    Old([v4.11.4以前<br/>Context7必須]) --> OldContext7[Context7 API呼び出し<br/>20-60秒]
    OldContext7 --> OldYAML[YAMLルール生成]
    OldYAML --> OldValidate[検証]
    OldValidate --> OldIndex[インデックス作成]
    OldIndex --> OldAdvise[AI分析]

    New([v4.11.5<br/>事前生成済み]) --> NewIndex[インデックス作成<br/>64ルール即座に適用]
    NewIndex --> NewAdvise[AI分析]

    OldAdvise --> OldTime[合計時間: 60-120秒]
    NewAdvise --> NewTime[合計時間: 10-30秒<br/>4-6倍高速化]

    classDef oldClass fill:#F44336,stroke:#C62828,stroke-width:2px,color:#fff
    classDef newClass fill:#4CAF50,stroke:#2E7D32,stroke-width:2px,color:#fff

    class Old,OldContext7,OldYAML,OldValidate,OldTime oldClass
    class New,NewIndex,NewAdvise,NewTime newClass
```

## まとめ: 推奨ワークフロー

### ケース1: 初回分析（コアルールで十分）
```bash
# 1. インデックス作成（64コアルール + カスタムルール適用）
py codex_review_severity.py index

# 2. AI詳細分析
py codex_review_severity.py advise --all --out reports/initial_analysis

# 3. 改善コード適用
python apply_improvements_from_report.py reports/initial_analysis.md --apply
```

### ケース2: 技術スタック特化分析（React/Angular等）
```bash
# 完全自動実行（Context7 → インデックス → AI分析）
python generate_tech_config.py --tech react --auto-run
```

### ケース3: GUI経由（推奨）
```bash
# GUIを起動
python gui_main.py

# GUIで以下を実行:
# 1. 起動タブ → Context7統合分析（オプション）
# 2. 起動タブ → インデックス作成
# 3. 起動タブ → AI分析実行
# 4. 起動タブ → 改善コード適用
# 5. 監視タブ → 進捗確認
# 6. 履歴タブ → 結果確認
```

---

**v4.11.5の主な変更点:**
- ✅ **64ルールを事前生成** → Context7不要で即座に分析可能
- ✅ **8データベース完全対応** → Cassandra, Elasticsearch, Redis等の深層分析
- ✅ **GUI統合** → 16技術スタックから選択可能

**最終更新:** 2025年10月14日 04:00 JST
**バージョン:** v4.11.5
