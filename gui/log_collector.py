"""
BugSearch2 Log Collector

リアルタイムログストリーミング機能
プロセスの標準出力/標準エラー出力を非同期で収集
"""

import time
import threading
import queue
import re
from typing import Dict, List, Optional, Any
from dataclasses import dataclass
from datetime import datetime
from collections import deque


@dataclass
class LogEntry:
    """ログエントリー"""
    job_id: str
    timestamp: float
    level: str  # INFO, WARNING, ERROR, DEBUG
    message: str
    source: str  # stdout or stderr

    def to_dict(self) -> Dict[str, Any]:
        """辞書形式に変換"""
        return {
            'job_id': self.job_id,
            'timestamp': self.timestamp,
            'datetime': datetime.fromtimestamp(self.timestamp).strftime('%Y-%m-%d %H:%M:%S'),
            'level': self.level,
            'message': self.message,
            'source': self.source,
        }

    def formatted(self) -> str:
        """フォーマット済み文字列"""
        dt = datetime.fromtimestamp(self.timestamp).strftime('%H:%M:%S')
        return f"[{dt}] {self.level}: {self.message}"


class LogCollector:
    """
    リアルタイムログストリーミング

    機能:
    - 非同期ログ収集（別スレッド）
    - ログレベル検出（INFO, WARNING, ERROR）
    - 進捗情報のパース
    - ログのバッファリングと検索
    """

    def __init__(self, max_buffer_size: int = 10000):
        self.log_buffers: Dict[str, deque] = {}  # job_id -> deque of LogEntry
        self.log_threads: Dict[str, List[threading.Thread]] = {}  # job_id -> threads
        self.stop_flags: Dict[str, threading.Event] = {}  # job_id -> stop event
        self.max_buffer_size = max_buffer_size

        # ログレベル検出用パターン
        self.level_patterns = {
            'ERROR': re.compile(r'\b(ERROR|Error|error|FAILED|Failed|failed)\b'),
            'WARNING': re.compile(r'\b(WARNING|Warning|warning|WARN|Warn)\b'),
            'SUCCESS': re.compile(r'\b(SUCCESS|Success|success|COMPLETE|Complete)\b'),
            'INFO': re.compile(r'\b(INFO|Info|info)\b'),
        }

        # 進捗情報検出用パターン
        self.progress_patterns = {
            'percentage': re.compile(r'(\d+)%'),
            'fraction': re.compile(r'(\d+)/(\d+)'),
            'tqdm': re.compile(r'\|[█░\-]+\|\s*(\d+)%'),
        }

    def start_collecting(
        self,
        job_id: str,
        stdout_pipe,
        stderr_pipe
    ):
        """
        ログ収集を開始

        Args:
            job_id: ジョブID
            stdout_pipe: 標準出力パイプ
            stderr_pipe: 標準エラー出力パイプ
        """
        if job_id in self.log_threads:
            print(f"[WARNING] Log collection already started for job: {job_id}")
            return

        # バッファ初期化
        self.log_buffers[job_id] = deque(maxlen=self.max_buffer_size)
        self.stop_flags[job_id] = threading.Event()

        # スレッド起動
        threads = []

        if stdout_pipe:
            stdout_thread = threading.Thread(
                target=self._log_reader_thread,
                args=(job_id, stdout_pipe, 'stdout'),
                daemon=True
            )
            stdout_thread.start()
            threads.append(stdout_thread)

        if stderr_pipe:
            stderr_thread = threading.Thread(
                target=self._log_reader_thread,
                args=(job_id, stderr_pipe, 'stderr'),
                daemon=True
            )
            stderr_thread.start()
            threads.append(stderr_thread)

        self.log_threads[job_id] = threads
        print(f"[OK] Log collection started for job: {job_id}")

    def stop_collecting(self, job_id: str):
        """
        ログ収集を停止

        Args:
            job_id: ジョブID
        """
        if job_id not in self.stop_flags:
            return

        # 停止フラグを設定
        self.stop_flags[job_id].set()

        # スレッドの終了を待機
        if job_id in self.log_threads:
            for thread in self.log_threads[job_id]:
                thread.join(timeout=2.0)

            del self.log_threads[job_id]
            del self.stop_flags[job_id]

        print(f"[OK] Log collection stopped for job: {job_id}")

    def _log_reader_thread(self, job_id: str, pipe, source: str):
        """
        ログ読み取りスレッド（バイトモード対応）

        Args:
            job_id: ジョブID
            pipe: パイプ（stdout or stderr）
            source: ソース名（'stdout' or 'stderr'）
        """
        stop_flag = self.stop_flags.get(job_id)

        try:
            # バイトモードで読み込み（Windows cp932エラー対策）
            for line_bytes in iter(pipe.readline, b''):
                # 停止フラグチェック
                if stop_flag and stop_flag.is_set():
                    break

                if line_bytes:
                    # UTF-8でデコード（エラーは?に置換）
                    try:
                        line = line_bytes.decode('utf-8', errors='replace')
                    except Exception as decode_error:
                        # デコード失敗時はlatin1でフォールバック
                        line = line_bytes.decode('latin1', errors='replace')

                    line = line.rstrip('\n\r')
                    if line:  # 空行はスキップ
                        # ログエントリー作成
                        entry = self._create_log_entry(job_id, line, source)
                        self.log_buffers[job_id].append(entry)

        except Exception as e:
            error_entry = LogEntry(
                job_id=job_id,
                timestamp=time.time(),
                level='ERROR',
                message=f"Log reader error: {str(e)}",
                source=source
            )
            self.log_buffers[job_id].append(error_entry)

        finally:
            pipe.close()

    def _create_log_entry(self, job_id: str, line: str, source: str) -> LogEntry:
        """
        ログエントリーを作成

        Args:
            job_id: ジョブID
            line: ログ行
            source: ソース（'stdout' or 'stderr'）

        Returns:
            LogEntry
        """
        timestamp = time.time()
        level = self._detect_log_level(line)

        return LogEntry(
            job_id=job_id,
            timestamp=timestamp,
            level=level,
            message=line,
            source=source
        )

    def _detect_log_level(self, line: str) -> str:
        """
        ログレベルを検出

        Args:
            line: ログ行

        Returns:
            ログレベル（ERROR, WARNING, SUCCESS, INFO, DEBUG）
        """
        # パターンマッチング
        for level, pattern in self.level_patterns.items():
            if pattern.search(line):
                return level

        # デフォルト
        return 'DEBUG'

    def get_logs(
        self,
        job_id: str,
        max_lines: Optional[int] = None,
        level_filter: Optional[str] = None
    ) -> List[LogEntry]:
        """
        ログを取得

        Args:
            job_id: ジョブID
            max_lines: 最大行数（指定しない場合は全て）
            level_filter: レベルフィルター（例: 'ERROR'）

        Returns:
            ログエントリーのリスト
        """
        if job_id not in self.log_buffers:
            return []

        logs = list(self.log_buffers[job_id])

        # レベルフィルター適用
        if level_filter:
            logs = [log for log in logs if log.level == level_filter]

        # 最大行数制限
        if max_lines:
            logs = logs[-max_lines:]

        return logs

    def get_latest_logs(self, job_id: str, count: int = 100) -> List[LogEntry]:
        """
        最新のログを取得

        Args:
            job_id: ジョブID
            count: 取得する行数

        Returns:
            最新のログエントリー
        """
        return self.get_logs(job_id, max_lines=count)

    def search_logs(
        self,
        job_id: str,
        keyword: str,
        case_sensitive: bool = False
    ) -> List[LogEntry]:
        """
        ログを検索

        Args:
            job_id: ジョブID
            keyword: 検索キーワード
            case_sensitive: 大文字小文字を区別するか

        Returns:
            マッチしたログエントリー
        """
        if job_id not in self.log_buffers:
            return []

        logs = list(self.log_buffers[job_id])

        if case_sensitive:
            return [log for log in logs if keyword in log.message]
        else:
            keyword_lower = keyword.lower()
            return [log for log in logs if keyword_lower in log.message.lower()]

    def parse_progress(self, line: str) -> Optional[float]:
        """
        ログから進捗情報を抽出

        Args:
            line: ログ行

        Returns:
            進捗率（0.0～1.0）、見つからない場合はNone
        """
        # パーセンテージパターン（例: "65%"）
        match = self.progress_patterns['percentage'].search(line)
        if match:
            percentage = int(match.group(1))
            return min(percentage / 100.0, 1.0)

        # 分数パターン（例: "50/100"）
        match = self.progress_patterns['fraction'].search(line)
        if match:
            current = int(match.group(1))
            total = int(match.group(2))
            if total > 0:
                return min(current / total, 1.0)

        # tqdmパターン
        match = self.progress_patterns['tqdm'].search(line)
        if match:
            percentage = int(match.group(1))
            return min(percentage / 100.0, 1.0)

        return None

    def get_progress(self, job_id: str) -> Optional[float]:
        """
        ジョブの現在の進捗率を取得

        Args:
            job_id: ジョブID

        Returns:
            進捗率（0.0～1.0）、見つからない場合はNone
        """
        if job_id not in self.log_buffers:
            return None

        # 最新のログから進捗情報を探す（逆順）
        logs = list(self.log_buffers[job_id])
        for log in reversed(logs):
            progress = self.parse_progress(log.message)
            if progress is not None:
                return progress

        return None

    def get_error_logs(self, job_id: str) -> List[LogEntry]:
        """
        エラーログのみを取得

        Args:
            job_id: ジョブID

        Returns:
            エラーログのリスト
        """
        return self.get_logs(job_id, level_filter='ERROR')

    def get_warning_logs(self, job_id: str) -> List[LogEntry]:
        """
        警告ログのみを取得

        Args:
            job_id: ジョブID

        Returns:
            警告ログのリスト
        """
        return self.get_logs(job_id, level_filter='WARNING')

    def clear_logs(self, job_id: str):
        """
        ログをクリア

        Args:
            job_id: ジョブID
        """
        if job_id in self.log_buffers:
            self.log_buffers[job_id].clear()
            print(f"[OK] Logs cleared for job: {job_id}")

    def get_statistics(self, job_id: str) -> Dict[str, int]:
        """
        ログ統計を取得

        Args:
            job_id: ジョブID

        Returns:
            統計情報（レベル別カウント）
        """
        if job_id not in self.log_buffers:
            return {}

        logs = list(self.log_buffers[job_id])

        stats = {
            'total': len(logs),
            'ERROR': 0,
            'WARNING': 0,
            'SUCCESS': 0,
            'INFO': 0,
            'DEBUG': 0,
        }

        for log in logs:
            if log.level in stats:
                stats[log.level] += 1

        return stats


if __name__ == '__main__':
    # 簡単なテスト
    import subprocess

    collector = LogCollector()

    # テストプロセス（Pythonバージョンとヘルプを表示）
    process = subprocess.Popen(
        ['python', '--version'],
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
        text=True
    )

    job_id = "test_job_001"
    collector.start_collecting(job_id, process.stdout, process.stderr)

    # 少し待機
    time.sleep(2)

    # ログ取得
    logs = collector.get_logs(job_id)
    print(f"\nCollected {len(logs)} log entries:")
    for log in logs:
        print(f"  {log.formatted()}")

    # 統計表示
    stats = collector.get_statistics(job_id)
    print(f"\nStatistics: {stats}")

    # クリーンアップ
    collector.stop_collecting(job_id)
    process.wait()
