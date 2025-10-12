"""
BugSearch2 GUI Control Center
メインGUIアプリケーション

バージョン: v1.0.0
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


class BugSearchGUI(ctk.CTk):
    """
    BugSearch2 GUI Control Center

    メインウィンドウとタブ管理
    """

    def __init__(self):
        super().__init__()

        # ウィンドウ設定
        self.title("BugSearch2 Control Center v1.0.0")

        # マネージャー初期化
        self.process_manager = ProcessManager()
        self.log_collector = LogCollector()
        self.queue_manager = QueueManager(max_concurrent=3)
        self.state_manager = StateManager()

        # ウィンドウ状態復元
        window_state = self.state_manager.get_window_state()
        self.geometry(f"{window_state.width}x{window_state.height}")

        if window_state.x and window_state.y:
            self.geometry(f"+{window_state.x}+{window_state.y}")

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
        """起動タブ"""
        tab = self.tabview.tab("🚀 起動")

        # スクロール可能フレーム
        scroll_frame = ctk.CTkScrollableFrame(tab)
        scroll_frame.pack(fill="both", expand=True)

        # Context7統合分析
        self.create_job_section(
            scroll_frame,
            "Context7統合分析 (--auto-run)",
            self.launch_context7_analysis
        )

        # インデックス作成
        self.create_job_section(
            scroll_frame,
            "インデックス作成",
            self.launch_index_creation
        )

        # AI分析実行
        self.create_job_section(
            scroll_frame,
            "AI分析実行",
            self.launch_ai_analysis
        )

        # 改善コード適用
        self.create_job_section(
            scroll_frame,
            "改善コード適用",
            self.launch_apply_improvements
        )

    def create_job_section(self, parent, title: str, command):
        """ジョブセクションを作成"""
        frame = ctk.CTkFrame(parent)
        frame.pack(fill="x", padx=10, pady=10)

        # タイトル
        title_label = ctk.CTkLabel(
            frame,
            text=title,
            font=ctk.CTkFont(size=16, weight="bold")
        )
        title_label.pack(anchor="w", padx=10, pady=(10, 5))

        # 起動ボタン
        launch_btn = ctk.CTkButton(
            frame,
            text="▶ 起動",
            command=command,
            width=120,
            height=36,
            fg_color="green",
            hover_color="darkgreen"
        )
        launch_btn.pack(anchor="w", padx=10, pady=(0, 10))

    def setup_monitor_tab(self):
        """監視タブ"""
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

        # 下部: リアルタイムログ
        log_frame = ctk.CTkFrame(tab)
        log_frame.pack(fill="both", expand=True, padx=10, pady=(0, 10))

        log_label = ctk.CTkLabel(
            log_frame,
            text="リアルタイムログ",
            font=ctk.CTkFont(size=16, weight="bold")
        )
        log_label.pack(anchor="w", padx=10, pady=10)

        # ログテキストボックス
        self.log_textbox = ctk.CTkTextbox(log_frame, height=300)
        self.log_textbox.pack(fill="both", expand=True, padx=10, pady=(0, 10))

        # ログクリアボタン
        clear_btn = ctk.CTkButton(
            log_frame,
            text="🗑 ログクリア",
            command=self.clear_logs,
            width=120
        )
        clear_btn.pack(anchor="e", padx=10, pady=(0, 10))

    def setup_settings_tab(self):
        """設定タブ"""
        tab = self.tabview.tab("⚙ 設定")

        scroll_frame = ctk.CTkScrollableFrame(tab)
        scroll_frame.pack(fill="both", expand=True, padx=10, pady=10)

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

    def setup_history_tab(self):
        """履歴タブ"""
        tab = self.tabview.tab("📜 履歴")

        # 履歴リスト（スクロール可能）
        self.history_list = ctk.CTkScrollableFrame(tab)
        self.history_list.pack(fill="both", expand=True, padx=10, pady=10)

        # クリアボタン
        clear_history_btn = ctk.CTkButton(
            tab,
            text="🗑 履歴クリア",
            command=self.clear_history,
            width=120
        )
        clear_history_btn.pack(anchor="e", padx=10, pady=(0, 10))

    # イベントハンドラー

    def launch_context7_analysis(self):
        """Context7統合分析を起動"""
        command = ['python', 'generate_tech_config.py', '--auto-run']
        self.start_job("Context7統合分析", command, JobPriority.HIGH)

    def launch_index_creation(self):
        """インデックス作成を起動"""
        command = ['python', 'codex_review_severity.py', 'index']
        self.start_job("インデックス作成", command, JobPriority.NORMAL)

    def launch_ai_analysis(self):
        """AI分析を起動"""
        command = ['python', 'codex_review_severity.py', 'advise', '--all']
        self.start_job("AI分析", command, JobPriority.NORMAL)

    def launch_apply_improvements(self):
        """改善コード適用を起動"""
        # TODO: レポートファイル選択ダイアログ
        command = ['python', 'apply_improvements_from_report.py', 'reports/latest.md']
        self.start_job("改善コード適用", command, JobPriority.LOW)

    def start_job(self, name: str, command: list, priority: JobPriority):
        """ジョブを開始"""
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

                self.update_status(f"ジョブ起動: {name}")
            else:
                self.update_status(f"ジョブキュー追加: {name}")

        except Exception as e:
            self.show_error(f"ジョブ起動失敗: {str(e)}")

    def clear_logs(self):
        """ログをクリア"""
        self.log_textbox.delete("1.0", "end")
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

    def show_file_menu(self):
        """ファイルメニュー表示"""
        # TODO: ドロップダウンメニュー実装
        self.update_status("ファイルメニュー")

    def show_help(self):
        """ヘルプ表示"""
        help_text = """
BugSearch2 GUI Control Center v1.0.0

使用方法:
1. 起動タブでジョブを開始
2. 監視タブで進捗を確認
3. 設定タブでカスタマイズ

詳細: doc/guides/GUI_USER_GUIDE.md
        """
        # ダイアログ表示（簡易実装）
        dialog = ctk.CTkToplevel(self)
        dialog.title("ヘルプ")
        dialog.geometry("400x300")

        text = ctk.CTkTextbox(dialog)
        text.pack(fill="both", expand=True, padx=10, pady=10)
        text.insert("1.0", help_text)
        text.configure(state="disabled")

    def update_status(self, message: str):
        """ステータスバー更新"""
        self.status_bar.configure(text=message)

    def show_error(self, message: str):
        """エラー表示"""
        self.update_status(f"❌ {message}")

    def update_history_view(self):
        """履歴ビュー更新"""
        # TODO: 履歴表示実装
        pass

    def periodic_update(self):
        """定期更新"""
        # キュー状態更新
        status = self.queue_manager.get_status()
        self.update_status(
            f"実行中: {status['running']}/{status['max_concurrent']} | "
            f"キュー: {status['queued']} | 完了: {status['completed']}"
        )

        # ログ更新
        # TODO: ログ取得と表示

        # 次の更新をスケジュール
        self.after(self.update_interval, self.periodic_update)

    def on_closing(self):
        """終了処理"""
        # ウィンドウ状態保存
        self.state_manager.set_window_state(
            width=self.winfo_width(),
            height=self.winfo_height(),
            x=self.winfo_x(),
            y=self.winfo_y()
        )
        self.state_manager.save_state()

        # プロセス停止
        # TODO: 実行中プロセスの停止確認

        self.destroy()


def main():
    """メインエントリーポイント"""
    app = BugSearchGUI()
    app.mainloop()


if __name__ == '__main__':
    main()
