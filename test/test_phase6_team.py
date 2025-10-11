"""
Phase 6テスト: チーム機能

@perfect品質保証:
- レポート比較機能
- 進捗トラッキング
- ダッシュボードAPI

バージョン: v4.7.0 (Phase 6.0)
作成日: 2025年10月12日 JST
"""

import unittest
from pathlib import Path
import json
import shutil
import sys
from datetime import datetime, timedelta
import tempfile

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent.parent))

from core.report_comparator import ReportComparator, ReportDiff
from core.progress_tracker import ProgressTracker


class TestReportComparator(unittest.TestCase):
    """レポート比較機能のテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path(tempfile.mkdtemp())
        self.comparator = ReportComparator()

        # テスト用レポート作成
        self.old_report = self.test_dir / "old_report.json"
        self.new_report = self.test_dir / "new_report.json"

        self.old_data = {
            'timestamp': '2025-01-01T00:00:00',
            'issues': [
                {'file': 'src/test.py', 'line': 10, 'rule_id': 'TEST_1', 'severity': 5, 'message': 'Issue 1'},
                {'file': 'src/test.py', 'line': 20, 'rule_id': 'TEST_2', 'severity': 8, 'message': 'Issue 2'},
                {'file': 'src/test.py', 'line': 30, 'rule_id': 'TEST_3', 'severity': 3, 'message': 'Issue 3'},
            ]
        }

        self.new_data = {
            'timestamp': '2025-01-15T00:00:00',
            'issues': [
                {'file': 'src/test.py', 'line': 20, 'rule_id': 'TEST_2', 'severity': 9, 'message': 'Issue 2 (worse)'},
                {'file': 'src/test.py', 'line': 30, 'rule_id': 'TEST_3', 'severity': 3, 'message': 'Issue 3'},
                {'file': 'src/test.py', 'line': 40, 'rule_id': 'TEST_4', 'severity': 7, 'message': 'Issue 4 (new)'},
            ]
        }

        with open(self.old_report, 'w', encoding='utf-8') as f:
            json.dump(self.old_data, f, indent=2, ensure_ascii=False)

        with open(self.new_report, 'w', encoding='utf-8') as f:
            json.dump(self.new_data, f, indent=2, ensure_ascii=False)

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_report_comparison(self):
        """レポート比較テスト"""
        diff = self.comparator.compare_reports(self.old_report, self.new_report)

        self.assertIsInstance(diff, ReportDiff)
        self.assertEqual(len(diff.new_issues), 1)  # TEST_4が新規
        self.assertEqual(len(diff.fixed_issues), 1)  # TEST_1が修正
        self.assertEqual(len(diff.unchanged_issues), 2)  # TEST_2とTEST_3は残存
        self.assertEqual(len(diff.worsened_issues), 1)  # TEST_2が悪化（8→9）

        print("✅ レポート比較テスト成功")

    def test_improvement_rate(self):
        """改善率計算テスト"""
        diff = self.comparator.compare_reports(self.old_report, self.new_report)

        # 新規1件、修正1件 → 改善率50%
        self.assertAlmostEqual(diff.improvement_rate, 0.5, places=2)
        print("✅ 改善率計算テスト成功")

    def test_issue_key_generation(self):
        """問題キー生成テスト"""
        issue = {'file': 'test.py', 'line': 10, 'rule_id': 'TEST'}
        key = self.comparator._issue_key(issue)

        self.assertEqual(key, 'test.py:10:TEST')
        print("✅ 問題キー生成テスト成功")

    def test_report_not_found(self):
        """レポート未検出エラーテスト"""
        with self.assertRaises(FileNotFoundError):
            self.comparator.compare_reports(
                Path("nonexistent1.json"),
                self.new_report
            )

        print("✅ レポート未検出エラーテスト成功")

    def test_comparison_report_generation(self):
        """比較レポート生成テスト"""
        output_file = self.test_dir / "comparison_report.md"
        report = self.comparator.generate_comparison_report(
            self.old_report,
            self.new_report,
            output_file
        )

        self.assertTrue(output_file.exists())
        self.assertIn("レポート比較分析", report)
        self.assertIn("新規問題", report)
        self.assertIn("修正済み問題", report)

        print("✅ 比較レポート生成テスト成功")


class TestProgressTracker(unittest.TestCase):
    """進捗トラッキングのテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_file = Path(tempfile.mktemp(suffix='.json'))
        self.tracker = ProgressTracker(self.test_file)

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_file.exists():
            self.test_file.unlink()

    def test_snapshot_recording(self):
        """スナップショット記録テスト"""
        issues = [
            {'file': 'test.py', 'line': 10, 'severity': 8, 'category': 'security'},
            {'file': 'test.py', 'line': 20, 'severity': 5, 'category': 'performance'},
        ]

        self.tracker.record_snapshot(issues, datetime.now())

        self.assertEqual(len(self.tracker.snapshots), 1)
        self.assertEqual(self.tracker.snapshots[0]['total_issues'], 2)
        print("✅ スナップショット記録テスト成功")

    def test_progress_report_generation(self):
        """進捗レポート生成テスト"""
        # 3つのスナップショットを記録
        base_time = datetime(2025, 1, 1, 0, 0, 0)

        self.tracker.record_snapshot(
            [
                {'file': 'test1.py', 'line': 10, 'severity': 8, 'category': 'security'},
                {'file': 'test1.py', 'line': 20, 'severity': 5, 'category': 'performance'},
                {'file': 'test2.py', 'line': 30, 'severity': 3, 'category': 'style'},
            ],
            base_time
        )

        self.tracker.record_snapshot(
            [
                {'file': 'test1.py', 'line': 10, 'severity': 8, 'category': 'security'},
                {'file': 'test2.py', 'line': 30, 'severity': 3, 'category': 'style'},
            ],
            base_time + timedelta(days=7)
        )

        self.tracker.record_snapshot(
            [
                {'file': 'test2.py', 'line': 30, 'severity': 3, 'category': 'style'},
            ],
            base_time + timedelta(days=14)
        )

        # レポート生成
        report = self.tracker.generate_progress_report()

        self.assertNotIn('error', report)
        self.assertEqual(report['total_issues']['start'], 3)
        self.assertEqual(report['total_issues']['end'], 1)
        self.assertEqual(report['total_issues']['change'], -2)
        self.assertEqual(report['trend'], 'improving')

        print("✅ 進捗レポート生成テスト成功")

    def test_insufficient_snapshots(self):
        """スナップショット不足エラーテスト"""
        # スナップショット1つのみ
        self.tracker.record_snapshot(
            [{'file': 'test.py', 'line': 10, 'severity': 5, 'category': 'test'}],
            datetime.now()
        )

        report = self.tracker.generate_progress_report()

        self.assertIn('error', report)
        self.assertIn('スナップショットが不足', report['error'])

        print("✅ スナップショット不足エラーテスト成功")

    def test_severity_grouping(self):
        """深刻度別グループ化テスト"""
        issues = [
            {'severity': 8},
            {'severity': 8},
            {'severity': 5},
            {'severity': 3},
        ]

        grouped = self.tracker._group_by_severity(issues)

        self.assertEqual(grouped[8], 2)
        self.assertEqual(grouped[5], 1)
        self.assertEqual(grouped[3], 1)

        print("✅ 深刻度別グループ化テスト成功")

    def test_category_grouping(self):
        """カテゴリ別グループ化テスト"""
        issues = [
            {'category': 'security'},
            {'category': 'security'},
            {'category': 'performance'},
        ]

        grouped = self.tracker._group_by_category(issues)

        self.assertEqual(grouped['security'], 2)
        self.assertEqual(grouped['performance'], 1)

        print("✅ カテゴリ別グループ化テスト成功")

    def test_trend_calculation(self):
        """トレンド計算テスト"""
        # 改善トレンド（減少傾向）
        improving_snapshots = [
            {'total_issues': 10},
            {'total_issues': 8},
            {'total_issues': 6},
            {'total_issues': 4},
        ]

        trend = self.tracker._calculate_trend(improving_snapshots)
        self.assertEqual(trend, 'improving')

        # 悪化トレンド（増加傾向）
        worsening_snapshots = [
            {'total_issues': 4},
            {'total_issues': 6},
            {'total_issues': 8},
            {'total_issues': 10},
        ]

        trend = self.tracker._calculate_trend(worsening_snapshots)
        self.assertEqual(trend, 'worsening')

        print("✅ トレンド計算テスト成功")

    def test_export_progress_report(self):
        """進捗レポート出力テスト"""
        # スナップショット記録
        base_time = datetime(2025, 1, 1, 0, 0, 0)

        self.tracker.record_snapshot(
            [{'file': 'test.py', 'line': 10, 'severity': 8, 'category': 'security'}],
            base_time
        )

        self.tracker.record_snapshot(
            [],
            base_time + timedelta(days=7)
        )

        # レポート出力
        output_file = self.test_file.parent / "progress_report.md"
        self.tracker.export_progress_report(output_file)

        self.assertTrue(output_file.exists())
        content = output_file.read_text(encoding='utf-8')
        self.assertIn("進捗トラッキングレポート", content)

        # クリーンアップ
        output_file.unlink()

        print("✅ 進捗レポート出力テスト成功")


