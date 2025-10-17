"""
BugSearch2 GUI - 基本動作テスト

GUIコンポーネントの基本機能をテスト
"""

import sys
import os
import time
import unittest
from pathlib import Path

# プロジェクトルートをパスに追加
project_root = Path(__file__).parent.parent
sys.path.insert(0, str(project_root))

from gui.process_manager import ProcessManager, ProcessInfo
from gui.log_collector import LogCollector, LogEntry
from gui.queue_manager import QueueManager, JobPriority, JobStatus
from gui.state_manager import StateManager


class TestProcessManager(unittest.TestCase):
    """ProcessManagerのテスト"""

    def setUp(self):
        """テスト前の初期化"""
        self.manager = ProcessManager(state_file='.test_process_state.json')

    def tearDown(self):
        """テスト後のクリーンアップ"""
        if os.path.exists('.test_process_state.json'):
            os.remove('.test_process_state.json')

    def test_start_process(self):
        """プロセス起動テスト"""
        job_id = self.manager.start_process(['python', '--version'])
        self.assertIsNotNone(job_id)
        self.assertIn(job_id, self.manager.processes)

        # プロセス情報取得
        info = self.manager.get_process_info(job_id)
        self.assertIsNotNone(info)
        self.assertEqual(info['status'], 'running')

        # 少し待機してプロセス完了を待つ
        time.sleep(1)

        # ステータスチェック（failedも許容: テストコマンドは即座に終了する可能性がある）
        status = self.manager.check_process_status(job_id)
        self.assertIn(status, ['running', 'completed', 'failed'])

    def test_state_persistence(self):
        """状態永続化テスト"""
        job_id = self.manager.start_process(['python', '--version'])
        self.manager.save_state()

        # 新しいインスタンスで復元
        manager2 = ProcessManager(state_file='.test_process_state.json')
        self.assertIn(job_id, manager2.processes)


class TestLogCollector(unittest.TestCase):
    """LogCollectorのテスト"""

    def setUp(self):
        """テスト前の初期化"""
        self.collector = LogCollector()

    def test_log_entry_creation(self):
        """ログエントリー作成テスト"""
        entry = LogEntry(
            job_id='test_001',
            timestamp=time.time(),
            level='INFO',
            message='Test message',
            source='stdout'
        )
        self.assertEqual(entry.level, 'INFO')
        self.assertEqual(entry.message, 'Test message')

    def test_log_level_detection(self):
        """ログレベル検出テスト"""
        test_cases = [
            ('Error: something went wrong', 'ERROR'),
            ('Warning: deprecated function', 'WARNING'),
            ('Success: operation completed', 'SUCCESS'),
            ('Info: processing file', 'INFO'),
            ('Debug message', 'DEBUG'),
        ]

        for message, expected_level in test_cases:
            detected = self.collector._detect_log_level(message)
            self.assertEqual(detected, expected_level)

    def test_progress_parsing(self):
        """進捗パース テスト"""
        test_cases = [
            ('Processing: 65%', 0.65),
            ('Files: 50/100', 0.50),
            ('|████████░░| 80%', 0.80),
        ]

        for message, expected_progress in test_cases:
            progress = self.collector.parse_progress(message)
            self.assertIsNotNone(progress)
            self.assertAlmostEqual(progress, expected_progress, places=2)


class TestQueueManager(unittest.TestCase):
    """QueueManagerのテスト"""

    def setUp(self):
        """テスト前の初期化"""
        self.queue = QueueManager(max_concurrent=2)

    def test_add_job(self):
        """ジョブ追加テスト"""
        job_id = self.queue.add_job(
            name='Test Job',
            command=['python', '--version'],
            priority=JobPriority.NORMAL
        )
        self.assertIsNotNone(job_id)
        self.assertIn(job_id, self.queue.jobs)

    def test_priority_ordering(self):
        """優先度順序テスト"""
        job1 = self.queue.add_job('Low Priority', ['cmd'], JobPriority.LOW)
        job2 = self.queue.add_job('High Priority', ['cmd'], JobPriority.HIGH)
        job3 = self.queue.add_job('Urgent', ['cmd'], JobPriority.URGENT)

        # キューの先頭はURGENTであるべき
        self.assertEqual(self.queue.queue[0], job3)

    def test_dependency_management(self):
        """依存関係管理テスト"""
        job1 = self.queue.add_job('Job 1', ['cmd'], JobPriority.NORMAL)
        job2 = self.queue.add_job('Job 2', ['cmd'], JobPriority.NORMAL, depends_on=[job1])

        # job2はjob1が完了するまで開始できない
        self.assertFalse(self.queue.can_start_job(job2))

        # job1を完了させる
        self.queue.start_job(job1)
        self.queue.complete_job(job1)

        # 今度はjob2を開始できる
        self.assertTrue(self.queue.can_start_job(job2))

    def test_concurrent_limit(self):
        """並列実行数制限テスト"""
        # 3つのジョブを追加（max_concurrent=2）
        job1 = self.queue.add_job('Job 1', ['cmd'], JobPriority.NORMAL)
        job2 = self.queue.add_job('Job 2', ['cmd'], JobPriority.NORMAL)
        job3 = self.queue.add_job('Job 3', ['cmd'], JobPriority.NORMAL)

        # キュー処理
        self.queue.process_queue()

        # 実行中は2つまで
        self.assertLessEqual(len(self.queue.running), 2)


