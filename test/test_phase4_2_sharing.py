"""
Phase 4.2テスト: ルール共有機能

@perfect品質保証:
- ルールエクスポート (YAML/JSON)
- ルールインポート
- パッケージ作成・インストール
- メトリクス収集
- AI支援生成（モック）

バージョン: v4.5.0 (Phase 4.2)
作成日: 2025年10月12日 JST
"""

import unittest
from pathlib import Path
import shutil
import json
import yaml
import sys

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent.parent))

from core.rule_sharing import RuleExporter, RuleImporter, CommunityRuleRepository
from core.rule_metrics import RuleMetricsCollector, RuleMetric
from core.ai_rule_generator import AIRuleGenerator


class TestRuleSharing(unittest.TestCase):
    """ルール共有機能のテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path("test/fixtures/sharing-test")
        self.test_dir.mkdir(parents=True, exist_ok=True)

        # テストルール作成
        self.test_rule_file = self.test_dir / "test-rule.yml"
        rule_content = """rule:
  id: "TEST_EXPORT"
  category: "custom"
  name: "Test Export Rule"
  description: "Test rule for export functionality"
  base_severity: 7

  patterns:
    csharp:
      - pattern: 'TestPattern'
        context: "Test context"

  fixes:
    csharp:
      - "Fix suggestion 1"
      - "Fix suggestion 2"
