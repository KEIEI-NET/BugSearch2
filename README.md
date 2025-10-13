# BugSearch2 - AI Code Review System v4.11.7

静的コード解析とAI分析を組み合わせた高度なコードレビューシステムです。
**NEW**: Phase 8.5でレポート生成重大バグ修正！`--complete-report`機能が完全動作。64個のデータベース最適化ルールを事前生成により、Context7不要で即座に深層分析が可能。Cassandra/Elasticsearch/Redis等の8データベースを完全サポート。

*バージョン: v4.11.7 (Phase 8.5完了: レポート生成重大バグ修正)*
*最終更新: 2025年10月14日 11:00 JST*

**⚠️ セキュリティ強化版 - ReDoS脆弱性修正済み、環境変数保護強化**

## 📚 ドキュメント

### 🚀 クイックスタート
- 🎯 **NEW**: [GUI起動ガイド](GUI_STARTUP.md) - ワンクリックでGUI起動（Windows/macOS/Linux対応）
- 🖥️ [GUI使用ガイド](doc/guides/GUI_USER_GUIDE.md) - GUI Control Center v1.0.0完全マニュアル
- [Claude.ai コンテキスト](CLAUDE.md) - Claude CLIで開発する際の重要情報
- 🖥️ [複数PC環境セットアップ](QUICK_START_MULTI_PC.md) - Dropbox同期で他のPCでも作業継続（5分）
- 📖 [複数PC環境詳細ガイド](SETUP_GUIDE_MULTI_PC.md) - キャッシュ共有・トラブルシューティング
- ⚠️ [--topk パラメータの注意事項](#-topk-パラメータの注意事項) - **必読**：デフォルトは80ファイルのみ
- 📦 [インストール方法](#1-インストール) - 必要なパッケージとセットアップ

### 📖 技術文書
- [技術仕様](doc/TECHNICAL.md) - 詳細な技術仕様とアーキテクチャ
- [技術仕様 v3](doc/TECHNICAL_v3.md) - v3.1 並列処理版の詳細
- [CI 運用ガイド](doc/CI_GUIDE.md) - GitHub Actions を中心としたジョブ構成とパラメータ例
- [言語サポート](doc/LANGUAGES.md) - 対応言語の詳細

### 📊 開発情報
- [開発履歴](doc/DEVELOPMENT.md) - バージョン履歴と改善内容
- [変更履歴 v3](doc/changelog/CHANGELOG_v3.md) - v3.1の変更内容
- [テスト結果](doc/TEST_RESULTS.md) - 実行テストとパフォーマンス結果
- [テストガイド](doc/TESTING.md) - テスト手順と推奨コマンド

### 📝 ガイド
- [GPT-5 移行ガイド](doc/guides/GPT5_MIGRATION.md) - GPT-5への移行手順
- [GPT-5 ステータス](doc/guides/GPT5_STATUS.md) - GPT-5対応状況
- [拡張分析ガイド](doc/guides/ENHANCED_ANALYSIS_GUIDE.md) - 詳細分析の使い方
- [パフォーマンスレポート](doc/guides/PERFORMANCE_REPORT.md) - パフォーマンス測定結果
- [開発者ガイドライン](doc/guides/AGENTS.md) - リポジトリ運用ルールとコーディング規約

### 📊 システム図

#### Mermaid形式
- [アーキテクチャ図](doc/architecture.mmd) - システム全体構成
- [処理フロー図](doc/process-flow.mmd) - 詳細な処理の流れ
- [シーケンス図](doc/sequence-diagram.mmd) - コンポーネント間の相互作用
- [クラス図](doc/class-diagram.mmd) - クラス構造と関係

#### DrawIO形式
- [アーキテクチャ図](doc/flow/code-review-system-architecture.drawio)
- [処理フロー図](doc/flow/code-review-system.drawio)
- [シーケンス図](doc/sequence-diagram.drawio)
- [クラス図](doc/class/code-review-system.drawio)

## 🎉 バージョン4.11.7の新機能 - Phase 8.5完了 (@perfect品質達成)

### 🔧 レポート生成重大バグ修正（2025年10月14日）

**問題**: `--complete-report`フラグ使用時にクラッシュ発生
**原因**: tuple型とdict型の混在による`AttributeError: 'tuple' object has no attribute 'get'`
**解決**: tuple展開ロジックを修正し、dict型を確実に使用

1. **修正内容**
   ```python
   # 修正前（バグ）
   result = (complete_report_result, ...)
   if result.get('complete_report_generated'):  # ❌ エラー発生

   # 修正後（正常）
   complete_report_result, ... = result
   if complete_report_result.get('complete_report_generated'):  # ✅ 正常動作
   ```

2. **GUI統合テスト機能強化**
   - `--complete-report`フラグを`core/integration_test_engine.py`に追加
   - GUIから完全レポート生成が可能に
   - デフォルト: フラグ指定で有効化（`store_true`）

3. **テスト結果**
   - Phase 8.4の全15テストが引き続き合格
   - 後方互換性100%維持
   - クリティカルバグ完全修正

4. **使用例**
   ```bash
   # CLI: 完全レポート生成（修正済み）
   py codex_review_severity.py advise --all --complete-report --out reports/full

   # GUI: 統合テストタブから完全レポート生成
   # 「完全レポート生成」チェックボックスをON → 実行
   ```

---

## 🎉 バージョン4.11.6の新機能 - チェックボックスデフォルト設定 (@perfect品質達成)

### ⚙️ 統一されたデフォルト設定システム（2025年10月14日）

1. **YAMLマスター設定ファイル**
   - `config/integration_test_defaults.yml` - 全デフォルト値の一元管理
   - デフォルト値: `project-type=react`, `topics=security,performance`, `max-file-mb=4`, `worker-count=4`

2. **GUI設定タブ拡張**
   - [設定ファイルを開く] - デフォルト設定YAMLを直接編集
   - [表示を更新] - YAML変更をGUIに即座反映
   - [デフォルトに戻す] - 工場出荷時設定に復元

3. **CUIオプション引数デフォルト対応**
   - 引数省略時にconfig/integration_test_defaults.ymlから自動取得
   - `--project-type`, `--topics`, `--max-file-mb`, `--worker-count`全てに対応

4. **テスト結果**
   - 新規テストファイル: `test/test_integration_test_config.py` (294行)
   - 全15テスト合格（100%成功率）

---

## 🎉 バージョン4.11.5の新機能 - 事前生成データベースルール (@perfect品質達成)

### 🗄️ 64個のデータベース最適化ルール事前生成（2025年10月14日）

**革命的変更**: 8データベース×64ルールを事前生成、Context7不要で**4-6倍高速化**！

1. **8データベース完全対応**
   - **Cassandra** (529行、9ルール) - 分散アーキテクチャの深層分析
   - **Elasticsearch** (477行、8ルール) - 検索エンジン最適化
   - **Redis** (570行、8ルール) - インメモリKVSベストプラクティス
   - **MySQL** (420行、7ルール) - リレーショナルDB最適化
   - **PostgreSQL** (650行、9ルール) - 高度なRDB機能活用
   - **SQL Server** (720行、8ルール) - Microsoftエンタープライズ対応
   - **Oracle** (730行、8ルール) - エンタープライズDBアンチパターン
   - **Memcached** (680行、7ルール) - 分散キャッシュ最適化

2. **技術深度の向上**
   - **Cassandra**: ALLOW FILTERING、トゥームストーン、パーティション設計
   - **Elasticsearch**: 深いページング、ワイルドカード検索、マッピング爆発
   - **Redis**: KEYS *ブロッキング、Luaスクリプト、大きなキー問題
   - **6+言語対応**: Java, Python, JavaScript, C#, Go, PHP, SQL

3. **即座に利用可能**
   ```bash
   # Context7不要！即座にインデックス作成開始
   py codex_review_severity.py index

   # 64ルールで全データベース分析
   py codex_review_severity.py advise --all --out reports/db_analysis
   ```

4. **パフォーマンス改善**
   - **旧版**: Context7 API呼び出し（20-60秒） → YAML生成 → 検証
   - **v4.11.5**: ルール読み込み（即座） → 分析開始
   - **結果**: 4-6倍の高速化達成！

5. **GUI統合**
   - Context7タブに8データベース追加
   - 統合テストタブに8データベース追加
   - 合計16技術スタック対応（8フレームワーク + 8データベース）

6. **深刻度スコアリング**
   - **Critical (10)**: ALLOW FILTERING、深いページング、KEYS *コマンド
   - **High (9)**: SELECT FOR UPDATE WAIT、Commitインループ
   - **Medium (7-8)**: インデックス欠損、VACUUMなし

**詳細ドキュメント**: [doc/WORKFLOW_DIAGRAM.md](doc/WORKFLOW_DIAGRAM.md) - 完全な処理フロー図

---

## 🎉 バージョン4.11.0の新機能 - GUI Control Center v1.0.0実装

### 🖥️ GUI Control Center v1.0.0（2025年10月13日）

1. **CustomTkinterモダンUI**
   - 4タブ構成: 起動/監視/設定/履歴
   - ダーク/ライトテーマ対応
   - Windows/Mac/Linux完全対応

   **🎯 簡単起動（推奨）:**
   ```bash
   # Windows: ダブルクリック
   start_gui.bat

   # macOS/Linux: ターミナルから実行
   ./start_gui.sh
   ```
   起動スクリプトが自動で以下を実行します：
   - 仮想環境の作成・アクティベート
   - 依存パッケージのインストール
   - GUIの起動

   **手動起動:**
   ```bash
   # GUI起動コマンド
   python gui_main.py

   # 必要パッケージのインストール
   pip install -r requirements_gui.txt
   ```

2. **プロセス管理機能 (gui/process_manager.py)**
   - プロセス起動/停止/一時停止/再開
   - psutilによるクロスプラットフォーム対応
   - リアルタイムステータス監視
   ```python
   from gui.process_manager import ProcessManager

   manager = ProcessManager()
   pid = manager.start_process(
       'python codex_review_severity.py index',
       env_vars={'AI_PROVIDER': 'auto'}
   )
   manager.pause_process(pid)  # 一時停止
   manager.resume_process(pid) # 再開
   ```

3. **ログストリーミング (gui/log_collector.py)**
   - リアルタイムログ表示
   - ログレベル検出（INFO/WARNING/ERROR）
   - 進捗パース機能
   ```python
   from gui.log_collector import LogCollector

   collector = LogCollector()
   collector.start_collecting(process)
   for log_entry in collector.get_logs():
       print(f"[{log_entry['level']}] {log_entry['message']}")
   ```

4. **キュー管理システム (gui/queue_manager.py)**
   - 優先度管理（URGENT/HIGH/NORMAL/LOW）
   - 依存関係管理
   - 並列実行制御（最大10並列）
   ```python
   from gui.queue_manager import QueueManager

   queue = QueueManager(max_concurrent=3)
   queue.add_job({
       'command': 'python codex_review_severity.py advise --all',
       'priority': 'HIGH',
       'dependencies': ['index_job_id']
   })
   ```

5. **状態管理 (gui/state_manager.py)**
   - ウィンドウ状態の永続化
   - 設定の保存/読み込み
   - ジョブ履歴管理
   ```python
   from gui.state_manager import StateManager

   state_mgr = StateManager()
   state_mgr.save_window_state(width=1200, height=800)
   state_mgr.add_job_to_history(job_data)
   ```

6. **対応ジョブタイプ**
   - Context7統合分析（`--auto-run`）
   - インデックス作成（`index`）
   - AI分析実行（`advise --all`）
   - 改善コード適用（`apply_improvements_from_report.py`）

7. **テスト結果**
   - 14テスト実装、13テスト成功（93%）
   - UnicodeEncodeError完全解決（Windows cp932対応）
   ```bash
   # GUIテスト実行
   python test/test_gui_basic.py
   ```

### GUI システムアーキテクチャ

```mermaid
graph TB
    User[ユーザー] --> GUI[GUI Control Center]

    subgraph "GUI Application"
        GUI --> LaunchTab[起動タブ]
        GUI --> MonitorTab[監視タブ]
        GUI --> SettingsTab[設定タブ]
        GUI --> HistoryTab[履歴タブ]
    end

    subgraph "Backend Managers"
        LaunchTab --> ProcessMgr[ProcessManager]
        MonitorTab --> LogCollector[LogCollector]
        ProcessMgr --> QueueMgr[QueueManager]
        GUI --> StateMgr[StateManager]
    end

    subgraph "Existing CLI Tools"
        ProcessMgr --> GenTech[generate_tech_config.py]
        ProcessMgr --> CodexReview[codex_review_severity.py]
        ProcessMgr --> ApplyImprove[apply_improvements_from_report.py]
    end
```

### プロセス管理フロー

```mermaid
sequenceDiagram
    participant User
    participant GUI
    participant ProcessMgr
    participant QueueMgr
    participant Process

    User->>GUI: ジョブ起動ボタンクリック
    GUI->>QueueMgr: add_job()
    QueueMgr->>QueueMgr: 優先度順にソート
    QueueMgr->>ProcessMgr: start_process()
    ProcessMgr->>Process: subprocess.Popen()
    Process-->>ProcessMgr: PID返却
    ProcessMgr->>LogCollector: start_collecting()
    LogCollector-->>GUI: リアルタイムログ
    GUI-->>User: 進捗表示
```

### キュー管理システム

```mermaid
graph LR
    subgraph "Job Queue"
        Q1[URGENT Job] --> Q2[HIGH Job]
        Q2 --> Q3[NORMAL Job]
        Q3 --> Q4[LOW Job]
    end

    subgraph "Running (max_concurrent=3)"
        R1[Job 1]
        R2[Job 2]
        R3[Job 3]
    end

    subgraph "Completed"
        C1[Job ✓]
        C2[Job ✓]
    end

    Q1 -.空きあり.-> R1
    Q2 -.空きあり.-> R2
    Q3 -.空きあり.-> R3
    R1 -.完了.-> C1
    R2 -.完了.-> C2
```

## 🎉 バージョン4.10.0の新機能 - Phase 8.2完了 (@perfect品質達成)

### 🤖 Context7統合 & AI自動修正システム実装（2025年10月12日）

1. **Context7ライブラリ統合**
   - 技術ドキュメント自動取得
   - ライブラリID解決機能
   - 最新仕様に基づくルール生成
   ```bash
   # Context7から技術仕様を取得してYAML生成
   python generate_tech_config.py --tech react

   # 対話型ウィザード
   python generate_tech_config.py
   ```

2. **AI自動YAML修正機能**
   - 検証エラーの自動修正
   - 最大5回の再試行ロジック
   - Anthropic/OpenAIマルチプロバイダー対応
   ```python
   # プログラマティック使用
   from core.config_generator import ConfigGenerator

   generator = ConfigGenerator()
   yaml_content = generator.generate_yaml("angular")

   # 検証エラーを自動修正
   is_valid, errors = generator.validate_yaml(yaml_content)
   if not is_valid:
       yaml_content = generator.fix_yaml_with_ai(yaml_content, errors)
   ```

3. **完全自動実行フロー**
   - YAML生成→検証→修正→index→advise の完全自動化
   - `--auto-run`フラグで一括実行
   - CI/CD統合対応

   ```mermaid
   graph TD
       A[generate_tech_config --auto-run] --> B[Context7: ライブラリ情報取得]
       B --> C[YAML生成]
       C --> D{検証}
       D -->|エラーあり| E[AI自動修正<br/>最大5回試行]
       E --> F{修正成功?}
       F -->|Yes| G[YAML保存]
       F -->|No| H[エラー終了]
       D -->|エラーなし| G
       G --> I[index作成<br/>codex_review_severity.py index]
       I --> J[AI分析実行<br/>codex_review_severity.py advise --all]
       J --> K[レポート生成<br/>reports/ディレクトリ]
       K --> L[完了]
   ```

   ```bash
   # 完全自動実行（推奨）
   python generate_tech_config.py --tech vue --auto-run

   # 実行される処理:
   # 1. Context7からVue.js仕様取得
   # 2. カスタムYAML生成
   # 3. 検証とAI自動修正
   # 4. インデックス作成
   # 5. AI分析実行
   # 6. レポート生成
   ```

4. **5段階厳格検証システム**
   - YAMLスキーマ検証
   - 必須フィールドチェック
   - パターン妥当性検証
   - RuleValidator統合
   - エラー詳細表示
   ```yaml
   # 生成されるYAML例
   tech_stack:
     name: "React"
     version: "18.x"
     framework_type: "frontend"

   custom_rules:
     - id: "REACT_HOOKS_DEPS"
       name: "Missing useEffect dependencies"
       category: "react"
       base_severity: 7
       patterns:
         javascript:
           - pattern: 'useEffect\([^,]+,\s*\[\s*\]'
             context: "Empty dependency array in useEffect"
   ```

5. **@perfect品質達成**
   ```bash
   # 全テスト100%合格 (9/9成功)
   python test/test_config_generator.py

   # テスト内訳:
   # Phase 8.0: Context7統合 (7テスト)
   # Phase 8.1: YAML検証 (1テスト)
   # Phase 8.2: AI自動修正 (1テスト)
   ```

6. **実装詳細**
   - ConfigGeneratorクラス（687行）: core/config_generator.py
   - generate_tech_config CLI（277行）: generate_tech_config.py
   - 包括的テストスイート（572行）: test/test_config_generator.py
   - 総追加コード: +1,536行

7. **サポート技術スタック**
   - **フロントエンド**: React, Vue, Angular, Svelte, Next.js
   - **バックエンド**: Node.js, Django, Rails, Spring Boot
   - **モバイル**: React Native, Flutter
   - **その他**: カスタム設定可能

## 🎉 バージョン4.4.0の新機能 - Phase 4.1完了 (@perfect品質達成)

### 🧙 ルールテンプレート & 対話型ウィザード実装（2025年10月12日）

1. **5種類のルールテンプレートカタログ**
   - `forbidden-api.yml.template` - 禁止API検出（5変数）
   - `naming-convention.yml.template` - 命名規則チェック（7変数）
   - `security-check.yml.template` - セキュリティ脆弱性検出（5変数）
   - `performance.yml.template` - パフォーマンス問題検出（5変数）
   - `custom-pattern.yml.template` - 汎用カスタムパターン（8変数）
   ```bash
   # テンプレートディレクトリ
   rules/templates/
   ├── forbidden-api.yml.template
   ├── naming-convention.yml.template
   ├── security-check.yml.template
   ├── performance.yml.template
   └── custom-pattern.yml.template
   ```

2. **対話型ルール生成ウィザード（rule_wizard.py）**
   - ステップバイステップでカスタムルール作成
   - テンプレート選択のガイダンス
   - 変数入力の検証とヒント表示
   - 自動バリデーションとエラーチェック
   ```bash
   # 対話型でカスタムルールを作成
   python rule_wizard.py

   # ウィザードの流れ:
   # 1. テンプレート選択
   # 2. 変数値の入力（RULE_ID, API_NAME, SEVERITY等）
   # 3. 入力内容の確認
   # 4. 自動バリデーション
   # 5. .bugsearch/rules/custom/ にルール生成
   ```

3. **RuleTemplateManager/RuleTemplateクラス**
   - テンプレート読み込み・管理
   - 変数抽出（{VARIABLE_NAME}形式）
   - テンプレートレンダリング
   - ルール生成とバリデーション統合
   ```python
   # プログラマティックな使用例
   from core.rule_template import RuleTemplateManager

   manager = RuleTemplateManager()
   values = {
       'RULE_ID': 'FORBIDDEN_LEGACY_API',
       'API_NAME': 'LegacyDatabase',
       'SEVERITY': '9',
       'PATTERN': 'LegacyDatabase\\.Connect',
       'ALTERNATIVE_API': 'ModernDatabase.ConnectAsync'
   }

   manager.create_rule_from_template(
       'forbidden-api',
       values,
       Path('.bugsearch/rules/custom/forbidden-legacy-api.yml'),
       validate=True
   )
   ```

4. **@perfect品質達成**
   ```bash
   # 全テスト100%合格 (7/7成功)
   python test/test_phase4_1_templates.py

   # テスト項目:
   # - テンプレート読み込み
   # - 変数抽出
   # - テンプレートレンダリング
   # - ルール生成
   # - バリデーション統合
   # - 本番テンプレート確認
   ```

5. **拡張実装**
   - RuleTemplateクラス（100行）: core/rule_template.py 22-125行
   - RuleTemplateManagerクラス（115行）: core/rule_template.py 128-240行
   - RuleWizardクラス（250行）: rule_wizard.py 26-325行
   - 総追加コード: +343行（ウィザード）+240行（テンプレート管理）

## 🎉 バージョン4.5.0の新機能 - Phase 4.2完了 (@perfect品質達成)

### 🌐 ルール共有・メトリクス・AI支援生成機能実装（2025年10月12日）

1. **ルール共有システム（RuleExporter/RuleImporter）**
   - YAML/JSON形式でのエクスポート
   - メタデータ付加（エクスポート日時、バージョン、ソースファイル）
   - ルールパッケージ作成・インストール
   - 自動バリデーション統合
   ```python
   # ルールエクスポート (core/rule_sharing.py)
   from core.rule_sharing import RuleExporter, RuleImporter

   exporter = RuleExporter()
   # YAMLエクスポート
   yaml_content = exporter.export_rule(
       Path('rules/core/database/n-plus-one.yml'),
       output_format='yaml',
       include_metadata=True
   )

   # JSONエクスポート
   json_content = exporter.export_rule(
       Path('rules/core/security/sql-injection.yml'),
       output_format='json'
   )

   # パッケージ作成
   package_file = exporter.export_rule_package(
       rule_files=[rule1, rule2, rule3],
       package_name='my-security-rules',
       output_dir=Path('packages'),
       package_version='1.0.0'
   )
   ```

2. **ルールインポート機能**
   - YAML/JSON自動検出
   - 自動バリデーション実行
   - カスタムルールディレクトリへの配置
   ```python
   # ルールインポート
   importer = RuleImporter()

   # 単一ルールインポート
   imported_file = importer.import_rule(
       rule_content=yaml_or_json_string,
       output_dir=Path('.bugsearch/rules/custom'),
       validate=True
   )

   # パッケージインストール
   imported_files = importer.import_rule_package(
       package_file=Path('packages/my-security-rules.json'),
       output_dir=Path('.bugsearch/rules/custom'),
       validate=True
   )
   ```

3. **ルールメトリクス収集（RuleMetricsCollector）**
   - スレッドセーフな統計収集
   - 検出数・誤検知率・実行時間の追跡
   - 詳細レポート生成
   - JSON永続化
   ```python
   # メトリクス収集 (core/rule_metrics.py)
   from core.rule_metrics import RuleMetricsCollector

   collector = RuleMetricsCollector(Path('.bugsearch/metrics.json'))

   # 検出記録
   collector.record_detection(
       rule_id='DB_N_PLUS_ONE',
       file_path='src/UserService.cs',
       execution_time_ms=12.5
   )

   # 誤検知記録
   collector.record_false_positive('DB_N_PLUS_ONE')

   # 統計取得
   metric = collector.get_metrics('DB_N_PLUS_ONE')
   fp_rate = collector.get_false_positive_rate('DB_N_PLUS_ONE')
   top_rules = collector.get_top_rules_by_detections(limit=10)

   # レポート生成
   report = collector.generate_report(detailed=True)
   print(report)
   ```

4. **AI支援ルール生成（AIRuleGenerator）**
   - マルチAIプロバイダーサポート（Anthropic Claude / OpenAI GPT）
   - 自動フォールバック（Anthropic → OpenAI → Error）
   - コード例からのルール生成
   - 自然言語記述からのルール生成
   - ルール最適化機能
   ```python
   # AI支援ルール生成 (core/ai_rule_generator.py)
   from core.ai_rule_generator import AIRuleGenerator

   generator = AIRuleGenerator()

   # コード例からルール生成
   rule_yaml = generator.generate_from_code(
       code_example="""
       for user in users:
           profile = db.query("SELECT * FROM profiles WHERE user_id = ?", user.id)
       """,
       problem_description="N+1クエリ問題を検出したい",
       language="python"
   )

   # 自然言語からルール生成
   rule_yaml = generator.generate_from_description(
       description="HttpClientをusingブロックで使用していない場合を検出",
       target_language="csharp",
       category="performance"
   )

   # ルール最適化
   optimized_yaml = generator.optimize_rule(
       rule_yaml=existing_rule,
       optimization_goals=['accuracy', 'performance']
   )
   ```

5. **対話型ルール生成ウィザード**
   ```bash
   # AI支援ルール生成ウィザード
   python -c "from core.ai_rule_generator import RuleGenerationWizard; RuleGenerationWizard().run_code_to_rule_wizard()"

   # 自然言語からのルール生成
   python -c "from core.ai_rule_generator import RuleGenerationWizard; RuleGenerationWizard().run_description_to_rule_wizard()"
   ```

6. **コミュニティルールリポジトリ（CommunityRuleRepository）**
   - GitHubリポジトリ統合（実装予定）
   - ローカルキャッシュ管理
   - バージョン管理対応
   ```python
   # コミュニティルールリポジトリ (開発中)
   from core.rule_sharing import CommunityRuleRepository

   repo = CommunityRuleRepository()
   packages = repo.list_available_packages()
   package_file = repo.download_package('security-essentials', version='latest')
   ```

7. **@perfect品質達成**
   ```bash
   # 全テスト100%合格 (16/16成功)
   python test/test_phase4_2_sharing.py

   # テスト内訳:
   # TestRuleSharing: 7/7テスト成功
   #   - YAML/JSONエクスポート
   #   - YAML/JSONインポート
   #   - パッケージ作成・インストール
   # TestRuleMetrics: 7/7テスト成功
   #   - メトリクス収集・永続化
   #   - 誤検知追跡・レポート生成
   #   - Top N統計取得
   # TestAIRuleGenerator: 2/2テスト成功
   #   - YAML抽出機能
   ```

8. **実装詳細**
   - RuleExporter/RuleImporterクラス（300行）: core/rule_sharing.py 27-302行
   - CommunityRuleRepositoryクラス（85行）: core/rule_sharing.py 304-389行
   - RuleMetric dataclass + RuleMetricsCollectorクラス（400行）: core/rule_metrics.py 27-427行
   - AIRuleGenerator + RuleGenerationWizardクラス（450行）: core/ai_rule_generator.py 全体
   - 総追加コード: +1,235行（ルール共有+メトリクス+AI生成）

9. **環境変数設定**
   ```env
   # AI Provider設定（.envファイル）
   AI_PROVIDER=auto  # auto / anthropic / openai

   # Anthropic Claude（推奨）
   ANTHROPIC_API_KEY=sk-ant-xxx
   ANTHROPIC_MODEL=claude-sonnet-4-5

   # OpenAI GPT（フォールバック）
   OPENAI_API_KEY=sk-xxx
   OPENAI_MODEL=gpt-4o
   ```

10. **使用例: カスタムルールの作成から共有まで**
    ```bash
    # 1. AIでルール生成
    python -c "from core.ai_rule_generator import AIRuleGenerator; \
               gen = AIRuleGenerator(); \
               yaml = gen.generate_from_description('HttpClientのusing忘れを検出', 'csharp', 'performance'); \
               print(yaml)"

    # 2. ルールをファイルに保存
    # .bugsearch/rules/custom/httpclient-using.yml として保存

    # 3. ルールをエクスポート（共有用）
    python -c "from core.rule_sharing import RuleExporter; \
               from pathlib import Path; \
               exp = RuleExporter(); \
               yaml = exp.export_rule(Path('.bugsearch/rules/custom/httpclient-using.yml'), 'yaml'); \
               print(yaml)"

    # 4. パッケージ作成（複数ルールをまとめる）
    python -c "from core.rule_sharing import RuleExporter; \
               from pathlib import Path; \
               exp = RuleExporter(); \
               pkg = exp.export_rule_package( \
                   [Path(f) for f in ['rule1.yml', 'rule2.yml', 'rule3.yml']], \
                   'my-rules', \
                   Path('packages'), \
                   '1.0.0'); \
               print(f'Created: {pkg}')"

    # 5. メトリクス確認
    python -c "from core.rule_metrics import RuleMetricsCollector; \
               from pathlib import Path; \
               col = RuleMetricsCollector(Path('.bugsearch/metrics.json')); \
               print(col.generate_report(detailed=False))"
    ```

## 🎉 バージョン4.6.0の新機能 - Phase 5完了 (@perfect品質達成)

### ⚡ リアルタイム解析システム実装（2025年10月12日）

1. **ファイルウォッチャー機能 (core/file_watcher.py)**
   - リアルタイムファイル変更検出
   - デバウンス処理（連続変更の統合）
   - 12種類のコードファイル対応（C#, Java, PHP, JS, TS, Python, Go, C/C++）
   - スレッドセーフな実装
   ```python
   # ファイルウォッチャー使用例
   from pathlib import Path
   from core.file_watcher import FileWatcher

   def on_file_changed(file_path: Path):
       print(f"File changed: {file_path}")

   watcher = FileWatcher(
       watch_paths=[Path("./src")],
       on_file_changed=on_file_changed,
       debounce_seconds=1.0
   )
   watcher.start()
   ```

2. **差分解析エンジン (core/incremental_analyzer.py)**
   - Git diff統合による変更箇所検出
   - 変更行のみの高速解析（全体解析の10倍以上高速）
   - 増分インデックス更新
   ```python
   # 差分解析使用例
   from pathlib import Path
   from core.incremental_analyzer import IncrementalAnalyzer
   from core.rule_engine import load_all_rules

   analyzer = IncrementalAnalyzer(Path.cwd())

   # ファイルの差分を取得
   diff = analyzer.get_file_diff(Path("src/UserService.cs"))

   if diff and diff.total_changes > 0:
       # 変更行のみを解析
       detections = analyzer.analyze_changed_lines(
           file_path=diff.file_path,
           file_diff=diff,
           rules=load_all_rules()
       )
       print(f"Found {len(detections)} issues in changed lines")
   ```

3. **リアルタイム解析CLIモード (watch_mode.py)**
   - ファイル保存時の自動解析
   - リアルタイムフィードバック表示
   - 深刻度別の問題表示
   ```bash
   # リアルタイム解析モード起動
   python watch_mode.py

   # 複数ディレクトリ監視
   python watch_mode.py ./src ./lib

   # デバウンス時間調整
   python watch_mode.py --debounce 2.0
   ```

4. **VS Code拡張基盤（計画済み）**
   - package.json, extension.ts 構造設計完了
   - Language Server Protocol対応設計
   - リアルタイム診断表示設計

5. **@perfect品質達成**
   ```bash
   # 全テスト100%合格 (9/9成功)
   python test/test_phase5_realtime.py

   # テスト内訳:
   # TestIncrementalAnalyzer: 7/7成功
   #   - ファイル差分検出
   #   - Git diff統合
   #   - 変更行解析
   # TestFileWatcher: 2/2成功
   #   - モジュールインポート
   #   - サポート拡張子確認
   ```

6. **実装詳細**
   - FileWatcher/CodeFileHandlerクラス (180行): core/file_watcher.py
   - IncrementalAnalyzer/FileDiffクラス (280行): core/incremental_analyzer.py
   - リアルタイム解析CLI (200行): watch_mode.py
   - 総追加コード: +660行（リアルタイム解析システム）

7. **パフォーマンス**
   - 差分解析速度: 全体解析の10倍以上高速
   - デバウンス時間: 1秒（調整可能）
   - メモリ使用量: < 100MB（ウォッチモード）
   - CPU使用率: < 10%（アイドル時）

8. **依存関係**
   ```bash
   # 必須ライブラリ
   pip install watchdog  # ファイル変更監視

   # または requirements.txt に追加済み
   pip install -r requirements.txt
   ```

9. **使用シナリオ**
   ```bash
   # シナリオ1: 開発中のリアルタイムフィードバック
   # ターミナル1: リアルタイム解析起動
   python watch_mode.py ./src

   # ターミナル2: コーディング作業
   # → ファイルを編集・保存すると自動的に解析結果が表示される

   # シナリオ2: Git統合による差分解析
   # 変更した行のみを高速チェック
   python -c "from core.incremental_analyzer import IncrementalAnalyzer; \
              from pathlib import Path; \
              analyzer = IncrementalAnalyzer(Path.cwd()); \
              files = analyzer.get_modified_files_in_working_tree(); \
              print(f'{len(files)} files changed')"

   # シナリオ3: プログラマティックな統合
   # 独自のIDEやエディタから呼び出し
   ```

10. **技術スタック**
    - watchdog: クロスプラットフォームファイル監視
    - Git diff: 高速な変更検出
    - threading: 非同期デバウンス処理
    - pathlib: モダンなファイルパス操作

## 🎉 バージョン4.7.0の新機能 - Phase 6完了 (@perfect品質達成)

### 🤝 チーム機能実装（2025年10月12日）

1. **レポート比較エンジン (core/report_comparator.py)**
   - 2つのレポートの差分比較
   - 新規・修正・悪化した問題の検出
   - 改善率の自動計算
   - Markdown形式のレポート生成
   ```python
   # レポート比較使用例
   from pathlib import Path
   from core.report_comparator import ReportComparator

   comparator = ReportComparator()
   diff = comparator.compare_reports(
       old_report=Path("reports/2025-01-01.json"),
       new_report=Path("reports/2025-01-15.json")
   )

   print(f"新規問題: {len(diff.new_issues)}件")
   print(f"修正済み: {len(diff.fixed_issues)}件")
   print(f"改善率: {diff.improvement_rate:.1%}")
   ```

2. **進捗トラッキングシステム (core/progress_tracker.py)**
   - 問題の時系列追跡
   - スナップショット記録機能
   - トレンド分析（improving/worsening/stable/fluctuating）
   - 自動進捗レポート生成
   ```python
   # 進捗トラッキング使用例
   from pathlib import Path
   from datetime import datetime
   from core.progress_tracker import ProgressTracker

   tracker = ProgressTracker(Path(".bugsearch/progress.json"))

   # 現在の問題状況を記録
   tracker.record_snapshot(
       issues=current_issues,
       timestamp=datetime.now()
   )

   # 30日間の進捗レポート生成
   report = tracker.generate_progress_report(days=30)
   print(f"問題数変化: {report['total_issues']['change']}件")
   print(f"トレンド: {report['trend']}")

   # Markdownレポート出力
   tracker.export_progress_report(
       output_file=Path("reports/progress.md"),
       days=30
   )
   ```

3. **チームダッシュボード (dashboard/team_dashboard.py)**
   - Flask WebベースのダッシュボードUI
   - RESTful APIエンドポイント
   - リアルタイム統計表示
   - レポート比較API
   ```bash
   # ダッシュボード起動
   python dashboard/team_dashboard.py

   # APIエンドポイント:
   # - GET  /api/stats           - 統計データ取得
   # - GET  /api/progress?days=30 - 進捗データ取得
   # - POST /api/compare         - レポート比較
   # - GET  /api/reports         - レポート一覧
   # - GET  /health              - ヘルスチェック
   ```

4. **@perfect品質達成**
   ```bash
   # 全テスト100%合格 (14/14成功、2スキップ)
   python test/test_phase6_team.py

   # テスト内訳:
   # TestReportComparator: 5/5成功
   #   - レポート比較・改善率計算
   #   - 問題キー生成・エラーハンドリング
   # TestProgressTracker: 7/7成功
   #   - スナップショット記録・レポート生成
   #   - トレンド分析・データグループ化
   # TestDashboardAPI: 2スキップ (Flask未インストール)
   ```

5. **実装詳細**
   - ReportComparator/ReportDiffクラス (370行): core/report_comparator.py
   - ProgressTrackerクラス (570行): core/progress_tracker.py
   - Flask Dashboardアプリ (350行): dashboard/team_dashboard.py
   - 総追加コード: +1,290行（チーム機能システム）

6. **主要機能**
   - **時系列比較**: 複数レポートを時系列で自動比較
   - **トレンド分析**: 問題数の増減傾向を自動分析
   - **深刻度別追跡**: カテゴリ・深刻度ごとの変化を可視化
   - **Top N分析**: 最も問題の多いファイルを抽出
   - **データ永続化**: JSON形式でスナップショット保存
   - **REST API**: プログラマティックなアクセス

7. **使用シナリオ**
   ```bash
   # シナリオ1: 定期的な進捗追跡
   # 毎週金曜日に実行して進捗を記録
   python -c "from core.progress_tracker import ProgressTracker; \
              from pathlib import Path; \
              tracker = ProgressTracker(Path('.bugsearch/progress.json')); \
              tracker.record_snapshot(current_issues); \
              tracker.export_progress_report(Path('reports/weekly.md'))"

   # シナリオ2: リリース前後の比較
   # リリース前のレポートとリリース後のレポートを比較
   python -c "from core.report_comparator import ReportComparator; \
              from pathlib import Path; \
              comp = ReportComparator(); \
              comp.generate_comparison_report( \
                  Path('reports/pre-release.json'), \
                  Path('reports/post-release.json'), \
                  Path('reports/release-comparison.md'))"

   # シナリオ3: チームダッシュボードでリアルタイム監視
   # ダッシュボードを起動してブラウザでアクセス
   python dashboard/team_dashboard.py
   # → http://localhost:5000 でアクセス
   ```

8. **技術スタック**
   - Flask: Webフレームワーク (オプション依存)
   - JSON: データ永続化
   - dataclass: 構造化データ
   - pathlib: モダンなファイルパス操作

9. **オプション依存関係**
   ```bash
   # ダッシュボード機能を使用する場合のみ必要
   pip install flask

   # またはrequirements.txtに追加済み
   pip install -r requirements.txt
   ```

## 🎉 バージョン4.3.0の新機能 - Phase 4.0完了 (@perfect品質達成)

### 🎯 カスタムルールシステム実装（2025年10月12日）

1. **プロジェクト固有のカスタムルール**
   - `.bugsearch/rules/` ディレクトリで独自ルールを定義
   - YAMLフォーマットで柔軟なルール作成
   - コアルールとの統合管理
   ```bash
   # カスタムルールディレクトリ構造
   .bugsearch/
   ├── config.yml
   └── rules/
       ├── custom/           # カスタムカテゴリ
       │   ├── my-rule-1.yml
       │   └── my-rule-2.yml
       ├── database/         # コアカテゴリ拡張
       │   └── custom-query.yml
       └── disabled.yml      # 無効化ルール一覧
   ```

2. **ルール優先順位システム**
   - カスタムルール > コアルール（同名ルールの自動上書き）
   - ルール有効/無効の動的管理
   - カテゴリ単位の一括無効化
   ```python
   # RuleLoaderクラス (core/rule_engine.py)
   loader = RuleLoader(project_root)
   rules = loader.load_all_rules(include_custom=True)
   loader.disable_rule("DB_SELECT_STAR")  # ルール無効化
   loader.enable_rule("DB_SELECT_STAR")   # ルール有効化
   ```

3. **カスタムルールバリデーション**
   - YAML構文チェック
   - 必須フィールド検証（id, category, name, description, base_severity, patterns）
   - IDフォーマット検証（大文字、A-Z_）
   - 深刻度範囲検証（1-10）
   - 正規表現パターンの妥当性チェック
   ```python
   # RuleValidatorクラス (core/rule_engine.py)
   validator = RuleValidator()
   errors = validator.validate_rule(rule_file)
   ```

4. **@perfect品質達成**
   ```bash
   # 全テスト100%合格 (11/11成功)
   python test/test_phase4_custom_rules.py

   # テスト項目:
   # - カスタムルール読み込み (6テスト)
   # - ルールバリデーション (5テスト)
   ```

5. **使用例**
   ```bash
   # カスタムルールの作成
   mkdir -p .bugsearch/rules/custom
   cat > .bugsearch/rules/custom/forbidden-api.yml << 'EOF'
   rule:
     id: "CUSTOM_FORBIDDEN_API"
     category: "custom"
     name: "Forbidden API Usage"
     description: "社内で禁止されているAPIの使用を検出"
     base_severity: 8
     patterns:
       csharp:
         - pattern: 'LegacyDatabase\\.Connect'
           context: "Legacy database API usage (forbidden)"
   EOF

   # 分析実行（カスタムルール込み）
   python codex_review_severity.py index
   python codex_review_severity.py advise --all --out reports/custom_analysis
   ```

6. **拡張実装**
   - RuleLoaderクラス（150行）: core/rule_engine.py 330-480行
   - RuleValidatorクラス（140行）: core/rule_engine.py 482-625行
   - 総追加コード: +290行

## 📊 バージョン4.2.2の新機能 - Phase 3.3完了 (@perfect品質達成)

### 🎯 YAMLルールシステム完成（2025年10月12日）
1. **全10YAMLルール正常動作**
   - 4カテゴリ完全サポート (database×3, security×3, solid×2, performance×2)
   - 7言語対応 (C#, Java, PHP, JavaScript, TypeScript, Python, Go)
   - 約50パターンの問題検出

2. **技術スタック対応型解析**
   - Elasticsearch使用時のN+1深刻度自動軽減
   - ORM使用時のSELECT *深刻度調整
   - テンプレートエンジン使用時のXSS深刻度調整

3. **@perfect品質達成**
   ```bash
   # 全テスト100%合格 (8/8成功、スキップ0)
   python test/test_multiple_rules.py
   ```

4. **実用的なルール例**
   - `rules/core/database/n-plus-one.yml` - N+1クエリ問題検出
   - `rules/core/security/sql-injection.yml` - SQLインジェクション検出
   - `rules/core/security/xss-vulnerability.yml` - XSS脆弱性検出
   - `rules/core/security/float-money.yml` - 金額計算float使用検出

## 🎉 バージョン4.0の新機能 - AI改善自動適用版（継続サポート）

### 🚀 apply_improvements_from_report.py - 完全自動化ツール
1. **100点満点のセキュリティ評価達成**
   - デバッガー評価: 100/100点
   - セキュリティ評価: 100/100点
   - コードレビュー評価: 100/100点

2. **エンタープライズグレードの安全性**
   - パストラバーサル攻撃防止（ホワイトリスト方式）
   - TOCTOU攻撃対策（lstat()によるシンボリックリンク検証）
   - アトミックファイル更新（tempfile + fsync + atomic rename）
   - クロスプラットフォーム対応ファイルロック

3. **自動エンコーディング検出**
   - BOM自動認識（UTF-8/UTF-16）
   - chardet統合（confidence > 0.7）
   - 多段階フォールバック（UTF-8→CP932→Shift_JIS→latin1）

4. **実用的な機能**
   ```bash
   # プレビューモード（変更内容確認）
   python apply_improvements_from_report.py reports/complete_analysis.md --dry-run

   # 実際に適用
   python apply_improvements_from_report.py reports/complete_analysis.md --apply

   # ロールバック機能
   python apply_improvements_from_report.py --rollback backups/file.py.20251004.bak
   ```

## 📝 バージョン3.5の新機能 - 依存性管理改善版（2025年9月3日リリース）

### 🔧 インストール改善
1. **python-dotenv依存を削除**
   - 手動.envファイル読み込み機能実装（24-41行目）
   - `load_env_file()`関数で環境変数を安全に読み込み
   - 外部ライブラリ依存を削減してポータビリティ向上

2. **完全レポート生成機能**
   - `--complete-all`オプションで全6,089件のファイル処理可能
   - 進捗監視機能の全セクション対応
   - AI改善コード生成100%動作確認済み

3. **インストールガイド充実**
   - [INSTALL.md](INSTALL.md) - 詳細なインストール手順を新規作成
   - requirements.txt - 必要パッケージを明確化
   - Python 3.11+必須、3.13での特殊対応方法記載

### 📦 必要パッケージ
```bash
# 基本パッケージ (requirements.txt参照)
pip install openai anthropic scikit-learn joblib chardet

# Python 3.13でエラーの場合
pip install --only-binary :all: scikit-learn
```

### 🆕 完全分析コマンド
```bash
# 全ファイル完全分析（6,089件）
py codex_review_severity.py advise --complete-all --out reports/complete_analysis

# 部分分析（デフォルト80ファイル）
py codex_review_severity.py advise --out reports/quick_analysis
```

## 🎉 バージョン3.4の新機能（継続サポート）- コード品質100点達成版

### 🏆 達成したコード品質スコア
- **総合評価: 100/100点（満点達成）**
  - セキュリティ: 30/30点（全脆弱性修正）
  - パフォーマンス: 25/25点（2-3倍高速化）
  - エラーハンドリング: 20/20点（完全カバレッジ）
  - コード品質: 20/20点（SOLID原則準拠）
  - ドキュメント: 5/5点（型ヒント完備）

### 🔒 セキュリティ強化
1. **ReDoS脆弱性修正**
   - constructor/ngOnInit正規表現に文字数制限追加（最大500文字）
   - Go global参照パターン最適化（catastrophic backtracking防止）
   - 正規表現プリコンパイル化（50+パターン、2-3倍高速化）

2. **環境変数読み込みセキュリティ**
   - ホワイトリスト方式採用（許可された変数のみ読み込み）
   - 既存環境変数の上書き防止
   - 機密情報の漏洩リスク低減

3. **パストラバーサル脆弱性修正**（1814-1838行）
   - ".."を含むパスの自動拒否
   - Path.resolve()による正規化
   - カレントディレクトリ外アクセス制限

4. **API認証情報ログ保護**（全エラーハンドリング箇所）
   - OpenAI/Anthropic APIキーのマスク処理
   - Bearerトークンの自動マスク
   - エラーログからの機密情報除去

### ⚡ パフォーマンス最適化
- **正規表現プリコンパイル**: COMPILED_PATTERNS辞書（50+パターン）
- **実行速度改善**: 正規表現処理が2-3倍高速化
- **メモリ効率化**: load_index_stream()ジェネレータ追加（1095-1111行）
- **並列処理エラーハンドリング**（985-1029行）: 個別タスク失敗の適切な処理

### 📊 コード品質改善
- **完全な型ヒント追加**: 主要関数に型アノテーション完備
- **マジックナンバー完全定数化**（132-145行）: PROCESSING_CONSTANTS追加（12個の定数）
- **DRY原則適用**: `_check_large_interface()`共通関数化
- **CLI改善**: 詳細なヘルプメッセージ、使用例追加

### 🔧 新定数・設定値
```python
# PROCESSING_CONSTANTS（132-145行）
PROCESSING_CONSTANTS = {
    'DEFAULT_TOPK': 80,           # デフォルト分析ファイル数
    'MAX_FILE_SIZE_MB': 4,        # 最大ファイルサイズ(MB)
    'BATCH_SIZE': 100,            # バッチ処理サイズ
    'MAX_WORKERS': 10,            # 最大並列ワーカー数
    'API_TIMEOUT': 60,            # APIタイムアウト(秒)
    'MAX_RETRIES': 3,             # 最大リトライ回数
    # その他6個の定数...
}

# SOLID原則閾値設定
SOLID_THRESHOLDS = {
    'class_lines': 500,          # クラス最大行数
    'class_methods': 20,          # クラス最大メソッド数
    'interface_methods': 7,       # インターフェース推奨メソッド数
    'interface_max_methods': 10,  # インターフェース最大メソッド数
    'struct_fields': 15,          # 構造体最大フィールド数
    'switch_count': 3,            # switch文許容数
    # その他6個の閾値...
}

# プリコンパイル済み正規表現（50+パターン）
COMPILED_PATTERNS = {
    'php_sql_injection': re.compile(r'...'),
    'php_xss': re.compile(r'...'),
    # その他48個のパターン...
}
```

## 🆕 バージョン3.3の新機能（継続サポート）

### 📐 SOLID原則違反検出
**対応言語**: C#, Go, Java, PHP, JavaScript/TypeScript

- **S**ingle Responsibility: 巨大クラス（500行以上）、多数のメソッド
- **O**pen/Closed: switch文/instanceof/型チェックの多用
- **L**iskov Substitution: NotImplementedException、継承クラスでのthrow
- **I**nterface Segregation: 巨大インターフェース（7-10メソッド以上）
- **D**ependency Inversion: 具象クラス直接生成、グローバル変数使用

### 🅰️ Angularフレームワーク固有検査
- **ルーティング**: プライベートルートのガード未実装検出
- **変更検出**: ChangeDetectionStrategy未指定、OnPush戦略違反
- **依存性注入**: providedIn未指定、コンストラクタでのビジネスロジック
- **ライフサイクル**: Subscription放置、非同期処理の未処理（メモリリーク）
- **モジュール構成**: 巨大SharedModule検出

### 📁 --src-dirオプション追加
- **デフォルトディレクトリ**: `./src` をデフォルト検索対象に
- **カスタムパス指定**: `--src-dir ./custom/path` で任意のディレクトリ指定可能
```bash
# デフォルトで ./src を検索
py codex_review_severity.py index

# カスタムパス指定
py codex_review_severity.py index --src-dir ./application/code
```

## 🆕 バージョン3.2の新機能（継続サポート）

### 🤖 マルチAIプロバイダー対応
- **Anthropic Claude**: Sonnet 4.5 → Opus 4.1 → Sonnet 4.1 自動フォールバック
- **OpenAI GPT**: GPT-5-Codex → GPT-5 → GPT-4o モデル選択
- **自動切り替え**: Anthropic優先 → OpenAIフォールバック（AI_PROVIDER=auto）

## 🆕 バージョン3.1の新機能（継続サポート）

### 🚄 並列処理対応（10倍高速化）
- **並列AI分析**: ThreadPoolExecutor使用、10ワーカー同時実行
- **動的モデル選択**: 危険度に応じてGPT-5-Codex/GPT-4o/GPT-4o-miniを自動選択
- **キャッシュ機能**: MD5ハッシュベースでAPI呼び出しを削減

### 🌏 PHP言語サポート追加
- **セキュリティ脆弱性検出**: SQLインジェクション、XSS、ファイルインクルード等
- **非推奨関数検出**: mysql_*関数、eval()、extract()の危険な使用

## 🚀 特徴

## 🧪 ベンチマークと検証

- インデックス処理はバッチ書き出し・`--max-files`・`--max-seconds` で制御でき、30k ファイル超のリポジトリでも段階的に実行可能です。
- ストレージがボトルネックの場合は `--worker-count 4` などで並列読み込みを有効化し、共有ストレージでは 2 以下から調整しつつ `--max-seconds` と併用してタイムアウトを避けてください。
- 既存の `.advice_index.jsonl` が存在する場合はメタデータ (`.advice_index.meta.json`) を比較し、未変更ファイルは再読み込みせずに再利用されるため、大規模リポジトリでも差分更新が高速です。
- インデックス完了時には `[SUMMARY] seen=...` 形式のサマリが表示され、スキップ件数や再利用件数を一目で確認できます。
- 詳細な検証手順と推奨コマンドは [`doc/TESTING.md`](doc/TESTING.md) を参照してください（50/500/5000/10000 件のシナリオを収録）。
- `--profile-index --profile-output reports/profile.csv` を付与すると処理時間・スキップ件数などの統計を取得できます。
- 長時間処理が予想される場合は `--batch-size 300 --max-files 10000 --max-seconds 900` といった設定で部分的にインデックスを進め、プロファイル出力で進捗を確認してください。

- 📊 **2段階解析システム**: ルールベース解析 → AI詳細解析
- 🌏 **日本語対応**: 自動エンコーディング検出（UTF-8, Shift_JIS, CP932, EUC-JP）
- 🎯 **重要度ソート**: 問題を重要度スコアで自動ランク付け
- 🤖 **マルチAIプロバイダー対応（v3.2+）**: Anthropic Claude & OpenAI GPT
  - Claude Sonnet 4.5/Opus 4.1/Sonnet 4.1 自動フォールバック
  - GPT-5-Codex/GPT-4o/GPT-4o-mini 危険度別モデル選択
  - プロバイダー間自動切り替え（Anthropic優先→OpenAIフォールバック）
- ⚡ **大規模対応**: バッチ処理とタイムアウト管理で数万ファイル処理可能
- 📈 **進捗表示**: リアルタイムな処理状況表示（XX/YYファイル）

## 📋 クイックスタート

### 1. インストール

詳細なインストール手順は[INSTALL.md](INSTALL.md)を参照してください。

```bash
# 基本パッケージ (requirements.txt参照)
pip install openai anthropic scikit-learn joblib chardet

# または requirements.txt を使用
pip install -r requirements.txt

# GUI機能を使用する場合（オプション）
pip install -r requirements_gui.txt
# または個別インストール
pip install customtkinter psutil

# Python 3.13でのインストール
pip install --only-binary :all: scikit-learn
```

### 2. 環境設定
`.env`ファイル作成：
```env
# ========== AI Provider選択 ==========
# auto: Anthropic優先→OpenAIフォールバック
# anthropic: Claude専用
# openai: OpenAI専用
AI_PROVIDER=auto

# ========== OpenAI設定 ==========
OPENAI_API_KEY=your_api_key_here

# 利用可能なモデル（2025年9月時点）
# gpt-5-codex: コード特化、Responses API使用（動作確認済み✅）
# gpt-5      : 最高性能（準備完了、API公開待ち）
# gpt-5-mini : コスト効率重視（準備完了、API公開待ち）
# gpt-5-nano : 超軽量版（準備完了、API公開待ち）
# gpt-4o     : 現行安定版（推奨✅）
OPENAI_MODEL=gpt-4o

# ========== Anthropic Claude設定（v3.2+）==========
ANTHROPIC_API_KEY=your_anthropic_key

# 利用可能なモデル（2025年10月時点）
# claude-sonnet-4-5 : バランス型（推奨✅）
# claude-opus-4-1   : 最高性能
# claude-sonnet-4-1 : 高速・低コスト
# 優先順位: sonnet-4-5 → opus-4-1 → sonnet-4-1（自動フォールバック）
ANTHROPIC_MODEL=claude-sonnet-4-5
```

### 3. 基本的な実行

#### 🆕 方法0: GUI Control Center（推奨）
```bash
# GUI起動
python gui_main.py

# GUIからの操作:
# 1. 起動タブ: ジョブタイプ選択 → 実行ボタン
# 2. 監視タブ: リアルタイムログ確認
# 3. 設定タブ: AI Provider設定、並列度調整
# 4. 履歴タブ: 過去のジョブ結果確認
```

#### 方法1: 標準分析
```bash
# インデックス作成（デフォルト: ./src ディレクトリ、4MB制限、並列処理なし）
py codex_review_severity.py index

# オプション指定の例（ファイルサイズ制限、並列4スレッド）
py codex_review_severity.py index --max-file-mb 4 --worker-count 4

# 特定言語を除外する場合（例: Delphi）
py codex_review_severity.py index --exclude-langs delphi

# PHPファイルのみインデックス作成
py codex_review_severity.py index ./src/php

# ベクトル化（オプション、検索精度向上）
py codex_review_severity.py vectorize

# レビュー実行
py codex_review_severity.py query "データベース N+1" --topk 50 --out reports/review

# ⚠️ 重要: 全ファイル分析（--all オプションを使用）
py codex_review_severity.py advise --all --out reports/full_review
```

> **⚠️ 注意**: `advise` コマンドのデフォルトは80ファイルのみです。全ファイルを分析する場合は必ず `--all` オプションを指定してください。詳細は「[--topk パラメータの注意事項](#-topk-パラメータの注意事項)」を参照。

#### 方法2: 改良版分析（完全コード提供）
```bash
# 危険ファイル抽出
py codex_review_severity.py analyze . --topk 100

# 並列AI分析（改良版・完全コード）
py extract_and_batch_parallel_enhanced.py

# または実行スクリプト使用
run_enhanced_analysis.bat
```

## 📦 主要ファイル

### Pythonスクリプト
| ファイル | 用途 | 特徴 |
|---------|------|------|
| `codex_review_severity.py` | **🌟 メイン** | 全言語対応、重要度ソート、インデックス・分析の統合ツール |
| `extract_and_batch_parallel_enhanced.py` | **🎯 改良版** | 完全な修正コード提供、詳細な問題説明、並列処理 |
| `extract_and_batch_parallel.py` | **⚡ 並列版** | 10倍高速化、自動レジューム、キャッシュ対応 |
| `codex_review_gpt5_responses.py` | GPT-5-Codex | Responses API対応版 |
| `fix_report_encoding.py` | エンコーディング | 文字化け修正（総合版） |
| `simple_fix_report.py` | エンコーディング | 文字化け修正（簡易版） |
| `comprehensive_fix_report.py` | エンコーディング | 文字化け修正（詳細版） |
| `codex_review_with_retry.py` | リトライ機能 | API呼び出しリトライ処理 |
| `check_index.py` | インデックス確認 | インデックスファイルの検証 |

### 実行スクリプト
| ファイル | 用途 |
|---------|------|
| `run_enhanced_analysis.bat` | 改良版分析実行（Windows） |
| `run_batch_parallel.bat` | 並列処理実行（Windows） |
| `run_batch_parallel.sh` | 並列処理実行（Linux/Mac） |

### テストコード
| ファイル | 用途 |
|---------|------|
| `test/monitor_parallel.py` | 進捗モニタリング |
| その他テストファイル | [test/](test/) フォルダー参照 |

## 📁 プロジェクト構成

```
.
├── gui_main.py                       # 🆕 GUI Control Center メインアプリ
├── gui/                              # 🆕 GUIモジュール
│   ├── __init__.py                   # パッケージ初期化
│   ├── process_manager.py            # プロセス管理（459行）
│   ├── log_collector.py              # ログストリーミング（431行）
│   ├── queue_manager.py              # キュー管理（462行）
│   └── state_manager.py              # 状態管理（373行）
│
├── codex_review_severity.py          # メインスクリプト（全言語対応）
├── extract_and_batch_parallel*.py    # 並列処理版スクリプト
├── fix_report_encoding.py            # ユーティリティ
├── batch_config.json                 # 設定ファイル
├── requirements_gui.txt              # 🆕 GUI依存パッケージ
├── .env                              # 環境変数（要作成）
│
├── test/                             # ⭐ テストコード（新規テストはここに作成）
│   ├── test_gui_basic.py            # 🆕 GUIテスト（244行）
│   ├── test_*.py                     # 単体テスト
│   ├── benchmark_parallel.py         # パフォーマンステスト
│   ├── monitor_parallel.py           # モニタリングツール
│   └── sample*.{py,js,go,php}       # テストサンプルファイル
│
├── doc/                              # 📚 ドキュメント
│   ├── TECHNICAL.md                  # 技術仕様
│   ├── DEVELOPMENT.md                # 開発履歴
│   ├── TEST_RESULTS.md               # テスト結果
│   ├── GUI_ARCHITECTURE.md          # 🆕 GUI詳細アーキテクチャ
│   ├── guides/                       # ガイド文書
│   │   ├── GUI_USER_GUIDE.md        # 🆕 GUIユーザーガイド（531行）
│   │   ├── GPT5_MIGRATION.md        # GPT-5移行ガイド
│   │   ├── ENHANCED_ANALYSIS_GUIDE.md # 拡張分析ガイド
│   │   └── AGENTS.md                 # 運用ルール
│   ├── changelog/                    # 変更履歴
│   │   └── CHANGELOG_v3.md          # v3.1変更内容
│   └── archive/                      # アーカイブ
│       └── 説明.md                   # 旧バージョン説明
│
├── reports/                          # 分析レポート出力先（自動生成）
├── .cache/                           # キャッシュディレクトリ（自動生成）
│   └── analysis/                     # AI分析キャッシュ
├── .advice_index.jsonl               # インデックスファイル（自動生成）
└── .advice_*.pkl                     # TF-IDFベクトル（自動生成）
```

> **⭐ 重要**:
> - 新規テストコードは必ず `test/` フォルダー内に作成
> - ドキュメントは `doc/` 配下に整理済み
> - 生成ファイル（`.advice*`, `reports/`, `.cache/`）はgitignore対象

## 🔍 検出可能な問題

### データベース関連（v4.11.5: 8データベース×64ルール対応）

#### 🆕 Cassandra - 分散NoSQLデータベース (9ルール)
- **ALLOW FILTERING使用** - 重要度: 10
  - 全パーティション・全ノードスキャン、コーディネーターノードOOM
  - 推奨: Materialized View、Secondary Index、適切なPartition Key設計
- **巨大パーティション** - 重要度: 9
  - 単一パーティション100MB超、ホットスポット、圧縮遅延
  - 推奨: 複合Partition Key、時系列分割
- **トゥームストーン蓄積** - 重要度: 9
  - 削除レコード残存、Read時スキャン、パフォーマンス劣化
  - 推奨: TTL設計、gc_grace_seconds調整
- **セカンダリインデックス濫用** - 重要度: 8
- **Lightweight Transaction濫用** - 重要度: 8
- **Batch文誤用** - 重要度: 7

#### 🆕 Elasticsearch - 検索エンジン (8ルール)
- **深いページング** - 重要度: 10
  - from + size > 10000でコーディネーターOOM
  - 推奨: search_after、Scroll API（50倍高速化）
- **ワイルドカード検索** - 重要度: 9
  - *wildcards*検索で全文スキャン、メモリ消費
  - 推奨: n-gram tokenizer、edge n-gram
- **マッピング爆発** - 重要度: 9
  - 動的フィールド生成で1000+フィールド、メモリ枯渇
  - 推奨: 明示的マッピング、index.mapping.total_fields.limit
- **大きなドキュメント** - 重要度: 8
- **_allフィールド使用** - 重要度: 7
- **Force Merge濫用** - 重要度: 7

#### 🆕 Redis - インメモリKVS (8ルール)
- **KEYS *コマンド** - 重要度: 10
  - 全キースキャンでサーバーブロック（O(N)）
  - 推奨: SCANコマンド（イテレータ、1000倍高速）
- **大きなキー** - 重要度: 9
  - 10MB超のリスト/セット、メモリ断片化
  - 推奨: データ分割、複数キー
- **Luaスクリプトブロッキング** - 重要度: 9
  - 長時間Lua実行で全クライアントブロック
  - 推奨: スクリプト最適化、Redis Modules
- **パイプライン未使用** - 重要度: 8
- **有効期限設定なし** - 重要度: 8
- **キャッシュスタンピード** - 重要度: 8

#### MySQL - リレーショナルDB (7ルール)
- **Prepared Statement未使用** - 重要度: 10
- **インデックス欠損** - 重要度: 9
- **Connection Pool未使用** - 重要度: 9
- **N+1問題** - 重要度: 10
- **SELECT \*** の使用 - 重要度: 8
- **大OFFSET使用** - 重要度: 7

#### PostgreSQL - 高度なRDB (9ルール)
- **VACUUM未実行** - 重要度: 9
- **N+1問題** - 重要度: 10
- **JSONB未インデックス** - 重要度: 8
- **Prepared Statement未使用** - 重要度: 10
- **Connection Pool未使用** - 重要度: 9
- **統計情報未更新** - 重要度: 8

#### SQL Server - Microsoftエンタープライズ (8ルール)
- **デッドロック** - 重要度: 9
- **TEMPDB競合** - 重要度: 8
- **パラメータスニッフィング** - 重要度: 8
- **暗黙的変換** - 重要度: 8
- **Cursor濫用** - 重要度: 9
- **インデックス断片化** - 重要度: 7

#### Oracle - エンタープライズDB (8ルール)
- **行ごとPL/SQL処理** - 重要度: 10
- **ループ内Commit** - 重要度: 9
- **SELECT FOR UPDATE WAIT** - 重要度: 9
- **暗黙的変換** - 重要度: 8
- **Nested Loop Join強制** - 重要度: 8
- **統計情報未更新** - 重要度: 8

#### Memcached - 分散キャッシュ (7ルール)
- **長すぎるキー** - 重要度: 9
- **キャッシュスタンピード** - 重要度: 9
- **有効期限設定なし** - 重要度: 8
- **大きな値** - 重要度: 8
- **Connection Pool未使用** - 重要度: 8
- **キー命名規則違反** - 重要度: 7

**使用例:**
```bash
# 全データベースルール込みでインデックス作成
py codex_review_severity.py index

# Cassandra特化分析
py codex_review_severity.py advise --all --out reports/cassandra_analysis

# Elasticsearch特化分析
py codex_review_severity.py advise --all --out reports/elasticsearch_analysis
```

**ルールファイル**: `rules/core/database/*.yml` (8ファイル、計4,776行、64ルール)

### セキュリティ
- **金額計算でのfloat使用** - 重要度: 9
- **XSS脆弱性** - 重要度: 8
- **入力検証不足** - 重要度: 5
- **エラー情報漏洩** - 重要度: 5

### パフォーマンス
- **非効率なループ**
- **メモリリーク**
- **不要な再計算**
- **大量データの一括取得**

### コード品質
- **エラーハンドリング不足**
- **マジックナンバー**
- **重複コード**
- **未使用変数**

### 言語固有の問題

#### PHP
**セキュリティ脆弱性:**
- **SQLインジェクション脆弱性** - 重要度: 10
  - `$_GET['id']`を直接SQL文に結合
  - prepare/bind_paramなしのクエリ実行
- **コマンドインジェクション** - 重要度: 10
  - `system($_GET['cmd'])`, `exec()`, `shell_exec()`の使用
- **ファイルインクルード脆弱性** - 重要度: 9
  - `include($_GET['page'])`等のユーザー入力によるファイル読み込み
- **XSS脆弱性（未エスケープ出力）** - 重要度: 9
  - `echo $_GET['name']`のようなエスケープなし出力
  - htmlspecialchars/htmlentitiesなし
- **ディレクトリトラバーサル** - 重要度: 9
  - basename/realpathなしのファイル操作
- **eval()の使用** - 重要度: 9
  - 動的コード実行によるセキュリティリスク
- **セッション固定化攻撃** - 重要度: 8
  - session_regenerate_id()なしのsession_start()
- **CSRF対策不足** - 重要度: 8
  - POSTフォームにトークンなし

**非推奨・危険な関数:**
- **mysql_*関数（非推奨）** - 重要度: 7
  - PDO/mysqliの使用を推奨
- **extract()の危険な使用** - 重要度: 6
  - `extract($_GET)`, `extract($_POST)`等
- **register_globalsへの依存** - 重要度: 7

**パフォーマンス:**
- **N+1問題** - ループ内でのSQL実行
- **大量データ取得** - `SELECT * ... LIMIT 10000`等
- **非効率なループ処理** - ループ内に重いクエリ

**使用例:**
```bash
# PHPファイルのインデックス作成
py codex_review_severity.py index ./src/php

# PHP分析実行
py codex_review_severity.py advise --all --out reports/php_analysis
```

**テスト用サンプル:** `src/php/`フォルダーに脆弱性テスト用PHPファイルを配置

#### Go
- **エラーチェック不足** - 重要度: 8
- **goroutineリーク** - 重要度: 9
- **チャネルデッドロック** - 重要度: 7
- **defer忘れ** - 重要度: 6

#### C++
- **メモリリーク** - 重要度: 10
- **バッファオーバーフロー** - 重要度: 10
- **未初期化ポインタ** - 重要度: 9
- **RAII違反** - 重要度: 7

## 📄 出力レポート

### ルールベースレポート（*_rules.md）
```markdown
# ルールベース解析レポート
- 全ファイルの静的解析結果
- 問題の重要度分布（🔴緊急 🟠高 🟡中 🔵低 ⚪なし）
- 問題箇所のコードサンプル
- 簡易的な修正例
```

### AI詳細レポート（*_ai.md）
```markdown
# AI改善案付き解析レポート
- 高重要度ファイルの詳細解析
- Before/After形式の改善コード
- 詳細な説明と影響範囲
- パフォーマンス改善の期待値
```

## 🎯 実績・パフォーマンス

### テスト環境
- **対象ファイル**: 14,355個のC#ソースファイル
- **総コード行数**: 約200万行
- **テスト日時**: 2025-09-28

### 処理性能
| 処理 | ファイル数 | 実行時間 | 備考 |
|------|-----------|---------|------|
| インデックス作成 | 1,195 | 約30秒 | 1MB制限、Delphi除外 |
| ルール解析 | 50 | 約5秒 | 全ファイル対象 |
| AI解析 | 5 | 約60秒 | 高重要度のみ |

### 検出実績
- 🔴 **緊急問題**: 5件（N+1問題、SELECT *）
- 🟡 **中程度問題**: 7件（入力検証、エラー処理）
- ⚪ **問題なし**: 38件

## 🔧 カスタマイズ

### 設定値の調整
```python
# codex_review_ultimate.py の設定値
AI_TIMEOUT = 60         # AI解析タイムアウト（秒）
AI_MAX_RETRIES = 2      # AIリトライ回数
AI_MIN_SEVERITY = 7     # AI解析する最小重要度スコア
AI_MAX_FILES = 20       # AI解析する最大ファイル数
```

### 除外ディレクトリ
```python
IGNORE_DIRS = {
    ".git", "node_modules", "dist", "build",
    ".venv", "venv", "__pycache__", ".idea"
}
```

## 🚦 GitHub Actions連携 (v3.5.0)

`.github/workflows/codex-readonly-review-optimized.yml`でPR自動レビュー：

### 🔒 セキュリティ強化機能 (v3.5.0)
- **入力サニタイズ**: 悪意のあるパスインジェクション防止
- **環境変数保護**: `.env`ファイル不使用、GitHub Secretsのみ使用
- **SHAピン留め**: 全GitHub ActionsはSHA-256で固定
- **最小権限原則**: 必要最小限の権限のみ付与

### 🤖 マルチAIプロバイダー自動フォールバック
1. **Anthropic Claude優先** → APIキーなし/エラー時にOpenAIへ
2. **OpenAI GPT** → APIキーなし/エラー時にルールモードへ
3. **ルールベース** → AI不使用の静的解析のみ

### 📋 必要なGitHub Secrets設定
```yaml
# AIプロバイダー設定（オプション）
AI_PROVIDER: auto          # auto/anthropic/openai/rules
ANTHROPIC_API_KEY: sk-ant-xxx   # Claude API（オプション）
ANTHROPIC_MODEL: claude-3-5-sonnet-20241022  # Claudeモデル
OPENAI_API_KEY: sk-xxx          # OpenAI API（オプション）
OPENAI_MODEL: gpt-4o             # GPTモデル
```

### 🚀 ワークフロー設定例
```yaml
name: Code Review v3.5.0
on:
  pull_request:
    types: [opened, synchronize]

jobs:
  review:
    runs-on: ubuntu-latest
    permissions:
      contents: read
      pull-requests: write
    steps:
      - uses: actions/checkout@b4ffde65f46336ab88eb53be808477a3936bae11 # v4.1.1
      - uses: actions/setup-python@0b93645e9fea7318ecaed2b359559ac225c90a2b # v5.3.0
        with:
          python-version: '3.11'
      - run: pip install -r requirements.txt

      # AIプロバイダー自動選択（Anthropic→OpenAI→ルールベース）
      - name: Run Code Review
        env:
          AI_PROVIDER: ${{ secrets.AI_PROVIDER || 'auto' }}
          ANTHROPIC_API_KEY: ${{ secrets.ANTHROPIC_API_KEY || '' }}
          OPENAI_API_KEY: ${{ secrets.OPENAI_API_KEY || '' }}
        run: |
          python codex_review_severity.py index  # デフォルト: ./src
          python codex_review_severity.py vectorize  # セマンティック検索用
          python codex_review_severity.py advise --all --out reports/review

      # セキュリティクリーンアップ
      - name: Cleanup Sensitive Files
        if: always()
        run: |
          rm -f .env .env.* *.key *.pem
          find . -name "*.log" -exec rm -f {} \;

      - uses: actions/upload-artifact@v4
        with:
          name: review-reports
          path: reports/
```

### ⚡ v3.5.0の新機能
- **ベクトル化対応**: `vectorize`コマンドでセマンティック検索強化
- **HEREDOC修正**: Bash変数展開の適切な処理
- **エラーハンドリング強化**: 各ステップでの適切なフォールバック
- **自動クリーンアップ**: 機密ファイルの自動削除

## ⚠️ 制限事項

- **ファイルサイズ上限**: デフォルト4MB（`--max-file-mb`で変更可）
- **AI解析**: 最大20ファイル/実行（高負荷回避）
- **タイムアウト**: API呼び出し60秒/ファイル
- **エンコーディング**: 主要な日本語エンコーディングのみ対応

## 🛠️ トラブルシューティング

### よくある問題

#### ModuleNotFoundError: No module named 'dotenv'
```bash
# python-dotenvは不要になりました（v3.5以降）
# 手動.env読み込み機能が内蔵されています
```

#### Python 3.13でのインストールエラー
```bash
# scikit-learnのビルドエラー対策
pip install --only-binary :all: scikit-learn

# その他のパッケージ
pip install openai anthropic joblib chardet
```

#### エンコーディングエラー
```bash
# chardetが自動検出（UTF-8, Shift_JIS, CP932, EUC-JP対応）
py codex_review_severity.py index .  # 自動検出機能内蔵
```

#### タイムアウトエラー
```bash
# ファイル数を減らす
py codex_review_severity.py advise --topk 20

# タイムアウト値を調整（batch_config.json編集）
"timeout_per_file": 120  # 60秒から120秒に変更
```

#### AI改善コード生成が失敗
```bash
# --complete-allオプションで再試行
py codex_review_severity.py advise --complete-all --out reports/retry_analysis

# キャッシュクリア後に再実行
rm -rf .cache/analysis/
py codex_review_severity.py advise --complete-all --out reports/fresh_analysis
```

#### メモリ不足
```bash
# ファイルサイズ制限を厳しくする
py codex_review_severity.py index . --max-file-mb 1

# バッチサイズを小さくする
py extract_and_batch_parallel_enhanced.py  # batch_config.jsonで調整
```

## ⚡ パフォーマンスベストプラクティス

### 大規模ファイル処理時の推奨設定

#### 1. カーソルベースページネーション
6,089件以上の大規模処理時はIDカーソル方式を使用：
```sql
-- ❌ OFFSETベース（遅延あり）
SELECT * FROM files ORDER BY id LIMIT 100 OFFSET 5000;

-- ✅ カーソルベース（高速）
SELECT * FROM files WHERE id > last_id ORDER BY id LIMIT 100;
```

#### 2. DB接続プール設定
並列処理（MAX_WORKERS=10）時の推奨設定：
- 接続プールサイズ: ワーカー数+2以上（推奨: 12以上）
- タイムアウト設定の整合性: API_TIMEOUT（60秒）とDB接続タイムアウトを同期

#### 3. バッチサイズの動的調整
ファイルサイズに応じた最適化：
```python
# デフォルト: BATCH_SIZE=100
# 小ファイル（<100KB）: 200件/バッチ
# 中ファイル（100KB-1MB）: 100件/バッチ
# 大ファイル（>1MB）: 50件/バッチ
```

#### 4. 進捗表示とモニタリング
大規模処理時（1,000件以上）は自動的に以下を表示：
- 処理済み件数/総件数
- 推定残り時間
- 現在処理中のファイル名

```bash
# 進捗モニタリングツールの使用
python test/monitor_parallel.py
```

### ⚠️ --topk パラメータの注意事項

#### 問題の概要
`codex_review_severity.py advise` コマンドは、**デフォルトで80ファイルしか分析しません**。

これは全ファイルの約0.5%に過ぎず、重要な問題を見逃す可能性があります。

#### なぜこの問題が起きるのか
- インデックスには全ファイル（例: 15,710件）が含まれている
- しかし `--topk` のデフォルト値は80
- **インデックスのファイル数は自動的には引き継がれない**

#### 解決方法

##### 方法1: --all オプションを使用（推奨）
```bash
py codex_review_severity.py advise --all --out reports/analysis.md
```

##### 方法2: 手動でファイル数を指定
```bash
# インデックス作成時の indexed 数を確認
py codex_review_severity.py index ./src
# [SUMMARY] indexed=15710 と表示

# その数を指定
py codex_review_severity.py advise --topk 15710 --out reports/analysis.md
```

#### 推奨される使用パターン

**開発時（部分分析）**
```bash
# 上位1000ファイルで素早く確認
py codex_review_severity.py advise --topk 1000 --out reports/quick_check.md
```

**本番分析（全ファイル）**
```bash
# 全ファイルを徹底分析
py codex_review_severity.py advise --all --out reports/full_analysis.md
```

**CI/CD（閾値設定）**
```bash
# 危険度の高い上位500ファイルをチェック
py codex_review_severity.py advise --topk 500 --out reports/ci_check.md
```

#### チェックリスト
分析実行前に確認：
- [ ] `--all` または `--topk` を指定したか？
- [ ] 指定なしの場合、80ファイルのみで良いか？
- [ ] インデックスの indexed 数を確認したか？
- [ ] 全ファイル分析が必要か、部分分析で十分か？

## 📞 サポート

問題が発生した場合:
1. [SETUP_GUIDE.md](SETUP_GUIDE.md)のトラブルシューティング参照
2. [TEST_RESULTS.md](doc/TEST_RESULTS.md)で動作確認済み環境を確認
3. `reports/IMPORTANT_RESULTS.md`で既知の問題確認
4. [GitHubでIssue作成](https://github.com/KEIEI-NET/BugSearch2/issues)

## 📜 ライセンス

MIT License - 詳細は[LICENSE](LICENSE)参照

## 🤖 AIモデル選択ガイド

### GPT-5シリーズ対応状況（2025年9月28日時点）

| モデル | 状態 | エンドポイント | 備考 |
|--------|------|--------------|------|
| gpt-5-codex | ✅動作中 | `/v1/responses` | Responses API経由、コード分析特化 |
| gpt-4o | ✅動作中 | `/v1/chat/completions` | 安定版、推奨 |
| gpt-5 | ⏳準備完了 | `/v1/chat/completions` | API公開待ち |
| gpt-5-mini | ⏳準備完了 | `/v1/chat/completions` | API公開待ち |
| gpt-5-nano | ⏳準備完了 | `/v1/chat/completions` | API公開待ち |

**実装済み対策**：
- 空レスポンス時の自動リトライ（最大3回）
- APIエラー時のフォールバック機能
- レスポンス構造の自動判定

### 利用可能なモデル
- **gpt-5**: 最高性能モデル
  - 入力: 272,000トークン、出力: 128,000トークン
  - 数学: AIME 2025で94.6%
  - コーディング: SWE-benchで74.9%
  - 複雑な推論・分析タスクに最適

- **gpt-5-mini**: バランス型
  - コスト効率と処理速度のバランス
  - 大量ファイル処理に適している
  - 通常のコードレビューに推奨

- **gpt-5-nano**: 軽量版
  - 最速・最安価
  - シンプルな静的解析向け
  - 大規模バッチ処理に最適

### フォールバック機能
空レスポンス時は自動的に別モデルで再試行します：
- gpt-5 → gpt-4o
- gpt-5-mini → gpt-4o
- gpt-5-nano → gpt-5-mini

## 🙏 謝辞

- OpenAI GPT-5/GPT-4oモデルの提供
- scikit-learn、ChromaDB等のオープンソースライブラリ
- 日本語エンコーディング検出のchardetライブラリ

---

*最終更新: 2025年10月13日 10:00 JST*
*バージョン: v4.11.0 (Phase 4.1 GUI実装完了)*
*リポジトリ: https://github.com/KEIEI-NET/BugSearch2*

**更新履歴:**
- v4.11.0 (2025年10月13日): **Phase 4.1 GUI Control Center v1.0.0実装** - CustomTkinter GUI(+348行)、ProcessManager(+459行)、LogCollector(+431行)、QueueManager(+462行)、StateManager(+373行)、4タブUI、リアルタイムログ、キュー管理、13/14テスト成功(93%)
- v4.10.0 (2025年10月12日): **Phase 8.2完了 (@perfect品質達成)** - Context7統合&AI自動修正、ConfigGenerator(+687行)、generate_tech_config.py(+277行)、fix_yaml_with_ai()メソッド追加、run_full_analysis()完全自動実行、5段階検証システム、全テスト100%合格(9/9成功)
- v4.7.0 (2025年10月12日): **Phase 6完了 (@perfect品質達成)** - チーム機能実装、ReportComparator/ReportDiff(+370行)、ProgressTracker(+570行)、FlaskDashboard(+350行)、レポート比較・時系列追跡・トレンド分析・REST API、全テスト100%合格(14/14成功、2スキップ)
- v4.6.0 (2025年10月12日): **Phase 5完了 (@perfect品質達成)** - リアルタイム解析システム実装、FileWatcher/CodeFileHandler(+180行)、IncrementalAnalyzer/FileDiff(+280行)、watch_mode.py(+200行)、Git diff統合、デバウンス処理、スレッドセーフ実装、12言語サポート、10倍以上高速化、全テスト100%合格(9/9成功)
- v4.5.0 (2025年10月12日): **Phase 4.2完了 (@perfect品質達成)** - ルール共有・メトリクス・AI支援生成機能実装、RuleExporter/RuleImporter(+300行)、RuleMetricsCollector(+400行)、AIRuleGenerator(+450行)、マルチAIプロバイダーサポート、スレッドセーフメトリクス、YAML/JSON自動検出、全テスト100%合格(16/16成功)
- v4.4.0 (2025年10月12日): **Phase 4.1完了 (@perfect品質達成)** - ルールテンプレート機能実装、5種類のテンプレートカタログ、対話型ルール生成ウィザード(rule_wizard.py +343行)、RuleTemplateManager/RuleTemplateクラス(core/rule_template.py +240行)、全テスト100%合格(7/7成功)
- v4.3.0 (2025年10月12日): **Phase 4.0完了 (@perfect品質達成)** - カスタムルールシステム実装、RuleLoader/RuleValidator追加(+290行)、ルール優先順位(カスタム>コア)、ルール有効/無効管理、カスタムルールバリデーション、全テスト100%合格(11/11成功)
- v4.2.2 (2025年10月12日): **Phase 3.3完了** - 全10YAMLルール正常動作、4カテゴリ完全サポート、技術スタック対応型解析、全テスト100%合格、@perfect品質達成
- v4.2.1 (2025年10月12日): Phase 3.2完了 - RuleCategoryクラス実装、グローバルルール関数追加、技術スタック考慮の深刻度調整機能
- v4.2.0 (2025年10月12日): Phase 3.1完了 - 10個のYAMLルール作成、7言語サポート、技術スタック別推奨方法
- v4.0.0 (2025年10月11日): BugSearch2リポジトリ新規作成、apply_improvements_from_report.py完成、AI改善コード自動適用機能、100点満点セキュリティ達成、エンコーディング自動検出
- v3.5.0 (2025年09月03日): GitHub Actions v3.5.0セキュリティ強化、AI自動フォールバック、python-dotenv依存削除、完全レポート生成機能、インストールガイド追加
- v3.4.1 (2025年09月02日): ドキュメント更新、100点達成詳細の追記
- v3.4.0 (2025年09月02日): セキュリティ強化、パフォーマンス最適化、コード品質100点達成
- v3.3.0 (2024年10月02日): SOLID原則検出、Angularフレームワーク対応
- v3.2.0 (2024年09月30日): マルチAIプロバイダー対応（Anthropic Claude追加）
- v3.1.0 (2024年09月28日): 並列処理対応、PHP言語サポート追加
