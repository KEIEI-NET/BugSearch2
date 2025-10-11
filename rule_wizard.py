"""
対話型ルール生成ウィザード

Phase 4.1の新機能:
- 対話的なルール作成
- テンプレート選択
- 入力補助
- 自動バリデーション

バージョン: v4.4.0 (Phase 4.1)
作成日: 2025年10月12日 JST

使用方法:
    python rule_wizard.py
"""

import sys
from pathlib import Path
from typing import Dict, Optional
import re

from core.rule_template import RuleTemplateManager, RuleTemplate
from core.rule_engine import RuleValidator


class RuleWizard:
    """
    対話型ルール生成ウィザード

    Phase 4.1の新機能:
    - ステップバイステップでルール作成
    - テンプレート選択のガイダンス
    - 入力値の検証
    - 作成したルールの自動バリデーション
    """

    def __init__(self, project_root: Path = Path(".")):
        """
        Args:
            project_root: プロジェクトルートディレクトリ
        """
        self.project_root = project_root
        self.template_manager = RuleTemplateManager()
        self.validator = RuleValidator()

    def run(self):
        """ウィザードを実行"""
        self._print_header()

        # テンプレートが利用可能か確認
        if not self.template_manager.list_templates():
            print("[ERROR] テンプレートが見つかりません")
            print(f"[INFO] rules/templates/ ディレクトリにテンプレートを配置してください")
            return

        # テンプレート選択
        template = self._select_template()
        if not template:
            return

        # 変数値の入力
        values = self._input_variables(template)
        if not values:
            return

        # 出力先の決定
        output_path = self._get_output_path(values.get('RULE_ID', 'custom-rule'))

        # ルール生成
        success = self.template_manager.create_rule_from_template(
            template.id,
            values,
            output_path,
            validate=False  # 後で手動でバリデーション実行
        )

        if success:
            # バリデーション実行
            print()
            print("📋 ルールをバリデーション中...")
            errors = self.validator.validate_rule(output_path)

            if errors:
                print(f"[WARNING] {len(errors)}件のバリデーション警告:")
                for error in errors:
                    print(f"  - {error}")
                print()
                print("⚠️  警告がありますが、ルールファイルは作成されました")
            else:
                print("[OK] バリデーション成功 ✅")

            print()
            print("=" * 80)
            print("✅ ルール作成完了！")
            print("=" * 80)
            print(f"📁 ファイル: {output_path}")
            print()
            print("次のステップ:")
            print("1. ルールファイルを確認・編集")
            print("2. python codex_review_severity.py index で再インデックス")
            print("3. python codex_review_severity.py advise --all で分析実行")
            print()

    def _print_header(self):
        """ヘッダーを表示"""
        print()
        print("=" * 80)
        print("🧙 BugSearch2 カスタムルール作成ウィザード v4.4.0")
        print("=" * 80)
        print()
        print("このウィザードは、プロジェクト固有のカスタムルールを")
        print("対話的に作成するためのツールです。")
        print()

    def _select_template(self) -> Optional[RuleTemplate]:
        """
        テンプレート選択

        Returns:
            選択されたテンプレート（キャンセル時はNone）
        """
        templates = self.template_manager.list_templates()

        print("📚 利用可能なテンプレート:")
        print()

        for i, template in enumerate(templates, 1):
            print(f"{i}. {template.id}")
            print(f"   必須変数: {', '.join(template.variables)}")
            print()

        print(f"{len(templates) + 1}. (キャンセル)")
        print()

        while True:
            choice = input(f"テンプレート番号を選択 (1-{len(templates) + 1}): ").strip()

            if not choice:
                continue

            try:
                idx = int(choice) - 1

                # キャンセル
                if idx == len(templates):
                    print("キャンセルしました")
                    return None

                # 有効な選択
                if 0 <= idx < len(templates):
                    selected = templates[idx]
                    print(f"\n✅ テンプレート '{selected.id}' を選択しました\n")
                    return selected
                else:
                    print(f"[ERROR] 1-{len(templates) + 1}の範囲で指定してください")

            except ValueError:
                print("[ERROR] 数値を入力してください")

    def _input_variables(self, template: RuleTemplate) -> Optional[Dict[str, str]]:
        """
        変数値の入力

        Args:
            template: テンプレート

        Returns:
            変数値のマッピング（キャンセル時はNone）
        """
        print()
        print("=" * 80)
        print(f"📝 テンプレート: {template.id}")
        print("=" * 80)
        print()
        print(f"{len(template.variables)}個の変数を入力してください")
        print()

        values = {}

        for i, var_name in enumerate(template.variables, 1):
            print(f"[{i}/{len(template.variables)}] {var_name}")

            # 変数ごとのガイダンス
            guidance = self._get_variable_guidance(var_name)
            if guidance:
                print(f"  💡 ヒント: {guidance}")

            # 入力と検証のループ
            while True:
                value = input(f"  入力: ").strip()

                # 空入力でキャンセル確認
                if not value:
                    if i == 1:
                        confirm = input("  キャンセルしますか？ (y/n): ").strip().lower()
                        if confirm == 'y':
                            print("キャンセルしました")
                            return None
                    else:
                        print("  [ERROR] 値を入力してください")
                    continue

                # 検証
                error = self._validate_variable(var_name, value)
                if error:
                    print(f"  [ERROR] {error}")
                    continue

                # 成功
                values[var_name] = value
                print(f"  ✅ OK")
                break

            print()

        # 確認
        print("=" * 80)
        print("📋 入力内容の確認")
        print("=" * 80)
        for var_name, value in values.items():
            # 長い値は省略表示
            display_value = value if len(value) <= 50 else value[:47] + "..."
            print(f"  {var_name:20s}: {display_value}")
        print()

        while True:
            confirm = input("この内容でルールを作成しますか？ (y/n): ").strip().lower()

            if confirm == 'y':
                return values
            elif confirm == 'n':
                print("キャンセルしました")
                return None
            else:
                print("[ERROR] 'y' または 'n' を入力してください")

    def _get_variable_guidance(self, var_name: str) -> str:
        """
        変数ごとのガイダンスを提供

        Args:
            var_name: 変数名

        Returns:
            ガイダンステキスト
        """
        guidance = {
            'RULE_ID': "大文字とアンダースコアのみ（例: CUSTOM_FORBIDDEN_API）",
            'RULE_NAME': "ルールの名前（例: Forbidden API Usage）",
            'DESCRIPTION': "ルールの説明（例: Detects forbidden API usage）",
            'API_NAME': "検出対象のAPI名（例: LegacyDatabase）",
            'SEVERITY': "深刻度 1-10（10が最も重大、推奨: 7-8）",
            'PATTERN': "正規表現パターン（例: LegacyDatabase\\\\.Connect）",
            'CSHARP_PATTERN': "C#用正規表現パターン",
            'JAVA_PATTERN': "Java用正規表現パターン",
            'PYTHON_PATTERN': "Python用正規表現パターン",
            'ALTERNATIVE_API': "推奨される代替API（例: ModernDatabase.ConnectAsync）",
            'SAFE_ALTERNATIVE': "安全な代替手段（例: Parameterized Query）",
            'TARGET_TYPE': "対象の種類（例: Class, Method, Variable）",
            'CONVENTION': "命名規則（例: PascalCase, camelCase, snake_case）",
            'EXAMPLE_BEFORE': "悪い例（例: myVariable）",
            'EXAMPLE_AFTER': "良い例（例: MyVariable）",
            'VULNERABILITY_TYPE': "脆弱性の種類（例: SQL Injection, XSS）",
            'ISSUE_TYPE': "問題の種類（例: N+1 Query, Memory Leak）",
            'OPTIMIZED_APPROACH': "最適化手法（例: Batch Query, Caching）",
            'FIX_SUGGESTION': "修正提案（例: Use prepared statements）"
        }
        return guidance.get(var_name, "")

    def _validate_variable(self, var_name: str, value: str) -> Optional[str]:
        """
        変数値の検証

        Args:
            var_name: 変数名
            value: 入力値

        Returns:
            エラーメッセージ（正常時はNone）
        """
        if not value:
            return "値を入力してください"

        # RULE_ID検証
        if var_name == 'RULE_ID':
            if not re.match(r'^[A-Z_]+$', value):
                return "大文字とアンダースコアのみ使用可能です"
            if len(value) < 3:
                return "3文字以上必要です"

        # SEVERITY検証
        elif var_name == 'SEVERITY':
            try:
                severity = int(value)
                if not (1 <= severity <= 10):
                    return "1-10の範囲で指定してください"
            except ValueError:
                return "数値を入力してください"

        # PATTERN検証（正規表現）
        elif var_name.endswith('PATTERN'):
            try:
                re.compile(value)
            except re.error as e:
                return f"無効な正規表現: {e}"

        return None

    def _get_output_path(self, rule_id: str) -> Path:
        """
        出力先パスを決定

        Args:
            rule_id: ルールID

        Returns:
            出力先パス
        """
        custom_dir = self.project_root / ".bugsearch" / "rules" / "custom"
        custom_dir.mkdir(parents=True, exist_ok=True)

        # ルールIDからファイル名を生成（小文字、ハイフン区切り）
        filename = rule_id.lower().replace('_', '-') + '.yml'
        return custom_dir / filename


def main():
    """メイン関数"""
    wizard = RuleWizard()

    try:
        wizard.run()
    except KeyboardInterrupt:
        print("\n\n⚠️  中断されました")
        sys.exit(1)
    except Exception as e:
        print(f"\n[ERROR] 予期しないエラー: {e}")
        sys.exit(1)


if __name__ == "__main__":
    main()
