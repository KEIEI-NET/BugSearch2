#!/usr/bin/env python3
"""
GUI Phase 3 Improved - 進捗表示強化版

Phase 3 改善点:
- 実際のファイル数に基づく正確なプログレスバー
- ファイル数カウンター表示（12,500 / 34,125 files）
- 処理速度表示（1,250 files/sec）
- 推定残り時間表示

Created: 2025年10月21日
Status: Phase 3 改善版
"""

import customtkinter as ctk
import subprocess
import threading
import queue
from pathlib import Path
import sys
from tkinter import filedialog
import re
import time
import os


class BugSearchPhase3Improved(ctk.CTk):
    def __init__(self):
        super().__init__()

        self.title("BugSearch2 GUI Phase 3 - 進捗表示強化版")
        self.geometry("900x750")

        # カラーモード設定
        ctk.set_appearance_mode("dark")
        ctk.set_default_color_theme("blue")

        # ログキュー（スレッド間通信）
        self.log_queue = queue.Queue()
        self.process = None
        self.log_thread = None

        # 進捗トラッキング用変数
        self.total_files = 0
        self.current_files = 0
        self.start_time = None
        self.last_count = 0
        self.last_time = None

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
            width=850,
            height=20
        )
        self.progress_bar.pack(pady=5)
        self.progress_bar.set(0)

        # 進捗情報ラベル（新機能）
        self.progress_info_label = ctk.CTkLabel(
            self,
            text="",
            font=("Arial", 11),
            text_color="#888888"
        )
        self.progress_info_label.pack(pady=5)

        # タブビュー
        self.tabview = ctk.CTkTabview(self, width=850, height=350)
        self.tabview.pack(pady=10)

        # 3つのタブを追加
        self.tabview.add("Index")
        self.tabview.add("Advise")
        self.tabview.add("Query")

        # 各タブのUI構築
        self._build_index_tab()
        self._build_advise_tab()
        self._build_query_tab()

        # ログ表示エリア
        self.log_label = ctk.CTkLabel(
            self,
            text="リアルタイムログ:",
            font=("Arial", 14)
        )
        self.log_label.pack(pady=(10, 5))

        self.log_text = ctk.CTkTextbox(
            self,
            width=850,
            height=200,
            font=("Courier New", 10)
        )
        self.log_text.pack(pady=10)

    def _build_index_tab(self):
        """Indexタブ構築"""
        tab = self.tabview.tab("Index")

        # ディレクトリ選択
        dir_frame = ctk.CTkFrame(tab)
        dir_frame.pack(pady=10, padx=20, fill="x")

        ctk.CTkLabel(dir_frame, text="対象ディレクトリ:", font=("Arial", 12)).pack(side="left", padx=5)

        self.index_dir_entry = ctk.CTkEntry(dir_frame, width=400)
        self.index_dir_entry.pack(side="left", padx=5)
        self.index_dir_entry.insert(0, "test_gui_project")

        ctk.CTkButton(
            dir_frame,
            text="参照",
            command=self._browse_directory_index,
            width=80
        ).pack(side="left", padx=5)

        # オプション
        option_frame = ctk.CTkFrame(tab)
        option_frame.pack(pady=10, padx=20, fill="x")

        ctk.CTkLabel(option_frame, text="最大ファイルサイズ (MB):", font=("Arial", 11)).pack(side="left", padx=5)
        self.index_max_mb = ctk.CTkEntry(option_frame, width=60)
        self.index_max_mb.pack(side="left", padx=5)
        self.index_max_mb.insert(0, "4")

        ctk.CTkLabel(option_frame, text="ワーカー数:", font=("Arial", 11)).pack(side="left", padx=15)
        self.index_workers = ctk.CTkEntry(option_frame, width=60)
        self.index_workers.pack(side="left", padx=5)
        self.index_workers.insert(0, "4")

        # 実行ボタン
        ctk.CTkButton(
            tab,
            text="Index 実行",
            command=self.run_index,
            width=200,
            height=50,
            font=("Arial", 14)
        ).pack(pady=20)

    def _build_advise_tab(self):
        """Adviseタブ構築"""
        tab = self.tabview.tab("Advise")

        # トップK設定
        topk_frame = ctk.CTkFrame(tab)
        topk_frame.pack(pady=10, padx=20, fill="x")

        ctk.CTkLabel(topk_frame, text="分析ファイル数:", font=("Arial", 12)).pack(side="left", padx=5)

        self.advise_topk = ctk.CTkEntry(topk_frame, width=100)
        self.advise_topk.pack(side="left", padx=5)
        self.advise_topk.insert(0, "10")

        self.advise_all_check = ctk.CTkCheckBox(topk_frame, text="全ファイル分析 (--all)")
        self.advise_all_check.pack(side="left", padx=20)

        # 出力設定
        out_frame = ctk.CTkFrame(tab)
        out_frame.pack(pady=10, padx=20, fill="x")

        ctk.CTkLabel(out_frame, text="出力ファイル:", font=("Arial", 12)).pack(side="left", padx=5)

        self.advise_out = ctk.CTkEntry(out_frame, width=400)
        self.advise_out.pack(side="left", padx=5)
        self.advise_out.insert(0, "reports/analysis.md")

        ctk.CTkButton(
            out_frame,
            text="参照",
            command=self._browse_file_advise,
            width=80
        ).pack(side="left", padx=5)

        # モード設定
        mode_frame = ctk.CTkFrame(tab)
        mode_frame.pack(pady=10, padx=20, fill="x")

        ctk.CTkLabel(mode_frame, text="分析モード:", font=("Arial", 12)).pack(side="left", padx=5)

        self.advise_mode = ctk.CTkOptionMenu(
            mode_frame,
            values=["hybrid", "rules", "ai"],
            width=150
        )
        self.advise_mode.pack(side="left", padx=5)
        self.advise_mode.set("hybrid")

        # 実行ボタン
        ctk.CTkButton(
            tab,
            text="Advise 実行",
            command=self.run_advise,
            width=200,
            height=50,
            font=("Arial", 14)
        ).pack(pady=20)

    def _build_query_tab(self):
        """Queryタブ構築"""
        tab = self.tabview.tab("Query")

        # クエリ入力
        query_frame = ctk.CTkFrame(tab)
        query_frame.pack(pady=10, padx=20, fill="x")

        ctk.CTkLabel(query_frame, text="検索クエリ:", font=("Arial", 12)).pack(side="left", padx=5)

        self.query_text = ctk.CTkEntry(query_frame, width=500)
        self.query_text.pack(side="left", padx=5)
        self.query_text.insert(0, "N+1 query")

        # トップK設定
        topk_frame = ctk.CTkFrame(tab)
        topk_frame.pack(pady=10, padx=20, fill="x")

        ctk.CTkLabel(topk_frame, text="取得件数:", font=("Arial", 12)).pack(side="left", padx=5)

        self.query_topk = ctk.CTkEntry(topk_frame, width=100)
        self.query_topk.pack(side="left", padx=5)
        self.query_topk.insert(0, "20")

        # 実行ボタン
        ctk.CTkButton(
            tab,
            text="Query 実行",
            command=self.run_query,
            width=200,
            height=50,
            font=("Arial", 14)
        ).pack(pady=20)

    def _browse_directory_index(self):
        """ディレクトリ選択ダイアログ（Index用）"""
        directory = filedialog.askdirectory(
            title="対象ディレクトリを選択",
            initialdir=Path.cwd()
        )
        if directory:
            self.index_dir_entry.delete(0, "end")
            self.index_dir_entry.insert(0, directory)

    def _browse_file_advise(self):
        """ファイル選択ダイアログ（Advise出力用）"""
        filename = filedialog.asksaveasfilename(
            title="出力ファイルを選択",
            initialdir=Path.cwd() / "reports",
            defaultextension=".md",
            filetypes=[("Markdown files", "*.md"), ("All files", "*.*")]
        )
        if filename:
            self.advise_out.delete(0, "end")
            self.advise_out.insert(0, filename)

    def run_index(self):
        """Indexコマンドを実行"""
        # パラメータ取得
        directory = self.index_dir_entry.get().strip()
        max_mb = self.index_max_mb.get().strip()
        workers = self.index_workers.get().strip()

        # バリデーション
        if not directory:
            self._show_error("ディレクトリを指定してください")
            return

        if not max_mb.isdigit():
            self._show_error("最大ファイルサイズは数値で指定してください")
            return

        if not workers.isdigit():
            self._show_error("ワーカー数は数値で指定してください")
            return

        # コマンド構築（-u フラグでバッファリング無効化）
        cmd = [
            sys.executable,
            "-u",  # Unbuffered output
            "codex_review_severity.py",
            "index",
            directory,
            "--max-file-mb", max_mb,
            "--worker-count", workers
        ]

        self._run_command(cmd, "Index")

    def run_advise(self):
        """Adviseコマンドを実行"""
        # パラメータ取得
        out_file = self.advise_out.get().strip()
        mode = self.advise_mode.get()
        use_all = self.advise_all_check.get()

        # バリデーション
        if not out_file:
            self._show_error("出力ファイルを指定してください")
            return

        # コマンド構築（-u フラグでバッファリング無効化）
        cmd = [
            sys.executable,
            "-u",  # Unbuffered output
            "codex_review_severity.py",
            "advise"
        ]

        if use_all:
            cmd.append("--all")
        else:
            topk = self.advise_topk.get().strip()
            if not topk.isdigit():
                self._show_error("分析ファイル数は数値で指定してください")
                return
            cmd.extend(["--topk", topk])

        cmd.extend([
            "--mode", mode,
            "--out", out_file
        ])

        self._run_command(cmd, "Advise")

    def run_query(self):
        """Queryコマンドを実行"""
        # パラメータ取得
        query = self.query_text.get().strip()
        topk = self.query_topk.get().strip()

        # バリデーション
        if not query:
            self._show_error("検索クエリを入力してください")
            return

        if not topk.isdigit():
            self._show_error("取得件数は数値で指定してください")
            return

        # コマンド構築（-u フラグでバッファリング無効化）
        cmd = [
            sys.executable,
            "-u",  # Unbuffered output
            "codex_review_severity.py",
            "query",
            query,
            "--topk", topk
        ]

        self._run_command(cmd, "Query")

    def _show_error(self, message):
        """エラーメッセージ表示"""
        self.status_label.configure(text=f"Status: Error ❌")
        self.log_text.delete("1.0", "end")
        self.log_text.insert("1.0", f"❌ エラー: {message}\n")

    def _reset_progress_tracking(self):
        """進捗トラッキング変数をリセット"""
        self.total_files = 0
        self.current_files = 0
        self.start_time = time.time()
        self.last_count = 0
        self.last_time = time.time()

    def _update_progress_info(self):
        """進捗情報ラベルを更新"""
        if self.total_files == 0:
            # まだ合計数が分からない場合
            if self.current_files > 0:
                elapsed = time.time() - self.start_time
                speed = self.current_files / elapsed if elapsed > 0 else 0
                self.progress_info_label.configure(
                    text=f"処理中: {self.current_files:,} files - {speed:.0f} files/sec"
                )
            else:
                self.progress_info_label.configure(text="")
        else:
            # 合計数が分かっている場合
            percentage = (self.current_files / self.total_files * 100) if self.total_files > 0 else 0
            elapsed = time.time() - self.start_time
            speed = self.current_files / elapsed if elapsed > 0 else 0

            # 残り時間推定
            if speed > 0:
                remaining_files = self.total_files - self.current_files
                eta_seconds = remaining_files / speed
                eta_str = self._format_time(eta_seconds)
            else:
                eta_str = "計算中..."

            self.progress_info_label.configure(
                text=f"処理中: {self.current_files:,} / {self.total_files:,} files ({percentage:.1f}%) - {speed:.0f} files/sec - 残り約{eta_str}"
            )

    def _format_time(self, seconds):
        """秒数を読みやすい形式に変換"""
        if seconds < 60:
            return f"{int(seconds)}秒"
        elif seconds < 3600:
            minutes = int(seconds / 60)
            secs = int(seconds % 60)
            return f"{minutes}分{secs}秒"
        else:
            hours = int(seconds / 3600)
            minutes = int((seconds % 3600) / 60)
            return f"{hours}時間{minutes}分"

    def _parse_progress_from_log(self, message):
        """ログメッセージから進捗情報を抽出"""
        # [INFO] Indexed 500 files... パターン
        match_progress = re.search(r'\[INFO\] Indexed (\d+) files', message)
        if match_progress:
            count = int(match_progress.group(1))
            self.current_files = count
            return True

        # [OK] Indexed 34125 files -> .advice_index.jsonl パターン
        match_final = re.search(r'\[OK\] Indexed (\d+) files', message)
        if match_final:
            total = int(match_final.group(1))
            self.total_files = total
            self.current_files = total
            return True

        return False

    def _run_command(self, cmd, command_name):
        """コマンドを非同期で実行"""
        # すでに実行中の場合は無視
        if self.process is not None and self.process.poll() is None:
            self.log_text.insert("end", "⚠️ すでにコマンドが実行中です\n")
            return

        # 進捗トラッキングをリセット
        self._reset_progress_tracking()

        # UI更新
        self.status_label.configure(text=f"Status: {command_name} Running...")
        self.log_text.delete("1.0", "end")
        self.progress_bar.set(0)
        self.progress_info_label.configure(text="初期化中...")

        # ログに実行コマンド表示
        self.log_text.insert("end", f"🚀 実行中: {' '.join(cmd)}\n")
        self.log_text.insert("end", "=" * 80 + "\n\n")

        # 準備中メッセージを表示
        self.log_text.insert("end", "📁 ファイルの読み込み準備をしています...\n")
        self.log_text.insert("end", "⏳ 大規模プロジェクトの場合、数分お待ちください。\n\n")
        self.log_text.see("end")
        self.update_idletasks()  # UIを即座に更新

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
            # 環境変数でバッファリング無効化（二重対策）
            env = os.environ.copy()
            env['PYTHONUNBUFFERED'] = '1'

            self.process = subprocess.Popen(
                cmd,
                stdout=subprocess.PIPE,
                stderr=subprocess.PIPE,
                text=True,
                bufsize=1,
                cwd=Path.cwd(),
                encoding='utf-8',
                errors='replace',
                env=env
            )

            for line in self.process.stdout:
                self.log_queue.put(("stdout", line))

            for line in self.process.stderr:
                self.log_queue.put(("stderr", line))

            self.process.wait()

            if self.process.returncode == 0:
                self.log_queue.put(("success", f"\n✅ {command_name} 完了！（終了コード: 0）\n"))
            else:
                self.log_queue.put(("error", f"\n❌ {command_name} 失敗（終了コード: {self.process.returncode}）\n"))

        except Exception as e:
            self.log_queue.put(("error", f"\n❌ 例外発生: {type(e).__name__}: {str(e)}\n"))

        finally:
            self.log_queue.put(("done", command_name))

    def _update_log(self):
        """キューからログを取得してUI更新（進捗解析機能付き）"""
        try:
            while True:
                try:
                    log_type, message = self.log_queue.get_nowait()

                    if log_type == "stdout":
                        self.log_text.insert("end", message)

                        # ログから進捗を解析
                        if self._parse_progress_from_log(message):
                            # プログレスバー更新
                            if self.total_files > 0:
                                progress = self.current_files / self.total_files
                                self.progress_bar.set(progress)
                            else:
                                # 合計数不明の場合は不確定プログレス
                                current = self.progress_bar.get()
                                if current < 0.9:
                                    self.progress_bar.set(min(current + 0.02, 0.9))

                            # 進捗情報更新
                            self._update_progress_info()

                    elif log_type == "stderr":
                        self.log_text.insert("end", f"⚠️ {message}")

                    elif log_type == "success":
                        self.log_text.insert("end", message)
                        self.progress_bar.set(1.0)
                        self.status_label.configure(text="Status: Success! ✅")
                        # 最終進捗情報表示
                        if self.total_files > 0:
                            elapsed = time.time() - self.start_time
                            speed = self.total_files / elapsed if elapsed > 0 else 0
                            self.progress_info_label.configure(
                                text=f"完了: {self.total_files:,} files - 平均 {speed:.0f} files/sec - 所要時間 {self._format_time(elapsed)}"
                            )

                    elif log_type == "error":
                        self.log_text.insert("end", message)
                        self.progress_bar.set(0.0)
                        self.status_label.configure(text="Status: Failed ❌")
                        self.progress_info_label.configure(text="エラーが発生しました")

                    elif log_type == "done":
                        self.process = None
                        return

                    self.log_text.see("end")

                except queue.Empty:
                    break

        except Exception as e:
            print(f"Error in _update_log: {e}")

        self.after(100, self._update_log)


def main():
    """アプリケーション起動"""
    print("BugSearch2 GUI Phase 3 Improved - 進捗表示強化版")
    print("=" * 50)
    print("Starting GUI...")

    app = BugSearchPhase3Improved()
    app.mainloop()


if __name__ == "__main__":
    main()
