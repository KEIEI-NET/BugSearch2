"""
Phase 7テスト: 大規模ソースファイル解析システム（30,000+ファイル対応）

@tdd品質保証:
- メモリモニタリング
- チェックポイント機能
- 中断・再開機能
- 大規模バッチ処理

バージョン: v4.8.0 (Phase 7.0)
作成日: 2025年10月12日 JST
"""

import unittest
from pathlib import Path
import json
import tempfile
import shutil
import sys
from datetime import datetime
import time
import psutil
import os

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent.parent))

from core.memory_monitor import MemoryMonitor, MemoryStatus
from core.checkpoint_manager import CheckpointManager, Checkpoint
from core.large_scale_processor import LargeScaleProcessor, ProcessingConfig


class TestMemoryMonitor(unittest.TestCase):
    """メモリモニタリングのテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.monitor = MemoryMonitor(
            warning_threshold_mb=100,  # 警告: 100MB
            critical_threshold_mb=500,  # 危険: 500MB
            check_interval_seconds=0.1
        )

    def test_memory_status_enum(self):
        """メモリステータスEnumのテスト"""
        self.assertEqual(MemoryStatus.NORMAL.value, "normal")
        self.assertEqual(MemoryStatus.WARNING.value, "warning")
        self.assertEqual(MemoryStatus.CRITICAL.value, "critical")
        print("✅ メモリステータスEnum正常")

    def test_get_current_memory_usage(self):
        """現在のメモリ使用量取得テスト"""
        usage_mb = self.monitor.get_current_memory_usage()

        self.assertIsInstance(usage_mb, float)
        self.assertGreater(usage_mb, 0)
        print(f"✅ メモリ使用量取得成功: {usage_mb:.2f} MB")

    def test_check_memory_status(self):
        """メモリステータスチェックテスト"""
        status = self.monitor.check_memory_status()

        self.assertIsInstance(status, MemoryStatus)
        self.assertIn(status, [MemoryStatus.NORMAL, MemoryStatus.WARNING, MemoryStatus.CRITICAL])
        print(f"✅ メモリステータスチェック成功: {status.value}")

    def test_should_pause_processing(self):
        """処理一時停止判定テスト"""
        should_pause = self.monitor.should_pause_processing()

        self.assertIsInstance(should_pause, bool)
        print(f"✅ 処理一時停止判定: {should_pause}")

    def test_get_memory_statistics(self):
        """メモリ統計情報取得テスト"""
        stats = self.monitor.get_memory_statistics()

        self.assertIn('current_mb', stats)
        self.assertIn('available_mb', stats)
        self.assertIn('percent_used', stats)
        self.assertIn('status', stats)

        print(f"✅ メモリ統計取得成功:")
        print(f"   現在: {stats['current_mb']:.2f} MB")
        print(f"   利用可能: {stats['available_mb']:.2f} MB")
        print(f"   使用率: {stats['percent_used']:.1f}%")


class TestCheckpointManager(unittest.TestCase):
    """チェックポイント管理のテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path(tempfile.mkdtemp())
        self.checkpoint_file = self.test_dir / "checkpoint.json"
        self.manager = CheckpointManager(self.checkpoint_file)

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_checkpoint_creation(self):
        """チェックポイント作成テスト"""
        checkpoint = self.manager.create_checkpoint(
            processed_files=['file1.py', 'file2.py'],
            total_files=100,
            current_batch=1,
            total_batches=10,
            metadata={'test': 'value'}
        )

        self.assertIsInstance(checkpoint, Checkpoint)
        self.assertEqual(len(checkpoint.processed_files), 2)
        self.assertEqual(checkpoint.total_files, 100)
        self.assertEqual(checkpoint.current_batch, 1)
        print("✅ チェックポイント作成成功")

    def test_checkpoint_save_load(self):
        """チェックポイント保存・読込テスト"""
        # チェックポイント作成
        original = self.manager.create_checkpoint(
            processed_files=['file1.py', 'file2.py', 'file3.py'],
            total_files=100,
            current_batch=2,
            total_batches=10
        )

        # 保存
        self.manager.save_checkpoint(original)
        self.assertTrue(self.checkpoint_file.exists())

        # 読込
        loaded = self.manager.load_checkpoint()
        self.assertIsNotNone(loaded)
        self.assertEqual(len(loaded.processed_files), 3)
        self.assertEqual(loaded.current_batch, 2)

        print("✅ チェックポイント保存・読込成功")

    def test_checkpoint_resume_detection(self):
        """再開可能性検出テスト"""
        # チェックポイントなし
        self.assertFalse(self.manager.can_resume())

        # チェックポイント作成
        checkpoint = self.manager.create_checkpoint(
            processed_files=['file1.py'],
            total_files=100,
            current_batch=1,
            total_batches=10
        )
        self.manager.save_checkpoint(checkpoint)

        # 再開可能
        self.assertTrue(self.manager.can_resume())

        print("✅ 再開可能性検出成功")

    def test_checkpoint_deletion(self):
        """チェックポイント削除テスト"""
        # チェックポイント作成・保存
        checkpoint = self.manager.create_checkpoint(
            processed_files=['file1.py'],
            total_files=100,
            current_batch=1,
            total_batches=10
        )
        self.manager.save_checkpoint(checkpoint)
        self.assertTrue(self.checkpoint_file.exists())

        # 削除
        self.manager.delete_checkpoint()
        self.assertFalse(self.checkpoint_file.exists())

        print("✅ チェックポイント削除成功")

    def test_checkpoint_progress_percentage(self):
        """進捗率計算テスト"""
        checkpoint = self.manager.create_checkpoint(
            processed_files=['file1.py', 'file2.py'],
            total_files=10,
            current_batch=2,
            total_batches=5
        )

        progress = checkpoint.get_progress_percentage()
        self.assertEqual(progress, 20.0)  # 2/10 = 20%

        print(f"✅ 進捗率計算成功: {progress}%")


