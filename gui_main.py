"""
BugSearch2 GUI Control Center
メインGUIアプリケーション

バージョン: v4.11.5 (GUI v1.0.0)
"""

import os
import sys
import time
import threading
from pathlib import Path
from typing import Optional

# CustomTkinterのインポート（インストールされていない場合はエラーメッセージを表示）
try:
    import customtkinter as ctk
except ImportError:
    print("✗ CustomTkinter not installed")
    print("  Install with: pip install customtkinter")
    sys.exit(1)

# GUIモジュールのインポート
from gui.process_manager import ProcessManager
from gui.log_collector import LogCollector
from gui.queue_manager import QueueManager, JobPriority
from gui.state_manager import StateManager
from gui.widgets import ProgressWidget, LogViewer

# 統合テスト設定管理 (Phase 8.4)
from core.integration_test_config import get_config_manager


class BugSearchGUI(ctk.CTk):
    """
    BugSearch2 GUI Control Center

    メインウィンドウとタブ管理
    """

    def __init__(self):
        super().__init__()

        # ウィンドウ設定
        self.title("BugSearch2 Control Center v4.11.5")

        # プロジェクトルートディレクトリ
        self.project_root = Path.cwd()

        # マネージャー初期化
        self.process_manager = ProcessManager()
        self.log_collector = LogCollector()
        self.queue_manager = QueueManager(max_concurrent=3)
        self.state_manager = StateManager()

        # 統合テスト設定マネージャー初期化 (Phase 8.4)
        self.config_manager = get_config_manager()

        # ジョブウィジェット管理
        self.job_widgets = {}  # {job_id: {'frame': CTkFrame, 'progress': ProgressWidget, 'buttons': {...}}}
        self.job_sections = {}  # {job_type: options_frame} - ジョブタイプ別のオプションフレーム

        # 起動時の初期化
        self.initialize_project()

        # ウィンドウ状態復元（1920x1024以内に制限）
        window_state = self.state_manager.get_window_state()

        # 最大サイズを1920x1024に制限（タスクバー分も考慮して少し小さめ）
        max_width = 1920
        max_height = 1000  # タスクバー・タイトルバーを考慮

        # 最小サイズ
        min_width = 1200
        min_height = 700

        # サイズを制限
        width = max(min_width, min(window_state.width, max_width))
        height = max(min_height, min(window_state.height, max_height))

        self.geometry(f"{width}x{height}")
        self.minsize(min_width, min_height)  # 最小サイズを設定

        if window_state.x and window_state.y:
            # 画面内に収まるように位置を調整
            x = max(0, min(window_state.x, max_width - width))
            y = max(0, min(window_state.y, max_height - height))
            self.geometry(f"+{x}+{y}")

        # テーマ設定
        theme = self.state_manager.get_setting('theme', 'dark')
        ctk.set_appearance_mode(theme)
        ctk.set_default_color_theme("blue")

        # UI構築
        self.setup_ui()

        # 更新タイマー
        self.update_interval = 1000  # 1秒
        self.after(self.update_interval, self.periodic_update)

        # 終了時のハンドラー
        self.protocol("WM_DELETE_WINDOW", self.on_closing)

    def initialize_project(self):
        """プロジェクト初期化 - 設定ファイル自動生成"""
        config_file = self.project_root / '.bugsearch.yml'

        if not config_file.exists():
            # デフォルト設定ファイルをコピー
            default_config = self.project_root / 'config' / 'default.bugsearch.yml'

            if default_config.exists():
                try:
                    import shutil
                    shutil.copy(default_config, config_file)
                    print(f"[OK] Created default configuration: {config_file}")
                except Exception as e:
                    print(f"[WARN] Failed to create config file: {e}")
            else:
                print(f"[WARN] Default config not found: {default_config}")

    def setup_ui(self):
        """UI構築"""
        # メニューバー
        self.setup_menu()

        # メインコンテナ
        self.main_container = ctk.CTkFrame(self)
        self.main_container.pack(fill="both", expand=True, padx=10, pady=10)

        # ステータスバー
        self.status_bar = ctk.CTkLabel(
            self.main_container,
            text="Ready",
            anchor="w"
        )
        self.status_bar.pack(side="bottom", fill="x", pady=(5, 0))

        # タブビュー
        self.tabview = ctk.CTkTabview(self.main_container)
        self.tabview.pack(fill="both", expand=True)

        # タブ追加
        self.tabview.add("🚀 起動")
        self.tabview.add("📊 監視")
        self.tabview.add("⚙ 設定")
        self.tabview.add("📜 履歴")

        # 各タブのセットアップ
        self.setup_launch_tab()
        self.setup_monitor_tab()
        self.setup_settings_tab()
        self.setup_history_tab()

    def setup_menu(self):
        """メニューバー（代替実装）"""
        # CustomTkinterにはメニューバーがないため、ボタンで代替
        menu_frame = ctk.CTkFrame(self)
        menu_frame.pack(fill="x", padx=10, pady=(10, 0))

        # ファイルメニュー
        file_btn = ctk.CTkButton(
            menu_frame,
            text="📁 File",
            width=80,
            command=self.show_file_menu
        )
        file_btn.pack(side="left", padx=2)

        # ヘルプメニュー
        help_btn = ctk.CTkButton(
            menu_frame,
            text="❓ Help",
            width=80,
            command=self.show_help
        )
        help_btn.pack(side="left", padx=2)

    def setup_launch_tab(self):
        """起動タブ - 詳細オプション対応"""
        tab = self.tabview.tab("🚀 起動")

        # スクロール可能フレーム
        scroll_frame = ctk.CTkScrollableFrame(tab)
        scroll_frame.pack(fill="both", expand=True)

        # Context7統合分析
        self.create_job_section(
            scroll_frame,
            "Context7統合分析 (--auto-run)",
            self.launch_context7_analysis,
            job_type="context7"
        )

        # インデックス作成
        self.create_job_section(
            scroll_frame,
            "インデックス作成",
            self.launch_index_creation,
            job_type="index"
        )

        # AI分析実行
        self.create_job_section(
            scroll_frame,
            "AI分析実行",
            self.launch_ai_analysis,
            job_type="advise"
        )

        # 改善コード適用
        self.create_job_section(
            scroll_frame,
            "改善コード適用",
            self.launch_apply_improvements,
            job_type="apply"
        )

        # 統合テスト (新機能)
        self.create_job_section(
            scroll_frame,
            "統合テスト (フル実行)",
            self.launch_integration_test,
            job_type="integration_test"
        )

    def create_job_section(self, parent, title: str, command, job_type: str = "generic"):
        """ジョブセクションを作成 - 詳細オプション対応"""
        frame = ctk.CTkFrame(parent)
        frame.pack(fill="x", padx=10, pady=10)

        # タイトルと起動ボタンの行
        header_frame = ctk.CTkFrame(frame)
        header_frame.pack(fill="x", padx=10, pady=(10, 5))

        title_label = ctk.CTkLabel(
            header_frame,
            text=title,
            font=ctk.CTkFont(size=16, weight="bold")
        )
        title_label.pack(side="left", anchor="w")

        # 起動ボタン
        launch_btn = ctk.CTkButton(
            header_frame,
            text="▶ 起動",
            command=command,
            width=100,
            height=32,
            fg_color="green",
            hover_color="darkgreen"
        )
        launch_btn.pack(side="right", padx=(10, 0))

        # 詳細設定トグルボタン
        options_visible = ctk.BooleanVar(value=False)
        toggle_btn = ctk.CTkButton(
            header_frame,
            text="⚙ 詳細設定",
            command=lambda: self.toggle_options(options_frame, options_visible, toggle_btn),
            width=100,
            height=32
        )
        toggle_btn.pack(side="right", padx=(0, 5))

        # 詳細設定フレーム（初期状態で非表示）
        options_frame = ctk.CTkFrame(frame)
        # pack()は後で呼ぶ

        # ジョブタイプ別のオプションを追加
        self.create_job_options(options_frame, job_type)

        # カスタムコマンドラインオプション（ジョブタイプ別の例）
        custom_label = ctk.CTkLabel(
            options_frame,
            text="カスタムオプション:",
            font=ctk.CTkFont(size=12)
        )
        custom_label.pack(anchor="w", padx=10, pady=(10, 2))

        # ジョブタイプ別のプレースホルダー例
        placeholder_examples = {
            "index": "例: --max-file-mb 4 --worker-count 8",
            "advise": "例: --all --complete-report --max-complete-items 100",
            "context7": "例: --tech react --topic security",
            "apply": "例: --filter 'src/*.py' --verbose"
        }
        placeholder = placeholder_examples.get(job_type, "追加オプションを入力")

        custom_entry = ctk.CTkEntry(
            options_frame,
            placeholder_text=placeholder
        )
        custom_entry.pack(fill="x", padx=10, pady=(0, 10))

        # オプションフレームをフレームに保存（トグル用）
        frame.options_frame = options_frame
        frame.custom_entry = custom_entry

        # ジョブタイプ別のオプションフレームを保存
        self.job_sections[job_type] = options_frame

    def toggle_options(self, options_frame, visible_var, toggle_btn):
        """詳細設定の表示/非表示をトグル"""
        if visible_var.get():
            # 非表示にする
            options_frame.pack_forget()
            toggle_btn.configure(text="⚙ 詳細設定")
            visible_var.set(False)
        else:
            # 表示する
            options_frame.pack(fill="x", padx=10, pady=(0, 10))
            toggle_btn.configure(text="▲ 詳細設定を閉じる")
            visible_var.set(True)

    def create_job_options(self, parent, job_type: str):
        """ジョブタイプ別のオプションUIを作成"""
        if job_type == "index":
            # インデックス作成オプション
            ctk.CTkLabel(
                parent,
                text="インデックス作成オプション:",
                font=ctk.CTkFont(size=12, weight="bold")
            ).pack(anchor="w", padx=10, pady=(10, 5))

            parent.max_file_mb_var = ctk.StringVar(value="4")
            self.create_option_row(parent, "最大ファイルサイズ (MB):", parent.max_file_mb_var)

            parent.worker_count_var = ctk.StringVar(value="4")
            self.create_option_row(parent, "ワーカー数:", parent.worker_count_var)

        elif job_type == "advise":
            # AI分析オプション
            ctk.CTkLabel(
                parent,
                text="AI分析オプション:",
                font=ctk.CTkFont(size=12, weight="bold")
            ).pack(anchor="w", padx=10, pady=(10, 5))

            parent.complete_report_var = ctk.BooleanVar(value=False)
            ctk.CTkCheckBox(
                parent,
                text="完全レポート生成 (--complete-report)",
                variable=parent.complete_report_var
            ).pack(anchor="w", padx=10, pady=2)

            parent.max_complete_items_var = ctk.StringVar(value="100")
            self.create_option_row(parent, "完全レポート最大件数:", parent.max_complete_items_var)

        elif job_type == "context7":
            # Context7オプション
            ctk.CTkLabel(
                parent,
                text="Context7オプション:",
                font=ctk.CTkFont(size=12, weight="bold")
            ).pack(anchor="w", padx=10, pady=(10, 5))

            # 技術スタック選択（チェックボックス）
            tech_label = ctk.CTkLabel(
                parent,
                text="技術スタック (--tech):",
                font=ctk.CTkFont(size=11)
            )
            tech_label.pack(anchor="w", padx=10, pady=(5, 2))

            # メジャーな技術スタックのチェックボックス
            parent.tech_checkboxes = {}
            tech_stacks = [
                ("react", "React - JavaScriptライブラリ"),
                ("angular", "Angular - TypeScriptフレームワーク"),
                ("vue", "Vue.js - プログレッシブフレームワーク"),
                ("express", "Express - Node.jsバックエンド"),
                ("django", "Django - Pythonフレームワーク"),
                ("spring-boot", "Spring Boot - Javaフレームワーク"),
                ("flask", "Flask - Python軽量フレームワーク"),
                ("nestjs", "NestJS - TypeScriptバックエンド"),
                ("cassandra", "Cassandra - 分散NoSQLデータベース"),
                ("elasticsearch", "Elasticsearch - 検索エンジン"),
                ("redis", "Redis - インメモリKVS"),
                ("mysql", "MySQL - リレーショナルデータベース"),
                ("postgresql", "PostgreSQL - オープンソースデータベース"),
                ("sqlserver", "SQL Server - Microsoft データベース"),
                ("oracle", "Oracle Database - エンタープライズデータベース"),
                ("memcached", "Memcached - 分散メモリキャッシュ")
            ]

            tech_grid = ctk.CTkFrame(parent)
            tech_grid.pack(fill="x", padx=10, pady=(0, 10))

            # デフォルト設定を取得 (Phase 8.4)
            default_tech_stacks = self.config_manager.get_context7_default_tech_stacks()

            for i, (tech, desc) in enumerate(tech_stacks):
                row = i // 2
                col = i % 2

                # デフォルト設定に含まれている場合はチェック済みに (Phase 8.4)
                is_default = tech in default_tech_stacks
                var = ctk.BooleanVar(value=is_default)
                parent.tech_checkboxes[tech] = var

                checkbox = ctk.CTkCheckBox(
                    tech_grid,
                    text=desc,
                    variable=var,
                    width=250
                )
                checkbox.grid(row=row, column=col, sticky="w", padx=5, pady=2)

            # トピック選択（チェックボックス）
            topic_label = ctk.CTkLabel(
                parent,
                text="トピック (--topic) - 分析フォーカス:",
                font=ctk.CTkFont(size=11)
            )
            topic_label.pack(anchor="w", padx=10, pady=(10, 2))

            # トピックのチェックボックス（大幅に増量）
            parent.topic_checkboxes = {}
            topics = [
                ("security", "セキュリティ - 脆弱性・認証・XSS・SQLi・CSRF対策"),
                ("performance", "パフォーマンス - 速度最適化・メモリ管理・レンダリング"),
                ("best-practices", "ベストプラクティス - コーディング規約・設計パターン"),
                ("error-handling", "エラーハンドリング - 例外処理・リトライ・ロギング"),
                ("testing", "テスト - ユニットテスト・統合テスト・E2Eテスト"),
                ("accessibility", "アクセシビリティ - ARIA・キーボード対応・スクリーンリーダー"),
                ("optimization", "最適化 - バンドルサイズ・コード分割・遅延ロード"),
                ("architecture", "アーキテクチャ - 設計原則・モジュール分割・依存関係"),
                ("patterns", "デザインパターン - Factory・Observer・Singleton等"),
                ("styling", "スタイリング - CSS設計・レスポンシブ・テーマ"),
                ("state-management", "状態管理 - Redux・Vuex・NgRx・Context API"),
                ("routing", "ルーティング - ナビゲーション・ガード・遅延ロード"),
                ("deployment", "デプロイ - ビルド最適化・CI/CD・環境設定"),
                ("monitoring", "モニタリング - ログ・メトリクス・エラートラッキング"),
                ("api-integration", "API連携 - REST・GraphQL・WebSocket・認証"),
                ("data-validation", "データ検証 - バリデーション・型安全性・サニタイズ")
            ]

            # スクロール可能なトピックリスト
            topic_scroll = ctk.CTkScrollableFrame(parent, height=200)
            topic_scroll.pack(fill="x", padx=10, pady=(0, 10))

            # トピック数に応じて列数を決定（8行で折り返し）
            topic_count = len(topics)
            if topic_count <= 16:
                num_columns = 2  # 16個以内: 2列
            elif topic_count <= 24:
                num_columns = 3  # 24個以内: 3列
            else:
                num_columns = 4  # 25個以上: 4列

            max_rows = 8  # 8行で折り返し

            # デフォルト設定を取得 (Phase 8.4)
            default_topics = self.config_manager.get_context7_default_topics()

            for i, (topic, desc) in enumerate(topics):
                # デフォルト設定に含まれている場合はチェック済みに (Phase 8.4)
                is_default = topic in default_topics
                var = ctk.BooleanVar(value=is_default)
                parent.topic_checkboxes[topic] = var

                # 行と列を計算（8行で折り返し、左から右、上から下）
                col = i // max_rows
                row = i % max_rows

                checkbox = ctk.CTkCheckBox(
                    topic_scroll,
                    text=desc,
                    variable=var,
                    width=350  # 幅を指定してテキストが見切れないように
                )
                checkbox.grid(row=row, column=col, sticky="w", padx=5, pady=2)

        elif job_type == "integration_test":
            # 統合テストオプション (新機能)
            ctk.CTkLabel(
                parent,
                text="統合テストオプション:",
                font=ctk.CTkFont(size=12, weight="bold")
            ).pack(anchor="w", padx=10, pady=(10, 5))

            # プロジェクトタイプ選択
            project_label = ctk.CTkLabel(
                parent,
                text="プロジェクトタイプ (--project-type):",
                font=ctk.CTkFont(size=11)
            )
            project_label.pack(anchor="w", padx=10, pady=(5, 2))

            project_types = [
                ("react", "React - JavaScriptライブラリ"),
                ("angular", "Angular - TypeScriptフレームワーク"),
                ("vue", "Vue.js - プログレッシブフレームワーク"),
                ("express", "Express - Node.jsバックエンド"),
                ("django", "Django - Pythonフレームワーク"),
                ("spring-boot", "Spring Boot - Javaフレームワーク"),
                ("flask", "Flask - Python軽量フレームワーク"),
                ("nestjs", "NestJS - TypeScriptバックエンド"),
                ("cassandra", "Cassandra - 分散NoSQLデータベース"),
                ("elasticsearch", "Elasticsearch - 検索エンジン"),
                ("redis", "Redis - インメモリKVS"),
                ("mysql", "MySQL - リレーショナルデータベース"),
                ("postgresql", "PostgreSQL - オープンソースデータベース"),
                ("sqlserver", "SQL Server - Microsoft データベース"),
                ("oracle", "Oracle Database - エンタープライズデータベース"),
                ("memcached", "Memcached - 分散メモリキャッシュ")
            ]

            parent.project_checkboxes = {}
            project_grid = ctk.CTkFrame(parent)
            project_grid.pack(fill="x", padx=10, pady=(0, 10))

            # デフォルト設定を取得 (Phase 8.4)
            default_projects = self.config_manager.get_integration_test_default_project_types()

            for i, (proj, desc) in enumerate(project_types):
                row = i // 2
                col = i % 2

                # デフォルト設定に含まれている場合はチェック済みに (Phase 8.4)
                is_default = proj in default_projects
                var = ctk.BooleanVar(value=is_default)
                parent.project_checkboxes[proj] = var

                checkbox = ctk.CTkCheckBox(
                    project_grid,
                    text=desc,
                    variable=var,
                    width=250
                )
                checkbox.grid(row=row, column=col, sticky="w", padx=5, pady=2)

            # トピック選択（統合テスト用）
            topic_label = ctk.CTkLabel(
                parent,
                text="トピック (--topics) - 分析フォーカス:",
                font=ctk.CTkFont(size=11)
            )
            topic_label.pack(anchor="w", padx=10, pady=(10, 2))

            # トピックのチェックボックス（Context7と完全同期 - 16種類）
            parent.topic_checkboxes = {}
            topics = [
                ("security", "セキュリティ - 脆弱性・認証・XSS・SQLi・CSRF対策"),
                ("performance", "パフォーマンス - 速度最適化・メモリ管理・レンダリング"),
                ("best-practices", "ベストプラクティス - コーディング規約・設計パターン"),
                ("error-handling", "エラーハンドリング - 例外処理・リトライ・ロギング"),
                ("testing", "テスト - ユニットテスト・統合テスト・E2Eテスト"),
                ("accessibility", "アクセシビリティ - ARIA・キーボード対応・スクリーンリーダー"),
                ("optimization", "最適化 - バンドルサイズ・コード分割・遅延ロード"),
                ("architecture", "アーキテクチャ - 設計原則・モジュール分割・依存関係"),
                ("patterns", "デザインパターン - Factory・Observer・Singleton等"),
                ("styling", "スタイリング - CSS設計・レスポンシブ・テーマ"),
                ("state-management", "状態管理 - Redux・Vuex・NgRx・Context API"),
                ("routing", "ルーティング - ナビゲーション・ガード・遅延ロード"),
                ("deployment", "デプロイ - ビルド最適化・CI/CD・環境設定"),
                ("monitoring", "モニタリング - ログ・メトリクス・エラートラッキング"),
                ("api-integration", "API連携 - REST・GraphQL・WebSocket・認証"),
                ("data-validation", "データ検証 - バリデーション・型安全性・サニタイズ")
            ]

            topic_scroll = ctk.CTkScrollableFrame(parent, height=200)
            topic_scroll.pack(fill="x", padx=10, pady=(0, 10))

            # 2列レイアウト（8行で折り返し）
            max_rows = 8

            # デフォルト設定を取得 (Phase 8.4)
            default_topics = self.config_manager.get_integration_test_default_topics()

            for i, (topic, desc) in enumerate(topics):
                col = i // max_rows
                row = i % max_rows

                # デフォルト設定に含まれている場合はチェック済みに (Phase 8.4)
                is_default = topic in default_topics
                var = ctk.BooleanVar(value=is_default)
                parent.topic_checkboxes[topic] = var

                checkbox = ctk.CTkCheckBox(
                    topic_scroll,
                    text=desc,
                    variable=var,
                    width=350
                )
                checkbox.grid(row=row, column=col, sticky="w", padx=5, pady=2)

            # ファイル容量・並列度オプション（統合テスト用）
            ctk.CTkLabel(
                parent,
                text="インデックス作成オプション:",
                font=ctk.CTkFont(size=12, weight="bold")
            ).pack(anchor="w", padx=10, pady=(15, 5))

            parent.max_file_mb_var = ctk.StringVar(value="4")
            self.create_option_row(parent, "最大ファイルサイズ (MB):", parent.max_file_mb_var)

            parent.worker_count_var = ctk.StringVar(value="4")
            self.create_option_row(parent, "ワーカー数:", parent.worker_count_var)

    def create_option_row(self, parent, label_text: str, variable, placeholder: str = ""):
        """オプション行を作成"""
        row_frame = ctk.CTkFrame(parent)
        row_frame.pack(fill="x", padx=10, pady=2)

        label = ctk.CTkLabel(row_frame, text=label_text, width=180, anchor="w")
        label.pack(side="left", padx=(0, 5))

        entry = ctk.CTkEntry(
            row_frame,
            textvariable=variable,
            width=200,
            placeholder_text=placeholder
        )
        entry.pack(side="left", fill="x", expand=True)

    def setup_monitor_tab(self):
        """監視タブ - Phase 4.2完全実装"""
        tab = self.tabview.tab("📊 監視")

        # 上部: 実行中ジョブ
        jobs_frame = ctk.CTkFrame(tab)
        jobs_frame.pack(fill="both", expand=True, padx=10, pady=10)

        jobs_label = ctk.CTkLabel(
            jobs_frame,
            text="実行中のジョブ",
            font=ctk.CTkFont(size=16, weight="bold")
        )
        jobs_label.pack(anchor="w", padx=10, pady=10)

        # ジョブリスト（スクロール可能）
        self.jobs_list = ctk.CTkScrollableFrame(jobs_frame, height=200)
        self.jobs_list.pack(fill="both", expand=True, padx=10, pady=(0, 10))

        # 下部: リアルタイムログ（LogViewerウィジェット使用）
        log_frame = ctk.CTkFrame(tab)
        log_frame.pack(fill="both", expand=True, padx=10, pady=(0, 10))

        log_label = ctk.CTkLabel(
            log_frame,
            text="リアルタイムログ",
            font=ctk.CTkFont(size=16, weight="bold")
        )
        log_label.pack(anchor="w", padx=10, pady=10)

        # LogViewerウィジェット
        self.log_viewer = LogViewer(log_frame)
        self.log_viewer.pack(fill="both", expand=True, padx=10, pady=(0, 10))

    def setup_settings_tab(self):
        """設定タブ - プロジェクトルート・ソースフォルダ設定追加"""
        tab = self.tabview.tab("⚙ 設定")

        scroll_frame = ctk.CTkScrollableFrame(tab)
        scroll_frame.pack(fill="both", expand=True, padx=10, pady=10)

        # プロジェクトルート表示 - 新機能
        root_label = ctk.CTkLabel(
            scroll_frame,
            text="プロジェクトルート:",
            font=ctk.CTkFont(size=14, weight="bold")
        )
        root_label.pack(anchor="w", padx=10, pady=(10, 5))

        root_frame = ctk.CTkFrame(scroll_frame)
        root_frame.pack(fill="x", padx=10, pady=(0, 15))

        root_path_label = ctk.CTkLabel(
            root_frame,
            text=str(self.project_root),
            font=ctk.CTkFont(size=11),
            anchor="w"
        )
        root_path_label.pack(side="left", fill="x", expand=True, padx=10, pady=10)

        # フォルダを開くボタン
        open_root_btn = ctk.CTkButton(
            root_frame,
            text="📂 開く",
            command=lambda: self.open_folder(self.project_root),
            width=80,
            height=32
        )
        open_root_btn.pack(side="right", padx=10, pady=10)

        # ソースフォルダ設定 - 既存機能
        src_label = ctk.CTkLabel(
            scroll_frame,
            text="ソースフォルダ:",
            font=ctk.CTkFont(size=14, weight="bold")
        )
        src_label.pack(anchor="w", padx=10, pady=(10, 5))

        # ソースフォルダパス表示 + 選択ボタン
        src_frame = ctk.CTkFrame(scroll_frame)
        src_frame.pack(fill="x", padx=10, pady=(0, 10))

        # 現在のソースフォルダパスを取得（デフォルト: ./src）
        current_src_dir = self.state_manager.get_setting('source_directory', './src')
        self.src_dir_var = ctk.StringVar(value=current_src_dir)

        # パス表示ラベル
        self.src_dir_label = ctk.CTkLabel(
            src_frame,
            text=current_src_dir,
            font=ctk.CTkFont(size=11),
            anchor="w"
        )
        self.src_dir_label.pack(side="left", fill="x", expand=True, padx=(10, 5), pady=10)

        # フォルダ選択ボタン
        browse_btn = ctk.CTkButton(
            src_frame,
            text="📁 選択",
            command=self.select_source_directory,
            width=100,
            height=32
        )
        browse_btn.pack(side="right", padx=10, pady=10)

        # テーマ設定
        theme_label = ctk.CTkLabel(
            scroll_frame,
            text="テーマ:",
            font=ctk.CTkFont(size=14, weight="bold")
        )
        theme_label.pack(anchor="w", padx=10, pady=(10, 5))

        self.theme_var = ctk.StringVar(
            value=self.state_manager.get_setting('theme', 'dark')
        )
        theme_menu = ctk.CTkOptionMenu(
            scroll_frame,
            values=["dark", "light"],
            variable=self.theme_var,
            command=self.change_theme
        )
        theme_menu.pack(anchor="w", padx=10, pady=(0, 10))

        # 並列実行数
        concurrent_label = ctk.CTkLabel(
            scroll_frame,
            text="最大並列実行数:",
            font=ctk.CTkFont(size=14, weight="bold")
        )
        concurrent_label.pack(anchor="w", padx=10, pady=(10, 5))

        self.concurrent_slider = ctk.CTkSlider(
            scroll_frame,
            from_=1,
            to=10,
            number_of_steps=9,
            command=self.change_concurrent_limit
        )
        self.concurrent_slider.set(
            self.state_manager.get_setting('max_concurrent_jobs', 3)
        )
        self.concurrent_slider.pack(fill="x", padx=10, pady=(0, 5))

        self.concurrent_value_label = ctk.CTkLabel(
            scroll_frame,
            text=f"現在: {int(self.concurrent_slider.get())}",
        )
        self.concurrent_value_label.pack(anchor="w", padx=10, pady=(0, 10))

        # デフォルト設定管理 (Phase 8.4)
        defaults_label = ctk.CTkLabel(
            scroll_frame,
            text="デフォルト設定:",
            font=ctk.CTkFont(size=14, weight="bold")
        )
        defaults_label.pack(anchor="w", padx=10, pady=(20, 5))

        defaults_frame = ctk.CTkFrame(scroll_frame)
        defaults_frame.pack(fill="x", padx=10, pady=(0, 10))

        # 説明テキスト
        defaults_desc = ctk.CTkLabel(
            defaults_frame,
            text="起動タブのチェックボックスのデフォルト値を管理します",
            font=ctk.CTkFont(size=11),
            anchor="w"
        )
        defaults_desc.pack(anchor="w", padx=10, pady=(10, 5))

        # 現在の設定サマリー
        summary_text = self.get_defaults_summary()
        self.defaults_summary = ctk.CTkTextbox(
            defaults_frame,
            height=150,
            wrap="word"
        )
        self.defaults_summary.pack(fill="x", padx=10, pady=(5, 10))
        self.defaults_summary.insert("1.0", summary_text)
        self.defaults_summary.configure(state="disabled")

        # ボタンフレーム
        defaults_buttons = ctk.CTkFrame(defaults_frame)
        defaults_buttons.pack(fill="x", padx=10, pady=(0, 10))

        # 設定ファイルを編集ボタン
        edit_defaults_btn = ctk.CTkButton(
            defaults_buttons,
            text="📝 設定ファイルを編集",
            command=self.edit_defaults_config,
            width=150,
            height=32
        )
        edit_defaults_btn.pack(side="left", padx=5)

        # 更新ボタン
        refresh_defaults_btn = ctk.CTkButton(
            defaults_buttons,
            text="🔄 表示を更新",
            command=self.refresh_defaults_display,
            width=120,
            height=32
        )
        refresh_defaults_btn.pack(side="left", padx=5)

        # リセットボタン
        reset_defaults_btn = ctk.CTkButton(
            defaults_buttons,
            text="🔄 デフォルトにリセット",
            command=self.reset_defaults_config,
            width=150,
            height=32,
            fg_color="orange",
            hover_color="darkorange"
        )
        reset_defaults_btn.pack(side="right", padx=5)

    def setup_history_tab(self):
        """履歴タブ - Phase 4.3完全実装"""
        tab = self.tabview.tab("📜 履歴")

        # 統計サマリーフレーム
        stats_frame = ctk.CTkFrame(tab)
        stats_frame.pack(fill="x", padx=10, pady=(10, 5))

        stats_title = ctk.CTkLabel(
            stats_frame,
            text="統計サマリー",
            font=ctk.CTkFont(size=14, weight="bold")
        )
        stats_title.pack(anchor="w", padx=10, pady=(10, 5))

        # 統計ラベル用のフレーム
        stats_content = ctk.CTkFrame(stats_frame)
        stats_content.pack(fill="x", padx=10, pady=(0, 10))

        self.total_jobs_label = ctk.CTkLabel(
            stats_content,
            text="合計ジョブ数: 0",
            font=ctk.CTkFont(size=12)
        )
        self.total_jobs_label.pack(side="left", padx=10)

        self.success_rate_label = ctk.CTkLabel(
            stats_content,
            text="成功率: 0%",
            font=ctk.CTkFont(size=12)
        )
        self.success_rate_label.pack(side="left", padx=10)

        self.avg_time_label = ctk.CTkLabel(
            stats_content,
            text="平均実行時間: 0s",
            font=ctk.CTkFont(size=12)
        )
        self.avg_time_label.pack(side="left", padx=10)

        # 履歴リスト（スクロール可能）
        history_header = ctk.CTkLabel(
            tab,
            text="ジョブ実行履歴",
            font=ctk.CTkFont(size=14, weight="bold")
        )
        history_header.pack(anchor="w", padx=20, pady=(5, 5))

        self.history_list = ctk.CTkScrollableFrame(tab, height=300)
        self.history_list.pack(fill="both", expand=True, padx=10, pady=(0, 10))

        # ボタンフレーム
        button_frame = ctk.CTkFrame(tab)
        button_frame.pack(fill="x", padx=10, pady=(0, 10))

        # 更新ボタン
        refresh_btn = ctk.CTkButton(
            button_frame,
            text="🔄 更新",
            command=self.update_history_view,
            width=120
        )
        refresh_btn.pack(side="left", padx=5)

        # クリアボタン
        clear_history_btn = ctk.CTkButton(
            button_frame,
            text="🗑 履歴クリア",
            command=self.clear_history,
            width=120
        )
        clear_history_btn.pack(side="right", padx=5)

    # イベントハンドラー

    def launch_context7_analysis(self):
        """Context7統合分析を起動 - チェックボックス対応"""
        command = ['python', 'generate_tech_config.py']

        # Context7オプションフレームを取得
        options_frame = self.job_sections.get("context7")

        if options_frame and hasattr(options_frame, 'tech_checkboxes'):
            # 選択された技術スタックを取得
            selected_techs = [
                tech for tech, var in options_frame.tech_checkboxes.items()
                if var.get()
            ]

            # 技術スタックが選択されている場合、最初のものを使用
            if selected_techs:
                command.extend(['--tech', selected_techs[0]])

        if options_frame and hasattr(options_frame, 'topic_checkboxes'):
            # 選択されたトピックを取得
            selected_topics = [
                topic for topic, var in options_frame.topic_checkboxes.items()
                if var.get()
            ]

            # Phase 3実装: トピックが選択されている場合、全てを渡す（複数トピック対応）
            if selected_topics:
                for topic in selected_topics:
                    command.extend(['--topic', topic])

        # --auto-runフラグを追加（完全自動実行）
        command.append('--auto-run')

        self.start_job("Context7統合分析", command, JobPriority.HIGH)

    def launch_index_creation(self):
        """インデックス作成を起動 - ソースディレクトリ対応"""
        command = ['python', 'codex_review_severity.py', 'index']

        # ソースディレクトリ設定を追加
        src_dir = self.state_manager.get_setting('source_directory', './src')
        if src_dir and src_dir != './src':  # デフォルト以外の場合のみ追加
            command.extend(['--src-dir', src_dir])

        self.start_job("インデックス作成", command, JobPriority.NORMAL)

    def launch_ai_analysis(self):
        """AI分析を起動"""
        command = ['python', 'codex_review_severity.py', 'advise', '--all']
        self.start_job("AI分析", command, JobPriority.NORMAL)

    def launch_apply_improvements(self):
        """改善コード適用を起動 - --apply標準対応"""
        # レポートファイル選択ダイアログ
        from tkinter import filedialog, messagebox
        import os

        # 初期ディレクトリをreportsフォルダに設定
        initial_dir = os.path.join(os.getcwd(), 'reports')
        if not os.path.exists(initial_dir):
            initial_dir = os.getcwd()

        # ファイル選択ダイアログを表示
        report_file = filedialog.askopenfilename(
            title="改善レポートを選択（全改善コードを適用）",
            initialdir=initial_dir,
            filetypes=[
                ("Markdown files", "*.md"),
                ("Text files", "*.txt"),
                ("All files", "*.*")
            ]
        )

        if report_file:
            # 確認ダイアログを表示
            result = messagebox.askyesno(
                "確認",
                f"レポート内の全改善コードを適用します。\n\n"
                f"ファイル: {os.path.basename(report_file)}\n\n"
                f"バックアップは自動的に作成されます。\n"
                f"続行しますか？",
                icon='question'
            )

            if result:
                # --applyフラグを標準で追加（全改善を適用）
                command = ['python', 'apply_improvements_from_report.py', report_file, '--apply']
                self.start_job("改善コード適用（全体）", command, JobPriority.LOW)
            else:
                self.update_status("改善コード適用がキャンセルされました")
        else:
            self.update_status("レポートファイル選択がキャンセルされました")

    def launch_integration_test(self):
        """統合テストを起動 - 新機能"""
        # 統合テストオプションフレームを取得
        options_frame = self.job_sections.get("integration_test")

        if not options_frame:
            self.show_error("統合テストオプションが見つかりません")
            return

        # プロジェクトタイプを取得
        selected_projects = []
        if hasattr(options_frame, 'project_checkboxes'):
            selected_projects = [
                proj for proj, var in options_frame.project_checkboxes.items()
                if var.get()
            ]

        if not selected_projects:
            from tkinter import messagebox
            messagebox.showwarning(
                "プロジェクトタイプ未選択",
                "プロジェクトタイプを選択してください。"
            )
            return

        # 選択されたトピックを取得
        selected_topics = []
        if hasattr(options_frame, 'topic_checkboxes'):
            selected_topics = [
                topic for topic, var in options_frame.topic_checkboxes.items()
                if var.get()
            ]

        if not selected_topics:
            from tkinter import messagebox
            messagebox.showwarning(
                "トピック未選択",
                "少なくとも1つのトピックを選択してください。"
            )
            return

        # コマンドを構築（最初のプロジェクトタイプのみ使用）
        project_type = selected_projects[0]
        command = ['python', '-m', 'core.integration_test_engine',
                   '--project-type', project_type]

        # トピックを追加
        command.append('--topics')
        command.extend(selected_topics)

        # max-file-mbとworker-countを追加
        if hasattr(options_frame, 'max_file_mb_var'):
            max_file_mb = options_frame.max_file_mb_var.get()
            if max_file_mb:
                command.extend(['--max-file-mb', max_file_mb])

        if hasattr(options_frame, 'worker_count_var'):
            worker_count = options_frame.worker_count_var.get()
            if worker_count:
                command.extend(['--worker-count', worker_count])

        # ジョブ名
        job_name = f"統合テスト ({project_type})"

        self.start_job(job_name, command, JobPriority.HIGH)

    def start_job(self, name: str, command: list, priority: JobPriority):
        """ジョブを開始 - Phase 4.2完全実装"""
        try:
            job_id = self.queue_manager.add_job(
                name=name,
                command=command,
                priority=priority
            )

            # キューを処理
            started = self.queue_manager.process_queue()

            if job_id in started:
                # プロセスマネージャーで起動
                self.process_manager.start_process(command, job_id=job_id)

                # プロセスパイプを取得
                pipes = self.process_manager.get_process_pipes(job_id)
                if pipes:
                    stdout, stderr = pipes
                    # ログ収集開始
                    self.log_collector.start_collecting(job_id, stdout, stderr)

                # ジョブカードを作成
                self.create_job_card(job_id, name)

                self.update_status(f"ジョブ起動: {name}")
            else:
                self.update_status(f"ジョブキュー追加: {name}")

        except Exception as e:
            self.show_error(f"ジョブ起動失敗: {str(e)}")

    def create_job_card(self, job_id: str, name: str):
        """ジョブカードを作成 - Phase 4.2新機能"""
        # ジョブフレーム
        job_frame = ctk.CTkFrame(self.jobs_list)
        job_frame.pack(fill="x", padx=5, pady=5)

        # ヘッダー
        header_frame = ctk.CTkFrame(job_frame)
        header_frame.pack(fill="x", padx=10, pady=(10, 5))

        job_label = ctk.CTkLabel(
            header_frame,
            text=f"{name} [{job_id[:8]}]",
            font=ctk.CTkFont(size=12, weight="bold")
        )
        job_label.pack(side="left")

        # コントロールボタン
        button_frame = ctk.CTkFrame(header_frame)
        button_frame.pack(side="right")

        pause_btn = ctk.CTkButton(
            button_frame,
            text="⏸ 一時停止",
            width=80,
            height=24,
            command=lambda: self.pause_job(job_id)
        )
        pause_btn.pack(side="left", padx=2)

        resume_btn = ctk.CTkButton(
            button_frame,
            text="▶ 再開",
            width=60,
            height=24,
            command=lambda: self.resume_job(job_id),
            state="disabled"  # 初期状態では無効
        )
        resume_btn.pack(side="left", padx=2)

        stop_btn = ctk.CTkButton(
            button_frame,
            text="⏹ 停止",
            width=60,
            height=24,
            fg_color="red",
            hover_color="darkred",
            command=lambda: self.stop_job(job_id)
        )
        stop_btn.pack(side="left", padx=2)

        # プログレスウィジェット
        progress_widget = ProgressWidget(job_frame)
        progress_widget.pack(fill="x", padx=10, pady=(0, 10))

        # ウィジェットを保存
        self.job_widgets[job_id] = {
            'name': name,  # Phase 4.3: ジョブ名を保存
            'frame': job_frame,
            'progress': progress_widget,
            'buttons': {
                'pause': pause_btn,
                'resume': resume_btn,
                'stop': stop_btn
            }
        }

    def pause_job(self, job_id: str):
        """ジョブを一時停止"""
        if self.process_manager.pause_process(job_id):
            self.update_status(f"ジョブ一時停止: {job_id[:8]}")
            # ボタン状態更新
            if job_id in self.job_widgets:
                self.job_widgets[job_id]['buttons']['pause'].configure(state="disabled")
                self.job_widgets[job_id]['buttons']['resume'].configure(state="normal")
        else:
            self.show_error(f"一時停止失敗: {job_id[:8]}")

    def resume_job(self, job_id: str):
        """ジョブを再開"""
        if self.process_manager.resume_process(job_id):
            self.update_status(f"ジョブ再開: {job_id[:8]}")
            # ボタン状態更新
            if job_id in self.job_widgets:
                self.job_widgets[job_id]['buttons']['pause'].configure(state="normal")
                self.job_widgets[job_id]['buttons']['resume'].configure(state="disabled")
        else:
            self.show_error(f"再開失敗: {job_id[:8]}")

    def stop_job(self, job_id: str):
        """ジョブを停止"""
        if self.process_manager.stop_process(job_id):
            self.log_collector.stop_collecting(job_id)
            self.update_status(f"ジョブ停止: {job_id[:8]}")
            # ジョブカードを削除
            if job_id in self.job_widgets:
                self.job_widgets[job_id]['frame'].destroy()
                del self.job_widgets[job_id]
        else:
            self.show_error(f"停止失敗: {job_id[:8]}")

    def clear_logs(self):
        """ログをクリア - Phase 4.2更新"""
        self.log_viewer.clear_logs()
        self.update_status("ログクリア完了")

    def clear_history(self):
        """履歴をクリア"""
        self.state_manager.clear_job_history()
        self.update_history_view()
        self.update_status("履歴クリア完了")

    def change_theme(self, theme: str):
        """テーマ変更"""
        ctk.set_appearance_mode(theme)
        self.state_manager.set_setting('theme', theme)
        self.update_status(f"テーマ変更: {theme}")

    def change_concurrent_limit(self, value):
        """並列実行数変更"""
        limit = int(value)
        self.concurrent_value_label.configure(text=f"現在: {limit}")
        self.queue_manager.max_concurrent = limit
        self.state_manager.set_setting('max_concurrent_jobs', limit)

    def select_source_directory(self):
        """ソースディレクトリを選択 - 新機能"""
        from tkinter import filedialog

        # 現在のソースディレクトリを初期ディレクトリとして使用
        current_dir = self.state_manager.get_setting('source_directory', './src')
        if not os.path.exists(current_dir):
            current_dir = os.getcwd()

        # フォルダ選択ダイアログを表示
        selected_dir = filedialog.askdirectory(
            title="ソースフォルダを選択",
            initialdir=current_dir
        )

        if selected_dir:
            # 相対パスに変換（プロジェクトルートからの相対パス）
            try:
                rel_path = os.path.relpath(selected_dir, os.getcwd())
                # Windowsのバックスラッシュをスラッシュに変換
                rel_path = rel_path.replace('\\', '/')
            except ValueError:
                # 異なるドライブの場合は絶対パスを使用
                rel_path = selected_dir.replace('\\', '/')

            # 設定を保存
            self.state_manager.set_setting('source_directory', rel_path)
            self.src_dir_var.set(rel_path)

            # UIを更新
            self.src_dir_label.configure(text=rel_path)

            self.update_status(f"ソースフォルダを設定: {rel_path}")
        else:
            self.update_status("ソースフォルダ選択がキャンセルされました")

    def get_defaults_summary(self) -> str:
        """デフォルト設定のサマリーテキストを取得 (Phase 8.4)"""
        lines = []
        lines.append("【Context7統合分析】")
        lines.append("")

        # 技術スタック
        tech_stacks = self.config_manager.get_context7_default_tech_stacks()
        if tech_stacks:
            lines.append(f"  技術スタック: {', '.join(tech_stacks)}")
        else:
            lines.append("  技術スタック: (なし)")

        # トピック
        topics = self.config_manager.get_context7_default_topics()
        if topics:
            lines.append(f"  トピック: {', '.join(topics)}")
        else:
            lines.append("  トピック: (なし)")

        lines.append("")
        lines.append("【統合テスト】")
        lines.append("")

        # プロジェクトタイプ
        projects = self.config_manager.get_integration_test_default_project_types()
        if projects:
            lines.append(f"  プロジェクトタイプ: {', '.join(projects)}")
        else:
            lines.append("  プロジェクトタイプ: (なし)")

        # トピック
        test_topics = self.config_manager.get_integration_test_default_topics()
        if test_topics:
            lines.append(f"  トピック: {', '.join(test_topics)}")
        else:
            lines.append("  トピック: (なし)")

        # インデックスオプション
        lines.append("")
        max_mb = self.config_manager.get_integration_test_default_max_file_mb()
        worker = self.config_manager.get_integration_test_default_worker_count()
        lines.append(f"  最大ファイルサイズ: {max_mb} MB")
        lines.append(f"  ワーカー数: {worker}")

        return "\n".join(lines)

    def edit_defaults_config(self):
        """デフォルト設定ファイルを編集 (Phase 8.4)"""
        import subprocess
        import platform

        config_file = Path('config/integration_test_defaults.yml')
        if not config_file.exists():
            self.show_error("設定ファイルが見つかりません")
            return

        try:
            system = platform.system()
            if system == 'Windows':
                os.startfile(str(config_file))
            elif system == 'Darwin':  # macOS
                subprocess.run(['open', str(config_file)])
            else:  # Linux
                subprocess.run(['xdg-open', str(config_file)])

            self.update_status("設定ファイルを開きました")

            # 確認ダイアログ
            from tkinter import messagebox
            messagebox.showinfo(
                "設定ファイル編集",
                "設定ファイルを編集したら、「表示を更新」ボタンで反映してください。"
            )
        except Exception as e:
            self.show_error(f"設定ファイルを開けませんでした: {str(e)}")

    def refresh_defaults_display(self):
        """デフォルト設定表示を更新 (Phase 8.4)"""
        try:
            # 設定を再読み込み
            self.config_manager.reload_config()

            # サマリーテキストを更新
            summary_text = self.get_defaults_summary()
            self.defaults_summary.configure(state="normal")
            self.defaults_summary.delete("1.0", "end")
            self.defaults_summary.insert("1.0", summary_text)
            self.defaults_summary.configure(state="disabled")

            self.update_status("デフォルト設定を更新しました")
        except Exception as e:
            self.show_error(f"設定更新失敗: {str(e)}")

    def reset_defaults_config(self):
        """デフォルト設定をリセット (Phase 8.4)"""
        from tkinter import messagebox

        # 確認ダイアログ
        result = messagebox.askyesno(
            "確認",
            "デフォルト設定をリセットします。\n"
            "現在の設定は失われますが、よろしいですか？",
            icon='warning'
        )

        if not result:
            self.update_status("リセットがキャンセルされました")
            return

        try:
            # リセット実行
            self.config_manager.reset_to_defaults()

            # 表示を更新
            self.refresh_defaults_display()

            self.update_status("デフォルト設定をリセットしました")

            messagebox.showinfo(
                "リセット完了",
                "デフォルト設定をリセットしました。"
            )
        except Exception as e:
            self.show_error(f"リセット失敗: {str(e)}")

    def show_file_menu(self):
        """ファイルメニュー表示 - Phase 4.4完全実装"""
        # メニューウィンドウ作成
        menu = ctk.CTkToplevel(self)
        menu.title("ファイルメニュー")
        menu.geometry("280x320")
        menu.resizable(False, False)

        # メニューをメインウィンドウの上に配置
        menu.transient(self)
        menu.grab_set()

        # メニュー項目フレーム
        menu_frame = ctk.CTkFrame(menu)
        menu_frame.pack(fill="both", expand=True, padx=10, pady=10)

        # 設定ファイルを開く
        open_config_btn = ctk.CTkButton(
            menu_frame,
            text="📝 設定ファイルを開く",
            command=lambda: [self.open_config_file(), menu.destroy()],
            height=40,
            anchor="w"
        )
        open_config_btn.pack(fill="x", pady=5)

        # レポートフォルダを開く
        open_reports_btn = ctk.CTkButton(
            menu_frame,
            text="📊 レポートフォルダを開く",
            command=lambda: [self.open_reports_folder(), menu.destroy()],
            height=40,
            anchor="w"
        )
        open_reports_btn.pack(fill="x", pady=5)

        # 区切り線
        separator = ctk.CTkFrame(menu_frame, height=2)
        separator.pack(fill="x", pady=10)

        # 状態をエクスポート
        export_btn = ctk.CTkButton(
            menu_frame,
            text="💾 状態をエクスポート",
            command=lambda: [self.export_state(), menu.destroy()],
            height=40,
            anchor="w"
        )
        export_btn.pack(fill="x", pady=5)

        # 状態をインポート
        import_btn = ctk.CTkButton(
            menu_frame,
            text="📂 状態をインポート",
            command=lambda: [self.import_state(), menu.destroy()],
            height=40,
            anchor="w"
        )
        import_btn.pack(fill="x", pady=5)

        # 区切り線
        separator2 = ctk.CTkFrame(menu_frame, height=2)
        separator2.pack(fill="x", pady=10)

        # 終了
        quit_btn = ctk.CTkButton(
            menu_frame,
            text="🚪 終了",
            command=lambda: [menu.destroy(), self.quit_app()],
            height=40,
            anchor="w",
            fg_color="red",
            hover_color="darkred"
        )
        quit_btn.pack(fill="x", pady=5)

    def show_help(self):
        """ヘルプ表示 - 改善版（モーダルダイアログ）"""
        help_text = """
BugSearch2 GUI Control Center v4.11.5

【使用方法】
1. 設定タブでソースフォルダを設定
2. 起動タブでジョブを開始
3. 監視タブで進捗を確認
4. 履歴タブで実行結果を確認

【各タブの機能】
🚀 起動: 分析ジョブの起動
📊 監視: リアルタイムログと進捗
⚙ 設定: テーマ/並列度/ソースフォルダ
📜 履歴: 過去の実行結果と統計

【ショートカット】
- 📁 File → レポート/設定ファイルを開く
- ❓ Help → このヘルプを表示

詳細: doc/guides/GUI_USER_GUIDE.md
        """
        # モーダルダイアログ作成
        dialog = ctk.CTkToplevel(self)
        dialog.title("ヘルプ - BugSearch2")
        dialog.geometry("500x450")
        dialog.resizable(False, False)

        # メインウィンドウの中央に配置
        dialog.transient(self)

        # モーダル化（他の操作をブロック）
        dialog.grab_set()

        # メインウィンドウの中央に配置計算
        x = self.winfo_x() + (self.winfo_width() // 2) - (500 // 2)
        y = self.winfo_y() + (self.winfo_height() // 2) - (450 // 2)
        dialog.geometry(f"+{x}+{y}")

        # テキストボックス
        text = ctk.CTkTextbox(dialog, wrap="word")
        text.pack(fill="both", expand=True, padx=10, pady=(10, 5))
        text.insert("1.0", help_text)
        text.configure(state="disabled")

        # 閉じるボタン
        close_btn = ctk.CTkButton(
            dialog,
            text="閉じる",
            command=dialog.destroy,
            width=120,
            height=36
        )
        close_btn.pack(pady=(5, 10))

    def update_status(self, message: str):
        """ステータスバー更新"""
        self.status_bar.configure(text=message)

    def show_error(self, message: str):
        """エラー表示"""
        self.update_status(f"❌ {message}")

    def update_history_view(self):
        """履歴ビュー更新 - Phase 4.3完全実装"""
        # 全ジョブ履歴を取得
        all_history = self.state_manager.get_all_job_history()

        # 統計計算
        total_jobs = len(all_history)
        completed_jobs = sum(1 for job in all_history.values() if job.get('status') == 'completed')
        success_rate = (completed_jobs / total_jobs * 100) if total_jobs > 0 else 0

        total_time = sum(job.get('elapsed_time', 0) for job in all_history.values())
        avg_time = (total_time / total_jobs) if total_jobs > 0 else 0

        # 統計ラベル更新
        self.total_jobs_label.configure(text=f"合計ジョブ数: {total_jobs}")
        self.success_rate_label.configure(text=f"成功率: {success_rate:.1f}%")
        self.avg_time_label.configure(text=f"平均実行時間: {avg_time:.1f}s")

        # 既存の履歴カードをクリア
        for widget in self.history_list.winfo_children():
            widget.destroy()

        # 履歴カードを生成（最新順）
        sorted_history = sorted(
            all_history.items(),
            key=lambda x: x[1].get('recorded_at', 0),
            reverse=True
        )

        for job_id, job_info in sorted_history:
            self.create_history_card(job_id, job_info)

    def create_history_card(self, job_id: str, job_info: dict):
        """履歴カードを作成 - Phase 4.3新機能"""
        # カードフレーム
        card = ctk.CTkFrame(self.history_list)
        card.pack(fill="x", padx=5, pady=5)

        # ヘッダー（ジョブ名とステータス）
        header_frame = ctk.CTkFrame(card)
        header_frame.pack(fill="x", padx=10, pady=(10, 5))

        job_name_label = ctk.CTkLabel(
            header_frame,
            text=f"{job_info.get('name', 'Unknown')} [{job_id[:8]}]",
            font=ctk.CTkFont(size=12, weight="bold")
        )
        job_name_label.pack(side="left")

        # ステータスバッジ
        status = job_info.get('status', 'unknown')
        status_colors = {
            'completed': 'green',
            'failed': 'red',
            'running': 'blue',
            'queued': 'orange'
        }
        status_color = status_colors.get(status, 'gray')

        status_badge = ctk.CTkLabel(
            header_frame,
            text=f"● {status}",
            text_color=status_color,
            font=ctk.CTkFont(size=11)
        )
        status_badge.pack(side="right", padx=5)

        # 詳細情報
        info_frame = ctk.CTkFrame(card)
        info_frame.pack(fill="x", padx=10, pady=(0, 10))

        # 実行時間
        elapsed_time = job_info.get('elapsed_time', 0)
        time_label = ctk.CTkLabel(
            info_frame,
            text=f"⏱ 実行時間: {elapsed_time:.1f}s",
            font=ctk.CTkFont(size=10)
        )
        time_label.pack(side="left", padx=5)

        # タイムスタンプ
        recorded_at = job_info.get('recorded_at', 0)
        if recorded_at > 0:
            import datetime
            dt = datetime.datetime.fromtimestamp(recorded_at)
            timestamp_str = dt.strftime('%Y-%m-%d %H:%M:%S')
            timestamp_label = ctk.CTkLabel(
                info_frame,
                text=f"📅 {timestamp_str}",
                font=ctk.CTkFont(size=10)
            )
            timestamp_label.pack(side="right", padx=5)

    def periodic_update(self):
        """定期更新 - Phase 4.2完全実装"""
        # キュー状態更新
        status = self.queue_manager.get_status()
        self.update_status(
            f"実行中: {status['running']}/{status['max_concurrent']} | "
            f"キュー: {status['queued']} | 完了: {status['completed']}"
        )

        # 各ジョブのログと進捗を更新
        for job_id in list(self.job_widgets.keys()):
            # ログを取得して表示
            logs = self.log_collector.get_logs(job_id, limit=50)  # 最新50件
            if logs:
                # LogViewerに追加
                self.log_viewer.add_logs(logs)
                # ログバッファをクリア（重複防止）
                self.log_collector.clear_logs(job_id)

            # 進捗を更新
            progress = self.log_collector.get_progress(job_id)
            if progress is not None:
                widget = self.job_widgets[job_id]['progress']
                # プロセス情報を取得してステータステキストを設定
                proc_info = self.process_manager.get_process_info(job_id)
                if proc_info:
                    status_text = f"{proc_info['status']}"
                    widget.set_progress(progress, status_text)

            # 完了したジョブをチェック
            proc_status = self.process_manager.check_process_status(job_id)
            if proc_status in ['completed', 'failed']:
                # ログ収集を停止
                self.log_collector.stop_collecting(job_id)
                # プログレスを100%に設定
                widget = self.job_widgets[job_id]['progress']
                widget.set_progress(1.0, proc_status)
                # ボタンを無効化
                self.job_widgets[job_id]['buttons']['pause'].configure(state="disabled")
                self.job_widgets[job_id]['buttons']['resume'].configure(state="disabled")
                self.job_widgets[job_id]['buttons']['stop'].configure(state="disabled")

                # ジョブ履歴に記録 - Phase 4.3新機能
                proc_info = self.process_manager.get_process_info(job_id)
                if proc_info and job_id in self.job_widgets:
                    job_name = self.job_widgets[job_id].get('name', 'Unknown')
                    self.state_manager.add_job_history(job_id, {
                        'name': job_name,
                        'status': proc_status,
                        'elapsed_time': time.time() - proc_info.get('start_time', time.time())
                    })

        # 次の更新をスケジュール
        self.after(self.update_interval, self.periodic_update)

    def open_config_file(self):
        """設定ファイルを開く - Phase 4.4新機能"""
        import subprocess
        import platform

        config_file = Path('.bugsearch.yml')
        if not config_file.exists():
            self.show_error("設定ファイル (.bugsearch.yml) が見つかりません")
            return

        try:
            system = platform.system()
            if system == 'Windows':
                os.startfile(str(config_file))
            elif system == 'Darwin':  # macOS
                subprocess.run(['open', str(config_file)])
            else:  # Linux
                subprocess.run(['xdg-open', str(config_file)])

            self.update_status("設定ファイルを開きました")
        except Exception as e:
            self.show_error(f"設定ファイルを開けませんでした: {str(e)}")

    def open_reports_folder(self):
        """レポートフォルダを開く - Phase 4.4新機能"""
        reports_dir = Path('reports')
        if not reports_dir.exists():
            reports_dir.mkdir(parents=True, exist_ok=True)

        self.open_folder(reports_dir)

    def open_folder(self, folder_path: Path):
        """汎用フォルダオープン機能 - バックグラウンドスレッド対応"""
        import subprocess
        import platform

        def _open_in_thread():
            """バックグラウンドスレッドでフォルダを開く"""
            try:
                system = platform.system()
                if system == 'Windows':
                    os.startfile(str(folder_path))
                elif system == 'Darwin':  # macOS
                    subprocess.run(['open', str(folder_path)])
                else:  # Linux
                    subprocess.run(['xdg-open', str(folder_path)])

                # 成功時のステータス更新（after()でメインスレッドで実行）
                self.after(0, lambda: self.update_status(f"フォルダを開きました: {folder_path}"))
            except Exception as e:
                # エラー時のステータス更新（after()でメインスレッドで実行）
                self.after(0, lambda: self.show_error(f"フォルダを開けませんでした: {str(e)}"))

        # 即座にフィードバックを表示
        self.update_status(f"フォルダを開いています: {folder_path}")

        # バックグラウンドスレッドで実行（GUIをブロックしない）
        thread = threading.Thread(target=_open_in_thread, daemon=True)
        thread.start()

    def export_state(self):
        """状態をエクスポート - Phase 4.4新機能"""
        from tkinter import filedialog
        import json
        import datetime

        # 保存先を選択
        default_filename = f"bugsearch_state_{datetime.datetime.now().strftime('%Y%m%d_%H%M%S')}.json"
        filepath = filedialog.asksaveasfilename(
            title="状態をエクスポート",
            defaultextension=".json",
            initialfile=default_filename,
            filetypes=[("JSON files", "*.json"), ("All files", "*.*")]
        )

        if not filepath:
            self.update_status("エクスポートがキャンセルされました")
            return

        try:
            # 現在の状態を保存
            self.state_manager.save_state()

            # StateManagerの状態ファイルを読み込んでコピー
            state_file = Path('.gui_state.json')
            if state_file.exists():
                with open(state_file, 'r', encoding='utf-8') as f:
                    state_data = json.load(f)

                # エクスポート用メタデータ追加
                export_data = {
                    'exported_at': datetime.datetime.now().isoformat(),
                    'version': 'v4.11.5',
                    'state': state_data
                }

                # ファイルに書き込み
                with open(filepath, 'w', encoding='utf-8') as f:
                    json.dump(export_data, f, indent=2, ensure_ascii=False)

                self.update_status(f"状態をエクスポートしました: {filepath}")
            else:
                self.show_error("状態ファイルが見つかりません")

        except Exception as e:
            self.show_error(f"エクスポート失敗: {str(e)}")

    def import_state(self):
        """状態をインポート - Phase 4.4新機能"""
        from tkinter import filedialog, messagebox
        import json

        # インポート確認
        result = messagebox.askyesno(
            "確認",
            "現在の状態が上書きされます。\n続行しますか？",
            icon='warning'
        )

        if not result:
            self.update_status("インポートがキャンセルされました")
            return

        # ファイルを選択
        filepath = filedialog.askopenfilename(
            title="状態をインポート",
            filetypes=[("JSON files", "*.json"), ("All files", "*.*")]
        )

        if not filepath:
            self.update_status("インポートがキャンセルされました")
            return

        try:
            # JSONファイルを読み込み
            with open(filepath, 'r', encoding='utf-8') as f:
                import_data = json.load(f)

            # バリデーション
            if 'state' not in import_data:
                self.show_error("無効なエクスポートファイル形式です")
                return

            state_data = import_data['state']

            # StateManagerの状態ファイルに書き込み
            state_file = Path('.gui_state.json')
            with open(state_file, 'w', encoding='utf-8') as f:
                json.dump(state_data, f, indent=2, ensure_ascii=False)

            self.update_status(f"状態をインポートしました: {filepath}")

            # 再起動を促すダイアログ
            messagebox.showinfo(
                "インポート完了",
                "状態がインポートされました。\n変更を反映するにはアプリケーションを再起動してください。"
            )

        except Exception as e:
            self.show_error(f"インポート失敗: {str(e)}")

    def quit_app(self):
        """アプリケーション終了 - Phase 4.4新機能"""
        self.on_closing()

    def on_closing(self):
        """終了処理 - Phase 4.3完全実装"""
        # 実行中のジョブをチェック
        running_jobs = [
            job_id for job_id in self.job_widgets.keys()
            if self.process_manager.check_process_status(job_id) == 'running'
        ]

        # 実行中のジョブがある場合は確認ダイアログを表示
        if running_jobs:
            from tkinter import messagebox

            job_names = [self.job_widgets[jid].get('name', 'Unknown') for jid in running_jobs]
            message = (
                f"実行中のジョブが {len(running_jobs)} 件あります:\n\n"
                + "\n".join(f"  • {name}" for name in job_names)
                + "\n\n本当に終了しますか？"
            )

            result = messagebox.askyesno(
                "確認",
                message,
                icon='warning'
            )

            if not result:
                # キャンセルされた場合は終了しない
                return

            # 全プロセスを停止
            for job_id in running_jobs:
                self.process_manager.stop_process(job_id)
                self.log_collector.stop_collecting(job_id)

        # ウィンドウ状態保存
        self.state_manager.set_window_state(
            width=self.winfo_width(),
            height=self.winfo_height(),
            x=self.winfo_x(),
            y=self.winfo_y()
        )
        self.state_manager.save_state()

        # 終了
        self.destroy()


def main():
    """メインエントリーポイント"""
    app = BugSearchGUI()
    app.mainloop()


if __name__ == '__main__':
    main()
