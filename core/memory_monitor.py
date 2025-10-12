"""
メモリモニタリングシステム

Phase 7.0の新機能:
- リアルタイムメモリ監視
- 閾値ベースの警告システム
- 自動ガベージコレクション
- メモリ統計情報提供

バージョン: v4.8.0 (Phase 7.0)
作成日: 2025年10月12日 JST

@tdd品質:
- 型ヒント完備
- メモリ安全性保証
- リアルタイムモニタリング
"""

from enum import Enum
from typing import Dict, Optional
import psutil
import gc
import logging


# ロガー設定
logger = logging.getLogger(__name__)


class MemoryStatus(Enum):
    """メモリステータス"""
    NORMAL = "normal"      # 正常
    WARNING = "warning"    # 警告（注意が必要）
    CRITICAL = "critical"  # 危険（処理を一時停止すべき）


class MemoryMonitor:
    """
    メモリモニタリングシステム

    リアルタイムでメモリ使用量を監視し、閾値を超えた場合に警告または
    処理の一時停止を推奨します。

    使用例:
        monitor = MemoryMonitor(
            warning_threshold_mb=1000,
            critical_threshold_mb=2000
        )

        # 定期的にチェック
        if monitor.should_pause_processing():
            # 処理を一時停止してガベージコレクション
            monitor.force_garbage_collection()
            time.sleep(1)

        # 統計情報取得
        stats = monitor.get_memory_statistics()
        print(f"メモリ使用量: {stats['current_mb']:.2f} MB")
    """

    def __init__(
        self,
        warning_threshold_mb: float = 1000.0,
        critical_threshold_mb: float = 2000.0,
        check_interval_seconds: float = 1.0,
        auto_gc_enabled: bool = True
    ):
        """
        初期化

        Args:
            warning_threshold_mb: 警告閾値（MB）
            critical_threshold_mb: 危険閾値（MB）
            check_interval_seconds: チェック間隔（秒）
            auto_gc_enabled: 自動ガベージコレクション有効化
        """
        self.warning_threshold_mb = warning_threshold_mb
        self.critical_threshold_mb = critical_threshold_mb
        self.check_interval_seconds = check_interval_seconds
        self.auto_gc_enabled = auto_gc_enabled

        # プロセス情報
        self.process = psutil.Process()

        # 統計情報
        self.check_count = 0
        self.warning_count = 0
        self.critical_count = 0
        self.gc_count = 0

        logger.info(
            f"MemoryMonitor initialized: "
            f"warning={warning_threshold_mb}MB, "
            f"critical={critical_threshold_mb}MB"
        )

    def get_current_memory_usage(self) -> float:
        """
        現在のメモリ使用量を取得（MB単位）

        Returns:
            メモリ使用量（MB）
        """
        memory_info = self.process.memory_info()
        return memory_info.rss / (1024 * 1024)  # バイト → MB

    def check_memory_status(self) -> MemoryStatus:
        """
        メモリステータスをチェック

        Returns:
            現在のメモリステータス
        """
        self.check_count += 1
        current_mb = self.get_current_memory_usage()

        if current_mb >= self.critical_threshold_mb:
            self.critical_count += 1
            logger.warning(
                f"CRITICAL memory usage: {current_mb:.2f} MB "
                f"(threshold: {self.critical_threshold_mb} MB)"
            )
            return MemoryStatus.CRITICAL

        elif current_mb >= self.warning_threshold_mb:
            self.warning_count += 1
            logger.info(
                f"WARNING memory usage: {current_mb:.2f} MB "
                f"(threshold: {self.warning_threshold_mb} MB)"
            )
            return MemoryStatus.WARNING

        else:
            return MemoryStatus.NORMAL

    def should_pause_processing(self) -> bool:
        """
        処理を一時停止すべきか判定

        Returns:
            True: 一時停止すべき, False: 継続可能
        """
        status = self.check_memory_status()

        if status == MemoryStatus.CRITICAL:
            # 自動GC実行
            if self.auto_gc_enabled:
                self.force_garbage_collection()
            return True

        return False

    def force_garbage_collection(self):
        """
        強制的にガベージコレクションを実行

        メモリ使用量が高い場合に手動で呼び出すことができます。
        """
        before_mb = self.get_current_memory_usage()

        # 全世代のガベージコレクション実行
        collected = gc.collect()
        self.gc_count += 1

        after_mb = self.get_current_memory_usage()
        freed_mb = before_mb - after_mb

        logger.info(
            f"Garbage collection completed: "
            f"collected={collected} objects, "
            f"freed={freed_mb:.2f} MB "
            f"(before={before_mb:.2f} MB, after={after_mb:.2f} MB)"
        )

    def get_memory_statistics(self) -> Dict:
        """
        メモリ統計情報を取得

        Returns:
            統計情報辞書
        """
        current_mb = self.get_current_memory_usage()
        status = self.check_memory_status()

        # システム全体のメモリ情報
        system_memory = psutil.virtual_memory()

        return {
            'current_mb': current_mb,
            'available_mb': system_memory.available / (1024 * 1024),
            'total_mb': system_memory.total / (1024 * 1024),
            'percent_used': system_memory.percent,
            'status': status.value,
            'warning_threshold_mb': self.warning_threshold_mb,
            'critical_threshold_mb': self.critical_threshold_mb,
            'check_count': self.check_count,
            'warning_count': self.warning_count,
            'critical_count': self.critical_count,
            'gc_count': self.gc_count
        }

    def reset_statistics(self):
        """統計情報をリセット"""
        self.check_count = 0
        self.warning_count = 0
        self.critical_count = 0
        self.gc_count = 0

        logger.info("Memory statistics reset")

    def get_system_memory_info(self) -> Dict:
        """
        システム全体のメモリ情報を取得

        Returns:
            システムメモリ情報
        """
        memory = psutil.virtual_memory()

        return {
            'total_mb': memory.total / (1024 * 1024),
            'available_mb': memory.available / (1024 * 1024),
            'used_mb': memory.used / (1024 * 1024),
            'free_mb': memory.free / (1024 * 1024),
            'percent': memory.percent,
            'buffers_mb': getattr(memory, 'buffers', 0) / (1024 * 1024),
            'cached_mb': getattr(memory, 'cached', 0) / (1024 * 1024)
        }

    def __repr__(self) -> str:
        """文字列表現"""
        current_mb = self.get_current_memory_usage()
        status = self.check_memory_status()

        return (
            f"MemoryMonitor("
            f"current={current_mb:.2f}MB, "
            f"status={status.value}, "
            f"warning={self.warning_threshold_mb}MB, "
            f"critical={self.critical_threshold_mb}MB)"
        )