class TestLargeScaleProcessor(unittest.TestCase):
    """大規模処理プロセッサーのテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path(tempfile.mkdtemp())
        self.checkpoint_file = self.test_dir / "checkpoint.json"

        # テスト用ファイル作成（100ファイル）
        self.test_files = []
        for i in range(100):
            test_file = self.test_dir / f"test_{i}.py"
            test_file.write_text(f"# Test file {i}\nprint('Hello {i}')\n", encoding='utf-8')
            self.test_files.append(test_file)

        # 設定
        self.config = ProcessingConfig(
            batch_size=10,
            checkpoint_interval=5,  # 5ファイルごとにチェックポイント
            memory_check_interval=2,
            max_memory_mb=500,
            enable_auto_gc=True
        )

        self.processor = LargeScaleProcessor(
            config=self.config,
            checkpoint_file=self.checkpoint_file
        )

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_batch_division(self):
        """バッチ分割テスト"""
        batches = self.processor.divide_into_batches(self.test_files)

        self.assertEqual(len(batches), 10)  # 100ファイル / 10 = 10バッチ
        self.assertEqual(len(batches[0]), 10)  # 各バッチ10ファイル

        print(f"✅ バッチ分割成功: {len(batches)}バッチ")

    def test_simple_processing(self):
        """シンプル処理テスト"""

        def simple_processor(file_path: Path) -> dict:
            """テスト用プロセッサー"""
            return {
                'file': str(file_path),
                'size': file_path.stat().st_size,
                'success': True
            }

        # 最初の10ファイルだけ処理
        results = self.processor.process_files(
            files=self.test_files[:10],
            processor_func=simple_processor
        )

        self.assertEqual(len(results), 10)
        self.assertTrue(all(r['success'] for r in results))

        print("✅ シンプル処理テスト成功")

    def test_checkpoint_creation_during_processing(self):
        """処理中のチェックポイント作成テスト"""

        processed_count = [0]  # カウンター

        def counting_processor(file_path: Path) -> dict:
            processed_count[0] += 1
            return {'file': str(file_path), 'success': True}

        # 20ファイル処理（チェックポイント間隔5なので、4回チェックポイント作成）
        results = self.processor.process_files(
            files=self.test_files[:20],
            processor_func=counting_processor
        )

        self.assertEqual(len(results), 20)
        self.assertEqual(processed_count[0], 20)

        # チェックポイント存在確認
        self.assertTrue(self.checkpoint_file.exists())

        print("✅ 処理中チェックポイント作成成功")

    def test_resume_from_checkpoint(self):
        """チェックポイントからの再開テスト"""

        # 1回目: 全100ファイルを処理開始するが、10ファイルで中断をシミュレート
        # エラー時に停止する設定でプロセッサーを作成
        interrupt_config = ProcessingConfig(
            batch_size=10,
            checkpoint_interval=5,
            memory_check_interval=2,
            max_memory_mb=500,
            enable_auto_gc=True,
            stop_on_error=True  # エラー時に停止
        )

        interrupt_processor = LargeScaleProcessor(
            config=interrupt_config,
            checkpoint_file=self.checkpoint_file
        )

        processed_count = [0]
        interrupt_at = 10

        class InterruptException(Exception):
            """中断をシミュレートする例外"""
            pass

        def processor_v1(file_path: Path) -> dict:
            processed_count[0] += 1
            if processed_count[0] >= interrupt_at:
                # 10ファイル処理後に中断
                raise InterruptException("Simulated interruption")
            return {'file': str(file_path), 'version': 1}

        # 中断をキャッチ
        try:
            results_v1 = interrupt_processor.process_files(
                files=self.test_files,  # 全100ファイルを指定
                processor_func=processor_v1
            )
        except InterruptException:
            pass  # 期待される中断

        # チェックポイント確認（9ファイルまで処理済み、10番目で中断）
        checkpoint = interrupt_processor.checkpoint_manager.load_checkpoint()
        self.assertIsNotNone(checkpoint)
        self.assertGreater(len(checkpoint.processed_files), 0)
        processed_in_v1 = len(checkpoint.processed_files)

        # 2回目: 新しいプロセッサーで残り処理
        processor_v2 = LargeScaleProcessor(
            config=self.config,
            checkpoint_file=self.checkpoint_file
        )

        def processor_func_v2(file_path: Path) -> dict:
            return {'file': str(file_path), 'version': 2}

        # 再開処理（全100ファイルを指定するが、処理済みファイルはスキップされる）
        results_v2 = processor_v2.process_files(
            files=self.test_files,  # 同じ100ファイルを指定
            processor_func=processor_func_v2,
            resume=True
        )

        # 残りファイルのみ処理されるはず
        expected_remaining = 100 - processed_in_v1
        self.assertEqual(len(results_v2), expected_remaining)

        print(f"✅ チェックポイント再開成功（v1: {processed_in_v1}ファイル, v2: {len(results_v2)}ファイル）")

    def test_memory_monitoring_during_processing(self):
        """処理中メモリモニタリングテスト"""

        memory_checks = []

        def monitored_processor(file_path: Path) -> dict:
            # メモリ状態記録
            status = self.processor.memory_monitor.check_memory_status()
            memory_checks.append(status)
            return {'file': str(file_path), 'success': True}

        results = self.processor.process_files(
            files=self.test_files[:20],
            processor_func=monitored_processor
        )

        self.assertEqual(len(results), 20)
        self.assertGreater(len(memory_checks), 0)

        print(f"✅ メモリモニタリング成功: {len(memory_checks)}回チェック")

    def test_auto_pause_on_high_memory(self):
        """高メモリ使用時の自動一時停止テスト"""

        # 極端に低いメモリ閾値設定（テスト用）
        low_memory_config = ProcessingConfig(
            batch_size=10,
            checkpoint_interval=5,
            memory_check_interval=1,
            max_memory_mb=1,  # 1MBで危険判定（必ず超える）
            enable_auto_gc=True
        )

        processor = LargeScaleProcessor(
            config=low_memory_config,
            checkpoint_file=self.test_dir / "test_checkpoint.json"
        )

        pause_detected = [False]

        def pause_detecting_processor(file_path: Path) -> dict:
            if processor.memory_monitor.should_pause_processing():
                pause_detected[0] = True
            return {'file': str(file_path), 'success': True}

        # 処理実行（メモリチェックで一時停止が発生するはず）
        results = processor.process_files(
            files=self.test_files[:10],
            processor_func=pause_detecting_processor
        )

        # 一時停止が検出されたことを確認
        # （実際には処理は継続するが、フラグが立つことを確認）
        self.assertTrue(pause_detected[0])

        print("✅ 高メモリ使用時一時停止検出成功")


class TestIntegration(unittest.TestCase):
    """統合テスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path(tempfile.mkdtemp())

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_end_to_end_processing(self):
        """エンドツーエンド処理テスト"""

        # 1000ファイル作成
        test_files = []
        for i in range(1000):
            test_file = self.test_dir / f"file_{i}.py"
            test_file.write_text(f"# File {i}\n", encoding='utf-8')
            test_files.append(test_file)

        # プロセッサー設定
        config = ProcessingConfig(
            batch_size=50,
            checkpoint_interval=100,
            memory_check_interval=10,
            max_memory_mb=1000,
            enable_auto_gc=True
        )

        checkpoint_file = self.test_dir / "checkpoint.json"
        processor = LargeScaleProcessor(config, checkpoint_file)

        # 処理実行
        def test_processor(file_path: Path) -> dict:
            return {
                'file': str(file_path.name),
                'size': file_path.stat().st_size,
                'timestamp': datetime.now().isoformat()
            }

        start_time = time.time()
        results = processor.process_files(test_files, test_processor)
        elapsed = time.time() - start_time

        # 検証
        self.assertEqual(len(results), 1000)
        self.assertTrue(all('file' in r for r in results))

        # 統計出力
        print(f"✅ エンドツーエンド処理成功:")
        print(f"   ファイル数: 1,000")
        print(f"   処理時間: {elapsed:.2f}秒")
        print(f"   スループット: {len(results)/elapsed:.1f} files/sec")


