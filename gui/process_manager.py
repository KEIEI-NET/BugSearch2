"""
BugSearch2 Process Manager

プロセスの起動、監視、制御（一時停止/再開/停止）を担当
クロスプラットフォーム対応（Windows/Unix）
"""

import os
import sys
import time
import uuid
import subprocess
import psutil
from dataclasses import dataclass, field
from datetime import datetime
from typing import Dict, List, Optional, Any
from pathlib import Path
import json


@dataclass
class ProcessInfo:
    """プロセス情報を保持するデータクラス"""
    job_id: str
    command: List[str]
    pid: Optional[int] = None
    status: str = 'pending'  # pending, running, paused, completed, failed
    progress: float = 0.0
    start_time: Optional[float] = None
    end_time: Optional[float] = None
    exit_code: Optional[int] = None
    error_message: Optional[str] = None
    config: Dict[str, Any] = field(default_factory=dict)

    def to_dict(self) -> Dict[str, Any]:
        """辞書形式に変換"""
        return {
            'job_id': self.job_id,
            'command': self.command,
            'pid': self.pid,
            'status': self.status,
            'progress': self.progress,
            'start_time': self.start_time,
            'end_time': self.end_time,
            'exit_code': self.exit_code,
            'error_message': self.error_message,
            'config': self.config,
        }

    @classmethod
    def from_dict(cls, data: Dict[str, Any]) -> 'ProcessInfo':
        """辞書から復元"""
        return cls(**data)