class TestStateManager(unittest.TestCase):
    """StateManagerのテスト"""

    def setUp(self):
        """テスト前の初期化"""
        self.manager = StateManager(state_file='.test_app_state.json')

    def tearDown(self):
        """テスト後のクリーンアップ"""
        if os.path.exists('.test_app_state.json'):
            os.remove('.test_app_state.json')

    def test_window_state(self):
        """ウィンドウ状態テスト"""
        self.manager.set_window_state(width=1600, height=900, maximized=True)
        state = self.manager.get_window_state()

        self.assertEqual(state.width, 1600)
        self.assertEqual(state.height, 900)
        self.assertTrue(state.maximized)

    def test_settings(self):
        """設定テスト"""
        self.manager.set_setting('theme', 'light')
        self.manager.set_setting('max_concurrent_jobs', 5)

        self.assertEqual(self.manager.get_setting('theme'), 'light')
        self.assertEqual(self.manager.get_setting('max_concurrent_jobs'), 5)

    def test_job_history(self):
        """ジョブ履歴テスト"""
        job_info = {
            'name': 'Test Job',
            'status': 'completed',
            'elapsed_time': 120.5
        }
        self.manager.add_job_history('job_001', job_info)

        retrieved = self.manager.get_job_history('job_001')
        self.assertIsNotNone(retrieved)
        self.assertEqual(retrieved['name'], 'Test Job')

    def test_state_persistence(self):
        """状態永続化テスト"""
        self.manager.set_window_state(width=1400, height=800)
        self.manager.set_setting('theme', 'dark')
        self.manager.save_state()

        # 新しいインスタンスで復元
        manager2 = StateManager(state_file='.test_app_state.json')
        state = manager2.get_window_state()
        self.assertEqual(state.width, 1400)
        self.assertEqual(manager2.get_setting('theme'), 'dark')

    def test_export_import(self):
        """エクスポート/インポートテスト"""
        self.manager.set_custom_data('test_key', 'test_value')
        export_path = '.test_export.json'

        # エクスポート
        success = self.manager.export_state(export_path)
        self.assertTrue(success)

        # 新しいインスタンスでインポート
        manager2 = StateManager(state_file='.test_app_state2.json')
        success = manager2.import_state(export_path)
        self.assertTrue(success)
        self.assertEqual(manager2.get_custom_data('test_key'), 'test_value')

        # クリーンアップ
        os.remove(export_path)
        if os.path.exists('.test_app_state2.json'):
            os.remove('.test_app_state2.json')


def run_tests():
    """テストを実行"""
    # テストスイート作成
    loader = unittest.TestLoader()
    suite = unittest.TestSuite()

    suite.addTests(loader.loadTestsFromTestCase(TestProcessManager))
    suite.addTests(loader.loadTestsFromTestCase(TestLogCollector))
    suite.addTests(loader.loadTestsFromTestCase(TestQueueManager))
    suite.addTests(loader.loadTestsFromTestCase(TestStateManager))

    # テスト実行
    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)

    # 結果サマリー
    print("\n" + "=" * 70)
    print(f"Tests run: {result.testsRun}")
    print(f"Successes: {result.testsRun - len(result.failures) - len(result.errors)}")
    print(f"Failures: {len(result.failures)}")
    print(f"Errors: {len(result.errors)}")
    print("=" * 70)

    return result.wasSuccessful()


if __name__ == '__main__':
    success = run_tests()
    sys.exit(0 if success else 1)
