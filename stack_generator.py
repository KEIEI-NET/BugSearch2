"""
BugSearch2 Tech Stack Generator

技術スタック設定ファイル(.bugsearch.yml)を対話的に生成
"""

import sys
import argparse
from pathlib import Path

# coreモジュールのインポート
from core import ProjectConfig, TechStack
from core.project_config import save_project_config
from core.models import FrontendStack, BackendStack, DatabaseInfo, InfrastructureInfo
from core.tech_stack_detector import auto_detect_tech_stack


def print_header():
    """ヘッダー表示"""
    print("=" * 80)
    print("BugSearch2 - Tech Stack Generator v1.0")
    print("=" * 80)
    print()


def select_from_list(prompt: str, options: list, allow_multiple: bool = False) -> any:
    """リストから選択"""
    print(prompt)
    for i, option in enumerate(options, 1):
        print(f"  {i}) {option}")

    if allow_multiple:
        print("  (カンマ区切りで複数選択可、例: 1,3,5)")

    while True:
        try:
            choice = input("選択: ").strip()
            if not choice:
                return None

            if allow_multiple:
                indices = [int(c.strip()) for c in choice.split(',')]
                return [options[i - 1] for i in indices if 1 <= i <= len(options)]
            else:
                idx = int(choice)
                if 1 <= idx <= len(options):
                    return options[idx - 1]
                print(f"  ⚠️  1-{len(options)}の範囲で選択してください")
        except (ValueError, IndexError):
            print(f"  ⚠️  正しい番号を入力してください")


def input_with_default(prompt: str, default: str = "") -> str:
    """デフォルト値付き入力"""
    if default:
        user_input = input(f"{prompt} [{default}]: ").strip()
        return user_input if user_input else default
    else:
        return input(f"{prompt}: ").strip()


def generate_with_auto_detection(project_dir: str = "."):
    """自動検出+手動修正でプロジェクト設定を生成"""
    print_header()
    print("技術スタックを自動検出します...")
    print()

    # 自動検出実行
    detection_result = auto_detect_tech_stack(project_dir)
    tech_stack = detection_result.tech_stack

    # 検出結果表示
    print("=" * 80)
    print("[OK] 自動検出結果:")
    print("=" * 80)
    print(f"信頼度: {detection_result.confidence * 100:.0f}%")
    print(f"検出ファイル数: {len(detection_result.detected_files)}件")
    print()

    if detection_result.detected_files:
        print("検出されたファイル:")
        for file in detection_result.detected_files[:5]:  # 最初の5件のみ表示
            print(f"  - {Path(file).name}")
        if len(detection_result.detected_files) > 5:
            print(f"  ... 他{len(detection_result.detected_files) - 5}件")
        print()

    if detection_result.warnings:
        print("[WARNING] 検出時の警告:")
        for warning in detection_result.warnings:
            print(f"  - {warning}")
        print()

    # 検出内容の詳細表示
    print("検出された技術スタック:")
    print()

    if tech_stack.frontend:
        print(f"  [フロントエンド]")
        print(f"    フレームワーク: {tech_stack.frontend.framework}")
        if tech_stack.frontend.version:
            print(f"    バージョン: {tech_stack.frontend.version}")
        if tech_stack.frontend.state_management:
            print(f"    状態管理: {tech_stack.frontend.state_management}")
    else:
        print("  [フロントエンド] 検出なし")

    print()

    if tech_stack.backend:
        print(f"  [バックエンド]")
        print(f"    言語: {tech_stack.backend.language}")
        if tech_stack.backend.version:
            print(f"    バージョン: {tech_stack.backend.version}")
        if tech_stack.backend.framework:
            print(f"    フレームワーク: {tech_stack.backend.framework}")
            if tech_stack.backend.framework_version:
                print(f"    フレームワークバージョン: {tech_stack.backend.framework_version}")
    else:
        print("  [バックエンド] 検出なし")

    print()

    if tech_stack.databases:
        print(f"  [データベース]")
        for db in tech_stack.databases:
            print(f"    - {db.type} ({db.purpose})")
    else:
        print("  [データベース] 検出なし")

    print()

    if tech_stack.cache:
        print(f"  [キャッシュ]")
        print(f"    - {tech_stack.cache.type}")

    if tech_stack.messaging:
        print(f"  [メッセージング]")
        print(f"    - {tech_stack.messaging.type}")

    if tech_stack.practices:
        print()
        print(f"  [プラクティス]")
        for practice in tech_stack.practices:
            print(f"    - {practice}")

    print()
    print("=" * 80)
    print()

    # 修正確認
    print("この検出結果を使用しますか？")
    print("  1) そのまま使用")
    print("  2) 手動で修正")
    print("  3) ゼロから手動入力")
    print("  4) キャンセル")

    choice = input("選択 [1]: ").strip()
    if not choice:
        choice = "1"

    if choice == "1":
        # そのまま使用
        pass
    elif choice == "2":
        # 手動修正（今後実装）
        print()
        print("[INFO] 手動修正機能は将来のバージョンで実装予定です。")
        print("       現在は .bugsearch.yml を直接編集してください。")
        print()
    elif choice == "3":
        # ゼロから手動入力
        print()
        return generate_interactive()
    else:
        print("キャンセルしました")
        return False

    # プロジェクト名とバージョンを入力
    print()
    project_name = input_with_default("プロジェクト名", Path(project_dir).name)
    project_version = input_with_default("バージョン", "1.0")

    # ProjectConfigの構築
    project_config = ProjectConfig(
        name=project_name,
        version=project_version,
        tech_stack=tech_stack,
        practices=tech_stack.practices,
        severity_adjustments_enabled=True,
        ai_include_tech_stack=True,
        ai_context_depth="standard"
    )

    # 保存確認
    print()
    print("=" * 80)
    print("[OK] 最終設定:")
    print("=" * 80)
    print(f"プロジェクト名: {project_config.name} v{project_config.version}")
    print(f"技術スタック: {project_config.tech_stack}")
    if tech_stack.practices:
        print(f"プラクティス: {', '.join(tech_stack.practices)}")
    print()

    confirm = input("この設定で .bugsearch.yml を生成しますか？ [Y/n]: ").strip().lower()
    if confirm in ('', 'y', 'yes'):
        save_project_config(project_config, ".bugsearch.yml")
        print()
        print("[SUCCESS] .bugsearch.yml を生成しました！")
        print()
        print("次のステップ:")
        print("  1. .bugsearch.yml を確認・編集")
        print("  2. py codex_review_severity.py index でインデックス作成")
        print("  3. py codex_review_severity.py advise --all でコード解析")
        return True
    else:
        print("キャンセルしました")
        return False


