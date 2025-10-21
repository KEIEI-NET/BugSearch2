#!/usr/bin/env python3
"""
GUI MVP - 最小限の動作確認版

Phase 1:
- ボタン1つ（Indexコマンド実行）
- ステータス表示
- subprocess統合のみ

Created: 2025年10月17日
Status: Phase 1 MVP実装
"""

import customtkinter as ctk
import subprocess
from pathlib import Path
import sys


class BugSearchMVP(ctk.CTk):
    def __init__(self):
        super().__init__()

        self.title("BugSearch2 GUI MVP")
        self.geometry("700x500")

        # カラーモード設定
        ctk.set_appearance_mode("dark")
        ctk.set_default_color_theme("blue")

        # ステータス表示
        self.status_label = ctk.CTkLabel(
            self,
            text="Status: Ready",
            font=("Arial", 18, "bold")
        )
        self.status_label.pack(pady=20)

        # Indexコマンドボタン
        self.index_button = ctk.CTkButton(
            self,
            text="Index コマンド実行",
            command=self.run_index,
            width=250,
            height=50,
            font=("Arial", 16)
        )
        self.index_button.pack(pady=20)

        # 出力表示エリア
        self.output_label = ctk.CTkLabel(
            self,
            text="出力:",
            font=("Arial", 14)
        )
        self.output_label.pack(pady=(10, 5))

        self.output_text = ctk.CTkTextbox(
            self,
            width=650,
            height=300,
            font=("Courier New", 11)
        )
        self.output_text.pack(pady=10)

    def run_index(self):
        """Indexコマンドを実行"""
        self.status_label.configure(text="Status: Running...")
        self.index_button.configure(state="disabled")
        self.output_text.delete("1.0", "end")

        # 強制的にUI更新
        self.update_idletasks()

        try:
            # CLIコマンド実行
            cmd = [
                sys.executable,  # Pythonインタープリタのパスを使用
                "codex_review_severity.py",
                "index",
                "test_gui_project"
            ]

            self.output_text.insert("1.0", f"実行中: {' '.join(cmd)}\n\n")
            self.update_idletasks()

            # Windows cp932対応: エンコーディングを明示的に指定
            result = subprocess.run(
                cmd,
                capture_output=True,
                text=True,
                cwd=Path.cwd(),
                timeout=60,
                encoding='utf-8',  # UTF-8を強制
                errors='replace'   # デコードエラーを?に置換
            )

            # 結果表示
            if result.returncode == 0:
                self.status_label.configure(text="Status: Success! ✅")
                output = f"✅ 成功!\n\n"
                output += f"【標準出力】\n{result.stdout}\n"
                if result.stderr:
                    output += f"\n【標準エラー】\n{result.stderr}"
                self.output_text.insert("1.0", output)
            else:
                self.status_label.configure(text="Status: Failed ❌")
                output = f"❌ エラー!\n\n"
                output += f"【終了コード】{result.returncode}\n\n"
                output += f"【標準出力】\n{result.stdout}\n"
                output += f"\n【標準エラー】\n{result.stderr}"
                self.output_text.insert("1.0", output)

        except subprocess.TimeoutExpired:
            self.status_label.configure(text="Status: Timeout ⏱️")
            self.output_text.insert("1.0", "❌ タイムアウト: 60秒以内に完了しませんでした")

        except Exception as e:
            self.status_label.configure(text="Status: Error ❌")
            self.output_text.insert("1.0", f"❌ 例外発生:\n\n{type(e).__name__}: {str(e)}")

        finally:
            self.index_button.configure(state="normal")


def main():
    """アプリケーション起動"""
    print("BugSearch2 GUI MVP - Phase 1")
    print("=" * 50)
    print("Starting GUI...")

    app = BugSearchMVP()
    app.mainloop()


if __name__ == "__main__":
    main()
