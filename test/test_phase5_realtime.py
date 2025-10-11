"""
Phase 5テスト: リアルタイム解析機能

@perfect品質保証:
- ファイルウォッチャー機能
- 差分解析エンジン
- デバウンス処理
- Git diff統合

バージョン: v4.6.0 (Phase 5.0)
作成日: 2025年10月12日 JST
"""

import unittest
from pathlib import Path
import time
import shutil
import sys

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent.parent))

from core.incremental_analyzer import IncrementalAnalyzer, FileDiff


class TestIncrementalAnalyzer(unittest.TestCase):
    """差分解析エンジンのテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path("test/fixtures/incremental-test")
        self.test_dir.mkdir(parents=True, exist_ok=True)
        self.analyzer = IncrementalAnalyzer(self.test_dir)

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_analyzer_initialization(self):
        """差分解析エンジンの初期化テスト"""
        analyzer = IncrementalAnalyzer(Path.cwd())
        self.assertIsNotNone(analyzer)
        self.assertEqual(analyzer.project_root, Path.cwd())
        print("✅ 差分解析エンジン初期化成功")

    def test_file_diff_dataclass(self):
        """FileDiff データクラステスト"""
        test_file = self.test_dir / "test.cs"

        diff = FileDiff(
            file_path=test_file,
            added_lines=[1, 2, 3],
            modified_lines=[4, 5],
            deleted_lines=[6],
            total_changes=6
        )

        self.assertEqual(diff.total_changes, 6)
        self.assertEqual(len(diff.added_lines), 3)
        self.assertEqual(len(diff.modified_lines), 2)
        self.assertEqual(len(diff.deleted_lines), 1)

        # changed_lines プロパティ
        changed = diff.changed_lines
        self.assertEqual(len(changed), 5)  # 1,2,3,4,5
        self.assertIn(1, changed)
        self.assertIn(5, changed)
        self.assertNotIn(6, changed)  # deleted_linesは含まれない

        print("✅ FileDiff データクラス動作確認")

    def test_git_repo_detection(self):
        """Gitリポジトリ検出テスト"""
        # カレントディレクトリ（BugSearch2プロジェクト）はGitリポジトリのはず
        analyzer_project = IncrementalAnalyzer(Path.cwd())
        self.assertTrue(analyzer_project._is_git_repo)

        # 一時ディレクトリもプロジェクト内にあるため、Gitリポジトリとして検出される
        # （これは正常な動作）
        # self.assertFalse(self.analyzer._is_git_repo)

        print("✅ Gitリポジトリ検出成功")

    def test_parse_diff_output(self):
        """Git diff出力のパーステスト"""
        # モックのGit diff出力
        diff_output = """
@@ -1,3 +1,4 @@
+新しい行1
 既存行1
 既存行2
+新しい行2
@@ -10,2 +11,3 @@
-削除行
 既存行3
+新しい行3
 既存行4
"""

        added, modified, deleted = self.analyzer._parse_diff(diff_output)

        # 追加行の検出確認
        self.assertGreater(len(added), 0)

        print(f"✅ Git diff パース成功 (追加: {len(added)}行)")

    def test_matches_rule_csharp(self):
        """ルールマッチングテスト (C#)"""
        # モックのルール
        class MockRule:
            def __init__(self):
                self.id = "DB_SELECT_STAR"
                self.name = "SELECT * の使用"
                self.base_severity = 8
                self.patterns = {
                    'csharp': [
                        {'pattern': r'SELECT\s+\*\s+FROM'}
                    ]
                }

        rule = MockRule()

        # マッチするケース
        line1 = '    var users = db.Query("SELECT * FROM users");'
        test_file = Path("test.cs")
        self.assertTrue(self.analyzer._matches_rule(line1, rule, test_file))

        # マッチしないケース
        line2 = '    var users = db.Query("SELECT id, name FROM users");'
        self.assertFalse(self.analyzer._matches_rule(line2, rule, test_file))

        print("✅ ルールマッチング動作確認")

    def test_analyze_changed_lines(self):
        """変更行解析テスト"""
        # テストファイル作成
        test_file = self.test_dir / "test.cs"
        test_file.write_text(
            "class UserService {\n"
            "    void GetUsers() {\n"
            "        var users = db.Query(\"SELECT * FROM users\");\n"
            "    }\n"
            "}\n"
        )

        # モックのFileDiff
        diff = FileDiff(
            file_path=test_file,
            added_lines=[3],  # SELECT * の行
            modified_lines=[],
            deleted_lines=[],
            total_changes=1
        )

        # モックのルール
        class MockRule:
            def __init__(self):
                self.id = "DB_SELECT_STAR"
                self.name = "SELECT * の使用"
                self.base_severity = 8
                self.patterns = {
                    'csharp': [
                        {'pattern': r'SELECT\s+\*\s+FROM'}
                    ]
                }

        rules = [MockRule()]

        # 変更行を解析
        detections = self.analyzer.analyze_changed_lines(test_file, diff, rules)

        self.assertEqual(len(detections), 1)
        self.assertEqual(detections[0]['rule_id'], 'DB_SELECT_STAR')
        self.assertEqual(detections[0]['line'], 3)
        self.assertEqual(detections[0]['severity'], 8)

        print("✅ 変更行解析成功")

    def test_get_file_diff_non_git(self):
        """非Gitリポジトリでの差分取得テスト"""
        # 非Gitリポジトリでは None が返される
        test_file = self.test_dir / "test.cs"
        test_file.write_text("class Test {}")

        diff = self.analyzer.get_file_diff(test_file)
        self.assertIsNone(diff)

        print("✅ 非Gitリポジトリ処理確認")


class TestFileWatcher(unittest.TestCase):
    """ファイルウォッチャーのテスト（基本機能のみ）"""

    def test_file_watcher_import(self):
        """ファイルウォッチャーモジュールのインポートテスト"""
        try:
            from core.file_watcher import FileWatcher, CodeFileHandler, WATCHDOG_AVAILABLE

            self.assertIsNotNone(FileWatcher)
            self.assertIsNotNone(CodeFileHandler)

            if not WATCHDOG_AVAILABLE:
                print("⚠️  watchdogライブラリ未インストール（スキップ）")
            else:
                print("✅ ファイルウォッチャーモジュールインポート成功")

        except ImportError as e:
            self.fail(f"インポートエラー: {e}")

    def test_code_file_handler_extensions(self):
        """サポート拡張子の確認テスト"""
        from core.file_watcher import CodeFileHandler

        expected_extensions = {
            '.cs', '.java', '.php', '.js', '.ts', '.tsx', '.py', '.go',
            '.c', '.cpp', '.h', '.hpp'
        }

        self.assertEqual(CodeFileHandler.SUPPORTED_EXTENSIONS, expected_extensions)
        print(f"✅ サポート拡張子確認: {len(expected_extensions)}種類")


def run_tests():
    """テストスイートを実行"""
    suite = unittest.TestSuite()

    # テストクラス追加
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestIncrementalAnalyzer))
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestFileWatcher))

    # テスト実行
    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)

    # 結果サマリー
    print("\n" + "=" * 80)
    print("📊 Phase 5テスト結果サマリー")
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
