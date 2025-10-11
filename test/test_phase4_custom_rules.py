"""
Phase 4.0テスト: カスタムルールシステム

@perfect品質保証:
- カスタムルールの読み込み
- ルール優先順位
- ルール無効化
- バリデーション
"""

import unittest
import sys
import shutil
from pathlib import Path

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent.parent))

from core.rule_engine import RuleLoader, RuleValidator


class TestCustomRules(unittest.TestCase):
    """カスタムルール機能のテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_project = Path("test/fixtures/custom-rules-project")
        self.test_project.mkdir(parents=True, exist_ok=True)

        # カスタムルールディレクトリ作成
        self.custom_dir = self.test_project / ".bugsearch" / "rules" / "custom"
        self.custom_dir.mkdir(parents=True, exist_ok=True)

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_project.exists():
            shutil.rmtree(self.test_project)

    def test_load_core_rules_only(self):
        """コアルールのみが読み込まれることを確認"""
        loader = RuleLoader(self.test_project)
        rules = loader.load_all_rules(include_custom=False)

        # コアルール (10個) が含まれる
        self.assertGreaterEqual(len(rules), 10, "10個以上のコアルールが読み込まれるべき")
        print(f"✅ コアルールのみ: {len(rules)}個読み込み")

    def test_load_custom_rules(self):
        """カスタムルールが読み込まれることを確認"""
        # カスタムルール作成
        custom_rule_content = """
rule:
  id: "CUSTOM_TEST_RULE"
  category: "custom"
  name: "Custom Test Rule"
  description: "テスト用カスタムルール"
  base_severity: 7

  patterns:
    csharp:
      - pattern: 'ForbiddenClass\\\\.Method'
        context: "Forbidden class usage"
"""
        custom_rule_file = self.custom_dir / "test-rule.yml"
        with open(custom_rule_file, 'w', encoding='utf-8') as f:
            f.write(custom_rule_content)

        # ルール読み込み
        loader = RuleLoader(self.test_project)
        rules = loader.load_all_rules(include_custom=True)

        # コアルール + カスタムルール
        self.assertGreaterEqual(len(rules), 11, "コアルール + カスタムルールが読み込まれるべき")

        # カスタムルールが含まれるか確認
        custom_rule_ids = [r.id for r in rules]
        self.assertIn("CUSTOM_TEST_RULE", custom_rule_ids, "カスタムルールが読み込まれていません")

        print(f"✅ カスタムルール込み: {len(rules)}個読み込み")

    def test_rule_priority_override(self):
        """カスタムルールがコアルールを上書きすることを確認"""
        # 既存のコアルールと同じIDでカスタムルールを作成
        custom_rule_content = """
rule:
  id: "DB_N_PLUS_ONE"
  category: "custom"
  name: "Custom N+1 Rule (Override)"
  description: "カスタマイズされたN+1検出ルール"
  base_severity: 5

  patterns:
    csharp:
      - pattern: 'CustomPattern'
        context: "Custom context"
