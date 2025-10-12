"""
技術スタック別 設定ファイル自動生成ツール

Context7を使って技術スタック/フレームワークのドキュメントを取得し、
チェックすべき重要点を自動抽出してYAML設定ファイルを生成します。

Phase 8実装:
- AI自動YAML修正機能（検証エラーを自動修正）
- 完全自動実行フロー（YAML生成 → index作成 → AI分析）

Usage:
    # 対話モード
    python generate_tech_config.py

    # 直接指定
    python generate_tech_config.py --tech react
    python generate_tech_config.py --tech angular --topic security
    python generate_tech_config.py --tech express --no-examples

    # 完全自動実行（YAML生成 → index → AI分析）
    python generate_tech_config.py --tech react --auto-run

Version: v2.0.0 (Phase 8: AI Auto-Fix + Full Automation)
"""

import sys
import argparse
import subprocess
from pathlib import Path

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent))

from core.config_generator import ConfigGenerator


def run_full_analysis(tech_name: str) -> bool:
    """
    生成されたYAML設定を使用して完全な解析を実行

    1. インデックス作成 (index)
    2. AI分析実行 (advise --all)

    Returns:
        bool: 全てのステップが成功したかどうか
    """
    print()
    print("=" * 80)
    print("🚀 完全自動解析を開始します")
    print("=" * 80)
    print()

    # ステップ1: インデックス作成
    print("📊 ステップ 1/2: インデックス作成中...")
    print("   コマンド: py codex_review_severity.py index")
    print()

    try:
        result = subprocess.run(
            ["py", "codex_review_severity.py", "index"],
            capture_output=True,
            text=True,
            timeout=300  # 5分タイムアウト
        )

        if result.returncode == 0:
            print("✅ インデックス作成完了")
            print()
        else:
            print("❌ インデックス作成に失敗しました")
            print(f"   エラー: {result.stderr}")
            return False

    except subprocess.TimeoutExpired:
        print("❌ インデックス作成がタイムアウトしました")
        return False
    except Exception as e:
        print(f"❌ インデックス作成でエラーが発生: {e}")
        return False

    # ステップ2: AI分析実行
    print("🤖 ステップ 2/2: AI分析実行中...")
    report_path = f"reports/{tech_name}_analysis"
    print(f"   コマンド: py codex_review_severity.py advise --all --out {report_path}")
    print("   ⚠️  この処理には数分〜数十分かかる場合があります")
    print()

    try:
        result = subprocess.run(
            ["py", "codex_review_severity.py", "advise", "--all", "--out", report_path],
            capture_output=True,
            text=True,
            timeout=1800  # 30分タイムアウト
        )

        if result.returncode == 0:
            print("✅ AI分析完了")
            print()
            print("=" * 80)
            print("🎉 完全自動解析が正常に完了しました！")
            print("=" * 80)
            print()
            print(f"📄 分析レポート: {report_path}.md")
            print()
            print("次のステップ:")
            print(f"  1. レポートを確認")
            print(f"     notepad {report_path}.md")
            print()
            print("  2. AI改善コードを適用（オプション）")
            print(f"     python apply_improvements_from_report.py {report_path}.md --dry-run")
            print(f"     python apply_improvements_from_report.py {report_path}.md --apply")
            print()
            return True
        else:
            print("❌ AI分析に失敗しました")
            print(f"   エラー: {result.stderr}")
            return False

    except subprocess.TimeoutExpired:
        print("❌ AI分析がタイムアウトしました")
        print("   ヒント: 大規模プロジェクトの場合は手動で実行することをお勧めします")
        return False
    except Exception as e:
        print(f"❌ AI分析でエラーが発生: {e}")
        return False