def run_tests():
    """テストスイートを実行"""
    suite = unittest.TestSuite()

    # テストクラス追加
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestMemoryMonitor))
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestCheckpointManager))
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestLargeScaleProcessor))
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestIntegration))

    # テスト実行
    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)

    # 結果サマリー
    print("\n" + "=" * 80)
    print("📊 Phase 7テスト結果サマリー")
    print("=" * 80)
    print(f"実行したテスト: {result.testsRun}")
    print(f"成功: {result.testsRun - len(result.failures) - len(result.errors)}")
    print(f"失敗: {len(result.failures)}")
    print(f"エラー: {len(result.errors)}")
    print(f"スキップ: {len(result.skipped)}")

    if result.wasSuccessful():
        try:
            print("\n✅ 全てのテストが合格しました！ (@tdd品質達成)")
        except UnicodeEncodeError:
            print("\n[OK] 全てのテストが合格しました！ (@tdd品質達成)")
        return 0
    else:
        print("\n❌ テストに失敗しました")
        if result.failures:
            print("\n失敗したテスト:")
            for test, traceback in result.failures:
                print(f"  - {test}")
        if result.errors:
            print("\nエラーが発生したテスト:")
            for test, traceback in result.errors:
                print(f"  - {test}")
        return 1


if __name__ == "__main__":
    sys.exit(run_tests())
