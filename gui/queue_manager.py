"""
BugSearch2 Queue Manager

複数ジョブのキュー管理とスケジューリング
優先度管理、依存関係管理、並列実行制御
"""

import time
from typing import Dict, List, Optional, Any, Callable
from dataclasses import dataclass, field
from datetime import datetime
from enum import Enum


class JobStatus(Enum):
    """ジョブ状態"""
    QUEUED = "queued"          # キューに追加済み
    WAITING = "waiting"        # 依存関係待機中
    RUNNING = "running"        # 実行中
    PAUSED = "paused"          # 一時停止中
    COMPLETED = "completed"    # 完了
    FAILED = "failed"          # 失敗
    CANCELLED = "cancelled"    # キャンセル


class JobPriority(Enum):
    """ジョブ優先度"""
    LOW = 1
    NORMAL = 5
    HIGH = 10
    URGENT = 20


@dataclass
class JobConfig:
    """ジョブ設定"""
    job_id: str
    name: str
    command: List[str]
    priority: JobPriority = JobPriority.NORMAL
    depends_on: List[str] = field(default_factory=list)  # 依存するジョブID
    config: Dict[str, Any] = field(default_factory=dict)
    created_at: float = field(default_factory=time.time)
    started_at: Optional[float] = None
    completed_at: Optional[float] = None
    status: JobStatus = JobStatus.QUEUED
    error_message: Optional[str] = None
    retry_count: int = 0
    max_retries: int = 0

    def to_dict(self) -> Dict[str, Any]:
        """辞書形式に変換"""
        return {
            'job_id': self.job_id,
            'name': self.name,
            'command': self.command,
            'priority': self.priority.value,
            'depends_on': self.depends_on,
            'config': self.config,
            'created_at': self.created_at,
            'started_at': self.started_at,
            'completed_at': self.completed_at,
            'status': self.status.value,
            'error_message': self.error_message,
            'retry_count': self.retry_count,
            'max_retries': self.max_retries,
        }


