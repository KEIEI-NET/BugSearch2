"""
BugSearch2 Log Viewer Widget

ログビューアウィジェット
"""

import customtkinter as ctk
from typing import List, Optional
from gui.log_collector import LogEntry


class LogViewer(ctk.CTkFrame):
    """
    ログビューアウィジェット

    機能:
    - ログ表示
    - ログレベル別フィルタリング
    - 自動スクロール
    - ログクリア
    """

    def __init__(self, master, **kwargs):
        super().__init__(master, **kwargs)

        self.auto_scroll = True
        self.filter_level = None  # None = all levels

        self.setup_ui()

    def setup_ui(self):
        """UI構築"""
        # コントロールフレーム
        control_frame = ctk.CTkFrame(self)
        control_frame.pack(fill="x", padx=10, pady=10)

        # フィルタードロップダウン
        ctk.CTkLabel(control_frame, text="Filter:").pack(side="left", padx=5)

        self.filter_var = ctk.StringVar(value="All")
        filter_menu = ctk.CTkOptionMenu(
            control_frame,
            values=["All", "ERROR", "WARNING", "SUCCESS", "INFO", "DEBUG"],
            variable=self.filter_var,
            command=self.on_filter_changed
        )
        filter_menu.pack(side="left", padx=5)

        # 自動スクロールチェックボックス
        self.autoscroll_var = ctk.BooleanVar(value=True)
        autoscroll_cb = ctk.CTkCheckBox(
            control_frame,
            text="Auto-scroll",
            variable=self.autoscroll_var,
            command=self.on_autoscroll_changed
        )
        autoscroll_cb.pack(side="left", padx=10)

        # クリアボタン
        clear_btn = ctk.CTkButton(
            control_frame,
            text="Clear",
            width=80,
            command=self.clear_logs
        )
        clear_btn.pack(side="right", padx=5)

        # ログテキストボックス
        self.textbox = ctk.CTkTextbox(
            self,
            wrap="word",
            font=ctk.CTkFont(family="Consolas", size=11)
        )
        self.textbox.pack(fill="both", expand=True, padx=10, pady=(0, 10))

        # タグの設定（色分け）
        self.textbox.tag_config("ERROR", foreground="red")
        self.textbox.tag_config("WARNING", foreground="orange")
        self.textbox.tag_config("SUCCESS", foreground="green")
        self.textbox.tag_config("INFO", foreground="blue")
        self.textbox.tag_config("DEBUG", foreground="gray")

    def add_log(self, log_entry: LogEntry):
        """
        ログエントリーを追加

        Args:
            log_entry: LogEntryオブジェクト
        """
        # フィルター適用
        if self.filter_level and log_entry.level != self.filter_level:
            return

        # フォーマットされたログを追加
        formatted_log = log_entry.formatted() + "\n"
        self.textbox.insert("end", formatted_log, log_entry.level)

        # 自動スクロール
        if self.auto_scroll:
            self.textbox.see("end")

    def add_logs(self, log_entries: List[LogEntry]):
        """
        複数のログエントリーを追加

        Args:
            log_entries: LogEntryオブジェクトのリスト
        """
        for entry in log_entries:
            self.add_log(entry)

    def clear_logs(self):
        """ログをクリア"""
        self.textbox.delete("1.0", "end")

    def on_filter_changed(self, value: str):
        """フィルター変更時のハンドラ"""
        if value == "All":
            self.filter_level = None
        else:
            self.filter_level = value

        # TODO: 既存のログを再表示（フィルター適用）

    def on_autoscroll_changed(self):
        """自動スクロール変更時のハンドラ"""
        self.auto_scroll = self.autoscroll_var.get()

    def get_text(self) -> str:
        """テキストボックスの内容を取得"""
        return self.textbox.get("1.0", "end")

    def save_to_file(self, filepath: str):
        """
        ログをファイルに保存

        Args:
            filepath: 保存先ファイルパス
        """
        with open(filepath, 'w', encoding='utf-8') as f:
            f.write(self.get_text())
