#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""
統合テスト設定マネージャーのテストコード

Phase 8.4テスト - デフォルトチェックボックス設定システム

Test Coverage:
- 設定ファイル読み込み
- デフォルト値取得
- 設定保存
- バリデーション
- リセット機能
- リロード機能
"""

import os
import sys
import unittest
import tempfile
import shutil
from pathlib import Path

# プロジェクトルートをパスに追加
project_root = Path(__file__).parent.parent
sys.path.insert(0, str(project_root))

from core.integration_test_config import (
    IntegrationTestConfigManager,
    get_config_manager
)


class TestIntegrationTestConfigManager(unittest.TestCase):
    """IntegrationTestConfigManager のテストケース"""

    def setUp(self):
        """各テストの前処理"""
        # 一時ディレクトリを作成
        self.test_dir = Path(tempfile.mkdtemp())
        self.config_file = self.test_dir / "test_config.yml"

        # テスト用のマネージャーを作成
        self.manager = IntegrationTestConfigManager(config_path=self.config_file)

    def tearDown(self):
        """各テストの後処理"""
        # 一時ディレクトリをクリーンアップ
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_01_default_config_creation(self):
        """テスト1: デフォルト設定ファイル自動生成"""
        # 設定ファイルが自動生成されることを確認
        self.assertTrue(self.config_file.exists(), "設定ファイルが生成されていません")

        # バージョンが設定されていることを確認
        self.assertIn('version', self.manager.config)
        self.assertEqual(self.manager.config['version'], '1.0.0')

    def test_02_context7_defaults(self):
        """テスト2: Context7デフォルト設定取得"""
        tech_stacks = self.manager.get_context7_default_tech_stacks()
        topics = self.manager.get_context7_default_topics()

        # デフォルト値が正しく取得できることを確認
        self.assertIsInstance(tech_stacks, list)
        self.assertIsInstance(topics, list)

        # デフォルト値が期待通りであることを確認
        self.assertIn('react', tech_stacks)
        self.assertIn('angular', tech_stacks)
        self.assertIn('security', topics)
        self.assertIn('performance', topics)

    def test_03_integration_test_defaults(self):
        """テスト3: 統合テストデフォルト設定取得"""
        project_types = self.manager.get_integration_test_default_project_types()
        topics = self.manager.get_integration_test_default_topics()
        max_file_mb = self.manager.get_integration_test_default_max_file_mb()
        worker_count = self.manager.get_integration_test_default_worker_count()

        # デフォルト値が正しく取得できることを確認
        self.assertIsInstance(project_types, list)
        self.assertIsInstance(topics, list)
        self.assertIsInstance(max_file_mb, int)
        self.assertIsInstance(worker_count, int)

        # デフォルト値が期待通りであることを確認
        self.assertIn('react', project_types)
        self.assertIn('security', topics)
        self.assertEqual(max_file_mb, 4)
        self.assertEqual(worker_count, 4)

    def test_04_index_defaults(self):
        """テスト4: インデックス作成デフォルト設定取得"""
        max_file_mb = self.manager.get_index_default_max_file_mb()
        worker_count = self.manager.get_index_default_worker_count()
        exclude_langs = self.manager.get_index_default_exclude_langs()

        # デフォルト値が正しく取得できることを確認
        self.assertIsInstance(max_file_mb, int)
        self.assertIsInstance(worker_count, int)
        self.assertIsInstance(exclude_langs, list)

        self.assertEqual(max_file_mb, 4)
        self.assertEqual(worker_count, 4)

    def test_05_advise_defaults(self):
        """テスト5: AI分析デフォルト設定取得"""
        complete_report = self.manager.get_advise_default_complete_report()
        max_complete_items = self.manager.get_advise_default_max_complete_items()

        # デフォルト値が正しく取得できることを確認
        self.assertIsInstance(complete_report, bool)
        self.assertIsInstance(max_complete_items, int)

        self.assertEqual(complete_report, False)
        self.assertEqual(max_complete_items, 100)

    def test_06_save_context7_defaults(self):
        """テスト6: Context7デフォルト設定保存"""
        new_tech_stacks = ['vue', 'svelte']
        new_topics = ['accessibility', 'optimization']

        # 設定を保存
        result = self.manager.save_context7_defaults(new_tech_stacks, new_topics)
        self.assertTrue(result, "設定保存が失敗しました")

        # 保存した設定が反映されていることを確認
        saved_tech_stacks = self.manager.get_context7_default_tech_stacks()
        saved_topics = self.manager.get_context7_default_topics()

        self.assertEqual(saved_tech_stacks, new_tech_stacks)
        self.assertEqual(saved_topics, new_topics)

    def test_07_save_integration_test_defaults(self):
        """テスト7: 統合テストデフォルト設定保存"""
        new_projects = ['express', 'django']
        new_topics = ['testing', 'deployment']
        new_max_mb = 8
        new_workers = 8

        # 設定を保存
        result = self.manager.save_integration_test_defaults(
            new_projects, new_topics, new_max_mb, new_workers
        )
        self.assertTrue(result, "設定保存が失敗しました")

        # 保存した設定が反映されていることを確認
        saved_projects = self.manager.get_integration_test_default_project_types()
        saved_topics = self.manager.get_integration_test_default_topics()
        saved_max_mb = self.manager.get_integration_test_default_max_file_mb()
        saved_workers = self.manager.get_integration_test_default_worker_count()

        self.assertEqual(saved_projects, new_projects)
        self.assertEqual(saved_topics, new_topics)
        self.assertEqual(saved_max_mb, new_max_mb)
        self.assertEqual(saved_workers, new_workers)

    def test_08_validation(self):
        """テスト8: 設定バリデーション"""
        is_valid, errors = self.manager.validate_config()

        # デフォルト設定は常に有効であることを確認
        self.assertTrue(is_valid, f"バリデーションエラー: {errors}")
        self.assertEqual(len(errors), 0)

    def test_09_validation_with_invalid_config(self):
        """テスト9: 無効な設定のバリデーション"""
        # 意図的に無効な設定を作成
        self.manager.config = {'version': '1.0.0'}  # 必須セクションが不足

        is_valid, errors = self.manager.validate_config()

        # バリデーションが失敗することを確認
        self.assertFalse(is_valid)
        self.assertGreater(len(errors), 0)

    def test_10_reset_to_defaults(self):
        """テスト10: デフォルト設定へのリセット"""
        # カスタム設定を保存
        self.manager.save_context7_defaults(['custom1', 'custom2'], ['custom-topic'])

        # リセット実行
        result = self.manager.reset_to_defaults()
        self.assertTrue(result, "リセットが失敗しました")

        # デフォルト値に戻っていることを確認
        tech_stacks = self.manager.get_context7_default_tech_stacks()
        self.assertIn('react', tech_stacks)
        self.assertIn('angular', tech_stacks)
        self.assertNotIn('custom1', tech_stacks)

    def test_11_reload_config(self):
        """テスト11: 設定ファイル再読み込み"""
        # 初期値を保存
        original_techs = self.manager.get_context7_default_tech_stacks()

        # 設定を変更して保存
        new_techs = ['express', 'flask']
        self.manager.save_context7_defaults(new_techs, ['security'])

        # 別のマネージャーインスタンスで同じファイルを読み込み
        manager2 = IntegrationTestConfigManager(config_path=self.config_file)

        # 新しい設定が読み込まれていることを確認
        reloaded_techs = manager2.get_context7_default_tech_stacks()
        self.assertEqual(reloaded_techs, new_techs)

        # reload_config()メソッドのテスト
        manager2.save_context7_defaults(['go', 'rust'], ['performance'])
        self.manager.reload_config()

        # 再読み込み後、最新の設定が反映されていることを確認
        final_techs = self.manager.get_context7_default_tech_stacks()
        self.assertEqual(final_techs, ['go', 'rust'])

    def test_12_get_all_available_tech_stacks(self):
        """テスト12: 利用可能な全技術スタック取得"""
        tech_stacks = self.manager.get_all_available_tech_stacks()

        # リストが返されることを確認
        self.assertIsInstance(tech_stacks, list)
        self.assertGreater(len(tech_stacks), 0)

        # 各要素が (id, description) タプルであることを確認
        for tech_id, description in tech_stacks:
            self.assertIsInstance(tech_id, str)
            self.assertIsInstance(description, str)

    def test_13_get_all_available_topics(self):
        """テスト13: 利用可能な全トピック取得"""
        topics = self.manager.get_all_available_topics()

        # リストが返されることを確認
        self.assertIsInstance(topics, list)
        self.assertGreater(len(topics), 0)

        # 各要素が (id, description) タプルであることを確認
        for topic_id, description in topics:
            self.assertIsInstance(topic_id, str)
            self.assertIsInstance(description, str)

    def test_14_singleton_pattern(self):
        """テスト14: シングルトンパターンの確認"""
        # グローバルシングルトンを取得
        manager1 = get_config_manager()
        manager2 = get_config_manager()

        # 同じインスタンスであることを確認
        self.assertIs(manager1, manager2)

    def test_15_database_integration_test_defaults(self):
        """テスト15: データベース統合テストデフォルト設定取得"""
        db_types = self.manager.get_database_integration_test_default_database_types()
        topics = self.manager.get_database_integration_test_default_topics()

        # デフォルト値が正しく取得できることを確認
        self.assertIsInstance(db_types, list)
        self.assertIsInstance(topics, list)

        # デフォルト値が期待通りであることを確認
        self.assertIn('cassandra', db_types)
        self.assertIn('elasticsearch', db_types)
        self.assertIn('performance', topics)


def run_tests():
    """テスト実行"""
    # テストスイート作成
    loader = unittest.TestLoader()
    suite = loader.loadTestsFromTestCase(TestIntegrationTestConfigManager)

    # テスト実行
    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)

    # 結果サマリー
    print("\n" + "=" * 80)
    print("テスト結果サマリー")
    print("=" * 80)
    print(f"実行テスト数: {result.testsRun}")
    print(f"成功: {result.testsRun - len(result.failures) - len(result.errors)}")
    print(f"失敗: {len(result.failures)}")
    print(f"エラー: {len(result.errors)}")
    print("=" * 80)

    # 終了コード
    return 0 if result.wasSuccessful() else 1


if __name__ == '__main__':
    sys.exit(run_tests())
