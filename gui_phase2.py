#!/usr/bin/env python3
"""
GUI Phase 2 - リアルタイムログ表示

Phase 2 新機能:
- 非同期処理（threading使用）
- リアルタイムログ表示（stdout/stderr）
- プログレスバー
- 2つのコマンドボタン（Index / Advise）

Created: 2025年10月17日
Status: Phase 2 実装
"""

import customtkinter as ctk
import subprocess
import threading
import queue
from pathlib import Path
import sys


class BugSearchPhase2(ctk.CTk):
    def __init__(self):
        super().__init__()

        self.title("BugSearch2 GUI Phase 2 - リアルタイムログ")
        self.geometry("800x600")

        # カラーモード設定
        ctk.set_appearance_mode("dark")
        ctk.set_default_color_theme("blue")

        # ログキュー（スレッド間通信）
        self.log_queue = queue.Queue()
        self.process = None
        self.log_thread = None

        # UI構築
        self._build_ui()

    def _build_ui(self):
        """UI構築"""
        # ステータス表示
        self.status_label = ctk.CTkLabel(
            self,
            text="Status: Ready",
            font=("Arial", 18, "bold")
        )
        self.status_label.pack(pady=10)

        # プログレスバー
        self.progress_bar = ctk.CTkProgressBar(
            self,
            width=750,
            height=20
        )
        self.progress_bar.pack(pady=10)
        self.progress_bar.set(0)  # 0%

        # ボタンフレーム
        button_frame = ctk.CTkFrame(self)
        button_frame.pack(pady=10)

        # Indexボタン
        self.index_button = ctk.CTkButton(
            button_frame,
            text="Index 実行",
            command=self.run_index,
            width=200,
            height=50,
            font=("Arial", 14)
        )
        self.index_button.pack(side="left", padx=10)

        # Adviseボタン
        self.advise_button = ctk.CTkButton(
            button_frame,
            text="Advise 実行 (10件)",
            command=self.run_advise,
            width=200,
            height=50,
            font=("Arial", 14)
        )
        self.advise_button.pack(side="left", padx=10)

        # ログ表示エリア
        self.log_label = ctk.CTkLabel(
            self,
            text="リアルタイムログ:",
            font=("Arial", 14)
        )
        self.log_label.pack(pady=(10, 5))

        self.log_text = ctk.CTkTextbox(
            self,
            width=750,
            height=400,
            font=("Courier New", 10)
        )
        self.log_text.pack(pady=10)

    def run_index(self):
        """Indexコマンドを非同期実行"""
        cmd = [
            sys.executable,
            "codex_review_severity.py",
            "index",
            "test_gui_project"
        ]
        self._run_command(cmd, "Index")

    def run_advise(self):
        """Adviseコマンドを非同期実行"""
        cmd = [
            sys.executable,
            "codex_review_severity.py",
            "advise",
            "--topk", "10",
            "--out", "reports/phase2_test.md"
        ]
        self._run_command(cmd, "Advise")

    def _run_command(self, cmd, command_name):
        """コマンドを非同期で実行"""
        # すでに実行中の場合は無視
        if self.process is not None and self.process.poll() is None:
            self.log_text.insert("end", "⚠️ すでにコマンドが実行中です\n")
            return

        # UI更新
        self.status_label.configure(text=f"Status: {command_name} Running...")
        self.index_button.configure(state="disabled")
        self.advise_button.configure(state="disabled")
        self.log_text.delete("1.0", "end")
        self.progress_bar.set(0.1)  # 開始

        # ログに実行コマンド表示
        self.log_text.insert("end", f"🚀 実行中: {' '.join(cmd)}\n")
        self.log_text.insert("end", "=" * 80 + "\n\n")

        # 別スレッドでコマンド実行
        self.log_thread = threading.Thread(
            target=self._execute_command,
            args=(cmd, command_name),
            daemon=True
        )
        self.log_thread.start()

        # ログ更新タイマー開始
        self._update_log()

    def _execute_command(self, cmd, command_name):
        """コマンドを実行してログをキューに送る"""
        try:
            # プロセス開始
            self.process = subprocess.Popen(
                cmd,
                stdout=subprocess.PIPE,
                stderr=subprocess.PIPE,
                text=True,
                bufsize=1,  # 行バッファリング（重要！）
                cwd=Path.cwd(),
                encoding='utf-8',
                errors='replace'
            )

            # stdoutをリアルタイム読み取り
            for line in self.process.stdout:
                self.log_queue.put(("stdout", line))

            # stderrを読み取り
            for line in self.process.stderr:
                self.log_queue.put(("stderr", line))

            # プロセス終了待ち
            self.process.wait()

            # 完了メッセージ
            if self.process.returncode == 0:
                self.log_queue.put(("success", f"\n✅ {command_name} 完了！（終了コード: 0）\n"))
            else:
                self.log_queue.put(("error", f"\n❌ {command_name} 失敗（終了コード: {self.process.returncode}）\n"))

        except Exception as e:
            self.log_queue.put(("error", f"\n❌ 例外発生: {type(e).__name__}: {str(e)}\n"))

        finally:
            # 終了シグナル
            self.log_queue.put(("done", command_name))

    def _update_log(self):
        """キューからログを取得してUI更新（定期実行）"""
        try:
            # キューからログを取得（非ブロッキング）
            while True:
                try:
                    log_type, message = self.log_queue.get_nowait()

                    if log_type == "stdout":
                        self.log_text.insert("end", message)
                        # プログレスバー更新（簡易版）
                        current = self.progress_bar.get()
                        if current < 0.9:
                            self.progress_bar.set(current + 0.05)

                    elif log_type == "stderr":
                        self.log_text.insert("end", f"⚠️ {message}")

                    elif log_type == "success":
                        self.log_text.insert("end", message)
                        self.progress_bar.set(1.0)  # 100%
                        self.status_label.configure(text="Status: Success! ✅")

                    elif log_type == "error":
                        self.log_text.insert("end", message)
                        self.progress_bar.set(0.0)
                        self.status_label.configure(text="Status: Failed ❌")

                    elif log_type == "done":
                        # コマンド完了時の処理
                        self.index_button.configure(state="normal")
                        self.advise_button.configure(state="normal")
                        self.process = None
                        return  # タイマー停止

                    # スクロールを最下部に
                    self.log_text.see("end")

                except queue.Empty:
                    break

        except Exception as e:
            print(f"Error in _update_log: {e}")

        # 100ms後に再実行
        self.after(100, self._update_log)


def main():
    """アプリケーション起動"""
    print("BugSearch2 GUI Phase 2 - リアルタイムログ表示")
    print("=" * 50)
    print("Starting GUI...")

    app = BugSearchPhase2()
    app.mainloop()


if __name__ == "__main__":
    main()