class QueueManager:
    """
    複数ジョブのキュー管理

    機能:
    - ジョブキューイング
    - 優先度管理
    - 依存関係管理
    - 並列実行制御（max_concurrent）
    - 自動リトライ
    - キュー状態の永続化
    """

    def __init__(self, max_concurrent: int = 3):
        self.max_concurrent = max_concurrent
        self.jobs: Dict[str, JobConfig] = {}
        self.queue: List[str] = []  # job_idのリスト（優先度順）
        self.running: List[str] = []  # 実行中のjob_id
        self.completed: List[str] = []  # 完了したjob_id
        self.failed: List[str] = []  # 失敗したjob_id

        # コールバック
        self.on_job_start: Optional[Callable[[str], None]] = None
        self.on_job_complete: Optional[Callable[[str], None]] = None
        self.on_job_fail: Optional[Callable[[str, str], None]] = None

    def add_job(
        self,
        name: str,
        command: List[str],
        priority: JobPriority = JobPriority.NORMAL,
        depends_on: Optional[List[str]] = None,
        config: Optional[Dict[str, Any]] = None,
        max_retries: int = 0
    ) -> str:
        """
        ジョブをキューに追加

        Args:
            name: ジョブ名
            command: 実行コマンド
            priority: 優先度
            depends_on: 依存するジョブID
            config: 追加設定
            max_retries: 最大リトライ回数

        Returns:
            job_id: 追加したジョブのID
        """
        # ジョブID生成
        timestamp = datetime.now().strftime('%Y%m%d_%H%M%S_%f')
        job_id = f"job_{timestamp}"

        # ジョブ設定作成
        job = JobConfig(
            job_id=job_id,
            name=name,
            command=command,
            priority=priority,
            depends_on=depends_on or [],
            config=config or {},
            max_retries=max_retries
        )

        self.jobs[job_id] = job
        self.queue.append(job_id)

        # 優先度順にソート
        self._sort_queue()

        print(f"[OK] Job added to queue: {job_id} ({name}) [Priority: {priority.name}]")
        return job_id

    def _sort_queue(self):
        """キューを優先度順にソート"""
        self.queue.sort(
            key=lambda job_id: (
                -self.jobs[job_id].priority.value,  # 優先度（降順）
                self.jobs[job_id].created_at         # 作成時刻（昇順）
            )
        )

    def can_start_job(self, job_id: str) -> bool:
        """
        ジョブを開始できるかチェック

        Args:
            job_id: ジョブID

        Returns:
            開始可能な場合True
        """
        if job_id not in self.jobs:
            return False

        job = self.jobs[job_id]

        # 依存関係チェック
        for dep_job_id in job.depends_on:
            if dep_job_id not in self.completed:
                # 依存ジョブが完了していない
                return False

        # 並列実行数チェック
        if len(self.running) >= self.max_concurrent:
            return False

        return True

    def get_next_job(self) -> Optional[str]:
        """
        次に実行するジョブを取得

        Returns:
            job_id: 実行可能なジョブID、ない場合はNone
        """
        for job_id in self.queue:
            if self.can_start_job(job_id):
                return job_id

        return None

    def start_job(self, job_id: str) -> bool:
        """
        ジョブを開始

        Args:
            job_id: ジョブID

        Returns:
            成功した場合True
        """
        if job_id not in self.jobs:
            print(f"[ERROR] Job not found: {job_id}")
            return False

        if not self.can_start_job(job_id):
            print(f"[ERROR] Cannot start job: {job_id}")
            return False

        # キューから削除
        if job_id in self.queue:
            self.queue.remove(job_id)

        # 実行中リストに追加
        self.running.append(job_id)

        # ステータス更新
        job = self.jobs[job_id]
        job.status = JobStatus.RUNNING
        job.started_at = time.time()

        print(f"[STARTED] Job started: {job_id} ({job.name})")

        # コールバック実行
        if self.on_job_start:
            self.on_job_start(job_id)

        return True

    def complete_job(self, job_id: str):
        """
        ジョブを完了

        Args:
            job_id: ジョブID
        """
        if job_id not in self.jobs:
            return

        # 実行中リストから削除
        if job_id in self.running:
            self.running.remove(job_id)

        # 完了リストに追加
        if job_id not in self.completed:
            self.completed.append(job_id)

        # ステータス更新
        job = self.jobs[job_id]
        job.status = JobStatus.COMPLETED
        job.completed_at = time.time()

        elapsed = job.completed_at - job.started_at if job.started_at else 0
        print(f"[OK] Job completed: {job_id} ({job.name}) [Elapsed: {elapsed:.1f}s]")

        # コールバック実行
        if self.on_job_complete:
            self.on_job_complete(job_id)

    def fail_job(self, job_id: str, error_message: str):
        """
        ジョブを失敗

        Args:
            job_id: ジョブID
            error_message: エラーメッセージ
        """
        if job_id not in self.jobs:
            return

        job = self.jobs[job_id]

        # リトライ可能かチェック
        if job.retry_count < job.max_retries:
            job.retry_count += 1
            print(f"[WARNING] Job failed, retrying ({job.retry_count}/{job.max_retries}): {job_id}")

            # キューに戻す
            if job_id in self.running:
                self.running.remove(job_id)

            if job_id not in self.queue:
                self.queue.insert(0, job_id)  # 先頭に追加（優先実行）

            job.status = JobStatus.QUEUED
            return

        # リトライ上限に達した
        if job_id in self.running:
            self.running.remove(job_id)

        if job_id not in self.failed:
            self.failed.append(job_id)

        # ステータス更新
        job.status = JobStatus.FAILED
        job.completed_at = time.time()
        job.error_message = error_message

        print(f"[ERROR] Job failed: {job_id} ({job.name}) - {error_message}")

        # コールバック実行
        if self.on_job_fail:
            self.on_job_fail(job_id, error_message)

    def cancel_job(self, job_id: str):
        """
        ジョブをキャンセル

        Args:
            job_id: ジョブID
        """
        if job_id not in self.jobs:
            return

        job = self.jobs[job_id]

        # キューから削除
        if job_id in self.queue:
            self.queue.remove(job_id)

        # 実行中リストから削除
        if job_id in self.running:
            self.running.remove(job_id)

        # ステータス更新
        job.status = JobStatus.CANCELLED
        job.completed_at = time.time()

        print(f"[STOPPED] Job cancelled: {job_id} ({job.name})")

    def process_queue(self) -> List[str]:
        """
        キューを処理（実行可能なジョブを起動）

        Returns:
            起動したジョブIDのリスト
        """
        started_jobs = []

        while len(self.running) < self.max_concurrent:
            next_job = self.get_next_job()
            if next_job is None:
                break

            if self.start_job(next_job):
                started_jobs.append(next_job)

        return started_jobs

    def get_status(self) -> Dict[str, Any]:
        """
        キュー状態を取得

        Returns:
            キュー状態
        """
        return {
            'queued': len(self.queue),
            'running': len(self.running),
            'completed': len(self.completed),
            'failed': len(self.failed),
            'total': len(self.jobs),
            'max_concurrent': self.max_concurrent,
        }

    def get_job_info(self, job_id: str) -> Optional[Dict[str, Any]]:
        """
        ジョブ情報を取得

        Args:
            job_id: ジョブID

        Returns:
            ジョブ情報
        """
        if job_id not in self.jobs:
            return None

        job = self.jobs[job_id]
        info = job.to_dict()

        # 実行時間を計算
        if job.started_at:
            if job.completed_at:
                info['elapsed_time'] = job.completed_at - job.started_at
            else:
                info['elapsed_time'] = time.time() - job.started_at

        # 待ち時間を計算
        if not job.started_at:
            info['wait_time'] = time.time() - job.created_at

        return info

    def get_all_jobs(self) -> List[Dict[str, Any]]:
        """全ジョブ情報を取得"""
        return [self.get_job_info(job_id) for job_id in self.jobs]

    def get_queued_jobs(self) -> List[Dict[str, Any]]:
        """キュー中のジョブを取得"""
        return [self.get_job_info(job_id) for job_id in self.queue]

    def get_running_jobs(self) -> List[Dict[str, Any]]:
        """実行中のジョブを取得"""
        return [self.get_job_info(job_id) for job_id in self.running]

    def get_completed_jobs(self) -> List[Dict[str, Any]]:
        """完了したジョブを取得"""
        return [self.get_job_info(job_id) for job_id in self.completed]

    def get_failed_jobs(self) -> List[Dict[str, Any]]:
        """失敗したジョブを取得"""
        return [self.get_job_info(job_id) for job_id in self.failed]

    def clear_completed(self):
        """完了したジョブをクリア"""
        for job_id in self.completed[:]:
            if job_id in self.jobs:
                del self.jobs[job_id]

        self.completed.clear()
        print("[OK] Cleared completed jobs")

    def clear_failed(self):
        """失敗したジョブをクリア"""
        for job_id in self.failed[:]:
            if job_id in self.jobs:
                del self.jobs[job_id]

        self.failed.clear()
        print("[OK] Cleared failed jobs")


if __name__ == '__main__':
    # 簡単なテスト
    queue = QueueManager(max_concurrent=2)

    # ジョブ追加
    job1 = queue.add_job(
        name="Index Creation",
        command=['python', 'codex_review_severity.py', 'index'],
        priority=JobPriority.HIGH
    )

    job2 = queue.add_job(
        name="AI Analysis",
        command=['python', 'codex_review_severity.py', 'advise', '--all'],
        priority=JobPriority.NORMAL,
        depends_on=[job1]  # job1に依存
    )

    job3 = queue.add_job(
        name="React Config",
        command=['python', 'generate_tech_config.py', '--tech', 'react'],
        priority=JobPriority.URGENT
    )

    # キュー状態表示
    print(f"\nQueue Status: {queue.get_status()}")

    # キュー処理
    print("\nProcessing queue...")
    started = queue.process_queue()
    print(f"Started jobs: {started}")

    # 実行中ジョブ表示
    print(f"\nRunning jobs: {[j['name'] for j in queue.get_running_jobs()]}")