class TestDashboardAPI(unittest.TestCase):
    """ダッシュボードAPIのテスト（基本機能のみ）"""

    def test_dashboard_import(self):
        """ダッシュボードモジュールのインポートテスト"""
        try:
            from dashboard.team_dashboard import app

            self.assertIsNotNone(app)
            self.assertEqual(app.config.get('JSON_AS_ASCII'), False)

            print("✅ ダッシュボードモジュールインポート成功")

        except ImportError as e:
            # Flask未インストールの場合はスキップ
            if 'flask' in str(e).lower():
                print("⚠️ Flask未インストール（スキップ）")
                print("   インストール: pip install flask")
                self.skipTest("Flask未インストール")
            else:
                self.fail(f"インポートエラー: {e}")

    def test_dashboard_routes_exist(self):
        """ダッシュボードルート存在確認テスト"""
        try:
            from dashboard.team_dashboard import app
        except ImportError as e:
            # Flask未インストールの場合はスキップ
            if 'flask' in str(e).lower():
                print("⚠️ Flask未インストール（スキップ）")
                self.skipTest("Flask未インストール")
                return
            else:
                raise

        # ルール一覧を取得
        rules = [rule.rule for rule in app.url_map.iter_rules()]

        expected_routes = [
            '/',
            '/api/stats',
            '/api/progress',
            '/api/compare',
            '/api/reports',
            '/health'
        ]

        for route in expected_routes:
            self.assertIn(route, rules, f"ルート {route} が見つかりません")

        print(f"✅ ダッシュボードルート確認成功 ({len(expected_routes)}個)")


def run_tests():
    """テストスイートを実行"""
    suite = unittest.TestSuite()

    # テストクラス追加
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestReportComparator))
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestProgressTracker))
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestDashboardAPI))

    # テスト実行
    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)

    # 結果サマリー
    print("\n" + "=" * 80)
    print("📊 Phase 6テスト結果サマリー")
    print("=" * 80)
    print(f"実行したテスト: {result.testsRun}")
    print(f"成功: {result.testsRun - len(result.failures) - len(result.errors)}")
    print(f"失敗: {len(result.failures)}")
    print(f"エラー: {len(result.errors)}")
    print(f"スキップ: {len(result.skipped)}")

    if result.wasSuccessful():
        try:
            print("\n✅ 全てのテストが合格しました！ (@perfect品質達成)")
        except UnicodeEncodeError:
            print("\n[OK] 全てのテストが合格しました！ (@perfect品質達成)")
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
