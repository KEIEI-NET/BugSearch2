"""
BugSearch2 Progress Widget

進捗バーウィジェット
"""

import customtkinter as ctk
from typing import Optional


class ProgressWidget(ctk.CTkFrame):
    """
    進捗バーウィジェット

    機能:
    - プログレスバー表示
    - パーセンテージ表示
    - ステータステキスト表示
    """

    def __init__(self, master, **kwargs):
        super().__init__(master, **kwargs)

        self.progress = 0.0
        self.status_text = "Initializing..."

        self.setup_ui()

    def setup_ui(self):
        """UI構築"""
        # プログレスバー
        self.progressbar = ctk.CTkProgressBar(
            self,
            width=300,
            height=20
        )
        self.progressbar.pack(fill="x", padx=10, pady=(10, 5))
        self.progressbar.set(0)

        # ステータスラベル
        self.status_label = ctk.CTkLabel(
            self,
            text="Initializing... 0%",
            font=ctk.CTkFont(size=12)
        )
        self.status_label.pack(pady=(0, 10))

    def set_progress(self, value: float, status: Optional[str] = None):
        """
        進捗を設定

        Args:
            value: 進捗率（0.0〜1.0）
            status: ステータステキスト
        """
        self.progress = max(0.0, min(1.0, value))
        self.progressbar.set(self.progress)

        if status:
            self.status_text = status

        # ラベル更新
        percentage = int(self.progress * 100)
        self.status_label.configure(text=f"{self.status_text} {percentage}%")

    def set_indeterminate(self, enabled: bool = True):
        """
        不定形モード設定

        Args:
            enabled: 不定形モードを有効にするか
        """
        if enabled:
            self.progressbar.configure(mode="indeterminate")
            self.progressbar.start()
        else:
            self.progressbar.stop()
            self.progressbar.configure(mode="determinate")

    def reset(self):
        """進捗をリセット"""
        self.set_progress(0.0, "Ready")