"""
        with open(self.test_rule_file, 'w', encoding='utf-8') as f:
            f.write(rule_content)

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_export_yaml(self):
        """YAMLエクスポートテスト"""
        exporter = RuleExporter()
        result = exporter.export_rule(self.test_rule_file, output_format='yaml')

        self.assertIn('TEST_EXPORT', result)
        self.assertIn('Test Export Rule', result)
        self.assertIn('metadata', result)  # メタデータが含まれる
        print("✅ YAMLエクスポート成功")

    def test_export_json(self):
        """JSONエクスポートテスト"""
        exporter = RuleExporter()
        result = exporter.export_rule(self.test_rule_file, output_format='json')

        data = json.loads(result)
        self.assertEqual(data['rule']['id'], 'TEST_EXPORT')
        self.assertIn('metadata', data)
        print("✅ JSONエクスポート成功")

    def test_export_without_metadata(self):
        """メタデータなしエクスポートテスト"""
        exporter = RuleExporter()
        result = exporter.export_rule(
            self.test_rule_file,
            output_format='yaml',
            include_metadata=False
        )

        self.assertNotIn('metadata', result)
        print("✅ メタデータなしエクスポート成功")

    def test_import_rule_yaml(self):
        """YAMLルールインポートテスト"""
        # まずエクスポート
        exporter = RuleExporter()
        exported = exporter.export_rule(self.test_rule_file, output_format='yaml')

        # インポート
        importer = RuleImporter()
        output_dir = self.test_dir / "imported"
        imported_file = importer.import_rule(exported, output_dir, validate=False)

        self.assertIsNotNone(imported_file)
        self.assertTrue(imported_file.exists())

        # ファイル内容確認
        with open(imported_file, 'r', encoding='utf-8') as f:
            data = yaml.safe_load(f)
            self.assertEqual(data['rule']['id'], 'TEST_EXPORT')

        print(f"✅ YAMLインポート成功: {imported_file}")

    def test_import_rule_json(self):
        """JSONルールインポートテスト"""
        # まずエクスポート
        exporter = RuleExporter()
        exported = exporter.export_rule(self.test_rule_file, output_format='json')

        # インポート
        importer = RuleImporter()
        output_dir = self.test_dir / "imported-json"
        imported_file = importer.import_rule(exported, output_dir, validate=False)

        self.assertIsNotNone(imported_file)
        self.assertTrue(imported_file.exists())
        print(f"✅ JSONインポート成功: {imported_file}")

    def test_package_creation(self):
        """パッケージ作成テスト"""
        # 複数のテストルール作成
        rule_files = [self.test_rule_file]

        exporter = RuleExporter()
        package_file = exporter.export_rule_package(
            rule_files,
            "test-package",
            self.test_dir,
            package_version="1.0.0"
        )

        self.assertTrue(package_file.exists())

        # パッケージ内容確認
        with open(package_file, 'r', encoding='utf-8') as f:
            data = json.load(f)
            self.assertEqual(data['package']['name'], 'test-package')
            self.assertEqual(data['package']['version'], '1.0.0')
            self.assertEqual(len(data['package']['rules']), 1)
            self.assertEqual(data['package']['rule_count'], 1)

        print("✅ パッケージ作成成功")

    def test_package_installation(self):
        """パッケージインストールテスト"""
        # まずパッケージ作成
        exporter = RuleExporter()
        package_file = exporter.export_rule_package(
            [self.test_rule_file],
            "test-package",
            self.test_dir
        )

        # パッケージインストール
        importer = RuleImporter()
        output_dir = self.test_dir / "installed"
        imported_files = importer.import_rule_package(
            package_file,
            output_dir,
            validate=False
        )

        self.assertEqual(len(imported_files), 1)
        self.assertTrue(imported_files[0].exists())
        print("✅ パッケージインストール成功")


class TestRuleMetrics(unittest.TestCase):
    """ルールメトリクステスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path("test/fixtures/metrics-test")
        self.test_dir.mkdir(parents=True, exist_ok=True)
        self.metrics_file = self.test_dir / "metrics.json"

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_metrics_collection(self):
        """メトリクス収集テスト"""
        collector = RuleMetricsCollector(self.metrics_file)

        # 検出を記録
        collector.record_detection("TEST_RULE", "test.cs", 10.5)
        collector.record_detection("TEST_RULE", "test2.cs", 12.3)
        collector.record_detection("TEST_RULE", "test.cs", 11.0)  # 重複ファイル

        # メトリクス確認
        metric = collector.get_metrics("TEST_RULE")
        self.assertIsNotNone(metric)
        self.assertEqual(metric.total_detections, 3)
        self.assertEqual(len(metric.unique_files), 2)  # 2つのファイル
        self.assertGreater(metric.execution_time_ms, 0)

        print("✅ メトリクス収集成功")

    def test_false_positive_tracking(self):
        """誤検知追跡テスト"""
        collector = RuleMetricsCollector(self.metrics_file)

        # 検出と誤検知を記録
        collector.record_detection("TEST_RULE", "test.cs", 10.0)
        collector.record_detection("TEST_RULE", "test2.cs", 10.0)
        collector.record_false_positive("TEST_RULE")

        # 誤検知率確認
        fp_rate = collector.get_false_positive_rate("TEST_RULE")
        self.assertAlmostEqual(fp_rate, 0.5, places=2)

        print("✅ 誤検知追跡成功")

    def test_average_execution_time(self):
        """平均実行時間テスト"""
        collector = RuleMetricsCollector(self.metrics_file)

        # 検出を記録
        collector.record_detection("TEST_RULE", "test1.cs", 10.0)
        collector.record_detection("TEST_RULE", "test2.cs", 20.0)
        collector.record_detection("TEST_RULE", "test3.cs", 15.0)

        # 平均実行時間確認
        avg_time = collector.get_average_execution_time("TEST_RULE")
        self.assertAlmostEqual(avg_time, 15.0, places=1)

        print("✅ 平均実行時間計算成功")

    def test_top_rules_by_detections(self):
        """検出数トップルールテスト"""
        collector = RuleMetricsCollector(self.metrics_file)

        # 複数ルールの検出を記録
        collector.record_detection("RULE_A", "test.cs", 10.0)
        collector.record_detection("RULE_A", "test2.cs", 10.0)
        collector.record_detection("RULE_A", "test3.cs", 10.0)

        collector.record_detection("RULE_B", "test.cs", 10.0)
        collector.record_detection("RULE_B", "test2.cs", 10.0)

        collector.record_detection("RULE_C", "test.cs", 10.0)

        # Top 2を取得
        top_rules = collector.get_top_rules_by_detections(limit=2)

        self.assertEqual(len(top_rules), 2)
        self.assertEqual(top_rules[0].rule_id, "RULE_A")
        self.assertEqual(top_rules[0].total_detections, 3)
        self.assertEqual(top_rules[1].rule_id, "RULE_B")

        print("✅ Top検出数ルール取得成功")

    def test_metrics_persistence(self):
        """メトリクス永続化テスト"""
        # 最初のコレクター
        collector1 = RuleMetricsCollector(self.metrics_file)
        collector1.record_detection("TEST_RULE", "test.cs", 10.0)

        # 2つ目のコレクター（ファイルから読み込み）
        collector2 = RuleMetricsCollector(self.metrics_file)
        metric = collector2.get_metrics("TEST_RULE")

        self.assertIsNotNone(metric)
        self.assertEqual(metric.total_detections, 1)

        print("✅ メトリクス永続化成功")

    def test_metrics_report_generation(self):
        """メトリクスレポート生成テスト"""
        collector = RuleMetricsCollector(self.metrics_file)

        # データを記録
        collector.record_detection("RULE_A", "test.cs", 10.0)
        collector.record_detection("RULE_B", "test2.cs", 15.0)
        collector.record_false_positive("RULE_A")

        # レポート生成
        report = collector.generate_report(detailed=True)

        self.assertIn("ルールメトリクスレポート", report)
        self.assertIn("RULE_A", report)
        self.assertIn("RULE_B", report)
        self.assertIn("Top 5", report)

        print("✅ レポート生成成功")

    def test_metrics_reset(self):
        """メトリクスリセットテスト"""
        collector = RuleMetricsCollector(self.metrics_file)

        # データを記録
        collector.record_detection("TEST_RULE", "test.cs", 10.0)

        # 特定ルールをリセット
        collector.reset_metrics("TEST_RULE")
        metric = collector.get_metrics("TEST_RULE")

        self.assertIsNone(metric)

        print("✅ メトリクスリセット成功")


