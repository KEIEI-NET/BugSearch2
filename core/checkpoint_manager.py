"""
チェックポイント管理システム

Phase 7.0の新機能:
- 処理進捗の定期保存
- 中断からの再開サポート
- チェックポイントバージョニング
- メタデータ管理

バージョン: v4.8.0 (Phase 7.0)
作成日: 2025年10月12日 JST

@tdd品質:
- 型ヒント完備
- アトミック書き込み
- データ整合性保証
"""

from dataclasses import dataclass, field, asdict
from typing import List, Dict, Optional
from pathlib import Path
from datetime import datetime
import json
import logging


# ロガー設定
logger = logging.getLogger(__name__)


@dataclass
class Checkpoint:
    """
    チェックポイントデータクラス

    処理の進捗状況を表現します。
    """
    # 基本情報
    timestamp: str
    version: str = "1.0"

    # 進捗情報
    processed_files: List[str] = field(default_factory=list)
    total_files: int = 0
    current_batch: int = 0
    total_batches: int = 0

    # メタデータ
    metadata: Dict = field(default_factory=dict)

    # 統計情報
    success_count: int = 0
    error_count: int = 0

    def get_progress_percentage(self) -> float:
        """
        進捗率を計算（0.0-100.0）

        Returns:
            進捗率（パーセント）
        """
        if self.total_files == 0:
            return 0.0

        return (len(self.processed_files) / self.total_files) * 100.0

    def get_remaining_count(self) -> int:
        """
        残りファイル数を取得

        Returns:
            残りファイル数
        """
        return self.total_files - len(self.processed_files)

    def is_complete(self) -> bool:
        """
        処理が完了しているか判定

        Returns:
            True: 完了, False: 未完了
        """
        return len(self.processed_files) >= self.total_files

    def to_dict(self) -> Dict:
        """
        辞書形式に変換

        Returns:
            辞書データ
        """
        return asdict(self)

    @classmethod
    def from_dict(cls, data: Dict) -> 'Checkpoint':
        """
        辞書からCheckpointを生成

        Args:
            data: 辞書データ

        Returns:
            Checkpointインスタンス
        """
        return cls(**data)