def generate_interactive():
    """対話型でプロジェクト設定を生成（フルマニュアル）"""
    print_header()
    print("プロジェクトの技術スタックを設定します。")
    print("（Enterのみで次の質問へ、スキップも可能）")
    print()

    # プロジェクト名
    project_name = input_with_default("[1/7] プロジェクト名", "My Project")
    project_version = input_with_default("[2/7] バージョン", "1.0")

    # フロントエンド
    print()
    print("[3/7] フロントエンド")
    frontend_options = [
        "Angular",
        "React",
        "Vue.js",
        "Svelte",
        "なし/スキップ"
    ]
    frontend_framework = select_from_list(
        "フロントエンドフレームワークを選択:",
        frontend_options
    )

    frontend = None
    if frontend_framework and frontend_framework != "なし/スキップ":
        frontend_version = input_with_default(f"  {frontend_framework}のバージョン", "")

        # 状態管理
        state_mgmt_options = {
            "Angular": ["NgRx", "Akita", "なし"],
            "React": ["Redux", "MobX", "Zustand", "なし"],
            "Vue.js": ["Vuex", "Pinia", "なし"],
        }
        state_mgmt = None
        if frontend_framework in state_mgmt_options:
            state_mgmt = select_from_list(
                "  状態管理ライブラリ:",
                state_mgmt_options[frontend_framework]
            )
            if state_mgmt == "なし":
                state_mgmt = None

        frontend = FrontendStack(
            framework=frontend_framework,
            version=frontend_version if frontend_version else None,
            state_management=state_mgmt
        )

    # バックエンド
    print()
    print("[4/7] バックエンド")
    backend_languages = [
        "C#",
        "Java",
        "Python",
        "PHP",
        "Go",
        "Node.js"
    ]
    backend_language = select_from_list(
        "バックエンド言語を選択:",
        backend_languages
    )

    backend = None
    if backend_language:
        backend_version = input_with_default(f"  {backend_language}のバージョン", "")

        # フレームワーク選択
        framework_options = {
            "C#": ["ASP.NET Core", "ASP.NET Framework", "なし"],
            "Java": ["Spring Boot", "Quarkus", "Micronaut", "Jakarta EE"],
            "Python": ["Django", "FastAPI", "Flask", "なし"],
            "PHP": ["Laravel", "Symfony", "なし"],
            "Go": ["Gin", "Echo", "なし"],
            "Node.js": ["Express", "NestJS", "Fastify", "なし"]
        }

        backend_framework = None
        if backend_language in framework_options:
            backend_framework = select_from_list(
                "  フレームワーク:",
                framework_options[backend_language]
            )
            if backend_framework == "なし":
                backend_framework = None

        backend_framework_version = None
        if backend_framework:
            backend_framework_version = input_with_default(
                f"  {backend_framework}のバージョン",
                ""
            )

        backend = BackendStack(
            language=backend_language,
            version=backend_version if backend_version else None,
            framework=backend_framework,
            framework_version=backend_framework_version if backend_framework_version else None
        )

    # データベース
    print()
    print("[5/7] データベース")
    db_options = [
        "PostgreSQL",
        "MySQL",
        "SQL Server",
        "MongoDB",
        "Cassandra",
        "Redis",
        "Elasticsearch",
    ]
    selected_dbs = select_from_list(
        "データベースを選択（複数可）:",
        db_options,
        allow_multiple=True
    )

    databases = []
    cache = None
    if selected_dbs:
        for db_type in selected_dbs:
            # 用途を確認
            if db_type == "Redis":
                cache = InfrastructureInfo(
                    type="Redis",
                    category="cache"
                )
            elif db_type == "Elasticsearch":
                databases.append(DatabaseInfo(
                    type="Elasticsearch",
                    purpose="search"
                ))
            else:
                purpose = "primary" if len(databases) == 0 else "secondary"
                databases.append(DatabaseInfo(
                    type=db_type,
                    purpose=purpose
                ))

    # メッセージング
    print()
    print("[6/7] メッセージング（オプション）")
    messaging_options = [
        "RabbitMQ",
        "Kafka",
        "Azure Service Bus",
        "なし"
    ]
    messaging_type = select_from_list(
        "メッセージングシステム:",
        messaging_options
    )

    messaging = None
    if messaging_type and messaging_type != "なし":
        messaging = InfrastructureInfo(
            type=messaging_type,
            category="messaging"
        )

    # 開発プラクティス
    print()
    print("[7/7] 開発プラクティス（複数選択可）")
    practice_options = [
        "Repository Pattern",
        "CQRS",
        "Microservices",
        "Domain-Driven Design",
        "Event Sourcing",
    ]
    print("該当するプラクティスを選択（カンマ区切り、例: 1,3,4）:")
    for i, practice in enumerate(practice_options, 1):
        print(f"  {i}) {practice}")

    practices_input = input("選択（なしの場合はEnter）: ").strip()
    practices = []
    if practices_input:
        try:
            indices = [int(c.strip()) for c in practices_input.split(',')]
            practices = [practice_options[i - 1] for i in indices if 1 <= i <= len(practice_options)]
        except (ValueError, IndexError):
            print("  ⚠️  入力エラー: プラクティスは選択されませんでした")

    # ProjectConfigの構築
    tech_stack = TechStack(
        frontend=frontend,
        backend=backend,
        databases=databases,
        cache=cache,
        messaging=messaging,
        practices=practices
    )

    project_config = ProjectConfig(
        name=project_name,
        version=project_version,
        tech_stack=tech_stack,
        practices=practices,
        severity_adjustments_enabled=True,
        ai_include_tech_stack=True,
        ai_context_depth="standard"
    )

    # 確認
    print()
    print("=" * 80)
    print("[OK] 設定内容:")
    print("=" * 80)
    print(f"プロジェクト名: {project_config.name} v{project_config.version}")
    print(f"技術スタック: {project_config.tech_stack}")
    if practices:
        print(f"プラクティス: {', '.join(practices)}")
    print()

    # 保存
    confirm = input("この設定で .bugsearch.yml を生成しますか？ [Y/n]: ").strip().lower()
    if confirm in ('', 'y', 'yes'):
        save_project_config(project_config, ".bugsearch.yml")
        print()
        print("[SUCCESS] .bugsearch.yml を生成しました！")
        print()
        print("次のステップ:")
        print("  1. .bugsearch.yml を確認・編集")
        print("  2. py codex_review_severity.py index でインデックス作成")
        print("  3. py codex_review_severity.py advise --all でコード解析")
        return True
    else:
        print("キャンセルしました")
        return False


def main():
    """メイン関数"""
    parser = argparse.ArgumentParser(
        description="BugSearch2 Tech Stack Generator",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
使用例:
  py stack_generator.py auto              # 自動検出+手動修正
  py stack_generator.py init              # フルマニュアル入力
  py stack_generator.py auto --dir ./src  # 指定ディレクトリから自動検出
        """
    )

    parser.add_argument(
        'command',
        nargs='?',
        default='auto',
        choices=['init', 'auto'],
        help='コマンド: init (手動入力) または auto (自動検出)'
    )

    parser.add_argument(
        '--output',
        '-o',
        default='.bugsearch.yml',
        help='出力ファイル名 (デフォルト: .bugsearch.yml)'
    )

    parser.add_argument(
        '--dir',
        '-d',
        default='.',
        help='プロジェクトディレクトリ (デフォルト: カレントディレクトリ)'
    )

    args = parser.parse_args()

    if args.command == 'auto':
        generate_with_auto_detection(args.dir)
    elif args.command == 'init':
        generate_interactive()
    else:
        parser.print_help()
        sys.exit(1)


if __name__ == "__main__":
    main()