class TestAIRuleGenerator(unittest.TestCase):
    """AI支援ルール生成テスト（モック）"""

    def setUp(self):
        """テストセットアップ"""
        self.generator = AIRuleGenerator()

    def test_yaml_extraction(self):
        """YAML抽出テスト"""
        response = """
以下がルールです:

```yaml
rule:
  id: "TEST_RULE"
  category: "custom"
  name: "Test Rule"
  description: "Test"
  base_severity: 5
  patterns:
    csharp:
      - pattern: 'test'
        context: "test"
```

このルールは...
"""

        extracted = self.generator._extract_yaml(response)

        self.assertIsNotNone(extracted)
        self.assertIn("TEST_RULE", extracted)

        # YAMLとして妥当か確認
        data = yaml.safe_load(extracted)
        self.assertEqual(data['rule']['id'], 'TEST_RULE')

        print("✅ YAML抽出成功")

    def test_yaml_extraction_without_markers(self):
        """マーカーなしYAML抽出テスト"""
        response = """rule:
  id: "TEST_RULE"
  category: "custom"
  name: "Test"
  description: "Test"
  base_severity: 5
  patterns:
    csharp:
      - pattern: 'test'
        context: "test"
"""

        extracted = self.generator._extract_yaml(response)

        self.assertIsNotNone(extracted)
        self.assertIn("TEST_RULE", extracted)

        print("✅ マーカーなしYAML抽出成功")


def run_tests():
    """テストスイートを実行"""
    suite = unittest.TestSuite()

    # テストクラス追加
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestRuleSharing))
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestRuleMetrics))
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestAIRuleGenerator))

    # テスト実行
    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)

    # 結果サマリー
    print("\n" + "=" * 80)
    print("📊 Phase 4.2テスト結果サマリー")
    print("=" * 80)
    print(f"実行したテスト: {result.testsRun}")
    print(f"成功: {result.testsRun - len(result.failures) - len(result.errors)}")
    print(f"失敗: {len(result.failures)}")
    print(f"エラー: {len(result.errors)}")
    print(f"スキップ: {len(result.skipped)}")

    if result.wasSuccessful():
        print("\n✅ 全てのテストが合格しました！ (@perfect品質達成)")
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