class CheckpointManager:
    """
    チェックポイント管理システム

    大規模処理の進捗を定期的に保存し、中断した場所から再開できるようにします。

    使用例:
        manager = CheckpointManager(Path(".bugsearch/checkpoint.json"))

        # チェックポイント作成
        checkpoint = manager.create_checkpoint(
            processed_files=['file1.py', 'file2.py'],
            total_files=1000,
            current_batch=1,
            total_batches=20
        )

        # 保存
        manager.save_checkpoint(checkpoint)

        # 再開可能かチェック
        if manager.can_resume():
            checkpoint = manager.load_checkpoint()
            print(f"進捗: {checkpoint.get_progress_percentage():.1f}%")
    """

    def __init__(self, checkpoint_file: Path):
        """
        初期化

        Args:
            checkpoint_file: チェックポイントファイルのパス
        """
        self.checkpoint_file = checkpoint_file
        self.version = "1.0"

        logger.info(f"CheckpointManager initialized: {checkpoint_file}")

    def create_checkpoint(
        self,
        processed_files: List[str],
        total_files: int,
        current_batch: int = 0,
        total_batches: int = 0,
        metadata: Optional[Dict] = None,
        success_count: int = 0,
        error_count: int = 0
    ) -> Checkpoint:
        """
        新しいチェックポイントを作成

        Args:
            processed_files: 処理済みファイルのリスト
            total_files: 総ファイル数
            current_batch: 現在のバッチ番号
            total_batches: 総バッチ数
            metadata: 追加メタデータ
            success_count: 成功数
            error_count: エラー数

        Returns:
            チェックポイント
        """
        return Checkpoint(
            timestamp=datetime.now().isoformat(),
            version=self.version,
            processed_files=processed_files,
            total_files=total_files,
            current_batch=current_batch,
            total_batches=total_batches,
            metadata=metadata or {},
            success_count=success_count,
            error_count=error_count
        )

    def save_checkpoint(self, checkpoint: Checkpoint):
        """
        チェックポイントを保存

        Args:
            checkpoint: 保存するチェックポイント
        """
        # ディレクトリ作成
        self.checkpoint_file.parent.mkdir(parents=True, exist_ok=True)

        # アトミック書き込み（一時ファイル経由）
        temp_file = self.checkpoint_file.with_suffix('.tmp')

        try:
            with open(temp_file, 'w', encoding='utf-8') as f:
                json.dump(checkpoint.to_dict(), f, indent=2, ensure_ascii=False)

            # 一時ファイルを本ファイルに置き換え
            temp_file.replace(self.checkpoint_file)

            logger.info(
                f"Checkpoint saved: "
                f"{len(checkpoint.processed_files)}/{checkpoint.total_files} files "
                f"({checkpoint.get_progress_percentage():.1f}%)"
            )

        except Exception as e:
            logger.error(f"Failed to save checkpoint: {e}")
            if temp_file.exists():
                temp_file.unlink()
            raise

    def load_checkpoint(self) -> Optional[Checkpoint]:
        """
        チェックポイントを読み込み

        Returns:
            チェックポイント（存在しない場合はNone）
        """
        if not self.checkpoint_file.exists():
            logger.debug("No checkpoint file found")
            return None

        try:
            with open(self.checkpoint_file, 'r', encoding='utf-8') as f:
                data = json.load(f)

            checkpoint = Checkpoint.from_dict(data)

            logger.info(
                f"Checkpoint loaded: "
                f"{len(checkpoint.processed_files)}/{checkpoint.total_files} files "
                f"({checkpoint.get_progress_percentage():.1f}%)"
            )

            return checkpoint

        except Exception as e:
            logger.error(f"Failed to load checkpoint: {e}")
            return None

    def can_resume(self) -> bool:
        """
        再開可能かチェック

        Returns:
            True: 再開可能, False: 再開不可
        """
        if not self.checkpoint_file.exists():
            return False

        checkpoint = self.load_checkpoint()
        if checkpoint is None:
            return False

        # 完了していない場合は再開可能
        return not checkpoint.is_complete()

    def delete_checkpoint(self):
        """
        チェックポイントファイルを削除
        """
        if self.checkpoint_file.exists():
            self.checkpoint_file.unlink()
            logger.info("Checkpoint deleted")

    def get_checkpoint_info(self) -> Optional[Dict]:
        """
        チェックポイント情報を取得（読み込まずに）

        Returns:
            チェックポイント情報（存在しない場合はNone）
        """
        if not self.checkpoint_file.exists():
            return None

        checkpoint = self.load_checkpoint()
        if checkpoint is None:
            return None

        return {
            'exists': True,
            'timestamp': checkpoint.timestamp,
            'progress_percentage': checkpoint.get_progress_percentage(),
            'processed_count': len(checkpoint.processed_files),
            'total_count': checkpoint.total_files,
            'remaining_count': checkpoint.get_remaining_count(),
            'current_batch': checkpoint.current_batch,
            'total_batches': checkpoint.total_batches,
            'is_complete': checkpoint.is_complete(),
            'success_count': checkpoint.success_count,
            'error_count': checkpoint.error_count
        }

    def archive_checkpoint(self, archive_dir: Path):
        """
        チェックポイントをアーカイブ

        Args:
            archive_dir: アーカイブディレクトリ
        """
        if not self.checkpoint_file.exists():
            logger.warning("No checkpoint to archive")
            return

        archive_dir.mkdir(parents=True, exist_ok=True)

        # タイムスタンプ付きファイル名
        timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
        archive_file = archive_dir / f"checkpoint_{timestamp}.json"

        # コピー
        import shutil
        shutil.copy2(self.checkpoint_file, archive_file)

        logger.info(f"Checkpoint archived: {archive_file}")

    def __repr__(self) -> str:
        """文字列表現"""
        info = self.get_checkpoint_info()
        if info is None:
            return f"CheckpointManager(file={self.checkpoint_file}, status=no_checkpoint)"

        return (
            f"CheckpointManager("
            f"file={self.checkpoint_file}, "
            f"progress={info['progress_percentage']:.1f}%, "
            f"processed={info['processed_count']}/{info['total_count']})"
        )


if __name__ == "__main__":
    # 簡易テスト
    print("CheckpointManager 簡易テスト")
    print("-" * 80)

    import tempfile

    # 一時ファイル
    temp_file = Path(tempfile.mktemp(suffix='.json'))

    try:
        manager = CheckpointManager(temp_file)

        print("\n1. チェックポイント作成:")
        checkpoint = manager.create_checkpoint(
            processed_files=['file1.py', 'file2.py', 'file3.py'],
            total_files=10,
            current_batch=1,
            total_batches=2,
            metadata={'test': 'value'}
        )
        print(f"   進捗: {checkpoint.get_progress_percentage():.1f}%")
        print(f"   残り: {checkpoint.get_remaining_count()}ファイル")

        print("\n2. チェックポイント保存:")
        manager.save_checkpoint(checkpoint)
        print(f"   保存先: {temp_file}")

        print("\n3. チェックポイント読込:")
        loaded = manager.load_checkpoint()
        if loaded:
            print(f"   進捗: {loaded.get_progress_percentage():.1f}%")
            print(f"   タイムスタンプ: {loaded.timestamp}")

        print("\n4. 再開可能性チェック:")
        can_resume = manager.can_resume()
        print(f"   再開可能: {can_resume}")

        print("\n5. チェックポイント情報:")
        info = manager.get_checkpoint_info()
        if info:
            print(f"   処理済み: {info['processed_count']}/{info['total_count']}")
            print(f"   進捗率: {info['progress_percentage']:.1f}%")

        try:
            print("\n✅ 簡易テスト完了")
        except UnicodeEncodeError:
            print("\n[OK] 簡易テスト完了")

    finally:
        # クリーンアップ
        if temp_file.exists():
            temp_file.unlink()
