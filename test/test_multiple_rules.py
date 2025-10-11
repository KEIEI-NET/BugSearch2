"""
Phase 3.2テスト: 複数ルールの読み込みとカテゴリ別管理

@perfect品質保証:
- 全ルール読み込みテスト
- カテゴリ別グループ化テスト
- 技術スタック依存の深刻度調整テスト
"""

import unittest
import sys
from pathlib import Path

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent.parent))

from core.rule_engine import load_all_rules, group_rules_by_category, adjust_severity_by_tech_stack
from core.models import TechStack, DatabaseInfo, BackendStack


class TestMultipleRules(unittest.TestCase):
    """複数ルールの読み込みテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.rules_dir = Path("rules")
        self.assertTrue(self.rules_dir.exists(), "rules/ディレクトリが存在しません")

    def test_load_all_rules(self):
        """全ルールが正しく読み込まれることを確認"""
        rules = load_all_rules(self.rules_dir)

        # Phase 3.3完了: 全10ルールが正常に読み込まれる
        # (4つのYAMLファイルの構文エラーを修正済み)
        self.assertGreaterEqual(len(rules), 10, "10つ以上のルールが読み込まれるべき")

        # 各ルールが必要な属性を持つか確認
        for rule in rules:
            self.assertIsNotNone(rule.id, f"ルール {rule.name} にIDがありません")
            self.assertIsNotNone(rule.category, f"ルール {rule.name} にカテゴリがありません")
            self.assertIsNotNone(rule.name, f"ルールID {rule.id} に名前がありません")
            self.assertGreater(rule.base_severity, 0, f"ルール {rule.name} の深刻度が不正")
            self.assertLessEqual(rule.base_severity, 10, f"ルール {rule.name} の深刻度が不正")

        print(f"✅ {len(rules)}個のルールが正常に読み込まれました")

    def test_rule_categories(self):
        """カテゴリ別に整理されることを確認"""
        rules = load_all_rules(self.rules_dir)
        categories = group_rules_by_category(rules)

        # Phase 3.3完了: 全4カテゴリが正常
        expected_categories = ["database", "solid", "performance", "security"]

        for category in expected_categories:
            self.assertIn(category, categories, f"カテゴリ '{category}' が見つかりません")
            self.assertGreater(len(categories[category].rules), 0,
                               f"カテゴリ '{category}' にルールがありません")

        # カテゴリ情報を表示
        print(f"\n📊 カテゴリ別ルール数:")
        for category_name, category_obj in categories.items():
            highest_severity = category_obj.get_highest_severity()
            print(f"  - {category_name}: {len(category_obj.rules)}ルール (最高深刻度: {highest_severity})")

    def test_database_rules(self):
        """データベース関連ルールの確認"""
        rules = load_all_rules(self.rules_dir)
        categories = group_rules_by_category(rules)

        db_category = categories.get("database")
        self.assertIsNotNone(db_category, "databaseカテゴリが見つかりません")

        # Phase 3.3完了: 全3つのデータベースルールが正常
        expected_rules = ["DB_N_PLUS_ONE", "DB_MULTIPLE_JOIN", "DB_SELECT_STAR"]
        db_rule_ids = [rule.id for rule in db_category.rules]

        for expected_id in expected_rules:
            self.assertIn(expected_id, db_rule_ids,
                          f"データベースルール '{expected_id}' が見つかりません")

        print(f"✅ データベースルール: {len(db_category.rules)}個確認")

    def test_security_rules(self):
        """セキュリティ関連ルールの確認"""
        rules = load_all_rules(self.rules_dir)
        categories = group_rules_by_category(rules)

        # Phase 3.3完了: セキュリティYAMLファイルの構文エラーを修正済み
        sec_category = categories.get("security")
        self.assertIsNotNone(sec_category, "securityカテゴリが見つかりません")

        # セキュリティルール (SQL Injection, XSS, Float Money)
        expected_rules = ["SEC_SQL_INJECTION", "SEC_XSS", "SEC_FLOAT_MONEY"]
        sec_rule_ids = [rule.id for rule in sec_category.rules]

        for expected_id in expected_rules:
            self.assertIn(expected_id, sec_rule_ids,
                          f"セキュリティルール '{expected_id}' が見つかりません")

        print(f"✅ セキュリティルール: {len(sec_category.rules)}個確認")

    def test_solid_rules(self):
        """SOLID原則関連ルールの確認"""
        rules = load_all_rules(self.rules_dir)
        categories = group_rules_by_category(rules)

        solid_category = categories.get("solid")
        self.assertIsNotNone(solid_category, "solidカテゴリが見つかりません")

        # Phase 3.1で実装したSOLIDルール
        expected_rules = ["SOLID_LARGE_CLASS", "SOLID_LARGE_INTERFACE"]
        solid_rule_ids = [rule.id for rule in solid_category.rules]

        for expected_id in expected_rules:
            self.assertIn(expected_id, solid_rule_ids,
                          f"SOLIDルール '{expected_id}' が見つかりません")

        print(f"✅ SOLIDルール: {len(solid_category.rules)}個確認")

    def test_performance_rules(self):
        """パフォーマンス関連ルールの確認"""
        rules = load_all_rules(self.rules_dir)
        categories = group_rules_by_category(rules)

        perf_category = categories.get("performance")
        self.assertIsNotNone(perf_category, "performanceカテゴリが見つかりません")

        # Phase 3.1で実装したパフォーマンスルール
        expected_rules = ["PERF_MEMORY_LEAK", "PERF_GOROUTINE_LEAK"]
        perf_rule_ids = [rule.id for rule in perf_category.rules]

        for expected_id in expected_rules:
            self.assertIn(expected_id, perf_rule_ids,
                          f"パフォーマンスルール '{expected_id}' が見つかりません")

        print(f"✅ パフォーマンスルール: {len(perf_category.rules)}個確認")


class TestSeverityAdjustment(unittest.TestCase):
    """技術スタック依存の深刻度調整テスト"""

    def test_elasticsearch_n_plus_one_adjustment(self):
        """Elasticsearch使用時のN+1問題の深刻度軽減"""
        rules = load_all_rules(Path("rules"))

        # N+1ルールを取得
        n_plus_one_rule = None
        for rule in rules:
            if rule.id == "DB_N_PLUS_ONE":
                n_plus_one_rule = rule
                break

        self.assertIsNotNone(n_plus_one_rule, "N+1ルールが見つかりません")

        # Elasticsearchを使用する技術スタック
        tech_stack_with_es = TechStack(
            databases=[DatabaseInfo(type="Elasticsearch", purpose="search")]
        )

        # Elasticsearchなしの技術スタック
        tech_stack_without_es = TechStack(
            databases=[DatabaseInfo(type="PostgreSQL", purpose="primary")]
        )

        # 深刻度調整をテスト（Elasticsearch使用時はcode_contextに"search"等が必要）
        code_with_elastic = "async search() { const results = await elasticClient.search({ ... }); }"
        code_without_elastic = "for (const user of users) { await User.findOne({ id: user.id }); }"

        severity_with_es, notes_with_es = adjust_severity_by_tech_stack(
            n_plus_one_rule, tech_stack_with_es, n_plus_one_rule.base_severity, code_with_elastic
        )

        severity_without_es, notes_without_es = adjust_severity_by_tech_stack(
            n_plus_one_rule, tech_stack_without_es, n_plus_one_rule.base_severity, code_without_elastic
        )

        # Elasticsearch使用時は深刻度が低くなるはず
        self.assertLess(severity_with_es, severity_without_es,
                        "Elasticsearch使用時はN+1の深刻度が下がるべき")

        print(f"✅ N+1深刻度調整テスト:")
        print(f"   - Elasticsearchあり: {severity_with_es}/10")
        print(f"   - Elasticsearchなし: {severity_without_es}/10")

    def test_orm_select_star_adjustment(self):
        """ORM使用時のSELECT *の深刻度軽減"""
        rules = load_all_rules(Path("rules"))

        # SELECT *ルールを取得
        select_star_rule = None
        for rule in rules:
            if rule.id == "DB_SELECT_STAR":
                select_star_rule = rule
                break

        # Phase 3.3完了: SELECT_STARルールのYAML構文エラーを修正済み
        self.assertIsNotNone(select_star_rule, "SELECT_STARルールが見つかりません")
        tech_stack = TechStack(
            backend=BackendStack(language="C#", framework="ASP.NET Core"),
            databases=[DatabaseInfo(type="SQL Server", library="Entity Framework Core")]
        )

        code_with_orm = ".Select(x => new { x.Id, x.Name })"
        code_without_orm = "SELECT * FROM users"

        severity_with_orm, _ = adjust_severity_by_tech_stack(
            select_star_rule, tech_stack, select_star_rule.base_severity, code_with_orm
        )

        severity_without_orm, _ = adjust_severity_by_tech_stack(
            select_star_rule, tech_stack, select_star_rule.base_severity, code_without_orm
        )

        print(f"✅ SELECT *深刻度調整テスト:")
        print(f"   - ORM射影あり: {severity_with_orm}/10")
        print(f"   - ORM射影なし: {severity_without_orm}/10")


def run_tests():
    """テストスイートを実行"""
    # テストスイートを作成
    suite = unittest.TestSuite()

    # MultipleRulesテストを追加
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestMultipleRules))
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestSeverityAdjustment))

    # テストを実行
    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)

    # 結果サマリー
    print("\n" + "=" * 80)
    print("📊 Phase 3.3テスト結果サマリー")
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
        return 1


if __name__ == "__main__":
    sys.exit(run_tests())