class ProcessManager:
    """
    BugSearch2プロセスの起動、監視、制御を担当

    主要機能:
    - プロセス起動（subprocess）
    - プロセス一時停止/再開（psutil）
    - プロセス停止（SIGTERM → SIGKILL）
    - プロセス情報取得（CPU、メモリ、実行時間）
    - 状態の永続化と復元
    """

    def __init__(self, state_file: str = '.gui_state.json'):
        self.processes: Dict[str, ProcessInfo] = {}
        self.process_handles: Dict[str, subprocess.Popen] = {}  # プロセスハンドル管理
        self.state_file = state_file
        self.restore_state()

    def generate_job_id(self) -> str:
        """一意のジョブIDを生成"""
        timestamp = datetime.now().strftime('%Y%m%d_%H%M%S')
        unique_id = str(uuid.uuid4())[:8]
        return f"job_{timestamp}_{unique_id}"

    def start_process(
        self,
        command: List[str],
        job_id: Optional[str] = None,
        config: Optional[Dict[str, Any]] = None,
        cwd: Optional[str] = None
    ) -> str:
        """
        プロセスを起動

        Args:
            command: 実行するコマンド (例: ['python', 'codex_review_severity.py', 'index'])
            job_id: ジョブID（指定しない場合は自動生成）
            config: 追加設定（tech_stack, output_dirなど）
            cwd: 作業ディレクトリ

        Returns:
            job_id: 起動したプロセスのジョブID

        Raises:
            FileNotFoundError: コマンドが見つからない場合
            PermissionError: 実行権限がない場合
        """
        if job_id is None:
            job_id = self.generate_job_id()

        if config is None:
            config = {}

        # ProcessInfo作成
        proc_info = ProcessInfo(
            job_id=job_id,
            command=command,
            config=config,
            start_time=time.time(),
            status='starting'
        )

        try:
            # サブプロセス起動
            process = subprocess.Popen(
                command,
                stdout=subprocess.PIPE,
                stderr=subprocess.PIPE,
                text=True,
                bufsize=1,
                cwd=cwd,
                universal_newlines=True
            )

            proc_info.pid = process.pid
            proc_info.status = 'running'

            self.processes[job_id] = proc_info
            self.process_handles[job_id] = process  # プロセスハンドルを保存
            self.save_state()

            print(f"[OK] Process started: {job_id} (PID: {process.pid})")
            return job_id

        except FileNotFoundError as e:
            proc_info.status = 'failed'
            proc_info.error_message = f"Command not found: {command[0]}"
            self.processes[job_id] = proc_info
            raise

        except Exception as e:
            proc_info.status = 'failed'
            proc_info.error_message = str(e)
            self.processes[job_id] = proc_info
            self.save_state()
            raise

    def pause_process(self, job_id: str) -> bool:
        """
        プロセスを一時停止

        Args:
            job_id: ジョブID

        Returns:
            成功した場合True
        """
        if job_id not in self.processes:
            print(f"[ERROR] Job not found: {job_id}")
            return False

        proc_info = self.processes[job_id]

        if proc_info.pid is None:
            print(f"[ERROR] No PID for job: {job_id}")
            return False

        if proc_info.status != 'running':
            print(f"[ERROR] Process not running: {job_id} (status: {proc_info.status})")
            return False

        try:
            p = psutil.Process(proc_info.pid)
            p.suspend()  # クロスプラットフォーム対応
            proc_info.status = 'paused'
            self.save_state()
            print(f"[PAUSED] Process paused: {job_id} (PID: {proc_info.pid})")
            return True

        except psutil.NoSuchProcess:
            print(f"[ERROR] Process not found: {job_id} (PID: {proc_info.pid})")
            proc_info.status = 'failed'
            proc_info.error_message = "Process not found"
            self.save_state()
            return False

        except Exception as e:
            print(f"[ERROR] Failed to pause process: {e}")
            return False

    def resume_process(self, job_id: str) -> bool:
        """
        プロセスを再開

        Args:
            job_id: ジョブID

        Returns:
            成功した場合True
        """
        if job_id not in self.processes:
            print(f"[ERROR] Job not found: {job_id}")
            return False

        proc_info = self.processes[job_id]

        if proc_info.pid is None:
            print(f"[ERROR] No PID for job: {job_id}")
            return False

        if proc_info.status != 'paused':
            print(f"[ERROR] Process not paused: {job_id} (status: {proc_info.status})")
            return False

        try:
            p = psutil.Process(proc_info.pid)
            p.resume()  # クロスプラットフォーム対応
            proc_info.status = 'running'
            self.save_state()
            print(f"[STARTED] Process resumed: {job_id} (PID: {proc_info.pid})")
            return True

        except psutil.NoSuchProcess:
            print(f"[ERROR] Process not found: {job_id} (PID: {proc_info.pid})")
            proc_info.status = 'failed'
            proc_info.error_message = "Process not found"
            self.save_state()
            return False

        except Exception as e:
            print(f"[ERROR] Failed to resume process: {e}")
            return False

    def stop_process(self, job_id: str, timeout: int = 10) -> bool:
        """
        プロセスを停止

        1. SIGTERM送信（正常終了を要求）
        2. タイムアウト後SIGKILL（強制終了）

        Args:
            job_id: ジョブID
            timeout: タイムアウト秒数

        Returns:
            成功した場合True
        """
        if job_id not in self.processes:
            print(f"[ERROR] Job not found: {job_id}")
            return False

        proc_info = self.processes[job_id]

        if proc_info.pid is None:
            print(f"[ERROR] No PID for job: {job_id}")
            return False

        if proc_info.status in ['completed', 'failed']:
            print(f"[OK] Process already terminated: {job_id}")
            return True

        try:
            p = psutil.Process(proc_info.pid)

            # まずSIGTERMで正常終了を試みる
            p.terminate()

            # タイムアウト待機
            try:
                p.wait(timeout=timeout)
                print(f"[STOPPED] Process terminated gracefully: {job_id}")
            except psutil.TimeoutExpired:
                # タイムアウトしたら強制終了
                print(f"[WARNING] Timeout expired, killing process: {job_id}")
                p.kill()
                p.wait()
                print(f"[STOPPED] Process killed: {job_id}")

            proc_info.status = 'completed'
            proc_info.end_time = time.time()
            proc_info.exit_code = p.returncode if hasattr(p, 'returncode') else None

            # プロセスハンドルをクリーンアップ
            if job_id in self.process_handles:
                del self.process_handles[job_id]

            self.save_state()
            return True

        except psutil.NoSuchProcess:
            print(f"[ERROR] Process not found: {job_id} (PID: {proc_info.pid})")
            proc_info.status = 'failed'
            proc_info.error_message = "Process not found"
            self.save_state()
            return False

        except Exception as e:
            print(f"[ERROR] Failed to stop process: {e}")
            return False

    def get_process_info(self, job_id: str) -> Optional[Dict[str, Any]]:
        """
        プロセス情報を取得

        Args:
            job_id: ジョブID

        Returns:
            プロセス情報（PID、状態、CPU、メモリ、実行時間など）
        """
        if job_id not in self.processes:
            return None

        proc_info = self.processes[job_id]
        info = proc_info.to_dict()

        # 実行中の場合はリアルタイム情報を追加
        if proc_info.pid and proc_info.status == 'running':
            try:
                p = psutil.Process(proc_info.pid)
                info['cpu_percent'] = p.cpu_percent(interval=0.1)
                info['memory_mb'] = p.memory_info().rss / (1024 * 1024)
                info['num_threads'] = p.num_threads()
                info['elapsed_time'] = time.time() - proc_info.start_time if proc_info.start_time else 0
            except psutil.NoSuchProcess:
                proc_info.status = 'failed'
                proc_info.error_message = "Process terminated unexpectedly"
                self.save_state()

        # 実行時間を計算
        if proc_info.start_time:
            if proc_info.end_time:
                info['elapsed_time'] = proc_info.end_time - proc_info.start_time
            else:
                info['elapsed_time'] = time.time() - proc_info.start_time

        return info

    def get_all_processes(self) -> Dict[str, Dict[str, Any]]:
        """全プロセス情報を取得"""
        return {
            job_id: self.get_process_info(job_id)
            for job_id in self.processes
        }

    def get_process_pipes(self, job_id: str) -> Optional[tuple]:
        """
        プロセスのstdout/stderrパイプを取得

        Args:
            job_id: ジョブID

        Returns:
            (stdout, stderr)のタプル、プロセスが存在しない場合はNone
        """
        if job_id not in self.process_handles:
            return None

        process = self.process_handles[job_id]
        return (process.stdout, process.stderr)

    def check_process_status(self, job_id: str) -> Optional[str]:
        """
        プロセスの現在の状態をチェック

        Returns:
            'running', 'paused', 'completed', 'failed', None
        """
        if job_id not in self.processes:
            return None

        proc_info = self.processes[job_id]

        # 既に終了状態の場合はそのまま返す
        if proc_info.status in ['completed', 'failed']:
            return proc_info.status

        # プロセスが実際に存在するかチェック
        if proc_info.pid:
            try:
                p = psutil.Process(proc_info.pid)
                if p.is_running():
                    # サスペンド状態かチェック
                    if p.status() == psutil.STATUS_STOPPED:
                        proc_info.status = 'paused'
                    else:
                        proc_info.status = 'running'
                else:
                    proc_info.status = 'completed'
                    proc_info.end_time = time.time()
            except psutil.NoSuchProcess:
                proc_info.status = 'failed'
                proc_info.error_message = "Process not found"
                proc_info.end_time = time.time()

            self.save_state()

        return proc_info.status

    def save_state(self):
        """現在の状態をJSONに保存"""
        try:
            state = {
                'version': '1.0.0',
                'timestamp': time.time(),
                'processes': {
                    job_id: proc_info.to_dict()
                    for job_id, proc_info in self.processes.items()
                }
            }

            with open(self.state_file, 'w', encoding='utf-8') as f:
                json.dump(state, f, indent=2, ensure_ascii=False)

        except Exception as e:
            print(f"[ERROR] Failed to save state: {e}")

    def restore_state(self):
        """JSONから状態を復元"""
        if not os.path.exists(self.state_file):
            return

        try:
            with open(self.state_file, 'r', encoding='utf-8') as f:
                state = json.load(f)

            # バージョンチェック
            if state.get('version') != '1.0.0':
                print(f"[WARNING] State file version mismatch: {state.get('version')}")
                return

            # プロセス情報を復元
            for job_id, proc_data in state.get('processes', {}).items():
                self.processes[job_id] = ProcessInfo.from_dict(proc_data)

                # 実行中だったプロセスの状態を再チェック
                if self.processes[job_id].status in ['running', 'paused']:
                    self.check_process_status(job_id)

            print(f"[OK] Restored {len(self.processes)} processes from state file")

        except Exception as e:
            print(f"[ERROR] Failed to restore state: {e}")

    def cleanup_completed(self, max_age_hours: int = 24):
        """
        完了したジョブをクリーンアップ

        Args:
            max_age_hours: この時間より古い完了ジョブを削除
        """
        current_time = time.time()
        cutoff_time = current_time - (max_age_hours * 3600)

        jobs_to_remove = []
        for job_id, proc_info in self.processes.items():
            if proc_info.status in ['completed', 'failed']:
                if proc_info.end_time and proc_info.end_time < cutoff_time:
                    jobs_to_remove.append(job_id)

        for job_id in jobs_to_remove:
            del self.processes[job_id]
            # プロセスハンドルもクリーンアップ
            if job_id in self.process_handles:
                del self.process_handles[job_id]

        if jobs_to_remove:
            self.save_state()
            print(f"[OK] Cleaned up {len(jobs_to_remove)} old jobs")


if __name__ == '__main__':
    # 簡単なテスト
    manager = ProcessManager()

    # テストコマンド（Pythonバージョンを表示）
    job_id = manager.start_process(['python', '--version'])
    time.sleep(1)

    info = manager.get_process_info(job_id)
    print(f"\nProcess Info: {info}")

    # 状態チェック
    status = manager.check_process_status(job_id)
    print(f"Status: {status}")