"""
        custom_rule_file = self.custom_dir / "n-plus-one-override.yml"
        with open(custom_rule_file, 'w', encoding='utf-8') as f:
            f.write(custom_rule_content)

        # ルール読み込み
        loader = RuleLoader(self.test_project)
        rules = loader.load_all_rules(include_custom=True)

        # DB_N_PLUS_ONEルールを取得
        n_plus_one_rule = None
        for rule in rules:
            if rule.id == "DB_N_PLUS_ONE":
                n_plus_one_rule = rule
                break

        self.assertIsNotNone(n_plus_one_rule, "DB_N_PLUS_ONEルールが見つかりません")

        # カスタムルールの内容で上書きされているか確認
        self.assertEqual(n_plus_one_rule.name, "Custom N+1 Rule (Override)",
                        "カスタムルールで上書きされていません")
        self.assertEqual(n_plus_one_rule.base_severity, 5,
                        "深刻度が上書きされていません")

        print(f"✅ ルール上書き: {n_plus_one_rule.name} (深刻度: {n_plus_one_rule.base_severity})")

    def test_rule_disable(self):
        """ルールの無効化が機能することを確認"""
        loader = RuleLoader(self.test_project)

        # SELECT_STARルールを無効化
        loader.disable_rule("DB_SELECT_STAR")

        # ルール読み込み
        rules = loader.load_all_rules(include_custom=True)
        rule_ids = [r.id for r in rules]

        # SELECT_STARが無効化されていることを確認
        self.assertNotIn("DB_SELECT_STAR", rule_ids,
                        "DB_SELECT_STARが無効化されていません")

        print(f"✅ ルール無効化: DB_SELECT_STARが除外されました")

    def test_rule_enable(self):
        """ルールの有効化が機能することを確認"""
        loader = RuleLoader(self.test_project)

        # 一度無効化
        loader.disable_rule("DB_SELECT_STAR")

        # 再度有効化
        loader.enable_rule("DB_SELECT_STAR")

        # ルール読み込み
        rules = loader.load_all_rules(include_custom=True)
        rule_ids = [r.id for r in rules]

        # SELECT_STARが有効化されていることを確認
        self.assertIn("DB_SELECT_STAR", rule_ids,
                     "DB_SELECT_STARが有効化されていません")

        print(f"✅ ルール有効化: DB_SELECT_STARが有効です")

    def test_category_disable(self):
        """カテゴリ全体の無効化が機能することを確認"""
        # disabled.yml でカテゴリ無効化
        disabled_config_content = """
disabled_rules:
  - category: "performance"