def interactive_mode():
    """対話モードで設定ファイルを生成"""
    print("=" * 80)
    print("🔧 BugSearch2 技術スタック別 設定ファイル自動生成ツール")
    print("=" * 80)
    print()
    print("Context7を使って最新のドキュメントから自動的に")
    print("チェック項目を抽出し、YAML設定ファイルを生成します。")
    print()

    generator = ConfigGenerator()

    # サポートされている技術一覧
    print("📚 サポートされている技術スタック:")
    print()
    print("  フロントエンド:")
    print("    - react, angular, vue, svelte")
    print()
    print("  バックエンド:")
    print("    - express, nestjs, fastapi, django, flask, spring-boot")
    print()
    print("  データベース:")
    print("    - elasticsearch, cassandra, mongodb, redis")
    print()
    print("  その他:")
    print("    - typescript, nodejs, go")
    print()

    # 技術名入力
    while True:
        tech_name = input("生成する技術スタック/フレームワーク名を入力 (例: react): ").strip()
        if tech_name:
            break
        print("⚠️  技術名を入力してください")

    # トピック入力（オプション）
    print()
    print("フォーカスするトピックを指定できます（Enter=全般）:")
    print("  例: security, performance, best practices, testing")
    topic = input("トピック (オプション): ").strip() or None

    # サンプルコード含める？
    print()
    include_examples_input = input("サンプルコードを含めますか？ (Y/n): ").strip().lower()
    include_examples = include_examples_input != 'n'

    # カスタムファイル名（オプション）
    print()
    custom_filename = input("カスタムファイル名 (Enter=自動生成): ").strip() or None

    # 完全自動実行オプション
    print()
    print("YAML生成後、自動的にindex作成とAI分析を実行しますか？")
    print("  （大規模プロジェクトの場合は時間がかかります）")
    auto_run_input = input("完全自動実行 (y/N): ").strip().lower()
    auto_run = auto_run_input == 'y'

    # 確認
    print()
    print("=" * 80)
    print("📋 生成設定:")
    print(f"  技術スタック: {tech_name}")
    print(f"  トピック: {topic or '全般'}")
    print(f"  サンプルコード: {'含める' if include_examples else '含めない'}")
    print(f"  ファイル名: {custom_filename or '自動生成'}")
    print(f"  完全自動実行: {'有効' if auto_run else '無効'}")
    print("=" * 80)
    print()

    confirm = input("この設定で生成しますか？ (Y/n): ").strip().lower()
    if confirm == 'n':
        print("❌ キャンセルしました")
        return False

    print()

    # 生成実行
    success, filepath, message = generator.generate_config(
        tech_name=tech_name,
        topic=topic,
        include_examples=include_examples,
        custom_filename=custom_filename
    )

    print()
    if success:
        # 検証結果を確認
        validation_passed = "検証エラー" not in message

        if validation_passed:
            print("=" * 80)
            print("✅ SUCCESS: 設定ファイルが生成され、検証に合格しました！")
            print("=" * 80)
        else:
            print("=" * 80)
            print("⚠️  WARNING: 設定ファイルは生成されましたが、検証エラーがあります")
            print("=" * 80)
            print()
            print(f"⚠️  {message}")

        print()
        print(f"📄 ファイル: {filepath}")
        print()

        if validation_passed:
            print("✓ このファイルはBugSearch2で即座に使用可能です！")
            print()

            # 完全自動実行が有効な場合
            if auto_run:
                analysis_success = run_full_analysis(tech_name)
                if not analysis_success:
                    print()
                    print("⚠️  自動解析でエラーが発生しましたが、YAMLファイルは正常に生成されています")
                    print(f"   手動で解析を実行してください:")
                    print("     py codex_review_severity.py index")
                    print("     py codex_review_severity.py advise --all --out reports/analysis")
            else:
                print("次のステップ:")
                print("  1. (オプション) 生成されたファイルを確認・編集")
                print(f"     notepad {filepath}")
                print()
                print("  2. BugSearch2で解析実行")
                print("     py codex_review_severity.py index")
                print("     py codex_review_severity.py advise --all --out reports/analysis")
                print()
                print("  ※ config/配下のルールは自動的に読み込まれます")
        else:
            print("⚠️  検証エラーがあるため、ファイルを修正してください:")
            print(f"     notepad {filepath}")
            print()
            print("  修正後、以下のコマンドで再度検証できます:")
            print("     python test/test_config_generator.py")

        print()
        return True
    else:
        print("=" * 80)
        print("❌ ERROR: 設定ファイルの生成に失敗しました")
        print("=" * 80)
        print()
        print(f"エラー: {message}")
        print()
        return False


