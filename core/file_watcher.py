"""
ファイル変更監視システム

Phase 5.0の新機能:
- リアルタイムファイル変更検出
- デバウンス処理（連続変更の統合）
- コードファイルフィルタリング

バージョン: v4.6.0 (Phase 5.0)
作成日: 2025年10月12日 JST

@perfect品質:
- スレッドセーフな実装
- 適切なリソース管理
- クリーンなシャットダウン
"""

from pathlib import Path
from typing import Callable, Dict, Optional
from datetime import datetime
import time
import threading

# watchdogライブラリ（リアルタイムファイル監視用）
try:
    from watchdog.observers import Observer
    from watchdog.events import FileSystemEventHandler
    WATCHDOG_AVAILABLE = True
except ImportError:
    WATCHDOG_AVAILABLE = False
    # ダミークラス（watchdog未インストール時）
    class FileSystemEventHandler:
        pass
    Observer = None
    print("[WARNING] watchdogライブラリが見つかりません")
    print("[INFO] インストール: pip install watchdog")


class CodeFileHandler(FileSystemEventHandler):
    """
    コードファイルの変更を監視するハンドラー

    対応拡張子:
    - C#: .cs
    - Java: .java
    - PHP: .php
    - JavaScript/TypeScript: .js, .ts, .tsx
    - Python: .py
    - Go: .go
    - C/C++: .c, .cpp, .h, .hpp
    """

    SUPPORTED_EXTENSIONS = {
        '.cs', '.java', '.php', '.js', '.ts', '.tsx', '.py', '.go',
        '.c', '.cpp', '.h', '.hpp'
    }

    def __init__(
        self,
        on_file_changed: Callable[[Path], None],
        debounce_seconds: float = 1.0
    ):
        """
        初期化

        Args:
            on_file_changed: ファイル変更時のコールバック関数
            debounce_seconds: デバウンス時間（秒）
        """
        super().__init__()
        self.on_file_changed = on_file_changed
        self.debounce_seconds = debounce_seconds
        self._pending_files: Dict[Path, datetime] = {}
        self._lock = threading.Lock()
        self._debounce_thread: Optional[threading.Thread] = None
        self._stop_debounce = False

    def on_modified(self, event):
        """ファイル変更イベントハンドラー"""
        if event.is_directory:
            return

        file_path = Path(event.src_path)

        # サポート対象の拡張子のみ処理
        if file_path.suffix not in self.SUPPORTED_EXTENSIONS:
            return

        # 一時ファイルやバックアップファイルを除外
        if file_path.name.startswith('.') or file_path.name.endswith('~'):
            return

        # デバウンス処理
        with self._lock:
            self._pending_files[file_path] = datetime.now()

        # デバウンススレッドを起動（まだ動いていない場合）
        if self._debounce_thread is None or not self._debounce_thread.is_alive():
            self._debounce_thread = threading.Thread(
                target=self._process_pending_files,
                daemon=True
            )
            self._debounce_thread.start()

    def _process_pending_files(self):
        """デバウンス処理: 一定時間変更がないファイルのみ処理"""
        while not self._stop_debounce:
            time.sleep(0.5)

            with self._lock:
                now = datetime.now()
                files_to_process = []

                for file_path, last_modified in list(self._pending_files.items()):
                    time_since_modified = (now - last_modified).total_seconds()

                    if time_since_modified >= self.debounce_seconds:
                        files_to_process.append(file_path)
                        del self._pending_files[file_path]

                if not self._pending_files:
                    # 処理待ちファイルがなくなったらスレッド終了
                    break

            # コールバック実行（ロック外で）
            for file_path in files_to_process:
                try:
                    self.on_file_changed(file_path)
                except Exception as e:
                    print(f"[ERROR] ファイル処理エラー {file_path}: {e}")

    def stop(self):
        """デバウンススレッドを停止"""
        self._stop_debounce = True
        if self._debounce_thread and self._debounce_thread.is_alive():
            self._debounce_thread.join(timeout=5)


class FileWatcher:
    """
    ファイル変更監視システム

    リアルタイムでファイルの変更を検出し、
    自動的に解析をトリガーします。

    使用例:
        def analyze_file(file_path: Path):
            print(f"Analyzing: {file_path}")

        watcher = FileWatcher(
            watch_paths=[Path("./src")],
            on_file_changed=analyze_file
        )
        watcher.start()

        # アプリケーション実行...

        watcher.stop()
    """

    def __init__(
        self,
        watch_paths: list,
        on_file_changed: Callable[[Path], None],
        debounce_seconds: float = 1.0
    ):
        """
        初期化

        Args:
            watch_paths: 監視対象ディレクトリのリスト
            on_file_changed: ファイル変更時のコールバック
            debounce_seconds: デバウンス時間（秒）
        """
        if not WATCHDOG_AVAILABLE:
            raise ImportError(
                "watchdogライブラリが必要です。\n"
                "インストール: pip install watchdog"
            )

        self.watch_paths = watch_paths
        self.on_file_changed = on_file_changed
        self.debounce_seconds = debounce_seconds

        self.observer = Observer()
        self.handler = CodeFileHandler(
            on_file_changed=on_file_changed,
            debounce_seconds=debounce_seconds
        )
        self._is_running = False

    def start(self):
        """ファイル監視を開始"""
        if self._is_running:
            print("[WARNING] ファイルウォッチャーは既に実行中です")
            return

        for watch_path in self.watch_paths:
            if not watch_path.exists():
                print(f"[WARNING] 監視パスが存在しません: {watch_path}")
                continue

            self.observer.schedule(
                self.handler,
                str(watch_path),
                recursive=True
            )
            print(f"[INFO] ファイル監視開始: {watch_path}")

        self.observer.start()
        self._is_running = True
        print("[OK] ファイルウォッチャー起動完了")

    def stop(self):
        """ファイル監視を停止"""
        if not self._is_running:
            return

        print("[INFO] ファイルウォッチャーを停止中...")
        self.handler.stop()
        self.observer.stop()
        self.observer.join(timeout=10)
        self._is_running = False
        print("[OK] ファイルウォッチャー停止完了")

    def is_running(self) -> bool:
        """実行中かどうかを返す"""
        return self._is_running


if __name__ == "__main__":
    # 簡易テスト
    print("FileWatcher簡易テスト")
    print("-" * 80)

    if not WATCHDOG_AVAILABLE:
        print("[ERROR] watchdogライブラリがインストールされていません")
        print("[INFO] pip install watchdog")
        exit(1)

    def test_callback(file_path: Path):
        print(f"[DETECTED] {file_path}")

    test_dir = Path("./src")
    if not test_dir.exists():
        print(f"[ERROR] テストディレクトリが存在しません: {test_dir}")
        exit(1)

    watcher = FileWatcher(
        watch_paths=[test_dir],
        on_file_changed=test_callback,
        debounce_seconds=1.0
    )

    try:
        watcher.start()
        print("\nファイルを編集してください（Ctrl+Cで終了）...")
        while True:
            time.sleep(1)
    except KeyboardInterrupt:
        print("\n[INFO] 終了します")
        watcher.stop()