if __name__ == "__main__":
    # 簡易テスト
    print("MemoryMonitor 簡易テスト")
    print("-" * 80)

    monitor = MemoryMonitor(
        warning_threshold_mb=100,
        critical_threshold_mb=500
    )

    print("\n1. 現在のメモリ使用量:")
    current = monitor.get_current_memory_usage()
    print(f"   {current:.2f} MB")

    print("\n2. メモリステータスチェック:")
    status = monitor.check_memory_status()
    print(f"   {status.value}")

    print("\n3. メモリ統計情報:")
    stats = monitor.get_memory_statistics()
    print(f"   現在: {stats['current_mb']:.2f} MB")
    print(f"   利用可能: {stats['available_mb']:.2f} MB")
    print(f"   使用率: {stats['percent_used']:.1f}%")

    print("\n4. システムメモリ情報:")
    sys_info = monitor.get_system_memory_info()
    print(f"   合計: {sys_info['total_mb']:.2f} MB")
    print(f"   使用中: {sys_info['used_mb']:.2f} MB")
    print(f"   空き: {sys_info['free_mb']:.2f} MB")

    print("\n5. ガベージコレクション:")
    monitor.force_garbage_collection()

    try:
        print("\n✅ 簡易テスト完了")
    except UnicodeEncodeError:
        print("\n[OK] 簡易テスト完了")