def command_mode(args):
    """コマンドラインモードで設定ファイルを生成"""
    generator = ConfigGenerator()

    success, filepath, message = generator.generate_config(
        tech_name=args.tech,
        topic=args.topic,
        include_examples=not args.no_examples,
        custom_filename=args.output
    )

    if success:
        validation_passed = "検証エラー" not in message

        if validation_passed:
            print(f"\n✅ Config file generated and validated: {filepath}")
            print(f"   Status: Ready to use ✓")

            # 完全自動実行が有効な場合
            if args.auto_run:
                print()
                analysis_success = run_full_analysis(args.tech)
                if not analysis_success:
                    print()
                    print("⚠️  Auto-analysis failed, but YAML file is valid")
                    print("   Run manually: py codex_review_severity.py index")
                    return 3  # 解析エラーの場合は終了コード3

            return 0
        else:
            print(f"\n⚠️  Config file generated with validation errors: {filepath}")
            print(f"   {message}")
            print(f"   Please review and fix the file manually.")
            return 2  # 検証エラーの場合は終了コード2
    else:
        print(f"\n❌ Failed to generate config: {message}")
        return 1


def main():
    """メイン関数"""
    parser = argparse.ArgumentParser(
        description="技術スタック別 設定ファイル自動生成ツール (Context7統合)",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
使用例:
  # 対話モード（推奨）
  python generate_tech_config.py

  # 直接指定
  python generate_tech_config.py --tech react
  python generate_tech_config.py --tech angular --topic security
  python generate_tech_config.py --tech express --no-examples --output my-rules.yml

  # 完全自動実行（YAML生成 → 検証 → AI修正 → index作成 → AI分析）
  python generate_tech_config.py --tech react --auto-run
  python generate_tech_config.py --tech angular --topic security --auto-run

サポートされている技術:
  フロントエンド: react, angular, vue, svelte
  バックエンド: express, nestjs, fastapi, django, flask, spring-boot
  データベース: elasticsearch, cassandra, mongodb, redis
  その他: typescript, nodejs, go

Phase 8新機能:
  - AI自動修正: 検証エラーをAIが自動的に修正（最大5回試行）
  - 完全自動実行: --auto-runフラグでYAML生成から分析まで完全自動化
        """
    )

    parser.add_argument(
        "--tech",
        type=str,
        help="技術スタック/フレームワーク名 (例: react, angular, express)"
    )

    parser.add_argument(
        "--topic",
        type=str,
        default=None,
        help="フォーカスするトピック (例: security, performance)"
    )

    parser.add_argument(
        "--no-examples",
        action="store_true",
        help="サンプルコードを含めない"
    )

    parser.add_argument(
        "--output",
        "-o",
        type=str,
        default=None,
        help="カスタム出力ファイル名"
    )

    parser.add_argument(
        "--auto-run",
        action="store_true",
        help="YAML生成後、自動的にindex作成とAI分析を実行"
    )

    args = parser.parse_args()

    # 引数がない場合は対話モード
    if not args.tech:
        try:
            success = interactive_mode()
            return 0 if success else 1
        except KeyboardInterrupt:
            print("\n\n⚠️  中断されました")
            return 130
        except Exception as e:
            print(f"\n❌ エラー: {e}")
            import traceback
            traceback.print_exc()
            return 1
    else:
        # コマンドラインモード
        return command_mode(args)


if __name__ == "__main__":
    sys.exit(main())