"""
        disabled_file = self.test_project / ".bugsearch" / "rules" / "disabled.yml"
        disabled_file.parent.mkdir(parents=True, exist_ok=True)
        with open(disabled_file, 'w', encoding='utf-8') as f:
            f.write(disabled_config_content)

        # ルール読み込み
        loader = RuleLoader(self.test_project)
        rules = loader.load_all_rules(include_custom=True)

        # パフォーマンスカテゴリのルールが無効化されているか確認
        perf_rules = [r for r in rules if r.category == "performance"]
        self.assertEqual(len(perf_rules), 0,
                        "パフォーマンスカテゴリが無効化されていません")

        print(f"✅ カテゴリ無効化: performanceカテゴリ全体が除外されました")


class TestRuleValidation(unittest.TestCase):
    """ルールバリデーションのテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path("test/fixtures/validation-test")
        self.test_dir.mkdir(parents=True, exist_ok=True)
        self.validator = RuleValidator()

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_valid_rule(self):
        """正常なルールがバリデーションを通過することを確認"""
        valid_rule_content = """
rule:
  id: "CUSTOM_VALID_RULE"
  category: "custom"
  name: "Valid Rule"
  description: "正常なルール"
  base_severity: 7

  patterns:
    csharp:
      - pattern: 'ValidPattern'
        context: "Valid context"
"""
        rule_file = self.test_dir / "valid-rule.yml"
        with open(rule_file, 'w', encoding='utf-8') as f:
            f.write(valid_rule_content)

        # バリデーション実行
        errors = self.validator.validate_rule(rule_file)

        # エラーがないことを確認
        self.assertEqual(len(errors), 0, f"バリデーションエラー: {errors}")
        print(f"✅ バリデーション: 正常なルールが通過しました")

    def test_missing_required_fields(self):
        """必須フィールドが欠けているルールがエラーになることを確認"""
        invalid_rule_content = """
rule:
  id: "CUSTOM_INVALID_RULE"
  category: "custom"
  name: "Invalid Rule"
  # description と base_severity が欠けている
"""
        rule_file = self.test_dir / "invalid-rule.yml"
        with open(rule_file, 'w', encoding='utf-8') as f:
            f.write(invalid_rule_content)

        # バリデーション実行
        errors = self.validator.validate_rule(rule_file)

        # エラーがあることを確認
        self.assertGreater(len(errors), 0, "必須フィールド欠落がエラーになっていません")
        self.assertTrue(any('description' in e for e in errors),
                       "descriptionフィールドのエラーが検出されていません")

        print(f"✅ バリデーション: 必須フィールド欠落を検出しました ({len(errors)}件のエラー)")

    def test_invalid_id_format(self):
        """不正なIDフォーマットがエラーになることを確認"""
        invalid_rule_content = """
rule:
  id: "custom_lowercase_id"
  category: "custom"
  name: "Invalid ID Format"
  description: "小文字IDのテスト"
  base_severity: 7

  patterns:
    csharp:
      - pattern: 'Pattern'
        context: "Context"
"""
        rule_file = self.test_dir / "invalid-id.yml"
        with open(rule_file, 'w', encoding='utf-8') as f:
            f.write(invalid_rule_content)

        # バリデーション実行
        errors = self.validator.validate_rule(rule_file)

        # IDフォーマットエラーが検出されることを確認
        self.assertGreater(len(errors), 0, "不正なIDフォーマットがエラーになっていません")
        self.assertTrue(any('大文字' in e for e in errors),
                       "IDフォーマットエラーが検出されていません")

        print(f"✅ バリデーション: 不正なIDフォーマットを検出しました")

    def test_invalid_severity(self):
        """不正な深刻度がエラーになることを確認"""
        invalid_rule_content = """
rule:
  id: "CUSTOM_INVALID_SEVERITY"
  category: "custom"
  name: "Invalid Severity"
  description: "不正な深刻度のテスト"
  base_severity: 15

  patterns:
    csharp:
      - pattern: 'Pattern'
        context: "Context"
"""
        rule_file = self.test_dir / "invalid-severity.yml"
        with open(rule_file, 'w', encoding='utf-8') as f:
            f.write(invalid_rule_content)

        # バリデーション実行
        errors = self.validator.validate_rule(rule_file)

        # 深刻度エラーが検出されることを確認
        self.assertGreater(len(errors), 0, "不正な深刻度がエラーになっていません")
        self.assertTrue(any('1-10' in e for e in errors),
                       "深刻度範囲エラーが検出されていません")

        print(f"✅ バリデーション: 不正な深刻度を検出しました")

    def test_invalid_regex_pattern(self):
        """不正な正規表現がエラーになることを確認"""
        invalid_rule_content = """
rule:
  id: "CUSTOM_INVALID_REGEX"
  category: "custom"
  name: "Invalid Regex"
  description: "不正な正規表現のテスト"
  base_severity: 7

  patterns:
    csharp:
      - pattern: '([unclosed group'
        context: "Invalid regex pattern"
"""
        rule_file = self.test_dir / "invalid-regex.yml"
        with open(rule_file, 'w', encoding='utf-8') as f:
            f.write(invalid_rule_content)

        # バリデーション実行
        errors = self.validator.validate_rule(rule_file)

        # 正規表現エラーが検出されることを確認
        self.assertGreater(len(errors), 0, "不正な正規表現がエラーになっていません")
        self.assertTrue(any('正規表現' in e for e in errors),
                       "正規表現エラーが検出されていません")

        print(f"✅ バリデーション: 不正な正規表現を検出しました")


def run_tests():
    """テストスイートを実行"""
    # テストスイートを作成
    suite = unittest.TestSuite()

    # カスタムルールテストを追加
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestCustomRules))
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestRuleValidation))

    # テストを実行
    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)

    # 結果サマリー
    print("\n" + "=" * 80)
    print("📊 Phase 4.0テスト結果サマリー")
    print("=" * 80)
    print(f"実行したテスト: {result.testsRun}")
    print(f"成功: {result.testsRun - len(result.failures) - len(result.errors)}")
    print(f"失敗: {len(result.failures)}")
    print(f"エラー: {len(result.errors)}")

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
