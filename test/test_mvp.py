"""
MVP機能のテスト

Phase 1で実装した基本機能のテスト
"""

import sys
from pathlib import Path

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent.parent))

from core import load_project_config, RuleEngine


def test_project_config_loading():
    """プロジェクト設定の読み込みテスト"""
    print("=" * 80)
    print("テスト1: プロジェクト設定の読み込み")
    print("=" * 80)

    # テスト用設定ファイルを読み込み
    config = load_project_config("test/samples/test-bugsearch.yml", use_default_if_missing=False)

    if config:
        print(f"[OK] プロジェクト名: {config.name}")
        print(f"[OK] バックエンド: {config.tech_stack.backend}")
        print(f"[OK] データベース: {config.tech_stack.databases}")
        print(f"[OK] プラクティス: {config.practices}")
        return True
    else:
        print("[ERROR] 設定ファイルの読み込みに失敗")
        return False


def test_rule_engine():
    """ルールエンジンのテスト"""
    print()
    print("=" * 80)
    print("テスト2: ルールエンジン")
    print("=" * 80)

    # プロジェクト設定を読み込み
    config = load_project_config("test/samples/test-bugsearch.yml", use_default_if_missing=False)

    # ルールエンジンを初期化
    engine = RuleEngine(rules_dir="rules", project_config=config)

    print(f"[OK] 読み込まれたルール数: {len(engine.rules)}")

    # サンプルコードを読み込み
    sample_file = Path("test/samples/n-plus-one-csharp.cs")
    if not sample_file.exists():
        print(f"[ERROR] サンプルファイルが見つかりません: {sample_file}")
        return False

    with open(sample_file, 'r', encoding='utf-8') as f:
        code = f.read()

    # コード解析を実行
    print()
    print(f"サンプルファイルを解析: {sample_file}")
    issues = engine.analyze_code(code, str(sample_file), "csharp")

    print(f"[OK] 検出された問題: {len(issues)}件")
    print()

    # 問題の詳細を表示
    if issues:
        report = engine.format_issue_report(issues)
        print(report)
        return True
    else:
        print("[WARNING] 問題が検出されませんでした（サンプルコードを確認してください）")
        return False


def test_severity_adjustment():
    """深刻度調整のテスト"""
    print()
    print("=" * 80)
    print("テスト3: 技術スタックによる深刻度調整")
    print("=" * 80)

    # Entity Framework Core を使用している設定
    config_with_ef = load_project_config("test/samples/test-bugsearch.yml", use_default_if_missing=False)

    # 技術スタックなしの設定
    config_without_tech = load_project_config(".bugsearch.yml", use_default_if_missing=True)
    config_without_tech.severity_adjustments_enabled = False

    # EF Coreありの場合
    engine_with_ef = RuleEngine(rules_dir="rules", project_config=config_with_ef)
    sample_file = Path("test/samples/n-plus-one-csharp.cs")

    with open(sample_file, 'r', encoding='utf-8') as f:
        code = f.read()

    issues_with_ef = engine_with_ef.analyze_code(code, str(sample_file), "csharp")

    # 技術スタックなしの場合
    engine_without = RuleEngine(rules_dir="rules", project_config=config_without_tech)
    issues_without = engine_without.analyze_code(code, str(sample_file), "csharp")

    print(f"技術スタックあり（EF Core）: {len(issues_with_ef)}件")
    if issues_with_ef:
        for issue in issues_with_ef:
            print(f"  - {issue['name']}: 深刻度 {issue['severity']}/10")
            if issue['notes']:
                print(f"    注: {issue['notes'][0]}")

    print()
    print(f"技術スタックなし: {len(issues_without)}件")
    if issues_without:
        for issue in issues_without:
            print(f"  - {issue['name']}: 深刻度 {issue['severity']}/10 (基本)")

    return True


def main():
    """全テストを実行"""
    print("BugSearch2 MVP Test")
    print()

    tests = [
        ("プロジェクト設定の読み込み", test_project_config_loading),
        ("ルールエンジン", test_rule_engine),
        ("深刻度調整", test_severity_adjustment),
    ]

    results = []
    for name, test_func in tests:
        try:
            result = test_func()
            results.append((name, result))
        except Exception as e:
            print(f"[ERROR] テスト失敗: {name}")
            print(f"        エラー: {e}")
            import traceback
            traceback.print_exc()
            results.append((name, False))

    # サマリー
    print()
    print("=" * 80)
    print("テスト結果サマリー")
    print("=" * 80)

    passed = sum(1 for _, result in results if result)
    total = len(results)

    for name, result in results:
        status = "[PASS]" if result else "[FAIL]"
        print(f"{status}: {name}")

    print()
    print(f"合格: {passed}/{total}")

    if passed == total:
        print("SUCCESS: All tests passed!")
        return 0
    else:
        print("WARNING: Some tests failed")
        return 1


if __name__ == "__main__":
    sys.exit(main())
